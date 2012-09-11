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
    public partial class ChapterAdd : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataEntities ent = new DataEntities();

            int BookID = WS.RequestInt("bookid");
            string BookTitle = WS.RequestString("booktitle");
            int ClassID = WS.RequestInt("classid");
            string ClassName = WS.RequestString("classname");
            string Content = WS.RequestString("content").HtmlDeCode();
            string Title=WS.RequestString("title");

            Class cls = ObjectExtents.Class(ClassID);

            BookChapter c = new BookChapter();

            if (Title.Trim().Length == 0)
            {
                c.ID = -1;
                c.Title = "采集失败";
                Response.Clear();
                Response.Write(Voodoo.IO.XML.Serialize(c));
                return;
            }

            if ((from l in ent.BookChapter where l.Title==Title && l.BookTitle ==BookTitle select l).Count()>0)
            {
                c.Title = "已经存在";
                Response.Clear();
                Response.Write(Voodoo.IO.XML.Serialize(c));
                return;
            }


            c.BookID = BookID;
            c.BookTitle = BookTitle;
            c.ChapterIndex = 0;
            c.ClassID = ClassID;
            c.ClassName = ClassName;
            c.ClickCount = 0;
            //c.Content = Content;
            
            c.Enable = true;
            c.IsFree = true;
            c.IsImageChapter = false;
            c.IsTemp = false;
            c.IsVipChapter = false;
            c.TextLength = Content.TrimHTML().Length;
            c.Title = Title;
            c.UpdateTime = DateTime.Now;
            c.ValumeID = 0;

            ent.AddToBookChapter(c);
            //创建内容txt
            Voodoo.IO.File.Write(Server.MapPath(BasePage.GetBookChapterTxtUrl(c, cls)), Content);

            Book b = (from l in ent.Book where l.ID == BookID select l).FirstOrDefault();
            b.LastChapterID = c.ID;
            b.LastChapterTitle = c.Title;
            b.UpdateTime = c.UpdateTime;

            ent.SaveChanges();

            Response.Clear();
            Response.Write(Voodoo.IO.XML.Serialize(c));
        }
    }
}
