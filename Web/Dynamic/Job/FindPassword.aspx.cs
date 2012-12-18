using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Voodoo;
using Voodoo.Basement;

namespace Web.Dynamic.Job
{
    public partial class FindPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Value;
            string vcode = txtVerifyCode.Value;
            if (vcode != Session["SafeCode"].ToS().ToLower())
            {
                Js.AlertAndGoback("验证码输入错误，请重新输入！");
                return;
            }
            else
            {
                UserAction ua = new UserAction();
                var result=ua.FindPassword(email);
                if (result.Success)
                {
                    Js.AlertAndChangUrl(result.Text,"/");
                }
                else
                {
                    Js.AlertAndGoback(result.Text);
                }
            }
        }
    }
}