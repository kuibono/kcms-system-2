using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
//using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

using Voodoo;
using Voodoo.Data;
using Voodoo.Data.DbHelper;
using System.IO;



namespace Web
{
    public partial class _Default : Voodoo.Basement.BasePage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (WS.IsFromMobile())
            {
                //Response.Redirect("~/wap/book/");
                Server.Transfer("~/wap/book/Default.aspx");
            }
            else
            {
                Server.Transfer(SystemSetting.ClassFolder + "/Index" + SystemSetting.ExtName);
                //Server.Transfer("~/Dynamic/Movie/Default.aspx");
            }
        }
    }
}
