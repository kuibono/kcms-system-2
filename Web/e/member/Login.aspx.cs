using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Voodoo;
using Voodoo.Data;
using Voodoo.Basement;
using Voodoo.Setting;

namespace Web.e.member
{
    public partial class Login : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string userName = WS.RequestString("username");
            string userPass = WS.RequestString("userpass");
            int exp = WS.RequestInt("exp", 1);

            if (userName.IsNullOrEmpty() || userPass.IsNullOrEmpty())
            {
                Js.AlertAndGoback("账号和密码不能为空！");
                return;
            }

            UserAction ua = new UserAction();
            Result r = ua.UserLogin(userName, userPass, exp);
            if (r.Success)
            {
                Js.Jump("/");
            }
            else
            {
                Js.AlertAndGoback(r.Text);
            }
        }
    }
}
