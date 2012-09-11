using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Voodoo;
using Voodoo.Data;
using Voodoo.Basement;
using Voodoo.Setting;


namespace Web.e.admin.Book
{
    public partial class ChapterList : AdminBase
    {
        protected int id = WS.RequestInt("bookid");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindList();
            }
            if (WS.RequestString("action") == "del")
            {
                Button1_Click(sender, e);
            }
        }

        protected void BindList()
        {
            using (DataEntities ent = new DataEntities())
            {
                var cpl = (from l in ent.BookChapter where l.BookID == id select l).ToList();
                rp_List.DataSource = cpl;
                rp_List.DataBind();
            }
        }

        protected void btn_disable_Click(object sender, EventArgs e)
        {

        }

        protected void btn_enable_Click(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DataEntities ent = new DataEntities();

            var ids = WS.RequestString("id").Split(',').ToList();
            var chapters = (from l in ent.BookChapter where ids.IndexOf(l.ID.ToString()) > 0 select l).ToList();
            foreach (var chapter in chapters)
            {
                string FilePath = Server.MapPath(GetBookChapterUrl(chapter, chapter.GetClass()));
                Voodoo.IO.File.Delete(FilePath);
                ent.DeleteObject(chapter);
            }



            var book = (from l in ent.Book where l.ID == id select l).FirstOrDefault();
            var cls = book.GetClass();

            //更新书籍的最新章节
            var lastChapter = //BookChapterView.Find(string.Format("bookid={0} order by ChapterIndex,ID desc",id));
                (from l in ent.BookChapter where l.BookID == id orderby l.ChapterIndex orderby l.ID descending select l).First();
            book.LastChapterID = lastChapter.ID;
            book.LastChapterTitle = lastChapter.Title;
            


            chapters = (from l in ent.BookChapter where l.BookID == id orderby l.ChapterIndex orderby l.ID descending select l).ToList();

            ent.SaveChanges();
            ent.Dispose();

            foreach (var chapter in chapters)
            {
                CreatePage.CreateBookChapterPage(chapter, book, cls);
            }

            CreatePage.CreateContentPage(book, cls);

            CreatePage.CreateListPage(cls, 0);

            CreatePage.GreateIndexPage();

            Response.Redirect(string.Format("ChapterList.aspx?bookid={0}", id));
        }
    }
}
