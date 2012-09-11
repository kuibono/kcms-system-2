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
    public partial class BookAdd : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataEntities ent = new DataEntities();

            string Title = WS.RequestString("title");
            string Author = WS.RequestString("author");
            int ClassID = WS.RequestInt("classid");
            string ClassName = ObjectExtents.Class(ClassID).ClassName;
            string Intro = WS.RequestString("intro").HtmlDeCode();
            int Length = WS.RequestInt("length", 0);

            Book b = new Book();

            if (Title.IsNullOrEmpty())
            {
                b.ID = int.MinValue;
                Response.Clear();
                Response.Write(Voodoo.IO.XML.Serialize(b));
                return;
            }

            b.Addtime = DateTime.Now;
            b.Author = Author;
            b.ClassID = ClassID;
            b.ClassName = ClassName;
            b.ClickCount = 0;
            b.CorpusID = 0;
            b.Enable = true;
            b.FaceImage = "";
            b.Intro = Intro;
            b.IsFirstPost = false;
            b.IsVip = false;
            b.LastChapterID = 0;
            b.LastVipChapterID = 0;
            b.Length = Length;
            b.ReplyCount = 0;
            b.SaveCount = 0;
            b.Status = 0;//连载中
            b.Title = Title;
            b.UpdateTime = DateTime.Now;
            b.VipUpdateTime = DateTime.Now;
            b.ZtID = 0;

           
            var books = (from l in ent.Book where l.Title == Title && l.Author == Author select l).ToList();
            if (books.Count == 0)
            {
                ent.AddToBook(b);
            }
            else
            {
                b = books.FirstOrDefault();
            }
            ent.SaveChanges();


            Response.Clear();
            Response.Write(Voodoo.IO.XML.Serialize(b));
        }
    }
}
