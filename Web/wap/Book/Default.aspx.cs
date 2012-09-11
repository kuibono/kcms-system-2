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


    public partial class Default : Voodoo.Basement.BasePage
    {
        protected List<BookChapter> ReadingChapters=new List<BookChapter>();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                GetReadHistory();
            }
            catch { }
        }

        protected void GetReadHistory()
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
            var id=ids.Split(',').ToList();

            DataEntities ent=new DataEntities();
            ReadingChapters = //BookChapterView.GetModelList(string.Format("id in({0})", ids));.
                (from l in ent.BookChapter where id.IndexOf(l.ID.ToString()) > 0 select l).ToList();
        }
    }
}