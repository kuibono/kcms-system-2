using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Voodoo;
using Voodoo.Basement;
using System.Text;

namespace Web.wap.Book
{
    public partial class C : Voodoo.Basement.BasePage
    {
        public Voodoo.Basement.Book b;
        public BookChapter c;
        public Class cls;
        public string Content;

        public BookChapter pre;
        public BookChapter next;

        protected void Page_Load(object sender, EventArgs e)
        {
            long id = WS.RequestString("id").ToInt64();
            GetChapter(id);
            ProcessHistory(id);
        }

        protected void GetChapter(long id)
        {
            DataEntities ent = new DataEntities();
            if (id > 0)
            {
                c = (from l in ent.BookChapter where l.ID == id select l).FirstOrDefault();
            }
            else
            {
                c = (from l in ent.BookChapter  orderby id  select l).FirstOrDefault();
            }
            b = (from l in ent.Book where l.ID==c.BookID select l).FirstOrDefault();
            cls = b.GetClass();

            Content = Voodoo.IO.File.Read(Server.MapPath(Voodoo.Basement.BasePage.GetBookChapterTxtUrl(c, cls)));

            pre = Voodoo.Basement.BasePage.GetPreChapter(c, b);
            next = Voodoo.Basement.BasePage.GetNextChapter(c, b);
            ent.Dispose();

        }

        #region 设置阅读记录
        /// <summary>
        /// 设置阅读记录
        /// </summary>
        /// <param name="id"></param>
        protected void ProcessHistory(long id)
        {
            DataEntities ent = new DataEntities();
            try
            {
                long chapterid = id;
                BookChapter bc = (from l in ent.BookChapter where l.ID == id select l).FirstOrDefault();
                bc.ClickCount = bc.ClickCount > 0 ? bc.ClickCount + 1 : 1;

                ent.SaveChanges();

                //写入Cookie

                List<Cook> cookies = new List<Cook>();
                if (Voodoo.Cookies.Cookies.GetCookie("history") != null)
                {
                    string[] chapters = Voodoo.Cookies.Cookies.GetCookie("history").Value.Split(',');
                    foreach (string chapter in chapters)
                    {
                        string[] arr_chapter = chapter.Split('|');
                        cookies.Add(new Cook() { id = arr_chapter[0].ToInt64(), time = arr_chapter[1].ToDateTime(), bookid = arr_chapter[2].ToInt32() });
                    }
                }

                cookies = cookies.Where(p => p.bookid != bc.BookID).OrderByDescending(p => p.time).Take(4).ToList();
                cookies.Add(new Cook() { id = chapterid, time = DateTime.Now, bookid = bc.BookID });

                StringBuilder sb = new StringBuilder();

                foreach (Cook c in cookies)
                {
                    sb.Append(string.Format("{0}|{1}|{2},", c.id, c.time.ToString(), c.bookid.ToS()));
                }
                sb = sb.TrimEnd(',');

                HttpCookie _cookie = new HttpCookie("history", sb.ToString());
                _cookie.Expires = DateTime.Now.AddYears(1);

                Voodoo.Cookies.Cookies.SetCookie(_cookie);
            }//end try
            catch
            {
                Voodoo.Cookies.Cookies.Remove("history");
            }
            finally
            {
                ent.Dispose();
            }

        }
        #endregion
    }

    public class Cook
    {
        public long id { get; set; }

        public int bookid { get; set; }

        public DateTime time { get; set; }
    }
}