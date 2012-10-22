using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

using System.Web.Script.Services;
using System.Web.Script.Serialization;
using System.Collections.Generic;

using Voodoo;
using Voodoo.Basement;

namespace Web.e.Service
{
    /// <summary>
    /// UserService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    [System.Web.Script.Services.ScriptService]
    public class UserService : System.Web.Services.WebService
    {

        #region 帐号是否存在
        [WebMethod]
        public Result UserExist(string UserName)
        {
            Result r = new Result();
            using (DataEntities ent = new DataEntities())
            {
                var list = from l in ent.User where l.UserName == UserName select l;
                if (list.Count() == 0)
                {
                    r.Success = true;
                    r.Text = "这个用户名可以使用！";
                }
                else
                {
                    r.Success = false;
                    r.Text = "这个用户名已经存在，请重新选择！";
                }
                return r;
            }
        }
        #endregion

        #region Email是否存在
        [WebMethod]
        public Result EmailExist(string mail)
        {
            Result r = new Result();
            using (DataEntities ent = new DataEntities())
            {
                var list = from l in ent.User where l.Email == mail select l;
                if (mail.IsEmail() == false)
                {
                    r.Success = false;
                    r.Text = "Email格式错误！";
                }
                else if (list.Count() == 0)
                {
                    r.Success = true;
                    r.Text = "这个Email可以使用！";
                }
                else
                {
                    r.Success = false;
                    r.Text = "这个Email已经存在，请重新选择！";
                }
                return r;
            }
        }
        #endregion

        #region 用户注册
        [WebMethod]
        public Result UserReg(string email, string username, string pass, int group)
        {
            User u = new Voodoo.Basement.User();
            u.UserName = username;
            u.UserPass = Voodoo.Security.Encrypt.Md5(pass);
            u.Email = email;
            u.Group = group;

            UserAction ua = new UserAction();
            Result r = ua.UserRegister(u);
            if (r.Success)
            {
                ua.UserLogin(u.UserName, u.UserPass, 1);
            }
            return r;
        }
        #endregion

        #region 用户登录
        [WebMethod]
        public Result UserLogin(string UserName, string Password)
        {
            UserAction ua=new UserAction();
            return ua.UserLogin(UserName, Password, 7);
        }
        #endregion
    }
}
