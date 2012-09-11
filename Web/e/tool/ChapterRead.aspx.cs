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
    public class Cook
    {
        public long id { get; set; }

        public int bookid { get; set; }

        public DateTime time { get; set; }
    }

    public partial class ChapterRead : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                DataEntities ent = new DataEntities();

                long chapterid = WS.RequestString("cid").ToInt64();
                BookChapter bc = (from l in ent.BookChapter where l.ID == chapterid select l).FirstOrDefault();
                bc.ClickCount = bc.ClickCount > 0 ? bc.ClickCount + 1 : 1;

                ent.SaveChanges();

                ent.Dispose();
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
                cookies.Add(new Cook() { id = chapterid, time = DateTime.Now, bookid=bc.BookID });

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

        }
    }
}
