using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Voodoo;

namespace Web.e.member
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string url = WS.RequestString("url","~/").UrlDecode();

            Voodoo.Cookies.Cookies.Clear();

            System.Web.HttpCookie cookie = new System.Web.HttpCookie("User");
            cookie.Expires = DateTime.Now.AddDays(-1);
            Voodoo.Cookies.Cookies.SetCookie(cookie);

            Response.Redirect(url);
        }
    }
}
