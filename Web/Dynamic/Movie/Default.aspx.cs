using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Voodoo.Basement;
using Voodoo;

namespace Web.Dynamic.Movie
{
    public partial class Default : TemplateHelper
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string action = WS.RequestString("a");
            switch (action)
            {
                case "class":
                    GetClass(WS.RequestString("name"), WS.RequestInt("page", 1));
                    break;
                case "content":
                    Content(WS.RequestString("name"), WS.RequestString("class"));
                    break;
                case "kuaib":
                    Kuaib(WS.RequestInt("id", 1));
                    break;
                case "baidu":
                    Baidu(WS.RequestInt("id", 1));
                    break;
                case "drama":
                    Drama(WS.RequestInt("id", 1));
                    break;
                case "page":
                    Page(WS.RequestString("name"));
                    break;
                case "index":
                
                default:
                    Index();
                    break;
            }
        }

        #region 分类页面
        /// <summary>
        /// 分类页面
        /// </summary>
        /// <param name="id"></param>
        /// <param name="page"></param>
        protected void GetClass(string Name, int page)
        {
            Class cls = ClassAction.Classes.Where(p => p.ClassName == Name).FirstOrDefault();
            Response.Clear();
            Response.Write(CreateListPage(cls, page));
        }
        #endregion

        #region 首页
        /// <summary>
        /// 首页
        /// </summary>
        protected void Index()
        {
            Response.Clear();
            Response.Write(GetIndex());
        }
        #endregion

        #region 内容页
        /// <summary>
        /// 内容页
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Class"></param>
        protected void Content(string Name, string Class)
        {
            DataEntities ent = new DataEntities();
            MovieInfo mv = //MovieInfoView.Find(string.Format("StandardTitle=N'{0}' and ClassName=N'{1}'", Name, Class));
                (from l in ent.MovieInfo where l.StandardTitle==Name && l.ClassName==Class select l).FirstOrDefault();
            ent.Dispose();
            Response.Clear();
            Response.Write(CreateContentPage(mv, mv.GetClass()));
        }
        #endregion

        #region 快播
        /// <summary>
        /// 快播
        /// </summary>
        /// <param name="id"></param>
        protected void Kuaib(int id)
        {
            DataEntities ent = new DataEntities();
            MovieUrlKuaib k = (from l in ent.MovieUrlKuaib where l.id == id select l).FirstOrDefault();
            ent.Dispose();

            Response.Clear();
            Response.Write(CreateDramapage(k,k.GetClass()));
        }
        #endregion

        #region  百度
        /// <summary>
        /// 百度
        /// </summary>
        /// <param name="id"></param>
        protected void Baidu(int id)
        {
            DataEntities ent = new DataEntities();
            MovieUrlBaidu b = (from l in ent.MovieUrlBaidu where l.id == id select l).FirstOrDefault();
            ent.Dispose();
            Response.Clear();
            Response.Write(CreateDramapage(b,b.GetClass()));
        }
        #endregion

        #region 单集列表
        /// <summary>
        /// 单集列表
        /// </summary>
        /// <param name="id"></param>
        protected void Drama(int id)
        {
            DataEntities ent = new DataEntities();
            MovieDrama d =  (from l in ent.MovieDrama where l.id == id select l).FirstOrDefault();
            ent.Dispose();
            Response.Clear();
            Response.Write(CreateDramapage(d,d.GetClass()));
        }
        #endregion

        #region 单独页面
        /// <summary>
        /// 单独页面
        /// </summary>
        /// <param name="pagename"></param>
        protected void Page(string pagename)
        {
            DataEntities ent = new DataEntities();
            TemplatePage tp = (from l in ent.TemplatePage where l.PageName == pagename select l).FirstOrDefault();
            ent.Dispose();
            Response.Clear();
            Response.Write(GetStatisPage(tp.id));
        }
        #endregion
    }
}