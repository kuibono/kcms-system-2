using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Voodoo;
using Voodoo.Security;
using Voodoo.IO;

using System.Reflection;
using System.Text.RegularExpressions;

namespace Voodoo.Basement
{
    public class CreatePage
    {

        private static void ping(string str)
        {
            if (BasePage.SystemSetting.EnablePing)
            {
                BasePage.PingSE(str);
            }
        }

        #region  创建首页
        /// <summary>
        /// 创建首页
        /// </summary>
        /// <returns></returns>
        public static void GreateIndexPage()
        {
            TemplateHelper h = new TemplateHelper();
            SysSetting setting = BasePage.SystemSetting;
            string IndexFile = "~/" + setting.ClassFolder + "/index" + setting.ExtName;


            Voodoo.IO.File.Write(System.Web.HttpContext.Current.Server.MapPath(IndexFile), h.GetIndex());

            ping(BasePage.SystemSetting.SiteUrl);

            CreatePagesByCrateWith(1);
        }
        #endregion

        #region 生成静态页面
        /// <summary>
        /// 生成静态页面
        /// </summary>
        /// <param name="id">模板ID</param>
        public static void CreatePages(TemplatePage tp)
        {

            string FilePath = System.Web.HttpContext.Current.Server.MapPath(tp.FileName);

            TemplateHelper h = new TemplateHelper();
            Voodoo.IO.File.Write(FilePath, h.GetStatisPage(tp.id));

            ping(BasePage.SystemSetting.SiteUrl + tp.FileName);
        }

        /// <summary>
        /// 根据条件生成静态页面
        /// </summary>
        /// <param name="CreateWith">0不生成 1首页 2列表 3内容 4章节、播放、图片等内页</param>
        public static void CreatePagesByCrateWith(int CreateWith)
        {
            DataEntities ent = new DataEntities();

            var tps = (from l in ent.TemplatePage where l.CreateWith == CreateWith select l).ToList();
            ent.Dispose();

            foreach (var tp in tps)
            {
                CreatePages(tp);
            }

        }
        #endregion

        #region 生成内容页--新闻
        /// <summary>
        /// 生成内容页
        /// </summary>
        /// <param name="news"></param>
        /// <param name="cls"></param>
        public static void CreateContentPage(News news, Class cls)
        {
            TemplateHelper h = new TemplateHelper();
            string FileName = BasePage.GetNewsUrl(news, cls);

            Voodoo.IO.File.Write(System.Web.HttpContext.Current.Server.MapPath("~" + FileName), h.CreateContentPage(news, cls));
            ping(BasePage.SystemSetting.SiteUrl.TrimEnd('/') + FileName);
            CreatePagesByCrateWith(3);
        }
        #endregion

        #region  生成内容页--相册
        /// <summary>
        /// 生成内容页--图片
        /// </summary>
        /// <param name="album"></param>
        /// <param name="cls"></param>
        public static void CreateContentPage(ImageAlbum album, Class cls)
        {
            TemplateHelper h = new TemplateHelper();
            string FileName = BasePage.GetImageUrl(album, cls);

            Voodoo.IO.File.Write(System.Web.HttpContext.Current.Server.MapPath("~" + FileName), h.CreateContentPage(album, cls));
            ping(BasePage.SystemSetting.SiteUrl.TrimEnd('/') + FileName);

            CreatePagesByCrateWith(3);
        }
        #endregion

        #region  生成内容页--问答
        /// <summary>
        /// 生成内容页--图片
        /// </summary>
        /// <param name="album"></param>
        /// <param name="cls"></param>
        public static void CreateContentPage(Question qs, Class cls)
        {
            TemplateHelper h = new TemplateHelper();
            string FileName = BasePage.GetQuestionUrl(qs, cls);

            Voodoo.IO.File.Write(System.Web.HttpContext.Current.Server.MapPath("~" + FileName), h.CreateContentPage(qs, cls));
            ping(BasePage.SystemSetting.SiteUrl.TrimEnd('/') + FileName);
            CreatePagesByCrateWith(3);
        }
        #endregion

        #region  生成内容页--影视
        /// <summary>
        /// 生成内容页--影视
        /// </summary>
        /// <param name="album"></param>
        /// <param name="cls"></param>
        public static void CreateContentPage(MovieInfo movie, Class cls)
        {
            TemplateHelper h = new TemplateHelper();
            string FileName = BasePage.GetMovieUrl(movie, cls);

            Voodoo.IO.File.Write(System.Web.HttpContext.Current.Server.MapPath("~" + FileName), h.CreateContentPage(movie, cls));

            ping(BasePage.SystemSetting.SiteUrl.TrimEnd('/') + FileName);
            CreatePagesByCrateWith(3);
        }
        #endregion

        #region  生成内容页--书籍
        /// <summary>
        /// 生成内容页--图片
        /// </summary>
        /// <param name="album"></param>
        /// <param name="cls"></param>
        public static void CreateContentPage(Book b, Class cls)
        {
            TemplateHelper h = new TemplateHelper();
            string FileName = BasePage.GetBookUrl(b, cls);
            Voodoo.IO.File.Write(System.Web.HttpContext.Current.Server.MapPath("~" + FileName), h.CreateContentPage(b, cls));

            ping(BasePage.SystemSetting.SiteUrl.TrimEnd('/') + FileName);

            CreatePagesByCrateWith(3);
        }
        #endregion


        #region 生成播放页面--快播
        /// <summary>
        /// 生成播放页面--快播
        /// </summary>
        /// <param name="kuaib">快播地址</param>
        /// <param name="cls">分类</param>
        public static void CreateDramapage(MovieUrlKuaib kuaib, Class cls)
        {
            TemplateHelper h = new TemplateHelper();
            string FileName = BasePage.GetMovieDramaUrl(kuaib, cls);

            Voodoo.IO.File.Write(System.Web.HttpContext.Current.Server.MapPath("~" + FileName), h.CreateDramapage(kuaib, cls));
            ping(BasePage.SystemSetting.SiteUrl.TrimEnd('/') + FileName);
            CreatePagesByCrateWith(4);
        }
        #endregion 生成播放页面--快播

        #region 生成播放页面--百度
        /// <summary>
        /// 生成播放页面--快播
        /// </summary>
        /// <param name="kuaib">百度影音地址</param>
        /// <param name="cls">分类</param>
        public static void CreateDramapage(MovieUrlBaidu kuaib, Class cls)
        {
            TemplateHelper h = new TemplateHelper();
            string FileName = BasePage.GetMovieDramaUrl(kuaib, cls);


            Voodoo.IO.File.Write(System.Web.HttpContext.Current.Server.MapPath("~" + FileName), h.CreateDramapage(kuaib, cls));
            ping(BasePage.SystemSetting.SiteUrl.TrimEnd('/') + FileName);
            CreatePagesByCrateWith(4);
        }
        #endregion 生成播放页面--快播

        #region 生成播放页面--单集列表页面
        /// <summary>
        /// 生成播放页面--单集列表页面
        /// </summary>
        /// <param name="kuaib">百度影音地址</param>
        /// <param name="cls">分类</param>
        public static void CreateDramapage(MovieDrama drama, Class cls)
        {
            TemplateHelper h = new TemplateHelper();
            string FileName = BasePage.GetMovieDramaUrl(drama, cls);

            Voodoo.IO.File.Write(System.Web.HttpContext.Current.Server.MapPath("~" + FileName), h.CreateDramapage(drama, cls));
            ping(BasePage.SystemSetting.SiteUrl.TrimEnd('/') + FileName);
            CreatePagesByCrateWith(4);
        }
        #endregion 生成播放页面--单集列表页面



        #region  创建章节页面
        /// <summary>
        /// 创建章节页面
        /// </summary>
        /// <param name="cp"></param>
        /// <param name="b"></param>
        /// <param name="cls"></param>
        public static void CreateBookChapterPage(BookChapter cp, Book b, Class cls)
        {
            TemplateHelper h = new TemplateHelper();
            string FileName = BasePage.GetBookChapterUrl(cp, cls);

            Voodoo.IO.File.Write(System.Web.HttpContext.Current.Server.MapPath("~" + FileName), h.CreateBookChapterPage(cp, b, cls));
            ping(BasePage.SystemSetting.SiteUrl.TrimEnd('/') + FileName);
            CreatePagesByCrateWith(4);
        }
        #endregion


        #region 创建列表页面
        /// <summary>
        /// 创建列表页面
        /// </summary>
        /// <param name="c"></param>
        /// <param name="page"></param>
        public static void CreateListPage(Class c, int page)
        {
            CreateListPage(c, page, true);
        }

        public static void CreateListPage(Class c, int page, bool AutoCreateNext)
        {
            TemplateHelper h = new TemplateHelper();
            TemplateList temp = h.GetListTemplate(c);
            int recordCount = c.CountItem();
            int pagecount = (Convert.ToDouble(recordCount) / Convert.ToDouble(temp.ShowRecordCount)).YueShu();


            string Content = h.CreateListPage(c, page);

            string FileName = BasePage.GetClassUrl(c, page);
            Voodoo.IO.File.Write(System.Web.HttpContext.Current.Server.MapPath("~" + FileName), Content);

            ping(BasePage.SystemSetting.SiteUrl.TrimEnd('/') + FileName);

            //下一页链接
            if (pagecount > page && AutoCreateNext)
            {
                CreateListPage(c, page + 1);
            }
            if (page == 1)
            {
                CreatePagesByCrateWith(2);
            }
        }
        #endregion


        #region 搜索页面
        /// <summary>
        /// 搜索页面
        /// </summary>
        /// <param name="SysModel"></param>
        /// <param name="page"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetSearchResult(int SysModel, int page, string key)
        {
            TemplateHelper h = new TemplateHelper();
            return h.GetSearchResult(SysModel, page, key);

        }
        public static string GetSearchResult(string m_where, int SysModel, int page, string searchword)
        {
            TemplateHelper h = new TemplateHelper();
            return h.GetSearchResult(m_where, SysModel, page, searchword);

        }
        #endregion

    }
}
