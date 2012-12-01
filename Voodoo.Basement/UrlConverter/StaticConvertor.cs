using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Voodoo;
using System.Text.RegularExpressions;

namespace Voodoo.Basement.UrlConverter
{
    public class StaticConvertor : IConverter
    {
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

        #region 获取信息地址
        /// <summary>
        /// 获取信息地址
        /// </summary>
        /// <param name="news">信息</param>
        /// <param name="cls">栏目</param>
        /// <returns></returns>
        public string GetNewsUrl(News news, Class cls)
        {

            string result = "";
            if (news.NavUrl.Length > 0) //如果是外部链接
            {
                result = news.NavUrl;
            }
            else
            {
                //网站地址 栏目父目录 栏目目录 文件目录 文件名 扩展名

                string fileName = news.FileName;
                if (news.FileName.IsNullOrEmpty())
                {
                    fileName = news.ID.ToString();//此处需要修改
                }

                string sitrurl = "/";

                string parentForder = cls.ClassForder;
                if (!parentForder.IsNullOrEmpty())
                {
                    parentForder += "/";
                }
                string newsFolder = news.FileForder;
                if (!newsFolder.IsNullOrEmpty())
                {
                    newsFolder += "/";
                }

                result = string.Format("{0}{1}{2}/{3}{4}{5}",
                    sitrurl,
                    cls.ParentClassForder.IsNullOrEmpty() ? "" : cls.ParentClassForder + "/",
                    cls.ClassForder,
                    newsFolder,
                    fileName,
                    BasePage.SystemSetting.ExtName
                    );
                result = Regex.Replace(result, "[/]{2,}", "/");
            }


            return result;
        }
        #endregion

        private string TitleFilter(string Title)
        {
            return Title.ChinaseUrlEncode();

        }

        #region 获取图片内容页面地址 GetImageUrl
        /// <summary>
        /// 获取图片内容页面地址
        /// </summary>
        /// <param name="img"></param>
        /// <param name="cls"></param>
        /// <returns></returns>
        public string GetImageUrl(ImageAlbum img, Class cls)
        {
            string result = "";
            string fileName = img.ID.ToString();


            string sitrurl = "/";

            string parentForder = cls.ClassForder;
            if (!parentForder.IsNullOrEmpty())
            {
                parentForder += "/";
            }
            string newsFolder = img.Folder;
            if (newsFolder.IsNullOrEmpty())
            {
                newsFolder = "/";
            }

            result = string.Format("{0}{1}{2}/{3}/{4}{5}",
                sitrurl,
                cls.ParentClassForder.IsNullOrEmpty() ? "" : cls.ParentClassForder + "/",
                cls.ClassForder,
                newsFolder,
                fileName,
                BasePage.SystemSetting.ExtName
                );
            result = Regex.Replace(result, "[/]{2,}", "/");
            return result;
        }
        #endregion

        #region 获取问答url地址
        /// <summary>
        /// 获取问答url地址
        /// </summary>
        /// <param name="qs"></param>
        /// <param name="cls"></param>
        /// <returns></returns>
        public string GetQuestionUrl(Question qs, Class cls)
        {
            string result = "";
            string fileName = qs.ID.ToString();


            string sitrurl = "/";

            string parentForder = cls.ClassForder;
            if (!parentForder.IsNullOrEmpty())
            {
                parentForder += "/";
            }


            result = string.Format("{0}{1}{2}/{3}{4}",
                sitrurl,
                cls.ParentClassForder.IsNullOrEmpty() ? "" : cls.ParentClassForder + "/",
                cls.ClassForder,
                fileName,
                BasePage.SystemSetting.ExtName
                );
            result = Regex.Replace(result, "[/]{2,}", "/");
            return result;
        }
        #endregion

        #region 获取书籍url地址
        /// <summary>
        /// 获取问答url地址
        /// </summary>
        /// <param name="qs"></param>
        /// <param name="cls"></param>
        /// <returns></returns>
        public string GetBookUrl(Book b, Class cls)
        {
            string result = "";
            string fileName = b.Title + "-" + b.Author;//书名+作者


            string sitrurl = "/Book/";

            //string parentForder = cls.ClassForder;
            //if (!parentForder.IsNullOrEmpty())
            //{
            //    parentForder += "/";
            //}


            result = string.Format("{0}{1}/{2}/index{3}",
                sitrurl,
                //cls.ParentClassForder.IsNullOrEmpty() ? "" : cls.ParentClassForder + "/",
                cls.ClassForder,
                fileName,
                BasePage.SystemSetting.ExtName
                );
            result = Regex.Replace(result, "[/]{2,}", "/");
            return result;
        }
        #endregion

        #region 获取书籍章节url地址
        /// <summary>
        /// 获取问答url地址
        /// </summary>
        /// <param name="qs"></param>
        /// <param name="cls"></param>
        /// <returns></returns>
        public string GetBookChapterUrl(BookChapter cp, Class cls)
        {
            DataEntities ent = new DataEntities();

            string result = "";
            string fileName = cp.ID.ToString();

            Book b = (from l in ent.Book where l.ID == cp.BookID select l).FirstOrDefault();


            string sitrurl = "/Book/";

            result = string.Format("{0}{1}/{2}/{3}{4}",
                sitrurl,
                cls.ClassForder,
                 b.Title + "-" + b.Author,
                cp.ID,
                BasePage.SystemSetting.ExtName
                );
            result = Regex.Replace(result, "[/]{2,}", "/");
            return result;
        }

        /// <summary>
        /// 获取章节txt文件路径
        /// </summary>
        /// <param name="cp"></param>
        /// <param name="cls"></param>
        /// <returns></returns>
        public string GetBookChapterTxtUrl(BookChapter cp, Class cls)
        {
            return cp.TxtPath;
        }
        #endregion

        #region 获取影视地址
        /// <summary>
        /// 获取影视地址
        /// </summary>
        /// <param name="qs"></param>
        /// <param name="cls"></param>
        /// <returns></returns>
        public string GetMovieUrl(MovieInfo b, Class cls)
        {
            string result = "";
            string fileName = TitleFilter(b.Title);


            string sitrurl = "/Movie/";


            result = string.Format("{0}{1}/{2}/index{3}",
                sitrurl,
                cls.ClassForder,
                fileName,
                BasePage.SystemSetting.ExtName
                );

            result = Regex.Replace(result, "[/]{2,}", "/");
            result = result.Replace(":", "_");
            result = result.Replace(">", "");
            result = result.Replace("<", "");
            result = result.Replace("*", "");
            result = result.Replace("?", "");
            result = result.Replace("|", "_");
            return result;
        }
        #endregion

        #region 获取影视播放页面地址
        /// <summary>
        /// 获取影视地址
        /// </summary>
        /// <param name="qs"></param>
        /// <param name="cls"></param>
        /// <returns></returns>
        public string GetMovieDramaUrl(MovieUrlBaidu b, Class cls)
        {
            if (b == null)
            {
                return "";
            }
            string result = "";


            string sitrurl = "/Movie/";


            result = string.Format("{0}{1}/{2}/Baidu/{3}{4}",
                sitrurl,
                cls.ClassForder,
                TitleFilter(b.MovieTitle),
                b.id,
                BasePage.SystemSetting.ExtName
                );
            result = Regex.Replace(result, "[/]{2,}", "/");
            result = result.Replace(":", "_");
            result = result.Replace(">", "");
            result = result.Replace("<", "");
            result = result.Replace("*", "");
            result = result.Replace("?", "");
            result = result.Replace("|", "_");
            return result;
        }

        public string GetMovieDramaUrl(MovieUrlKuaib b, Class cls)
        {
            if (b == null)
            {
                return "";
            }
            using (DataEntities ent = new DataEntities())
            {
                MovieInfo movie = (from l in ent.MovieInfo where l.id == b.MovieID select l).FirstOrDefault();

                string result = "";


                string sitrurl = "/Movie/";


                result = string.Format("{0}{1}/{2}/Kuaib/{3}{4}",
                    sitrurl,
                    cls.ClassForder,
                    TitleFilter(movie.Title.Replace("/", "_")),
                    b.id,
                    BasePage.SystemSetting.ExtName
                    );
                result = Regex.Replace(result, "[/]{2,}", "/");
                result = result.Replace(":", "_");
                result = result.Replace(">", "");
                result = result.Replace("<", "");
                result = result.Replace("*", "");
                result = result.Replace("?", "");
                result = result.Replace("|", "_");
                return result;
            }
        }

        public string GetMovieDramaUrl(MovieDrama b, Class cls)
        {
            if (b == null)
            {
                return "";
            }
            string result = "";


            string sitrurl = "/Movie/";


            result = string.Format("{0}{1}/{2}/urls/{3}{4}",
                sitrurl,
                cls.ClassForder,
                TitleFilter(b.MovieTitle),
                b.id,
                BasePage.SystemSetting.ExtName
                );
            result = Regex.Replace(result, "[/]{2,}", "/");
            result = result.Replace(":", "_");
            result = result.Replace(">", "");
            result = result.Replace("<", "");
            result = result.Replace("*", "");
            result = result.Replace("?", "");
            result = result.Replace("|", "_");
            return result;
        }

        #endregion

        #region 获取产品地址
        public string GetProductUrl(Product p, Class cls)
        {
            return string.Format("/Product/{0}{1}", p.ID, BasePage.SystemSetting.ExtName);
        }
        #endregion


        #region 获取栏目地址
        /// <summary>
        /// 获取栏目地址
        /// </summary>
        /// <param name="cls">栏目</param>
        /// <returns></returns>
        public string GetClassUrl(Class cls)
        {

            string sitrurl = BasePage.SystemSetting.ClassFolder;
            if (sitrurl.IsNullOrEmpty())
            {
                sitrurl = "/Book";
            }
            string result = string.Format("{0}/{1}/index{2}",
                sitrurl,
                cls.ClassForder,
                SystemSetting.ExtName
                );

            result = Regex.Replace(result, "[/]{2,}", "/");
            return result;
        }

        /// <summary>
        /// 获取栏目地址
        /// </summary>
        /// <param name="cls"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public string GetClassUrl(Class cls, int page)
        {

            string sitrurl = BasePage.SystemSetting.ClassFolder;
            if (sitrurl.IsNullOrEmpty())
            {
                sitrurl = "/Book";
            }
            return string.Format("{0}/{1}/index{2}",
                sitrurl,
                cls.ClassForder,
                page > 1 ? "_" + page.ToS() + SystemSetting.ExtName : SystemSetting.ExtName
                );
        }
        #endregion


    }
}
