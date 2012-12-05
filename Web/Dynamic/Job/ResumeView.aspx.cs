using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Voodoo;
using Voodoo.Basement;
namespace Web.Dynamic.Job
{
    public partial class ResumeView : BasePage
    {
        public string ResumeOpen = "";
        public string Image = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadInfo();
            }
        }

        protected void LoadInfo()
        {
            User u = UserAction.opuser;
            if (u.ID < 0)
            {
                Js.AlertAndChangUrl("您还没有登录，请登录或注册后进入简历管理！", "/");
            }
            DataEntities ent = new DataEntities();
            JobResumeInfo r = new JobResumeInfo();
            try
            {
                r = (from l in ent.JobResumeInfo where l.UserID == u.ID select l).First();
            }
            catch
            {
                r.UserID = u.ID;
                r.IsResumeOpen = true;
                r.Image = "/u/ResumeFace/0.jpg";
                r.Title = u.UserName + "的简历";

                ent.AddToJobResumeInfo(r);
                ent.SaveChanges();
            }


            txt_ChineseName.Text = r.ChineseName;
            txt_Sex.Text=r.IsMale==true?"男":"女";

            txt_LivePlace.Text=JobAction.GetProviceName(r.Province.ToInt32())+"-"+JobAction.GetCityName(r.City.ToInt32());


            txt_Mobile.Text = r.Mobile;
            txt_Email.Text = r.Email;

            txt_WorkPlace.Text = JobAction.GetCityName(r.WorkPlace.ToInt32());


            txt_Birth.Text = r.Birthday.ToDateTime().ToString("yyyy年MM月dd日");

            ResumeOpen = r.IsResumeOpen == true ? "简历完全开放" : "简历关闭";
            Image = r.Image;
        }

        
    }
}