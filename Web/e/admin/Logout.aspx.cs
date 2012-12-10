using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.e.admin
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            System.Web.HttpCookie cookie = new System.Web.HttpCookie("sys_user");
            if (cookie != null)
            {
                cookie.Expires = DateTime.Now.AddDays(-1);
                Voodoo.Cookies.Cookies.SetCookie(cookie);
            }
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }
    }
}
