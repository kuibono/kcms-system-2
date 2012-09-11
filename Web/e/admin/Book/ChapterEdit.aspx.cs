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
using Voodoo.IO;

namespace Web.e.admin.Book
{
    public partial class ChapterEdit : AdminBase
    {
        /// <summary>
        /// 章节ID
        /// </summary>
        long id = WS.RequestString("id").ToInt64();

        int bookid = WS.RequestInt("bookid");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadInfo();
            }
        }

        protected void LoadInfo()
        {
            using (DataEntities ent = new DataEntities())
            {
                if (id > 0)
                {
                    var chapter = (from l in ent.BookChapter where l.ID == id select l).FirstOrDefault();
                    lb_BookTitle.Text = chapter.BookTitle;
                    lb_ValumeName.Text = chapter.ValumeName;
                    txt_Title.Text = chapter.Title;
                    string Content = Voodoo.IO.File.Read(Server.MapPath(GetBookChapterTxtUrl(chapter, chapter.GetClass())));
                    txt_Content.Text = Content;
                    chk_IsVip.Checked = chapter.IsVipChapter==true;
                    chk_IsEnable.Checked = chapter.Enable == true;
                    chk_IsTemp.Checked = chapter.IsTemp == true;
                    chk_IsFree.Checked = chapter.IsFree == true;
                    chk_IsImageChapter.Checked = chapter.IsImageChapter == true;

                }

                if (bookid > 0)
                {
                    var book = (from l in ent.Book where l.ID == bookid select l).FirstOrDefault();
                    lb_BookTitle.Text = book.Title;

                }
            }
        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            DataEntities ent = new DataEntities();

            var chapters = (from l in ent.BookChapter where l.ID == id select l).ToList();

            var chapter = new Voodoo.Basement.BookChapter();
            if (chapters.Count > 0)
            {
                chapter = chapters.FirstOrDefault();
            }
            chapter.Title = txt_Title.Text;
            chapter.IsVipChapter = chk_IsVip.Checked;
            chapter.Enable = chk_IsEnable.Checked;
            chapter.IsTemp = chk_IsTemp.Checked;
            chapter.IsFree = chk_IsFree.Checked;
            chapter.IsImageChapter = chk_IsImageChapter.Checked;
            if (chapters.Count== 0)
            {
                Voodoo.Basement.Book book = (from l in ent.Book where l.ID == bookid select l).FirstOrDefault();
                chapter.BookID = book.ID;
                chapter.BookTitle = book.Title;
                chapter.ClassID = book.ClassID;
                chapter.ClassName = book.ClassName;
                chapter.UpdateTime = DateTime.UtcNow.AddHours(8);

                ent.AddToBookChapter(chapter);
                ent.SaveChanges();

                book.LastChapterID = chapter.ID;
                book.LastChapterTitle = chapter.Title;
                book.UpdateTime = chapter.UpdateTime;
                CreatePage.CreateContentPage(book, book.GetClass());
            }
            ent.SaveChanges();
            ent.Dispose();

            Voodoo.IO.File.Write(
                Server.MapPath(GetBookChapterTxtUrl(chapter, chapter.GetClass())),
                txt_Content.Text);
            //生成章节页面
            CreatePage.CreateBookChapterPage(chapter, chapter.GetBook(), chapter.GetClass());

            Response.Redirect(string.Format("ChapterList.aspx?bookid={0}",chapter.BookID));
        }
    }
}
