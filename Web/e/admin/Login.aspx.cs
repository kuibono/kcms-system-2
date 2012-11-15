using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Voodoo;
using Voodoo.Basement;

namespace Web.e.admin
{
    public partial class Login : System.Web.UI.Page
    {
        private static string refer = "/e/admin/";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (System.Web.HttpContext.Current.Session["sys_user"] != null)
            {
                Response.Redirect("~/e/admin/");
            }

            string username = WS.RequestString("txt_UserName");
            string password = WS.RequestString("txt_Userpass");
            string vcode = WS.RequestString("txt_VCode");
            if (username.IsNullOrEmpty() == false)
            {
                ClientLogin(username, password, vcode);
            }
            else
            {
                refer = Request.UrlReferrer.ToS();
            }

            if (WS.RequestString("action") == "img")
            {
                RandomSlide();
            }

        }

        protected void ClientLogin(string userName, string userPass, string vCode)
        {
            if (vCode.ToLower() != Session["SafeCode"].ToS())
            {
                Js.AlertAndGoback("验证码错误！");
                return;
            }

            Result r = SysUserAction.UserLogin(userName, userPass, "", "");
            if (r.Success)
            {
                Response.Redirect("~/e/admin/");

            }
            else
            {
                Js.AlertAndGoback(r.Text);
            }
        }

        protected void RandomSlide()
        {
            int index = @int.GetRandomNumber(1, 7);
            string src = string.Format("../data/bgimage/{0}.jpg", index);
            Response.Redirect(src);
        }

        
    }
}
