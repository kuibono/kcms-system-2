using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Voodoo;

using Voodoo.Security;

namespace Voodoo.Basement
{
    /// <summary>
    /// 会员相关操作类
    /// </summary>
    public class UserAction
    {
        #region 用户注册
        /// <summary>
        /// 用户注册
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public Result UserRegister(User user)
        {
            using (DataEntities ent = new DataEntities())
            {
                SysSetting setting = BasePage.SystemSetting;

                Result r = new Result();
                if (!setting.EnableReg)//不允许注册
                {
                    r.Success = false;
                    r.Text = "系统关闭了用户注册功能！";
                    return r;
                }

                if ((from l in ent.User where l.UserName == user.UserName select l).Count() > 0)
                {
                    r.Success = false;
                    r.Text = "这个账号已经存在，请重新选择！";
                    return r;
                }

                if (user.UserName.Length > setting.MaxUserName || user.UserName.Length < setting.MinUserName)
                {
                    r.Success = false;
                    r.Text = string.Format("账号长度请设置在{0}和{1}之间", setting.MinUserName, setting.MaxUserName);
                    return r;
                }

                //密码经过MD5加密后无法验证长度

                //系统保留词
                string[] userNameFilter = setting.UserNameFilter.Trim().Split(',');
                foreach (string k in userNameFilter)
                {
                    if (user.UserName.Contains(k))
                    {
                        r.Success = false;
                        r.Text = "账号中存在系统保留词，请重新设置";
                        return r;
                    }
                }

                if (setting.EmailCheck)
                {
                    if ((from l in ent.User where l.Email == user.Email select l).Count() > 0)
                    {
                        r.Success = false;
                        r.Text = "您设置的邮箱账号已经在系统中注册，系统不允许重复注册";
                        return r;
                    }
                }

                //用户默认分组
                if (user.Group <= 0)
                {
                    user.Group = setting.RegisterDefaultGroup;
                }

                UserGroup g = //UserGroupView.GetModelByID(user.Group.ToS());
                    (from l in ent.UserGroup where l.ID == user.Group select l).FirstOrDefault();
                user.Enable = g.RegAutoAudit;

                //注册时间间隔
                user.RegIP = WS.GetIP();
                var ipusers = //UserView.GetModelList(string.Format("RegIP='{0}'", user.RegIP)).OrderByDescending(p => p.RegTime);
                    (from l in ent.User where l.RegIP == user.RegIP orderby l.RegTime descending select l).ToList();
                if (ipusers.Count() > 0)
                {
                    User _lastUser = ipusers.First();

                    if (_lastUser != null && (DateTime.Now - _lastUser.RegTime.ToDateTime()).TotalMinutes < Convert.ToDouble(setting.RegTimeSpan.ToDecimal()))
                    {
                        r.Success = false;
                        r.Text = "您的注册动作过于频繁，请稍后重试！";
                        return r;
                    }
                }
                user.RegTime = DateTime.Now;
                user.Cent = setting.RegCent;
                user.LastLoginIP = WS.GetIP();
                user.LastLoginTime = DateTime.Now;
                ent.AddToUser(user);
                ent.SaveChanges();
                r.Success = true;
                r.Text = "注册成功！";
                return r;
            }
        }
        #endregion

        #region 会员登陆
        /// <summary>
        /// 会员登陆
        /// </summary>
        /// <param name="UserName">账号</param>
        /// <param name="Password">密码</param>
        /// <param name="CookieDay">过期时间（天）</param>
        /// <returns></returns>
        public Result UserLogin(string UserName, string Password, int CookieDay)
        {


            Result r = new Result();
            UserName = UserName.TrimDbDangerousChar();
            Password = Password.TrimDbDangerousChar();
            if (UserName.IsNullOrEmpty())
            {
                r.Success = false;
                r.Text = "账号不能为空!";
                return r;
            }
            if (Password.IsNullOrEmpty())
            {
                r.Success = false;
                r.Text = "密码不能为空!";
                return r;
            }

            //User _user = UserView.Find(string.Format("UserName='{0}'", UserName));

            using (DataEntities ent = new DataEntities())
            {
                var users = (from l in ent.User where l.UserName == UserName select l).ToList();
                if (users.Count > 0)
                {
                    User _user = users.FirstOrDefault();
                    if (_user.UserPass == Voodoo.Security.Encrypt.Md5(Password))
                    {

                        if (_user.Enable == false)
                        {
                            r.Success = false;
                            r.Text = "您的帐号还没有经过审核，请耐心等待审核通过后登录";
                            return r;
                        }

                        //成功！
                        //写入Cookie
                        System.Web.HttpCookie cookie = new System.Web.HttpCookie("User");
                        cookie.Expires = DateTime.Now.AddDays(CookieDay);
                        cookie.Values.Add("uid", _user.ID.ToString());
                        cookie.Values.Add("k", Voodoo.Security.Encrypt.Md5(string.Format("{0}{1}{2}",
                            _user.ID,
                            _user.UserName,
                            _user.UserPass,
                            BasePage.SystemSetting.SiteName
                            )));
                        Cookies.Cookies.SetCookie(cookie);

                        _user.LastLoginIP = WS.GetIP();
                        _user.LastLoginTime = DateTime.Now;
                        _user.LoginCount += 1;
                        ent.SaveChanges();

                        r.Success = true;
                        r.Text = "登陆成功！";
                        return r;
                    }
                }

                r.Success = false;
                r.Text = "您输入的账号或密码错误";
                return r;
            }
        }
        #endregion

        #region 当前登录的用户
        /// <summary>
        /// 当前登录的用户
        /// </summary>
        public static User opuser
        {
            get
            {
                ////-----------------------临时使用----------------------------------------
                //using (DataEntities ent = new DataEntities())
                //{
                //    return (from l in ent.User where l.ID == 1 select l).FirstOrDefault();
                //}
                ////-----------------------------------------------------------------------


                System.Web.HttpCookie cookie = Cookies.Cookies.GetCookie("User");
                if (cookie == null)
                {
                    User u = new User();
                    u.ID = int.MinValue;
                    return u;
                }

                int id = cookie.Values["uid"].ToInt32();
                string key = cookie.Values["k"].ToString();

                using (DataEntities ent = new DataEntities())
                {
                    //User _u = UserView.GetModelByID(id.ToString());
                    var users = (from l in ent.User where l.ID == id select l).ToList();
                    if (users.Count > 0)
                    {
                        User _u = users.FirstOrDefault();
                        string userkey = Voodoo.Security.Encrypt.Md5(string.Format("{0}{1}{2}",
                            _u.ID,
                            _u.UserName,
                            _u.UserPass,
                            BasePage.SystemSetting.SiteName
                            ));
                        if (userkey != key)//伪造cookie
                        {
                            _u = new User();
                            _u.ID = int.MinValue;
                            return _u;

                        }
                        else//正确
                        {
                            return _u;
                        }
                    }
                    return new User() { ID = int.MinValue };
                }
            }
        }
        #endregion

        #region 用户群组
        /// <summary>
        /// 用户群组
        /// </summary>
        /// <returns></returns>
        public static List<UserGroup> GetUserGroups()
        {

            if (Cache.Cache.GetCache("_UserGroupList") == null)
            {
                using (DataEntities ent = new DataEntities())
                {
                    Cache.Cache.SetCache("_UserGroupList", (from l in ent.UserGroup select l).ToList(), 10);
                }
            }
            return (List<UserGroup>)Cache.Cache.GetCache("_UserGroupList");

        }
        #endregion

        #region 判断当前用户的投稿权限
        /// <summary>
        /// 判断当前用户的投稿权限
        /// </summary>
        /// <param name="ClassID"></param>
        /// <returns></returns>
        public static bool HasPostRight(int ClassID)
        {
            using (DataEntities ent = new DataEntities())
            {
                User u = opuser;
                Class cls = (from l in ent.Class where l.ID == ClassID select l).FirstOrDefault();
                if (u.ID.ToS().IsInArray(cls.PostRoles.Split(',')))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        #endregion

        #region 根据id获取用户
        /// <summary>
        /// 根据id获取用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static User GetUserByID(int id)
        {
            using (DataEntities ent = new DataEntities())
            {
                return (from l in ent.User where l.ID == id select l).FirstOrDefault();
            }
        }

        public static string GetUserNameByID(int id)
        {
            return GetUserByID(id).UserName;
        }
        #endregion
    }
}
