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

namespace Web.e.admin.Movie
{
    public partial class MovieEdit : AdminBase
    {
        protected int cls = WS.RequestInt("class", 0);
        protected int zt = WS.RequestInt("zt", 0);
        protected string url = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            url = string.Format("MovieList.aspx?class={0}&zt={1}", cls, zt);
            if (!IsPostBack)
            {

                LoadInfo();
            }
        }

        protected void LoadInfo()
        {
            DataEntities ent = new DataEntities();

            ddl_Class.DataSource = NewsAction.NewsClass.Where(p => p.ModelID == 6).ToList();
            ddl_Class.DataTextField = "ClassName";
            ddl_Class.DataValueField = "ID";
            ddl_Class.DataBind();

            ddl_Class.SelectedValue = cls.ToS();

            int id = WS.RequestInt("id");

            MovieInfo mi = //MovieInfoView.GetModelByID(id.ToS());
                (from l in ent.MovieInfo where l.id == id select l).FirstOrDefault();
            ent.Dispose();

            txt_Title.Text = mi.Title;
            txt_Director.Text = mi.Director;
            txt_Actors.Text = mi.Actors;
            txt_Tags.Text = mi.Tags;
            txt_Location.Text = mi.Location;
            txt_PublicYear.Text = mi.PublicYear;
            txt_Intro.Text = mi.Intro;
            FCKeditor1.Value = mi.Info;
            chk_IsMovie.Checked = mi.IsMove.ToBoolean();
            img_Movieface.ImageUrl = mi.FaceImage;
            rbl_Status.SelectedValue = mi.Status.ToS();
            chk_Enable.Checked = mi.Enable.ToBoolean();

        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            int id = WS.RequestInt("id");
            DataEntities ent = new DataEntities();

            MovieInfo mi = //MovieInfoView.GetModelByID(id.ToS());
                (from l in ent.MovieInfo where l.id == id select l).FirstOrDefault();
            mi.ClassID = ddl_Class.SelectedItem.Value.ToInt32();
            mi.ClassName = ddl_Class.SelectedItem.Text;
            mi.Title = txt_Title.Text;
            mi.Director = txt_Director.Text;
            mi.Actors = txt_Actors.Text;
            mi.Tags = txt_Tags.Text;
            mi.Location = txt_Location.Text;
            mi.PublicYear = txt_PublicYear.Text;
            mi.Intro = txt_Intro.Text;
            mi.IsMove = chk_IsMovie.Checked;
            mi.Status = rbl_Status.SelectedValue.ToInt32();
            mi.Enable = chk_Enable.Checked;
            mi.Info = FCKeditor1.Value;
            mi.InsertTime = DateTime.UtcNow.AddHours(8);
            mi.UpdateTime = DateTime.UtcNow.AddHours(8);
            mi.LastClickTime = DateTime.UtcNow.AddHours(8);

            if (id <= 0)
            {
                ent.AddToMovieInfo(mi);
            }
            ent.SaveChanges();

            //Deal Book face image
            if (file_Moviefacefile.FileName.IsNullOrEmpty() == false)
            {
                file_Moviefacefile.SaveAs(Server.MapPath("/u/MoviekFace/" + mi.id + ".jpg"));
                mi.FaceImage = "/u/MoviekFace/" + mi.id + ".jpg";
                ent.SaveChanges();
            }
            ent.Dispose();

            Response.Redirect(url);
        }
    }
}