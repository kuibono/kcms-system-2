using System;
using System.Collections;
using System.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

using System.IO;
using Voodoo;
using Voodoo.IO;
using Voodoo.other.SEO;
using Voodoo.Basement;
namespace Web.e.api
{
    /// <summary>
    /// xml-rpc接口，为系统提供一切可能。可以完成客户端的操作
    /// </summary>
    public partial class xmlrpc : System.Web.UI.Page
    {


        #region 处理请求
        /// <summary>
        /// 处理请求
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            string action = WS.RequestString("a").ToLower();
            switch (action)
            {
                case "booksearch":
                    string title = WS.RequestString("title");
                    string author = WS.RequestString("author");
                    string intro = WS.RequestString("intro");
                    SearchBook(title, author, intro);
                    break;
                case "bookexist":
                    title = WS.RequestString("title");
                    author = WS.RequestString("author");
                    BookExist(title, author);
                    break;
                case "getbook":
                    title = WS.RequestString("title");
                    author = WS.RequestString("author");
                    GetBook(title, author);
                    break;
                case "bookadd":
                    title = WS.RequestString("title");
                    author = WS.RequestString("author");
                    int classid = WS.RequestInt("class");
                    intro = WS.RequestString("intro").HtmlDeCode();
                    long length = WS.RequestString("length").ToInt64();
                    BookAdd(title, author, classid, intro, length);
                    break;
                case "bookedit":
                    int id = WS.RequestInt("id");
                    title = WS.RequestString("title");
                    author = WS.RequestString("author");
                    classid = WS.RequestInt("class");
                    intro = WS.RequestString("intro").HtmlDeCode();
                    length = WS.RequestString("length").ToInt64();
                    BookEdit(id, title, author, classid, intro, length);
                    break;
                case "bookdelete":
                    id = WS.RequestInt("id");
                    BookDelete(id);
                    break;
                case "getclass":
                    string ClassName = WS.RequestString("classname");
                    int ModelID = WS.RequestInt("model");
                    GetClass(ClassName, ModelID);
                    break;
                case "editclass":
                    classid = WS.RequestInt("class");
                    ClassName = WS.RequestString("classname");
                    int ParentID = WS.RequestInt("pid");
                    EditClass(classid, ClassName, ParentID);
                    break;
                case "getchapter":
                    string chaptertitle = WS.RequestString("chaptertitle");
                    string booktitle = WS.RequestString("booktitle");
                    GetChapter(booktitle, chaptertitle);
                    break;
                case "chapteradd":
                    int bookid = WS.RequestInt("bid");
                    chaptertitle = WS.RequestString("chaptertitle");
                    string Content = WS.RequestString("content").HtmlDeCode();
                    bool IsImageChapter = WS.RequestString("isimagechapter").ToBoolean();
                    bool IsTemp = WS.RequestString("istemp").ToBoolean();
                    ChapterAdd(bookid, chaptertitle, Content, IsImageChapter, IsTemp);
                    break;
                case "chapteredit":
                    long chapterid = WS.RequestString("chapterid").ToInt64();
                    chaptertitle = WS.RequestString("chaptertitle");
                    Content = WS.RequestString("content").HtmlDeCode();
                    IsImageChapter = WS.RequestString("isimagechapter").ToBoolean();
                    IsTemp = WS.RequestString("istemp").ToBoolean();
                    ChapterEdit(chapterid, chaptertitle, Content, IsImageChapter, IsTemp);
                    break;
                case "chapterdelete":
                    chapterid = WS.RequestString("chapterid").ToInt64();
                    ChapterDelete(chapterid);
                    break;
                case "chaptersearch":
                    booktitle = WS.RequestString("booktitle");
                    chaptertitle = WS.RequestString("chaptertitle");
                    IsImageChapter = WS.RequestString("isimagechapter").ToBoolean();
                    ChapterSearch(booktitle, chaptertitle, IsImageChapter);
                    break;
                case "getchaptercontent":
                    chapterid = WS.RequestString("chapterid").ToInt64();
                    GetChapterContent(chapterid);
                    break;
                case "createindex":
                    CreateIndex();
                    break;
                case "createclasspage":
                    int cls = WS.RequestInt("cls");
                    CreateClassPage(cls);
                    break;
                case "createbook":
                    bookid = WS.RequestInt("bookid");
                    CreateBook(bookid);
                    break;
                case "createchapters":
                    chapterid = WS.RequestInt("chapterid");
                    CreateChapters(chapterid);
                    break;
                case "createsitemap":
                    CreateSitemap();
                    break;
                case "savebookface":
                    bookid = WS.RequestInt("id");
                    HttpFileCollection files = Request.Files;
                    SaveBookFace(bookid, files);
                    break;
                default:
                    break;

            }
        }
        #endregion



        #region 书籍搜索
        /// <summary>
        /// 书籍搜索
        /// </summary>
        /// <param name="Title">标题</param>
        /// <param name="Author">作者</param>
        /// <param name="Intro">简介</param>
        protected void SearchBook(string Title, string Author, string Intro)
        {
            using (DataEntities ent = new DataEntities())
            {
                var books = from l in ent.Book
                            where
                                l.Title.Contains(Title) &&
                                l.Author.Contains(Author) &&
                                l.Intro.Contains(Intro)
                            select l;
                Response.Clear();
                Response.Write(XML.Serialize(books));
            }
        }
        #endregion

        #region 书籍是否存在
        /// <summary>
        /// 书籍是否存在
        /// </summary>
        /// <param name="Title">标题</param>
        /// <param name="Author">作者</param>
        protected void BookExist(string Title, string Author)
        {
            using (DataEntities ent = new DataEntities())
            {
                Response.Clear();
                Response.Write(XML.Serialize((from l in ent.Book where l.Title==Title && l.Author==Author select l).Count()>0));
            }

        }
        #endregion

        #region 获取书籍
        /// <summary>
        /// 获取书籍
        /// </summary>
        /// <param name="Title">标题</param>
        /// <param name="Author">作者</param>
        protected void GetBook(string Title, string Author)
        {
            using (DataEntities ent = new DataEntities())
            {
                Book b = (from l in ent.Book where l.Title == Title && l.Author == Author select l).FirstOrDefault();
                Response.Clear();
                Response.Write(XML.Serialize(b));
            }
        }
        #endregion

        #region 添加书籍
        /// <summary>
        /// 添加书籍
        /// </summary>
        /// <param name="Title">标题</param>
        /// <param name="Author">作者</param>
        /// <param name="ClassID">类别ID</param>
        /// <param name="Intro">简介</param>
        /// <param name="Length">长度</param>
        protected void BookAdd(string Title, string Author, int ClassID, string Intro, long Length)
        {
            string ClassName = ObjectExtents.Class(ClassID).ClassName;

            DataEntities ent=new DataEntities();

            Book b = new Book();

            if (Title.IsNullOrEmpty() && (from l in ent.Book where l.Title==Title && l.Author==Author select l).Count()>0)
            {
                b.ID = int.MinValue;
                Response.Clear();
                Response.Write(Voodoo.IO.XML.Serialize(b));
                return;
            }

            b.Addtime = DateTime.UtcNow.AddHours(8);
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
            b.UpdateTime = DateTime.UtcNow.AddHours(8);
            b.VipUpdateTime = DateTime.UtcNow.AddHours(8);
            b.ZtID = 0;

            var books = (from l in ent.Book where l.Title == Title && l.Author == Author select l).ToList();
            if (books.Count == 0)
            {
                ent.AddToBook(b);
                ent.SaveChanges();
            }
            else
            {
                b = books.FirstOrDefault();
            }
            ent.Dispose();

            Response.Clear();
            Response.Write(Voodoo.IO.XML.Serialize(b));
        }
        #endregion

        #region 书籍编辑
        /// <summary>
        /// 书籍编辑
        /// </summary>
        /// <param name="id">ID</param>
        /// <param name="Title">标题</param>
        /// <param name="Author">作者</param>
        /// <param name="ClassID">类别ID</param>
        /// <param name="Intro">简介</param>
        /// <param name="Length">长度</param>
        protected void BookEdit(int id, string Title, string Author, int ClassID, string Intro, long Length)
        {
            DataEntities ent = new DataEntities();

            Book b = (from l in ent.Book where l.ID == id select l).FirstOrDefault();
            string ClassName = ObjectExtents.Class(ClassID).ClassName;
            b.Title = Title.IsNull(b.Title);
            b.Author = Author.IsNull(b.Author);
            b.ClassID = ClassID.IsNull(b.ClassID);
            b.ClassName = ClassName.IsNull(b.ClassName);
            b.Intro = Intro.IsNull(b.Intro);
            b.Length = Length == 0 ? b.Length : Length;

            if (b.ID < 0)
            {
                Response.Clear();
                Response.Write(Voodoo.IO.XML.Serialize(false));
            }
            try
            {
                ent.SaveChanges();
                Response.Clear();
                Response.Write(Voodoo.IO.XML.Serialize(true));
            }
            catch
            {
                Response.Clear();
                Response.Write(Voodoo.IO.XML.Serialize(false));
            }
            finally
            {
                ent.Dispose();
            }
        }
        #endregion

        #region 设置书籍封面
        /// <summary>
        /// 设置书籍封面
        /// </summary>
        /// <param name="id">书籍ID</param>
        /// <param name="files">上传文件</param>
        protected void SaveBookFace(int id, HttpFileCollection files)
        {
            try
            {
                DataEntities ent = new DataEntities();

                Book b = (from l in ent.Book where l.ID == id select l).FirstOrDefault();

                string ImagePath = Server.MapPath("/Book/BookFace/" + id + ".jpg");
                DirectoryInfo dir = new FileInfo(ImagePath).Directory;
                if (!dir.Exists)
                {
                    dir.Create();
                }
                if (Voodoo.IO.File.Exists(ImagePath))
                {
                    Voodoo.IO.File.Delete(ImagePath);
                }
                files[0].SaveAs(ImagePath);
                b.FaceImage = "/Book/BookFace/" + id + ".jpg";

                ent.SaveChanges();
                ent.Dispose();

                Response.Clear();
                Response.Write(XML.Serialize(true));
            }
            catch
            {
                Response.Clear();
                Response.Write(XML.Serialize(false));
            }


        }
        #endregion

        #region 删除书籍
        /// <summary>
        /// 删除书籍
        /// </summary>
        /// <param name="id">ID</param>
        protected void BookDelete(int id)
        {
            using (DataEntities ent = new DataEntities())
            {
                var book = (from l in ent.Book where l.ID == id select l).FirstOrDefault();
                bool result = false;
                try
                {
                    ent.DeleteObject(book);
                    result = true;
                }
                catch
                {
                    result = false;
                }
                Response.Clear();
                Response.Write(Voodoo.IO.XML.Serialize(result));
            }
        }
        #endregion

        #region 获取栏目
        /// <summary>
        /// 获取栏目
        /// </summary>
        /// <param name="ClassName">栏目名称</param>
        /// <param name="ModelID">模型 1新闻 2图片 3问答 4小说</param>
        protected void GetClass(string ClassName, int ModelID)
        {
            DataEntities ent = new DataEntities();
            Class cls = (from l in ent.Class where l.ModelID == ModelID && l.ClassName == ClassName select l).FirstOrDefault();
            if (cls.ID <= 0)
            {
                //cls.ClassForder = PinyinHelper.GetPinyin(ClassName);
                cls.ClassForder = ClassName;
                cls.ClassKeywords = ClassName;
                cls.ClassName = ClassName;
                cls.ModelID = ModelID;
                cls.IsLeafClass = true;
                cls.ModelID = ModelID;
                cls.ShowInNav = true;
                ent.AddToClass(cls);
                
            }
            ent.SaveChanges();
            ent.Dispose();

            Voodoo.Cache.Cache.Clear("_NewClassList");

            Response.Clear();
            Response.Write(Voodoo.IO.XML.Serialize(cls));
        }
        #endregion

        #region 编辑类别
        /// <summary>
        /// 编辑类别
        /// </summary>
        /// <param name="ClassID">类别ID</param>
        /// <param name="ClassName">类别名称</param>
        /// <param name="ParentID">父ID</param>
        protected void EditClass(int ClassID, string ClassName, int ParentID)
        {
            DataEntities ent = new DataEntities();
            Class c = (from l in ent.Class where l.ID==ClassID select l).FirstOrDefault();
            if (c.ID < 0)
            {
                Response.Clear();
                Response.Write(XML.Serialize(false));
            }
            c.ParentID = ParentID.IsNull(c.ParentID.ToInt32());
            c.ClassName = ClassName.IsNull(c.ClassName);
            try
            {
                ent.SaveChanges();
                Response.Clear();
                Response.Write(XML.Serialize(true));
            }
            catch (System.Exception e)
            {
                Response.Clear();
                Response.Write(XML.Serialize(false));
            }
        }
        #endregion

        #region 获取章节
        /// <summary>
        /// 获取章节
        /// </summary>
        /// <param name="BookTitle">书籍标题</param>
        /// <param name="ChapterTitle">章节标题</param>
        protected void GetChapter(string BookTitle, string ChapterTitle)
        {
            using (DataEntities ent = new DataEntities())
            {
                BookChapter c = (from l in ent.BookChapter where l.BookTitle == BookTitle && l.Title == ChapterTitle select l).FirstOrDefault();
                Response.Clear();
                Response.Write(XML.Serialize(c));
            }
        }
        #endregion

        #region 添加章节
        /// <summary>
        /// 添加章节
        /// </summary>
        /// <param name="BookID">书籍ID</param>
        /// <param name="Title">标题</param>
        /// <param name="Content">内容</param>
        /// <param name="IsImageChapter">是否图片章节</param>
        protected void ChapterAdd(int BookID, string Title, string Content, bool IsImageChapter, bool IsTemp = false)
        {
            DataEntities ent = new DataEntities();

            Book b = (from l in ent.Book where l.ID == BookID select l).FirstOrDefault();
            Class cls = b.GetClass();
            BookChapter c = //BookChapterView.Find(string.Format("BookTitle=N'{0}' and Title=N'{1}'", b.Title, Title));
                (from l in ent.BookChapter where l.BookTitle == b.Title && l.Title == Title select l).FirstOrDefault();
            if (c.ID <= 0)
            {
                c.BookID = b.ID;
                c.BookTitle = b.Title;
                c.ChapterIndex = 0;
                c.ClassID = cls.ID;
                c.ClassName = cls.ClassName;
                c.ClickCount = 0;
                c.Enable = true;
                c.IsFree = true;
                c.IsImageChapter = IsImageChapter;
                c.IsTemp = IsTemp;
                c.IsVipChapter = false;
                c.TextLength = Content.Length;
                c.Title = Title;
                c.UpdateTime = DateTime.UtcNow.AddHours(8);//东八区时间

                ent.AddToBookChapter(c);
                ent.SaveChanges();

                //创建内容txt
                Voodoo.IO.File.Write(Server.MapPath(BasePage.GetBookChapterTxtUrl(c, cls)), Content);

                b.LastChapterID = c.ID;
                b.LastChapterTitle = c.Title;
                b.UpdateTime = c.UpdateTime;
                ent.SaveChanges();
            }
            ent.Dispose();
            Response.Clear();
            Response.Write(Voodoo.IO.XML.Serialize(c));
        }

        #endregion

        #region 编辑章节
        /// <summary>
        /// 编辑章节
        /// </summary>
        /// <param name="ChapterID">章节ID</param>
        /// <param name="Title">标题</param>
        /// <param name="Content">内容</param>
        /// <param name="IsImageChapter">是否图片章节</param>
        protected void ChapterEdit(long ChapterID, string Title, string Content, bool IsImageChapter, bool IsTemp = false)
        {
            using (DataEntities ent = new DataEntities())
            {
                var chapter = (from l in ent.BookChapter where l.ID == ChapterID select l).FirstOrDefault();
                var cls = chapter.GetClass();
                chapter.Title = Title.IsNull(chapter.Title);
                chapter.IsImageChapter = IsImageChapter;
                chapter.IsTemp = IsTemp;
                ent.SaveChanges();
                if (!Content.IsNullOrEmpty())
                {
                    Voodoo.IO.File.Write(Server.MapPath(BasePage.GetBookChapterTxtUrl(chapter, cls)), Content);
                }

                Response.Clear();
                Response.Write(Voodoo.IO.XML.Serialize(chapter));
            }
        }
        #endregion

        #region 删除章节
        /// <summary>
        /// 删除章节
        /// </summary>
        /// <param name="id">章节ID</param>
        protected void ChapterDelete(long id)
        {
            try
            {
                DataEntities ent = new DataEntities();

                var c = (from l in ent.BookChapter where l.ID == id select l).FirstOrDefault();
                var b = c.GetBook();
                Class cls = c.GetClass();
                Voodoo.IO.File.Delete(Server.MapPath(BasePage.GetBookChapterTxtUrl(c, cls)));
                ent.DeleteObject(c);
                ent.SaveChanges();

                var lastChapter = //BookChapterView.Find("BookId={0} order by ChapterIndex,id desc");
                    (from l in ent.BookChapter where l.BookID == b.ID orderby l.ChapterIndex orderby l.ID descending select l).FirstOrDefault();
                b.UpdateTime = lastChapter.UpdateTime;
                b.LastChapterID = lastChapter.ID;
                b.LastChapterTitle = lastChapter.Title;

                ent.SaveChanges();
                ent.Dispose();

                Response.Clear();
                Response.Write(Voodoo.IO.XML.Serialize(true));
            }
            catch (System.Exception e)
            {
                Response.Clear();
                Response.Write(Voodoo.IO.XML.Serialize(false));
            }

        }
        #endregion

        #region 搜索章节
        /// <summary>
        /// 搜索章节
        /// </summary>
        /// <param name="BookTitle">书籍标题</param>
        /// <param name="ChapterTitle">章节标题</param>
        /// <param name="IsImagechapter">是否图片章节</param>
        protected void ChapterSearch(string BookTitle, string ChapterTitle, bool IsImagechapter)
        {
            using (DataEntities ent = new DataEntities())
            {
                var cs = //BookChapterView.GetModelList(string.Format("BookTitle like N'%{0}%' and Title like N'%{1}%' and IsImageChapter={2}", BookTitle, ChapterTitle, IsImagechapter.BoolToShort()));
                    (from l in ent.BookChapter
                     where l.BookTitle.Contains(BookTitle) &&
                         l.Title.Contains(ChapterTitle) &&
                         l.IsImageChapter == IsImagechapter
                     select l
                         ).ToList();
                Response.Clear();
                Response.Write(XML.Serialize(cs));
            }
        }
        #endregion

        #region  获取章节内容
        /// <summary>
        /// 获取章节内容
        /// </summary>
        /// <param name="chapterID">章节id</param>
        protected void GetChapterContent(long chapterID)
        {
            using (DataEntities ent = new DataEntities())
            {
                BookChapter chapter = (from l in ent.BookChapter where l.ID == chapterID select l).FirstOrDefault();

                string path = BasePage.GetBookChapterTxtUrl(chapter, chapter.GetClass());

                string content = Voodoo.IO.File.Read(Server.MapPath(path));
                Response.Clear();
                Response.Write(XML.Serialize(content));
            }
        }
        #endregion

        #region 生成首页
        /// <summary>
        /// 生成首页
        /// </summary>
        protected void CreateIndex()
        {
            try
            {
                Voodoo.Basement.CreatePage.GreateIndexPage();
                Response.Clear();
                Response.Write(XML.Serialize(true));
            }
            catch (System.Exception e)
            {
                Response.Clear();
                Response.Write(XML.Serialize(false));
            }

        }
        #endregion

        #region 创建列表页面
        /// <summary>
        /// 创建列表页面
        /// </summary>
        protected void CreateClassPage(int cls)
        {
            try
            {
                var c = ObjectExtents.Class(cls);
                Voodoo.Basement.CreatePage.CreateListPage(c, 1);
                Response.Clear();
                Response.Write(XML.Serialize(true));
            }
            catch (System.Exception e)
            {
                Response.Clear();
                Response.Write(XML.Serialize(false));
            }
        }
        #endregion

        #region 生成书籍页面
        /// <summary>
        /// 生成书籍页面
        /// </summary>
        /// <param name="bookid">书籍ID</param>
        protected void CreateBook(int bookid)
        {
            try
            {
                using (DataEntities ent = new DataEntities())
                {
                    Book b = (from l in ent.Book where l.ID == bookid select l).FirstOrDefault();
                    Voodoo.Basement.CreatePage.CreateContentPage(b, b.GetClass());
                }
                Response.Clear();
                Response.Write(XML.Serialize(true));
            }
            catch (System.Exception e)
            {
                Response.Clear();
                Response.Write(XML.Serialize(false));
            }

        }
        #endregion

        #region  生成章节
        /// <summary>
        /// 生成章节
        /// </summary>
        /// <param name="bookid">书籍ID</param>
        protected void CreateChapters(long chapterid)
        {
            try
            {
                DataEntities ent = new DataEntities();
                var chapter = (from l in ent.BookChapter where l.ID == chapterid select l).FirstOrDefault();
                var book = chapter.GetBook();
                var cls = chapter.GetClass();
                var pre = BasePage.GetPreChapter(chapter, book);

                Voodoo.Basement.CreatePage.CreateBookChapterPage(chapter, book, cls);
                if (pre != null && pre.ID > 0)
                {
                    Voodoo.Basement.CreatePage.CreateBookChapterPage(pre, book, cls);
                }
                ent.Dispose();
                Response.Clear();
                Response.Write(XML.Serialize(true));
            }
            catch (System.Exception e)
            {
                Response.Clear();
                Response.Write(XML.Serialize(false));
            }

        }
        #endregion

        #region 生成站点地图
        /// <summary>
        /// 生成站点地图
        /// </summary>
        protected void CreateSitemap()
        {
            DataEntities ent = new DataEntities();

            Voodoo.other.SEO.SiteMap sm = new Voodoo.other.SEO.SiteMap();
            sm.url = new List<PageInfo>();

            sm.url.Add(new PageInfo() { changefreq = "always", lastmod = DateTime.Now, loc = Voodoo.Basement.BasePage.SystemSetting.SiteUrl, priority = "1.0" });
            List<Book> bs = //BookView.GetModelList("id>0 order by UpdateTime desc", 100);
                (from l in ent.Book orderby l.UpdateTime descending select l).Take(100).ToList();
            foreach (Book b in bs)
            {
                sm.url.Add(new PageInfo()
                {
                    changefreq = "daily",
                    lastmod = b.UpdateTime.ToDateTime(),
                    loc = (Voodoo.Basement.BasePage.SystemSetting.SiteUrl + BasePage.GetBookUrl(b, b.GetClass())).Replace("//Book/", "/Book/"),
                    priority = "0.8"
                });
            }

            List<BookChapter> bcs = //BookChapterView.GetModelList("id>0 order by UpdateTime desc", 500);
                (from l in ent.BookChapter orderby l.UpdateTime descending select l).Take(500).ToList();
            foreach (BookChapter bc in bcs)
            {
                sm.url.Add(new PageInfo()
                {
                    changefreq = "monthly",
                    lastmod = bc.UpdateTime,
                    loc = (Voodoo.Basement.BasePage.SystemSetting.SiteUrl + BasePage.GetBookChapterUrl(bc, bc.GetClass())).Replace("//Book/", "/Book/"),
                    priority = "0.7"
                });
            }
            try
            {
                sm.SaveSiteMap(Server.MapPath("~/sitemapxml/index.xml"));
                Response.Clear();
                Response.Write(XML.Serialize(true));
            }
            catch
            {
                Response.Clear();
                Response.Write(XML.Serialize(false));
            }
            finally
            {
                ent.Dispose();
            }
        }
        #endregion


        /////////////////////////////////////////////////////////////////
        ///                                                           
        ///  分类系统API
        ///
        /////////////////////////////////////////////////////////////////

    }
}
