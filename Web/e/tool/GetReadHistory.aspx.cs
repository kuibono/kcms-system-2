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
using System.Text;



namespace Web.e.tool
{
    public partial class GetReadHistory : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataEntities ent = new DataEntities();
            try
            {
                string chapters = "";
                if (Voodoo.Cookies.Cookies.GetCookie("history") != null)
                {
                    chapters = Voodoo.Cookies.Cookies.GetCookie("history").Value;
                }
                string[] cs = chapters.Split(',');

                List<Cook> cookie = new List<Cook>();

                string ids = "";
                foreach (string chapter in cs)
                {
                    string[] Arr_chapter = chapter.Split('|');
                    cookie.Add(new Cook() { id = Arr_chapter[0].ToInt64(), time = Arr_chapter[1].ToDateTime() });
                    ids += Arr_chapter[0] + ",";
                }

                ids = ids.TrimEnd(',');

                var id = ids.Split(',').ToList();

                List<BookChapter> list_chapter = (from l in ent.BookChapter where id.IndexOf(l.ID.ToString()) > 0 select l).ToList();

                StringBuilder sb = new StringBuilder();
                sb.Append("document.write('");
                foreach (BookChapter bc in list_chapter)
                {
                    Book b = (from l in ent.Book where l.ID == bc.BookID select l).FirstOrDefault();
                    Class c = b.GetClass();

                    BookChapter new_Chapter = //BookChapterView.GetModelByID(b.LastChapterID.ToString());
                        (from l in ent.BookChapter where l.ID == b.LastChapterID select l).FirstOrDefault();

                    sb.Append(string.Format("<a href=\"{0}\">{1}</a>（<a href=\"{2}\">{3}</a>） 最新：<a href=\"{4}\">{5}</a><br />",
                        BasePage.GetBookUrl(b, c),
                        bc.BookTitle,
                        BasePage.GetBookChapterUrl(bc, c),
                        bc.Title,
                        BasePage.GetBookChapterUrl(new_Chapter, c),
                        b.LastChapterTitle
                        ));
                }
                sb.Append("');");

                Response.Clear();
                Response.Write(sb.ToS());
            }// end try
            catch
            {
                Voodoo.Cookies.Cookies.Remove("history");
            }
            finally
            {
                ent.Dispose();
            }
        }
    }
}
