using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Voodoo;
using Voodoo.Basement;

namespace Web.e.tool
{
    public partial class BookOperate : System.Web.UI.Page
    {
        protected string id = WS.RequestString("id");
        protected void Page_Load(object sender, EventArgs e)
        {
            string action = WS.RequestString("action");
            switch (action)
            {
                case "tj":
                    BookTj(id);
                    break;
                case "err":
                    ChapterError(id);
                    break;
            }
        }

        /// <summary>
        /// 推荐票
        /// </summary>
        /// <param name="BookID"></param>
        protected void BookTj(string BookID)
        {
            using (DataEntities ent = new DataEntities())
            {
                int bookid = BookID.ToInt32();
                Book b = (from l in ent.Book where l.ID == bookid select l).FirstOrDefault();
                b.TjCount++;

                ent.SaveChanges();

                Response.Clear();
                Response.Write(b.TjCount.ToString().StringToJson());
            }
        }

        protected void ChapterError(string ChapterID)
        {
            using (DataEntities ent = new DataEntities())
            {
                long chapterid = ChapterID.ToInt64();

                BookChapter chapter = (from l in ent.BookChapter where l.ID == chapterid select l).FirstOrDefault();
                chapter.IsTemp = true;
                chapter.IsImageChapter = true;

                ent.SaveChanges();

                Response.Clear();
                Response.Write(chapter.ToJsonStr());
            }
        }
    }
}