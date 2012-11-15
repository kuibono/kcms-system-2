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
    public partial class Book : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataEntities ent=new DataEntities();
            int id=WS.RequestInt("id");
            var b=(from l in ent.Book where l.ID==id select l).FirstOrDefault();
            
            Response.Clear();
            TemplateHelper th = new TemplateHelper();
            Response.Write(th.CreateContentPage(b,b.GetClass()));
        }
    }
}