using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Voodoo;
using Voodoo.Basement;

namespace Web.Dynamic.News
{
    public partial class Class : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = WS.RequestInt("id");
            int page = WS.RequestInt("page", 1);

            var cls=ClassAction.Classes.Where(p=>p.ID==id).First();

            TemplateHelper th = new TemplateHelper();
            Response.Clear();
            Response.Write(th.CreateListPage(cls, page));
        }
    }
}