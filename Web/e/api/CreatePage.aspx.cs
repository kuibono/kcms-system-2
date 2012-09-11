using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Voodoo;
using Voodoo.Basement;
using System.IO;

namespace Web.e.api
{
    public partial class CreatePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string action = WS.RequestString("action");
            int id = WS.RequestInt("id");

            switch (action)
            {
                case "createindex":
                    CreateIndex();
                    break;
                case "createclasspage":
                    CreateClassPage();
                    break;
                case "createbook":
                    CreateBook(id);
                    break;
                case "createchapters":
                    CreateChapters(id);
                    break;
            }
        }

        protected void CreateIndex()
        {
            Voodoo.Basement.CreatePage.GreateIndexPage();
        }

        protected void CreateClassPage()
        {
            var cls = ClassAction.Classes;
            foreach (var c in cls)
            {
                Voodoo.Basement.CreatePage.CreateListPage(c, 1);
            }

        }

        protected void CreateBook(int bookid)
        {
            DataEntities ent = new DataEntities();
            Book b = (from l in ent.Book where l.ID == bookid select l).FirstOrDefault();
            ent.Dispose();

            Voodoo.Basement.CreatePage.CreateContentPage(b, b.GetClass());
        }

        protected void CreateChapters(int bookid)
        {
            DataEntities ent = new DataEntities();
            var chapters = (from l in ent.BookChapter where l.BookID == bookid select l).ToList();
            var book = chapters.FirstOrDefault().GetBook();
            foreach (var c in chapters)
            {
                Voodoo.Basement.CreatePage.CreateBookChapterPage(c, book, c.GetClass());
            }
        }
    }
}
