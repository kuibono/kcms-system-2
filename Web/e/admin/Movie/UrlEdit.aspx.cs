using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Voodoo;
using Voodoo.Basement;
using Voodoo.Setting;


namespace Web.e.admin.Movie
{
    public partial class UrlEdit : AdminBase
    {
        protected string type = WS.RequestString("type");
        protected long id = WS.RequestString("id").ToInt64();
        protected int movieID = 0;
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
                switch (type)
                {
                    case "kuaib":
                        var kuaibUrl = //MovieUrlKuaibView.GetModelByID(id.ToS());
                            (from l in ent.MovieUrlKuaib where l.id == id select l).FirstOrDefault();
                        txt_BookTitle.Text = kuaibUrl.MovieTitle;
                        txt_Title.Text = kuaibUrl.Title;
                        txt_Url.Text = kuaibUrl.Url;
                        movieID = kuaibUrl.MovieID.ToInt32();
                        break;
                    case "baidu":
                        var baiduUrl = //MovieUrlBaiduView.GetModelByID(id.ToS());
                            (from l in ent.MovieUrlBaidu where l.id == id select l).FirstOrDefault();
                        txt_BookTitle.Text = baiduUrl.MovieTitle;
                        txt_Title.Text = baiduUrl.Title;
                        txt_Url.Text = baiduUrl.Url;
                        movieID = baiduUrl.MovieID.ToInt32();
                        break;
                    case "mag":
                        var magUrl = //MovieUrlMagView.GetModelByID(id.ToS());
                            (from l in ent.MovieUrlMag where l.id == id select l).FirstOrDefault();
                        txt_BookTitle.Text = magUrl.MovieTitle;
                        txt_Title.Text = magUrl.Title;
                        txt_Url.Text = magUrl.Url;
                        movieID = magUrl.MovieID.ToInt32();
                        break;
                }
            }
        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            DataEntities ent = new DataEntities();

            movieID = WS.RequestInt("movieid", 0);
            MovieInfo movie = //MovieInfoView.GetModelByID(movieID.ToS());
                (from l in ent.MovieInfo where l.id == movieID select l).FirstOrDefault();
            #region deal
            switch (type)
            {
                case "kuaib":
                    var kuaibUrl = (from l in ent.MovieUrlKuaib where l.id == id select l).FirstOrDefault();
                    kuaibUrl.MovieTitle = movie.Title;
                    kuaibUrl.Title = txt_Title.Text;
                    kuaibUrl.Url = txt_Url.Text;
                    kuaibUrl.MovieID = movie.id;
                    kuaibUrl.UpdateTime = DateTime.Now;
                    
                    if (kuaibUrl.id <= 0)
                    {
                        ent.AddToMovieUrlKuaib(kuaibUrl);
                    }
                    break;
                case "baidu":
                    var baiduUrl = (from l in ent.MovieUrlBaidu where l.id == id select l).FirstOrDefault();
                    baiduUrl.MovieTitle = movie.Title;
                    baiduUrl.Title = txt_Title.Text;
                    baiduUrl.Url = txt_Url.Text;
                    baiduUrl.MovieID = movie.id;
                    baiduUrl.UpdateTime = DateTime.Now;
                    if (baiduUrl.id <= 0)
                    {
                        ent.AddToMovieUrlBaidu(baiduUrl);
                    }
                    break;
                case "mag":
                    var magUrl = (from l in ent.MovieUrlMag where l.id == id select l).FirstOrDefault();
                    magUrl.MovieTitle =  movie.Title;
                    magUrl.Title = txt_Title.Text;
                    magUrl.Url = txt_Url.Text;
                    magUrl.MovieID = movie.id;
                    magUrl.UpdateTime = DateTime.Now;
                    if (magUrl.id <= 0)
                    {
                        ent.AddToMovieUrlMag(magUrl);
                    }
                    break;
            }
            #endregion 
            ent.SaveChanges();
            ent.Dispose();

            Response.Redirect("UrlList.aspx?type=" + type + "&movieid="+movieID);
        }
    }
}