using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Voodoo;
using Voodoo.Basement;

namespace Web.wap.Book
{
    public partial class B : Voodoo.Basement.BasePage
    {
        public Voodoo.Basement.Book b;
        public List<BookChapter> cs;
        public Class cls;

        protected void Page_Load(object sender, EventArgs e)
        {
            int id = WS.RequestInt("id");
            GetBook(id);
        }

        protected void GetBook(int id)
        {
            DataEntities ent = new DataEntities();
            if (id > 0)
            {
                b = (from l in ent.Book where l.ID == id select l).FirstOrDefault();
            }
            else
            {
                b = (from l in ent.Book orderby l.ID descending select l).FirstOrDefault();
            }

            b.ClickCount++;


            cls = b.GetClass();
            cs = (from l in ent.BookChapter where l.BookID == id orderby l.ChapterIndex descending orderby l.ID descending select l).ToList();
            ent.Dispose();
        }
    }
}