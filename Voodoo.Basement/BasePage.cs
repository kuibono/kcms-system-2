using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Compilation;
using System.Web.Routing;
using System.Web.UI.WebControls;
using CookComputing.XmlRpc;
using Voodoo.Basement.UrlConverter;
using Voodoo.Data;
using Voodoo.IO;

namespace Voodoo.Basement
{
    #region 路由实现接口
    /// <summary>
    /// 路由实现接口
    /// </summary>
    public interface IRoutablePage
    {
        RequestContext RequestContext { get; set; }
    }
    #endregion

    public class RouteHandler : IRouteHandler
    {
        public string VirtualPath { get; private set; }

        public RouteHandler(string virtualPath)
        {
            this.VirtualPath = virtualPath;
        }

        /// <summary>
        /// 处理路由请求中有关参数协定的类
        /// </summary>
        /// <param name="requestContext"></param>
        /// <returns></returns>
        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            //as 的好处是，如果类型转换不成功，不会产生异常，而返回一个null值
            //根据指定的要处理那条路由请求的页面的虚拟路径来创建一个相应的Page对象
            var originalPage = BuildManager.CreateInstanceFromVirtualPath(VirtualPath, typeof(System.Web.UI.Page)) as IHttpHandler;
            if (originalPage != null)
            {
                var routePage = originalPage as IRoutablePage;
                if (routePage != null)
                {
                    routePage.RequestContext = requestContext;
                }
            }
            return originalPage;
        }
    }

    public class BasePage : System.Web.UI.Page, IRoutablePage
    {
        #region 获取Url转换器
        /// <summary>
        /// 获取Url转换器
        /// </summary>
        /// <returns></returns>
        private static IConverter GetConverter()
        {
            if (SystemSetting.EnableStatic)
            {
                return new StaticConvertor();
            }
            else
            {
                return new DynamicConverter();
            }
        }
        #endregion


        #region 路由功能
        public RequestContext RequestContext { get; set; }

        /// <summary>
        /// 获取路由中URL参数值和默认值集合
        /// </summary>
        public RouteValueDictionary RouteValues
        {
            get
            {
                if (RequestContext != null)
                {
                    return RequestContext.RouteData.Values;
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// 获取路由中指定名称的URL参数值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public object GetRouteValue(string key)
        {
            object resultValue = null;
            if (RouteValues != null && RouteValues.Count > 0)
            {
                RouteValues.TryGetValue(key, out resultValue);
            }
            return resultValue;
        }

        #endregion


        #region 静态系统参数
        /// <summary>
        /// 静态系统参数
        /// </summary>
        public static SysSetting SystemSetting
        {
            get
            {
                return Setting.SysSettingDAL.GetSetting();
            }
        }
        #endregion

        #region 获取数据访问对象GetHelper
        /// <summary>
        /// 获取数据访问对象
        /// </summary>
        public IDbHelper GetHelper()
        {
            return Voodoo.Setting.DataBase.GetHelper();
        }
        #endregion

        #region 通过ID获取群组
        /// <summary>
        /// 通过ID获取群组
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public SysGroup GetGroupByID(int id)
        {
            using (DataEntities ent = new DataEntities())
            {
                var list = (from l in ent.SysGroup where l.ID == id select l).ToList();
                if (list.Count > 0)
                {
                    return list.FirstOrDefault();
                }
                else
                {
                    return null;
                }
            }

        }
        public string GetGroupNameByID(int id)
        {
            return GetGroupByID(id).GroupName;
        }
        #endregion



        #region  根据ID获得部门名
        /// <summary>
        /// 根据ID获得部门名
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetDepartmentByID(int id)
        {
            using (DataEntities ent = new DataEntities())
            {
                var list = (from l in ent.SysDepartment where l.ID == id select l).ToList();
                if (list.Count > 0)
                {
                    return list.FirstOrDefault().DepartName;
                }
                else
                {
                    return "";
                }
            }

        }
        #endregion

        #region 获取系统分组
        /// <summary>
        /// 获取系统分组
        /// </summary>
        /// <returns></returns>
        public List<SysGroup> GetSysGroup()
        {
            using (DataEntities ent = new DataEntities())
            {
                return (from l in ent.SysGroup select l).ToList();
            }
        }
        #endregion

        #region 获取系统部门
        /// <summary>
        /// 获取系统部门
        /// </summary>
        /// <returns></returns>
        public List<SysDepartment> GetSysDepartment()
        {
            using (DataEntities ent = new DataEntities())
            {
                return (from l in ent.SysDepartment select l).ToList();
            }
        }
        #endregion

        #region 页面生成选项
        /// <summary>
        /// 页面生成选项
        /// </summary>
        public static ListItemCollection CreatePageOptions
        {
            get
            {
                ListItemCollection nv = new ListItemCollection();
                nv.Add(new ListItem("不生成", "0"));
                nv.Add(new ListItem("生成当前栏目", "1"));
                nv.Add(new ListItem("生成首页", "2"));
                nv.Add(new ListItem("生成父栏目", "3"));
                nv.Add(new ListItem("生成当前栏目与父栏目", "4"));
                nv.Add(new ListItem("生成父栏目与首页", "5"));
                nv.Add(new ListItem("生成当前栏目、父栏目与首页", "6"));
                return nv;
            }
        }
        #endregion

        #region 管理投稿选项
        /// <summary>
        /// 管理投稿选项
        /// </summary>
        public static NameValueCollection PostManagementOptions
        {
            get
            {
                NameValueCollection nv = new NameValueCollection();
                nv.Add("不能管理信息", "0");
                nv.Add("可管理未审核信息", "1");
                nv.Add("只可编辑未审核信息", "2");
                nv.Add("只可删除未审核信息", "3");
                nv.Add("可管理所有信息", "4");
                nv.Add("只可编辑所有信息", "5");
                nv.Add("只可删除所有信息", "6");
                return nv;
            }
        }
        #endregion


        #region 获取信息地址
        /// <summary>
        /// 获取信息地址
        /// </summary>
        /// <param name="news">信息</param>
        /// <param name="cls">栏目</param>
        /// <returns></returns>
        public static string GetNewsUrl(News news, Class cls)
        {
            return GetConverter().GetNewsUrl(news, cls);
        }
        #endregion

        #region 获取图片内容页面地址 GetImageUrl
        /// <summary>
        /// 获取图片内容页面地址
        /// </summary>
        /// <param name="img"></param>
        /// <param name="cls"></param>
        /// <returns></returns>
        public static string GetImageUrl(ImageAlbum img, Class cls)
        {
            return GetConverter().GetImageUrl(img, cls);
        }
        #endregion

        #region 获取问答url地址
        /// <summary>
        /// 获取问答url地址
        /// </summary>
        /// <param name="qs"></param>
        /// <param name="cls"></param>
        /// <returns></returns>
        public static string GetQuestionUrl(Question qs, Class cls)
        {
            return GetConverter().GetQuestionUrl(qs, cls);
        }
        #endregion

        #region 获取书籍url地址
        /// <summary>
        /// 获取问答url地址
        /// </summary>
        /// <param name="qs"></param>
        /// <param name="cls"></param>
        /// <returns></returns>
        public static string GetBookUrl(Book b, Class cls)
        {
            return GetConverter().GetBookUrl(b, cls);
        }
        #endregion

        #region 获取书籍章节url地址
        /// <summary>
        /// 获取问答url地址
        /// </summary>
        /// <param name="qs"></param>
        /// <param name="cls"></param>
        /// <returns></returns>
        public static string GetBookChapterUrl(BookChapter cp, Class cls)
        {
            return GetConverter().GetBookChapterUrl(cp, cls);
        }

        /// <summary>
        /// 获取章节txt文件路径
        /// </summary>
        /// <param name="cp"></param>
        /// <param name="cls"></param>
        /// <returns></returns>
        public static string GetBookChapterTxtUrl(BookChapter cp, Class cls)
        {
            return GetConverter().GetBookChapterTxtUrl(cp, cls);
        }
        #endregion

        #region 获取影视地址
        /// <summary>
        /// 获取影视地址
        /// </summary>
        /// <param name="qs"></param>
        /// <param name="cls"></param>
        /// <returns></returns>
        public static string GetMovieUrl(MovieInfo b, Class cls)
        {
            return GetConverter().GetMovieUrl(b, cls);
        }
        #endregion

        /// <summary>
        /// 标题地址标准化
        /// </summary>
        /// <param name="Title"></param>
        /// <returns></returns>
        public static string TitleFilter(string Title)
        {
            return Title.ChinaseUrlEncode();

        }

        #region 获取章节txt文件存储地址
        /// <summary>
        /// 获取章节txt文件存储地址
        /// </summary>
        /// <param name="bc"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static string GetChapterTxtStorePath(BookChapter bc,Book b)
        {
            string txtPath = Routing.StorageSetting.Get().BookChapterTxt;
            txtPath=txtPath.Replace("{classname}",b.ClassName);
            txtPath=txtPath.Replace("{classid}",b.ClassID.ToS());
            txtPath=txtPath.Replace("{title}",b.Title);
            txtPath=txtPath.Replace("{bookid}",b.ID.ToS());
            txtPath=txtPath.Replace("{author}",b.Author);
            txtPath = txtPath.Replace("{id}", bc.ID.ToS());

            return txtPath;
        }


        #endregion

        #region 获取影视播放页面地址
        /// <summary>
        /// 获取影视地址
        /// </summary>
        /// <param name="qs"></param>
        /// <param name="cls"></param>
        /// <returns></returns>
        public static string GetMovieDramaUrl(MovieUrlBaidu b, Class cls)
        {
            return GetConverter().GetMovieDramaUrl(b, cls);
        }

        public static string GetMovieDramaUrl(MovieUrlKuaib b, Class cls)
        {
            return GetConverter().GetMovieDramaUrl(b, cls);
        }

        public static string GetMovieDramaUrl(MovieDrama b, Class cls)
        {
            return GetConverter().GetMovieDramaUrl(b, cls);
        }

        #endregion


        #region 获取栏目地址
        /// <summary>
        /// 获取栏目地址
        /// </summary>
        /// <param name="cls">栏目</param>
        /// <returns></returns>
        public static string GetClassUrl(Class cls)
        {

            return GetConverter().GetClassUrl(cls);
        }

        /// <summary>
        /// 获取栏目地址
        /// </summary>
        /// <param name="cls"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public static string GetClassUrl(Class cls, int page)
        {
            return GetConverter().GetClassUrl(cls,page);
        }
        #endregion

        #region 获取上一篇文章、图片、提问
        /// <summary>
        /// 获取上一篇文章 
        /// </summary>
        /// <param name="news"></param>
        /// <param name="cls"></param>
        /// <returns></returns>
        public static News GetPreNews(News news, Class cls)
        {
            using (DataEntities ent = new DataEntities())
            {
                List<News> lresult = //NewsView.GetModelList(string.Format("classID={0} and ID<{1} order by ID Desc", cls.ID, news.ID), 1);
                    (from l in ent.News where l.ClassID == cls.ID && l.ID < news.ID orderby l.ID descending select l).ToList();
                if (lresult.Count == 0)
                {
                    return null;
                }
                else
                {
                    return lresult.First();
                }
            }
        }

        /// <summary>
        /// 获取上一个图片
        /// </summary>
        /// <param name="img"></param>
        /// <param name="cls"></param>
        /// <returns></returns>
        public static ImageAlbum GetPreImage(ImageAlbum img, Class cls)
        {
            using (DataEntities ent = new DataEntities())
            {
                List<ImageAlbum> lresult = //ImageAlbumView.GetModelList(string.Format("classID={0} and ID<{1} order by ID Desc", cls.ID, img.ID), 1);
                (from l in ent.ImageAlbum where l.ClassID == cls.ID && l.ID < img.ID orderby l.ID descending select l).ToList();
                if (lresult.Count == 0)
                {
                    return null;
                }
                else
                {
                    return lresult.First();
                }
            }
        }

        /// <summary>
        /// 获取上一篇提问
        /// </summary>
        /// <param name="qs"></param>
        /// <param name="cls"></param>
        /// <returns></returns>
        public static Question GetPreQuestion(Question qs, Class cls)
        {
            using (DataEntities ent = new DataEntities())
            {
                List<Question> lresult = //QuestionView.GetModelList(string.Format("classID={0} and ID<{1} order by ID Desc", cls.ID, qs.ID), 1);
                (from l in ent.Question where l.ClassID == qs.ID && l.ID < qs.ID orderby l.ID descending select l).ToList();
                if (lresult.Count == 0)
                {
                    return null;
                }
                else
                {
                    return lresult.First();
                }
            }
        }

        /// <summary>
        /// 获取上一本小说
        /// </summary>
        /// <param name="b"></param>
        /// <param name="cls"></param>
        /// <returns></returns>
        public static Book GetPreBook(Book b, Class cls)
        {
            using (DataEntities ent = new DataEntities())
            {
                List<Book> lresult = //BookView.GetModelList(string.Format("classID={0} and ID<{1} order by ID Desc", cls.ID, b.ID), 1);
                (from l in ent.Book where l.ClassID == cls.ID && l.ID < b.ID orderby l.ID descending select l).ToList();
                if (lresult.Count == 0)
                {
                    return null;
                }
                else
                {
                    return lresult.First();
                }
            }
        }

        /// <summary>
        /// 获取上一章节
        /// </summary>
        /// <param name="cp"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static BookChapter GetPreChapter(BookChapter cp, Book b)
        {
            using (DataEntities ent = new DataEntities())
            {
                List<BookChapter> lresult = //BookChapterView.GetModelList(string.Format("BookID={0} and ID<{1} order by ID Desc", b.ID, cp.ID), 1);
                (from l in ent.BookChapter where l.BookID == b.ID && l.ID < cp.ID orderby l.ID descending select l).ToList();
                if (lresult.Count == 0)
                {
                    return null;
                }
                else
                {
                    return lresult.First();
                }
            }
        }

        /// <summary>
        /// 获取快播上一集地址
        /// </summary>
        /// <param name="kuai"></param>
        /// <returns></returns>
        public static MovieUrlKuaib GetPreKuaibo(MovieUrlKuaib kuai)
        {
            using (DataEntities ent = new DataEntities())
            {
                List<MovieUrlKuaib> lresult = //MovieUrlKuaibView.GetModelList(string.Format("MovieID={0} and id<{1} order by id desc", kuai.MovieID, kuai.Id));
                (from l in ent.MovieUrlKuaib where l.MovieID == kuai.MovieID && l.id < kuai.id orderby l.id descending select l).ToList();
                if (lresult.Count == 0)
                {
                    return null;
                }
                else
                {
                    return lresult.First();
                }
            }
        }

        /// <summary>
        /// 获取百度上一集地址
        /// </summary>
        /// <param name="kuai"></param>
        /// <returns></returns>
        public static MovieUrlBaidu GetPreBaidu(MovieUrlBaidu kuai)
        {
            using (DataEntities ent = new DataEntities())
            {
                List<MovieUrlBaidu> lresult = //MovieUrlBaiduView.GetModelList(string.Format("MovieID={0} and id<{1} order by id desc", kuai.MovieID, kuai.Id));
                    (from l in ent.MovieUrlBaidu where l.MovieID == kuai.MovieID && l.id < kuai.id orderby l.id descending select l).ToList();
                if (lresult.Count == 0)
                {
                    return null;
                }
                else
                {
                    return lresult.First();
                }
            }
        }

        /// <summary>
        /// 获取上一个单集
        /// </summary>
        /// <param name="drama"></param>
        /// <returns></returns>
        public static MovieDrama GetPreDrama(MovieDrama drama)
        {
            using (DataEntities ent = new DataEntities())
            {
                List<MovieDrama> lresult = //MovieDramaView.GetModelList(string.Format("MovieID={0} and id<{1} order by id desc", drama.MovieID, drama.Id));
                (from l in ent.MovieDrama where l.MovieID == drama.MovieID && l.id < drama.id orderby l.id descending select l).ToList();
                if (lresult.Count == 0)
                {
                    return null;
                }
                else
                {
                    return lresult.First();
                }
            }
        }

        #endregion

        #region 获取下一篇文章、相册、提问
        /// <summary>
        /// 获取下一篇文章
        /// </summary>
        /// <param name="news"></param>
        /// <param name="cls"></param>
        /// <returns></returns>
        public static News GetNextNews(News news, Class cls)
        {
            using (DataEntities ent = new DataEntities())
            {
                List<News> lresult = //NewsView.GetModelList(string.Format("classID={0} and ID>{1} order by ID Asc", cls.ID, news.ID), 1);
                (from l in ent.News where l.ClassID == cls.ID && l.ID > news.ID orderby l.ID select l).ToList();
                if (lresult.Count == 0)
                {
                    return null;
                }
                else
                {
                    return lresult.First();
                }
            }
        }

        /// <summary>
        /// 获取下一个相册
        /// </summary>
        /// <param name="img"></param>
        /// <param name="cls"></param>
        /// <returns></returns>
        public static ImageAlbum GetNextImages(ImageAlbum img, Class cls)
        {
            using (DataEntities ent = new DataEntities())
            {
                List<ImageAlbum> lresult = //ImageAlbumView.GetModelList(string.Format("classID={0} and ID>{1} order by ID Asc", cls.ID, img.ID), 1);
                (from l in ent.ImageAlbum where l.ClassID == cls.ID && l.ID > img.ID orderby l.ID select l).ToList();
                if (lresult.Count == 0)
                {
                    return null;
                }
                else
                {
                    return lresult.First();
                }
            }
        }

        /// <summary>
        /// 获取下一个提问
        /// </summary>
        /// <param name="img"></param>
        /// <param name="cls"></param>
        /// <returns></returns>
        public static Question GetNextQuestion(Question qs, Class cls)
        {
            using (DataEntities ent = new DataEntities())
            {
                List<Question> lresult =// QuestionView.GetModelList(string.Format("classID={0} and ID>{1} order by ID Asc", cls.ID, qs.ID), 1);
                (from l in ent.Question where l.ClassID == cls.ID && l.ID > qs.ID orderby l.ID select l).ToList();
                if (lresult.Count == 0)
                {
                    return null;
                }
                else
                {
                    return lresult.First();
                }
            }
        }

        public static Book GetNextBook(Book b, Class cls)
        {
            using (DataEntities ent = new DataEntities())
            {
                List<Book> lresult = //BookView.GetModelList(string.Format("classID={0} and ID>{1} order by ID Asc", cls.ID, b.ID), 1);
                (from l in ent.Book where l.ClassID == cls.ID && l.ID > b.ID orderby l.ID select l).ToList();
                if (lresult.Count == 0)
                {
                    return null;
                }
                else
                {
                    return lresult.First();
                }
            }
        }

        /// <summary>
        /// 获取下一章节
        /// </summary>
        /// <param name="cp"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static BookChapter GetNextChapter(BookChapter cp, Book b)
        {
            using (DataEntities ent = new DataEntities())
            {
                List<BookChapter> lresult = //BookChapterView.GetModelList(string.Format("BookID={0} and ID>{1} order by ID Asc", b.ID, cp.ID), 1);
                (from l in ent.BookChapter where l.BookID == b.ID && l.ID > cp.ID orderby l.ID select l).ToList();
                if (lresult.Count == 0)
                {
                    return null;
                }
                else
                {
                    return lresult.First();
                }
            }
        }


        /// <summary>
        /// 获取快播下一集地址
        /// </summary>
        /// <param name="kuai"></param>
        /// <returns></returns>
        public static MovieUrlKuaib GetNextKuaibo(MovieUrlKuaib kuai)
        {
            if (kuai == null)
            {
                return new MovieUrlKuaib() { id = int.MinValue };
            }
            using (DataEntities ent = new DataEntities())
            {
                List<MovieUrlKuaib> lresult = //MovieUrlKuaibView.GetModelList(string.Format("MovieID={0} and id>{1} order by id asc", kuai.MovieID, kuai.Id));
                (from l in ent.MovieUrlKuaib where l.MovieID == kuai.MovieID && l.id > kuai.id orderby l.id select l).ToList();
                if (lresult.Count == 0)
                {
                    return null;
                }
                else
                {
                    return lresult.First();
                }
            }
        }

        /// <summary>
        /// 获取百度下一集地址
        /// </summary>
        /// <param name="kuai"></param>
        /// <returns></returns>
        public static MovieUrlBaidu GetNextBaidu(MovieUrlBaidu kuai)
        {
            using (DataEntities ent = new DataEntities())
            {
                List<MovieUrlBaidu> lresult = //MovieUrlBaiduView.GetModelList(string.Format("MovieID={0} and id>{1} order by id asc", kuai.MovieID, kuai.Id));
                (from l in ent.MovieUrlBaidu where l.MovieID == kuai.MovieID && l.id > kuai.id orderby l.id select l).ToList();
                if (lresult.Count == 0)
                {
                    return null;
                }
                else
                {
                    return lresult.First();
                }
            }
        }

        /// <summary>
        /// 获取下一个单集
        /// </summary>
        /// <param name="drama"></param>
        /// <returns></returns>
        public static MovieDrama GetNextDrama(MovieDrama drama)
        {
            using (DataEntities ent = new DataEntities())
            {
                List<MovieDrama> lresult = //MovieDramaView.GetModelList(string.Format("MovieID={0} and id>{1} order by id asc", drama.MovieID, drama.Id));
                (from l in ent.MovieDrama where l.MovieID == drama.MovieID && l.id > drama.id orderby l.id select l).ToList();
                if (lresult.Count == 0)
                {
                    return null;
                }
                else
                {
                    return lresult.First();
                }
            }
        }

        #endregion

        #region 获取产品地址
        public static string GetProductUrl(Product p, Class cls)
        {
            return GetConverter().GetProductUrl(p, cls);
        }
        #endregion

        #region 上传文件
        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="file"></param>
        /// <param name="ClassID"></param>
        /// <returns></returns>
        public static Result UpLoadFile(HttpPostedFile file, int ClassID)
        {
            Result r = new Result();
            SysSetting ss = BasePage.SystemSetting;

            string FileName = file.FileName.GetFileNameFromPath();//文件名
            string ExtName = file.FileName.GetFileExtNameFromPath();//扩展名
            string NewName = @string.GetGuid() + ExtName;//新文件名

            if (!ExtName.Replace(".", "").IsInArray(ss.FileExtNameFilter.Split(',')))
            {
                r.Success = false;
                r.Text = "不允许上传此类文件";
                return r;
            }
            if (file.ContentLength > ss.MaxPostFileSize)
            {
                r.Success = false;
                r.Text = "文件太大";
                return r;
            }

            string Folder = ss.FileDir + "/" + DateTime.Now.ToString("yyyy-MM-dd") + "/";//文件目录
            string FolderShotCut = Folder + "ShortCut/";//缩略图目录

            string FilePath = Folder + NewName;//文件路径
            string FilePath_ShortCut = FolderShotCut + NewName;//缩略图路径

            file.SaveAs(System.Web.HttpContext.Current.Server.MapPath(FilePath), true);

            File f = new File();

            if (ExtName.ToLower().Replace(".", "").IsInArray("jpg,jpeg,png,gif,bmp".Split(',')))
            {
                ImageHelper.MakeThumbnail(System.Web.HttpContext.Current.Server.MapPath(FilePath), System.Web.HttpContext.Current.Server.MapPath(FilePath_ShortCut), 105, 118, "Cut");
            }
            else
            {
                FilePath_ShortCut = "";
                f.FileType = 1;
            }
            FileInfo savedFile = new FileInfo(System.Web.HttpContext.Current.Server.MapPath(FilePath));



            f.FileDirectory = ss.FileDir;
            f.FileExtName = ExtName;
            f.FilePath = FilePath;
            f.FileSize = (savedFile.Length / 1024).ToInt32();
            //f.FileType=
            f.SmallPath = FilePath_ShortCut;
            f.UpTime = DateTime.Now;

            using (DataEntities ent = new DataEntities())
            {
                ent.AddToFile(f);
                ent.SaveChanges();
            }
            //FileView.Insert(f);

            r.Success = true;
            r.Text = FilePath;
            return r;
        }

        public static Result UpLoadFile(HttpPostedFile file, string Path)
        {
            FileInfo local_file = new FileInfo(System.Web.HttpContext.Current.Server.MapPath(Path));
            if (local_file.Exists)
            {
                local_file.Delete();
            }

            file.SaveAs(System.Web.HttpContext.Current.Server.MapPath(Path), true);

            return new Result() { Success = true, Text = Path };
        }

        /// <summary>
        /// 上传并且裁剪图片
        /// </summary>
        /// <param name="file">文件内容</param>
        /// <param name="PathWithName">文件路径（相对）</param>
        /// <param name="width">保留宽度</param>
        /// <param name="height">保留高度</param>
        /// <returns></returns>
        public static Result UpLoadImage(HttpPostedFile file, string PathWithName, int width, int height)
        {
            Result r = new Result();
            try
            {
                file.SaveAs(System.Web.HttpContext.Current.Server.MapPath("~/u/tmp.jpg"), true);
                if (width > 0 && height > 0)
                {
                    ImageHelper.MakeThumbnail(System.Web.HttpContext.Current.Server.MapPath("~/u/tmp.jpg"), System.Web.HttpContext.Current.Server.MapPath(PathWithName), width, height, "Cut");
                }
                else
                {
                    Voodoo.IO.File.Move(System.Web.HttpContext.Current.Server.MapPath("~/u/tmp.jpg"), System.Web.HttpContext.Current.Server.MapPath(PathWithName));
                }
                r.Success = true;
                r.Text = PathWithName;
            }
            catch (Exception ex)
            {
                r.Success = false;
                r.Text = ex.Message;
            }

            return r;

        }
        #endregion

        #region 创建系统关键词
        /// <summary>
        /// 创建系统关键词
        /// </summary>
        /// <param name="ModelID"></param>
        /// <param name="key"></param>
        public static void InsertKeyWords(int ModelID, string key)
        {
            using (DataEntities ent = new DataEntities())
            {
                var ks = //SysKeywordView.Find(string.Format("ModelID={0} and Keyword=N'{1}'", ModelID, key));
                    (from l in ent.SysKeyword where l.ModelID == ModelID && l.Keyword == key select l).ToList();
                if (ks.Count == 0)
                {
                    //不存在
                    SysKeyword k = new SysKeyword();
                    k.ModelID = ModelID;
                    k.Keyword = key;
                    k.ClickCount = 0;
                    ent.AddToSysKeyword(k);
                }
                else
                {
                    SysKeyword k = ks.FirstOrDefault();
                    k.ClickCount++;

                }
                ks.FirstOrDefault().ClearListCache();
                ent.SaveChanges();
            }
        }

        #endregion

        #region 生成随机背景颜色
        /// <summary>
        /// 生成随机背景颜色
        /// </summary>
        /// <returns></returns>
        public static string RandomBGColor()
        {
            string[] str = new string[] { "#DDD", 
                "RGB(164,200,264)",
                "rgb(254,204,68)",
                "rgb(55,149,210)",
                "rgb(167,190,14)",
                "rgb(255,175,53)",
                "rgb(92,192,205)",
                "rgb(195,195,195)",
                "rgb(239,139,112)",
                "rgb(153,198,35)",
                "rgb(170,106,173)",
                "rgb(242,181,31)"
            };

            return str[@int.GetRandomNumber(0, str.Length - 1)];
        }
        #endregion 生成随机背景颜色

        #region Ping搜索引擎
        /// <summary>
        /// Ping搜索引擎
        /// </summary>
        /// <param name="url">url地址（带域名）</param>
        public static void PingSE(string url)
        {
            var ses = SystemSetting.PingAddress.Split('\n');
            foreach (var se in ses)
            {
                try
                {
                    var proxy = XmlRpcProxyGen.Create<IMath>();
                    proxy.Url = se.Trim();

                    proxy.ping(SystemSetting.SiteName, SystemSetting.SiteUrl, url, SystemSetting.SiteUrl + "rss.aspx");
                }
                catch { }
            }
        }
        #endregion

        #region 从source文件中分析剧集
        /// <summary>
        /// 从source文件中分析剧集
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public List<Drama> CollectDramas(string source, int Movieid)
        {
            using (DataEntities ent = new DataEntities())
            {
                MovieInfo mv = //MovieInfoView.GetModelByID(Movieid.ToS());
                    (from l in ent.MovieInfo where l.id == Movieid select l).FirstOrDefault();

                var result = new List<Drama>();
                source = source.UrlDecode().AsciiToNative();

                List<string> tmp = new List<string>();
                Match m = new Regex("((bdhd://)|(qvod://)).*?((.rmvb)|(.rm)|(.avi)|(.mp4)|(.asf)|(.wmv))+").Match(source);
                while (m.Success)
                {
                    string str = m.Groups["0"].Value;
                    tmp.Add(str);
                    m = m.NextMatch();
                }

                foreach (string str in tmp)
                {
                    try
                    {
                        result.Add(new Drama()
                        {
                            Title = str.Split('|')[2].GetMatchGroup("[0-9]+").Groups[0].Value.IsNull(str.Split('|')[2].ToLower().Replace(".rmvb", "").Replace(".rm", "").Replace(".avi", "").Replace(".mp4", "").Replace(".asf", "").Replace(".wmv", "").Replace(" ", "").Replace(".", "")),
                            Url = str,
                            Type = str.StartsWith("bdhd") ? "baidu" : "qvod"
                        });
                    }
                    catch { }
                }


                return result;
            }
        }
        #endregion

        protected void SaveDramas(int MovieID, List<Drama> dramas)
        {
            if (dramas.Count == 0)
            {
                return;
            }

            using (DataEntities ent = new DataEntities())
            {
                MovieInfo mv = //MovieInfoView.GetModelByID(MovieID.ToS());
                    (from l in ent.MovieInfo where l.id == MovieID select l).FirstOrDefault();

                List<MovieUrlBaidu> baidus = new List<MovieUrlBaidu>();
                List<MovieUrlKuaib> kuaibos = new List<MovieUrlKuaib>();

                if (dramas[0].Type == "baidu")
                {
                    baidus = //MovieUrlBaiduView.GetModelList(string.Format("movieid={0}", MovieID));
                        (from l in ent.MovieUrlBaidu where l.MovieID == MovieID select l).ToList();

                    foreach (var drama in dramas)
                    {
                        if (baidus.Where(p => p.Title == drama.Title).Count() == 0)
                        {
                            MovieUrlBaidu m = new MovieUrlBaidu();
                            m.Enable = true;
                            m.MovieID = mv.id;
                            m.MovieTitle = mv.Title;
                            m.Title = drama.Title;
                            m.UpdateTime = DateTime.UtcNow.AddHours(8);
                            m.Url = drama.Url;
                            ent.AddToMovieUrlBaidu(m);

                        }
                    }
                }
                else
                {
                    kuaibos = //MovieUrlKuaibView.GetModelList(string.Format("movieid={0}", MovieID));
                         (from l in ent.MovieUrlKuaib where l.MovieID == MovieID select l).ToList();
                    foreach (var drama in dramas)
                    {
                        if (kuaibos.Where(p => p.Title == drama.Title).Count() == 0)
                        {
                            MovieUrlKuaib m = new MovieUrlKuaib();
                            m.Enable = true;
                            m.MovieID = mv.id;
                            m.MovieTitle = mv.Title;
                            m.Title = drama.Title;
                            m.UpdateTime = DateTime.UtcNow.AddHours(8);
                            m.Url = drama.Url;
                            ent.AddToMovieUrlKuaib(m);

                        }
                    }
                }
                ent.SaveChanges();
            }
        }
    }

    public interface IMath : IXmlRpcProxy
    {
        [XmlRpcMethod("weblogUpdates.ping")]
        CookComputing.XmlRpc.XmlRpcStruct ping(string a, string b, string c, string d);
    }
}
