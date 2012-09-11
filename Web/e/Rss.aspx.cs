using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Voodoo;
using Voodoo.Basement;

namespace Web.e
{
    public partial class Rss : Voodoo.Basement.BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataEntities ent = new DataEntities();

            var chapters = //BookChapterView.GetModelList("enable=1 order by UpdateTime desc", 500);
                (from l in ent.BookChapter where l.Enable==true orderby l.UpdateTime descending select l).Take(500);

            var items = new List<Voodoo.other.SEO.RssItem>();
            foreach (var chapter in chapters)
            {
                items.Add(new Voodoo.other.SEO.RssItem()
                {
                    Title = chapter.BookTitle + "-" + chapter.Title,
                    PutTime = chapter.UpdateTime,
                    Link = SystemSetting.SiteUrl+GetBookChapterUrl(chapter, chapter.GetClass() ),
                    Description = chapter.BookTitle + "Update to chapter:" + chapter.Title + ", from chanel" + chapter.ClassName
                });
            }

            var movies = (from l in ent.MovieInfo orderby l.UpdateTime descending  select l).Take(800);
            foreach (var m in movies)
            {
                items.Add(new Voodoo.other.SEO.RssItem()
                {
                    Title = m.Title,
                    PutTime = m.UpdateTime.ToDateTime(),
                    Link = SystemSetting.SiteUrl + GetMovieUrl(m,m.GetClass()),// GetBookChapterUrl(chapter, BookView.GetClass(chapter)),
                    Description = m.Title + "Update to :" + m.LastDramaTitle + ", from chanel" + m.ClassName+", Intro:"+m.Intro
                });
            }

            ent.Dispose();
            Response.Clear();
            Voodoo.other.SEO.Rss.GetRss(items, SystemSetting.SiteName, SystemSetting.SiteUrl, SystemSetting.Description, SystemSetting.Copyright);
        }
    }
}