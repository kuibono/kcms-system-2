using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

using Voodoo;
using Voodoo.Net;
using Voodoo.IO;

namespace Voodoo.Basement.Client
{
    /// <summary>
    /// 书籍客户端操作
    /// </summary>
    public class BookHelper
    {
        #region 变量
        /// <summary>
        /// 网站地址
        /// </summary>
        public string SiteUrl { get; set; }

        /// <summary>
        /// 账号
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// XML-RPC协议接口地址
        /// </summary>
        protected string xmlrpc
        {
            get
            {
                return (SiteUrl + "/e/api/xmlrpc.aspx").Replace("//e", "/e");
            }
        }

        #endregion

        #region 实例化
        public BookHelper(string siteUrl)
        {
            this.SiteUrl = siteUrl;
        }

        public BookHelper(string siteUrl, string username, string password)
        {
            this.SiteUrl = siteUrl;
            this.UserName = username;
            this.Password = password;
        }
        #endregion

        #region 书籍搜索
        /// <summary>
        /// 书籍搜索
        /// </summary>
        /// <param name="Title">标题</param>
        /// <param name="Author">作者</param>
        /// <param name="Intro">简介</param>
        public List<Book> SearchBook(string Title, string Author, string Intro)
        {
            string url = string.Format(xmlrpc + "?a=booksearch&title={0}&author={1}&intro={2}",
                Title,
                Author,
                Intro
                );
            return (List<Book>)Voodoo.IO.XML.DeSerialize(typeof(List<Book>), Url.Post(new NameValueCollection(), url, Encoding.UTF8));
        }
        #endregion

        #region 书籍是否存在
        /// <summary>
        /// 书籍是否存在
        /// </summary>
        /// <param name="Title">标题</param>
        /// <param name="Author">作者</param>
        public bool BookExist(string Title, string Author)
        {
            string url = string.Format(xmlrpc + "?a=bookexist&title={0}&author={1}",
                Title,
                Author
                );
            return (bool)Voodoo.IO.XML.DeSerialize(typeof(bool), Url.Post(new NameValueCollection(), url, Encoding.UTF8));
        }
        #endregion

        #region 获取书籍
        /// <summary>
        /// 获取书籍
        /// </summary>
        /// <param name="Title">标题</param>
        /// <param name="Author">作者</param>
        public Book GetBook(string Title, string Author)
        {
            string url = string.Format(xmlrpc + "?a=getbook&title={0}&author={1}", Title, Author);
            return (Book)Voodoo.IO.XML.DeSerialize(typeof(Book), Url.Post(new NameValueCollection(), url, Encoding.UTF8));
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
        public Book BookAdd(string Title, string Author, int ClassID, string Intro, long Length)
        {
            string url = xmlrpc + "?a=bookadd";
            NameValueCollection nv = new NameValueCollection();
            nv.Add("title", Title);
            nv.Add("author", Author);
            nv.Add("class", ClassID.ToS());
            nv.Add("intro", Intro);
            nv.Add("length", Length.ToS());

            return (Book)Voodoo.IO.XML.DeSerialize(typeof(Book), Url.Post(nv, url, Encoding.UTF8));
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
        public bool BookEdit(int id, string Title, string Author, int ClassID, string Intro, long Length)
        {
            string url = xmlrpc + "?a=bookedit";
            NameValueCollection nv = new NameValueCollection();
            nv.Add("id", id.ToS());
            nv.Add("title", Title);
            nv.Add("author", Author);
            nv.Add("class", ClassID.ToS());
            nv.Add("intro", Intro);
            nv.Add("length", Length.ToS());

            return (bool)Voodoo.IO.XML.DeSerialize(typeof(bool), Url.Post(nv, url, Encoding.UTF8));
        }
        #endregion

        #region 删除书籍
        /// <summary>
        /// 删除书籍
        /// </summary>
        /// <param name="id">ID</param>
        public bool BookDelete(int id)
        {
            string url = string.Format(xmlrpc + "?a=bookdelete&id={0}");
            return (bool)Voodoo.IO.XML.DeSerialize(typeof(bool), Url.Post(new NameValueCollection(), url, Encoding.UTF8));
        }
        #endregion

        #region 获取栏目
        /// <summary>
        /// 获取栏目
        /// </summary>
        /// <param name="ClassName">栏目名称</param>
        public Class GetClass(string ClassName)
        {
            string url = string.Format(xmlrpc + "?a=getclass&classname={0}&model=4", ClassName);
            return (Class)Voodoo.IO.XML.DeSerialize(typeof(Class), Url.Post(new NameValueCollection(), url, Encoding.UTF8));
        }
        #endregion

        #region 编辑类别
        /// <summary>
        /// 编辑类别
        /// </summary>
        /// <param name="ClassID">类别ID</param>
        /// <param name="ClassName">类别名称</param>
        /// <param name="ParentID">父ID</param>
        public bool EditClass(int ClassID, string ClassName, int ParentID)
        {
            string url = xmlrpc + "?a=editclass";
            NameValueCollection nv = new NameValueCollection();
            nv.Add("class", ClassID.ToS());
            nv.Add("classname", ClassName);
            nv.Add("pid", ParentID.ToS());
            return (bool)Voodoo.IO.XML.DeSerialize(typeof(bool), Url.Post(nv, url, Encoding.UTF8));
        }
        #endregion

        #region 获取章节
        /// <summary>
        /// 获取章节
        /// </summary>
        /// <param name="BookTitle">书籍标题</param>
        /// <param name="ChapterTitle">章节标题</param>
        public BookChapter GetChapter(string BookTitle, string ChapterTitle)
        {
            string url = string.Format(xmlrpc + "?a=getchapter&booktitle={0}&chaptertitle={1}", BookTitle, ChapterTitle);
            return (BookChapter)Voodoo.IO.XML.DeSerialize(typeof(BookChapter), Url.Post(new NameValueCollection(), url, Encoding.UTF8));
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
        public BookChapter ChapterAdd(int BookID, string Title, string Content, bool IsImageChapter,bool IsTemp=false)
        {
            string url = xmlrpc;
            NameValueCollection nv = new NameValueCollection();
            nv.Add("a", "chapteradd");
            nv.Add("bid", BookID.ToS());
            nv.Add("chaptertitle", Title);
            nv.Add("content", Content);
            nv.Add("isimagechapter", IsImageChapter ? "1" : "0");
            nv.Add("istemp", IsTemp ? "1" : "0");
            return (BookChapter)Voodoo.IO.XML.DeSerialize(typeof(BookChapter), Url.Post(nv, url, Encoding.UTF8));
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
        public BookChapter ChapterEdit(long ChapterID, string Title, string Content, bool IsImageChapter, bool IsTemp = false)
        {
            string url = xmlrpc + "?a=chapteredit";
            NameValueCollection nv = new NameValueCollection();
            nv.Add("chapterid", ChapterID.ToS());
            nv.Add("chaptertitle", Title);
            nv.Add("content", Content);
            nv.Add("isimagechapter", IsImageChapter ? "1" : "0");
            nv.Add("istemp", IsTemp ? "1" : "0");
            return (BookChapter)Voodoo.IO.XML.DeSerialize(typeof(BookChapter), Url.Post(nv, url, Encoding.UTF8));

        }
        #endregion

        #region 删除章节
        /// <summary>
        /// 删除章节
        /// </summary>
        /// <param name="id">章节ID</param>
        public bool ChapterDelete(long id)
        {
            string url = string.Format(xmlrpc + "?a=chapterdelete&chapterid={0}", id.ToS());
            return (bool)Voodoo.IO.XML.DeSerialize(typeof(bool), Url.Post(new NameValueCollection(), url, Encoding.UTF8));
        }
        #endregion

        #region 搜索章节
        /// <summary>
        /// 搜索章节
        /// </summary>
        /// <param name="BookTitle">书籍标题</param>
        /// <param name="ChapterTitle">章节标题</param>
        /// <param name="IsImagechapter">是否图片章节</param>
        public List<BookChapter> ChapterSearch(string BookTitle, string ChapterTitle, bool IsImagechapter)
        {
            string url = string.Format(xmlrpc + "?a=chaptersearch&booktitle={0}&chaptertitle={1}&isimagechapter={2}",
                BookTitle,
                ChapterTitle,
                IsImagechapter ? "1" : "0"
                );
            return (List<BookChapter>)Voodoo.IO.XML.DeSerialize(typeof(List<BookChapter>), Url.Post(new NameValueCollection(), url, Encoding.UTF8));
        }
        #endregion

        /// <summary>
        /// 获取章节内容
        /// </summary>
        /// <param name="ChapterID"></param>
        /// <returns></returns>
        public string GetChapterContent(long ChapterID)
        {
            string url = string.Format(xmlrpc + "?a=getchaptercontent&chapterid={0}",
                ChapterID.ToS()
                );
            return (string)Voodoo.IO.XML.DeSerialize(typeof(string), Url.Post(new NameValueCollection(), url, Encoding.UTF8));
        }

        #region 生成首页
        /// <summary>
        /// 生成首页
        /// </summary>
        public bool CreateIndex()
        {
            string url = xmlrpc + "?a=createindex";
            return (bool)Voodoo.IO.XML.DeSerialize(typeof(bool), Url.Post(new NameValueCollection(), url, Encoding.UTF8));

        }
        #endregion

        #region 创建列表页面
        /// <summary>
        /// 创建列表页面
        /// </summary>
        public bool CreateClassPage(int id)
        {
            string url = xmlrpc + "?a=createclasspage&cls="+id;
            return (bool)Voodoo.IO.XML.DeSerialize(typeof(bool), Url.Post(new NameValueCollection(), url, Encoding.UTF8));

        }
        #endregion

        #region 生成书籍页面
        /// <summary>
        /// 生成书籍页面
        /// </summary>
        /// <param name="bookid">书籍ID</param>
        public bool CreateBook(int bookid)
        {
            string url = xmlrpc + "?a=createbook&bookid=" + bookid;
            return (bool)Voodoo.IO.XML.DeSerialize(typeof(bool), Url.Post(new NameValueCollection(), url, Encoding.UTF8));


        }
        #endregion

        #region  生成章节
        /// <summary>
        /// 生成章节
        /// </summary>
        /// <param name="bookid">书籍ID</param>
        public bool CreateChapters(long chapterid)
        {
            string url = xmlrpc + "?a=createchapters&chapterid=" + chapterid;
            return (bool)Voodoo.IO.XML.DeSerialize(typeof(bool), Url.Post(new NameValueCollection(), url, Encoding.UTF8));

        }
        #endregion

        #region 生成站点地图
        /// <summary>
        /// 生成站点地图
        /// </summary>
        public bool CreateSitemap()
        {
            string url = xmlrpc + "?a=createsitemap";
            return (bool)Voodoo.IO.XML.DeSerialize(typeof(bool), Url.Post(new NameValueCollection(), url, Encoding.UTF8));
        }
        #endregion

        #region 设置书籍封面
        /// <summary>
        /// 设置书籍封面
        /// </summary>
        /// <param name="BookID">书籍ID</param>
        /// <param name="FilePath">本地图片路径</param>
        public void SetBookFace(int BookID,string FilePath)
        {
            Voodoo.Net.Url.UpLoadFile(FilePath, xmlrpc + "?a=savebookface&id=" + BookID+"&", false);
        }
        #endregion

    }
}
