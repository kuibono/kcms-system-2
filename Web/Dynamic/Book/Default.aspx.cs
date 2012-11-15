using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Voodoo.Basement;

namespace Web.Dynamic.Book
{
    public partial class Default : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Clear();
            TemplateHelper th=new TemplateHelper();
            Response.Write(th.GetIndex(Voodoo.Basement.TemplateHelper.TempType.小说首页));
        }
    }
}