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
    public partial class Default : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Clear();
            TemplateHelper th = new TemplateHelper();
            Response.Write(th.GetIndex(TemplateHelper.TempType.新闻首页));
        }
    }
}