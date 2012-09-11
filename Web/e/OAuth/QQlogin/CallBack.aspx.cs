using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Voodoo;
using Voodoo.Cookies;
using Voodoo.Basement;

using QConnectSDK;
using QConnectSDK.Models;
namespace Web.e.OAuth.QQlogin
{
    public partial class CallBack : Voodoo.Basement.BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                QQLogin();
            }
            catch
            {
                Js.AlertAndChangUrl("登录过程出现异常，请重新登录！", "/e/OAuth/QQlogin/");
            }
        }

        #region  QQ用户登录
        /// <summary>
        /// QQ用户登录
        /// </summary>
        protected void QQLogin()
        {
            DataEntities ent = new DataEntities();

            if (Request.Params["code"] != null)
            {
                QOpenClient qzone = null;
                QConnectSDK.Models.User currentUser = null;
                var verifier = Request.Params["code"];
                string state = Session["requeststate"].ToString();
                qzone = new QOpenClient(verifier, state);
                //
                currentUser = qzone.GetCurrentUser();
                if (null != currentUser)
                {
                    string openid = qzone.OAuthToken.OpenId;

                    var SysUser = //UserView.Find(string.Format("UserName=N'{0}'", openid));
                        (from l in ent.User where l.UserName == openid select l).FirstOrDefault();
                    if (SysUser.ID <= 0)
                    {

                        SysUser.Cent = SystemSetting.RegCent;
                        SysUser.ChineseName = currentUser.Nickname;

                        SysUser.Enable = true;
                        SysUser.Group = 0;
                        SysUser.Image = currentUser.Figureurl;

                        SysUser.LastLoginIP = WS.GetIP();
                        SysUser.LastLoginTime = DateTime.UtcNow.AddHours(8);
                        SysUser.LoginCount = 1;
                        SysUser.PostCount = 0;
                        SysUser.RegIP = WS.GetIP();
                        SysUser.RegTime = DateTime.UtcNow.AddHours(8);
                        SysUser.StudentNo = "";
                        SysUser.TeachNo = "";
                        SysUser.Tel = "";
                        SysUser.Twitter = "";
                        SysUser.UserName = openid;
                        SysUser.UserPass = "";
                        SysUser.WebSite = "";
                        //SysUser.Weibo = "";


                        try
                        {
                            var i = qzone.GetWeiboUserInfo("", qzone.OAuthToken.OpenId);
                            SysUser.Address = i.Data.Location;
                            SysUser.Email = i.Data.Email;
                            SysUser.Intro = i.Data.Introduction;
                            SysUser.ZipCode = i.Data.City_code.ToS();
                        }
                        catch
                        {

                        }

                        //UserView.Insert(SysUser);
                        ent.AddToUser(SysUser);

                    }
                    else
                    {
                        SysUser.LoginCount++;
                        SysUser.LastLoginIP = WS.GetIP();
                        SysUser.LastLoginTime = DateTime.UtcNow.AddHours(8);

                    }
                    ent.SaveChanges();

                    //System.Web.HttpContext.Current.Session["sys_user"] = SysUser.ID;

                    System.Web.HttpCookie cookie = new System.Web.HttpCookie("User");
                    cookie.Expires = DateTime.Now.AddDays(7);
                    cookie.Values.Add("uid", SysUser.ID.ToString());
                    cookie.Values.Add("k", Voodoo.Security.Encrypt.Md5(string.Format("{0}{1}{2}",
                        SysUser.ID,
                        SysUser.UserName,
                        SysUser.UserPass,
                        BasePage.SystemSetting.SiteName
                        )));
                    Voodoo.Cookies.Cookies.SetCookie(cookie);

                    Response.Redirect("/");


                }
                
                Session["QzoneOauth"] = qzone;
            }
            ent.Dispose();
        }
        #endregion
    }
}