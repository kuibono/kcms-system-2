using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Voodoo;
using Voodoo.Basement;

namespace Web.Dynamic.Book
{
    public partial class Search : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TemplateHelper th = new TemplateHelper();
            int page = WS.RequestInt("p", 1);
            string key = WS.RequestString("key");
            Response.Clear();
            Response.Write(th.GetSearchResult(4, page, key));
        }
    }
}