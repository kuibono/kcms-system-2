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
    public partial class Chapter : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            long id = WS.RequestLong("id");

            try
            {
                DataEntities ent=new DataEntities();

                var c = (from l in ent.BookChapter where l.ID == id select l).First();
                TemplateHelper th = new TemplateHelper();

                Response.Clear();
                Response.Write(th.CreateBookChapterPage(c,c.GetBook(),c.GetClass()));

            }
            catch(Exception ex)
            {
                throw new Exception("没有找到这个章节！");
            }
            
            
        }
    }
}