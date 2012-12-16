using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

using Voodoo.Basement.Routing;

namespace Voodoo.Basement.UrlConverter
{
    public class DynamicConverter : IConverter
    {
        #region 获取信息地址
        /// <summary>
        /// 获取信息地址
        /// </summary>
        /// <param name="news">信息</param>
        /// <param name="cls">栏目</param>
        /// <returns></returns>
        public string GetNewsUrl(News news, Class cls)
        {
            if (BasePage.SystemSetting.EnableReWrite)
            {
                string url = RewriteRule.Get().NewsPage.Exp;
                url = url.Replace("{newsid}", news.ID.ToS());
                return url;
            }
            else
            {
                return string.Format("/Dynamic/News/News.aspx?id={0}", news.ID);
            }
        }
        #endregion


        #region 获取图片内容页面地址 GetImageUrl
        /// <summary>
        /// 获取图片内容页面地址
        /// </summary>
        /// <param name="img"></param>
        /// <param name="cls"></param>
        /// <returns></returns>
        public string GetImageUrl(ImageAlbum img, Class cls)
        {
            return string.Format("/Dynamic/Image/Image.aspx?id={0}", img.ID);
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

            return string.Format("/Dynamic/Question/Question.aspx?id={0}", qs.ID);
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
            string url = RewriteRule.Get().BookInfo.Exp;
            url = url.Replace("{id}", b.ID.ToS());
            url = url.Replace("{classname}", b.ClassName);
            url = url.Replace("{title}", b.Title);
            url = url.Replace("{author}", b.Author);

            return url;
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
            if (cp == null || cp.ID < 0)
            {
                return "";
            }
            string url = RewriteRule.Get().BookChapter.Exp;
            url = url.Replace("{id}", cp.ID.ToS());
            url = url.Replace("{classname}", cls.ClassName);
            url = url.Replace("{title}", cp.BookTitle);
            url = url.Replace("{author}", cp.GetBook().Title);

            return url;
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
            return string.Format("/Dynamic/Movie/?a=content&id={0}", b.id);
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
            return string.Format("/Dynamic/Movie/?a=baidu&id={0}", b.id);
        }

        public string GetMovieDramaUrl(MovieUrlKuaib b, Class cls)
        {
            return string.Format("/Dynamic/Movie/?a=kuaib&id={0}", b.id);
        }

        public string GetMovieDramaUrl(MovieDrama b, Class cls)
        {
            return string.Format("/Dynamic/Movie/?a=drama&id={0}", b.id);
        }

        #endregion

        #region 获取产品地址
        public string GetProductUrl(Product p, Class cls)
        {
            return string.Format("/Dynamic/Product/?id={0}", p.ID);
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
            string url = "";
            if (BasePage.SystemSetting.EnableReWrite)
            {
                switch (cls.ModelID)
                {
                    case 1:
                        url = RewriteRule.Get().NewsClass.Exp;
                        break;
                    case 4:
                        url = RewriteRule.Get().BookClass.Exp;
                        break;
                    case 7:
                        url = RewriteRule.Get().ProductList.Exp;
                        break;
                    default:
                        url = string.Format("/Dynamic/Book/Class.aspx?id={0}", cls.ID);
                        break;
                }
                url = url.Replace("{id}", cls.ID.ToS());
                url = url.Replace("{classname}", cls.ClassName);
                url = url.Replace("{page}", "1");
            }
            else
            {
                url = string.Format("/Dynamic/Book/Class.aspx?id={0}", cls.ID);
            }
            return url;
        }

        /// <summary>
        /// 获取栏目地址
        /// </summary>
        /// <param name="cls"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public string GetClassUrl(Class cls, int page)
        {
            string url = "";
            if (BasePage.SystemSetting.EnableReWrite)
            {
                switch (cls.ModelID)
                {
                    case 1:
                        url = RewriteRule.Get().NewsClass.Exp;
                        break;
                    case 4:
                        url = RewriteRule.Get().BookClass.Exp;
                        break;
                    case 7:
                        url = RewriteRule.Get().ProductList.Exp;
                        break;
                    default:
                        url = string.Format("/Dynamic/Book/Class.aspx?id={0}&page={1}", cls.ID, page);
                        break;
                }
                url = url.Replace("{id}", cls.ID.ToS());
                url = url.Replace("{classname}", cls.ClassName);
                url = url.Replace("{page}", page.ToS());
            }
            else
            {
                url= string.Format("/Dynamic/Book/Class.aspx?id={0}&page={1}", cls.ID, page);
            }
            return url;
        }
        #endregion
    }
}
