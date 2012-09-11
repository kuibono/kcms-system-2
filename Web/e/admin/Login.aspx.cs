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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (System.Web.HttpContext.Current.Session["sys_user"] != null)
            {
                Response.Redirect("~/e/admin/");
            }
        }


        protected void btn_Login_Click(object sender, EventArgs e)
        {
            string userName = txt_UserName.Text.TrimDbDangerousChar();
            string userPass = txt_Userpass.Text.TrimDbDangerousChar();
            string vCode = txt_VCode.Text.TrimDbDangerousChar();

            if (vCode.ToLower() != Session["SafeCode"].ToS())
            {
                Js.AlertAndGoback("验证码错误！");
                return;
            }

            Result r=SysUserAction.UserLogin(userName, userPass, "", "");
            if (r.Success)
            {
                Response.Redirect("~/e/admin/");

            }
            else
            {
                Js.AlertAndGoback(r.Text);
            }
        }
    }
}
