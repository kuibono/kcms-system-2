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
    public partial class News : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = WS.RequestInt("id");
            string title = WS.RequestString("title");
            string dt = WS.RequestString("date");
            Voodoo.Basement.News news;
            using (DataEntities ent = new DataEntities())
            {
                if (id > 0)
                {
                    news = (from l in ent.News where l.ID == id select l).FirstOrDefault();
                }
                else
                {
                    news = (from l in ent.News where l.Title==title && l.FileForder==dt select l).FirstOrDefault();
                }
                TemplateHelper th = new TemplateHelper();
                Response.Clear();
                Response.Write(th.CreateContentPage(news, news.GetClass()));
            }

        }
    }
}