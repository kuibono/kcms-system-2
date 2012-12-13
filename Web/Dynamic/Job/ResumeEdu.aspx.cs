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
    public partial class ResumeEdu : BasePage
    {
        public string ResumeOpen = "";
        public string Image = "";

        User u = UserAction.opuser;
        JobResumeInfo r;
        protected void Page_Load(object sender, EventArgs e)
        {
            BindDropItems();
            LoadInfo();

        }
        protected void LoadInfo()
        {
            
            if (u.ID < 0)
            {
                Js.AlertAndChangUrl("您还没有登录，请登录或注册后进入简历管理！", "/");
            }
            DataEntities ent = new DataEntities();
            r = new JobResumeInfo();
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

            ResumeOpen = r.IsResumeOpen == true ? "简历完全开放" : "简历关闭";
            Image = r.Image;

            long id = WS.RequestLong("id");
            var q = (from l in ent.JobResumeEdu where l.ID == id select l).FirstOrDefault();
            if (WS.RequestString("action") == "edit")
            {
                lb_edu_id.Text = q.ID.ToS();
                txt_Edu_SchoolName.Text = q.SchoolName;
                ddl_edu_StartTime_Year.Text = q.StartTime.ToDateTime().Year.ToS();
                ddl_edu_StartTime_Month.Text = q.StartTime.ToDateTime().Month.ToS();
                ddl_edu_LeftTime_Year.Text = q.LeftTime.ToDateTime().Year.ToS();
                ddl_edu_LeftTime_Month.Text = q.LeftTime.ToDateTime().Month.ToS();
                ddl_edu_Edu.SetValue(q.Edu.ToS());
                ddl_edu_Specialty.SetValue(q.Specialty.ToS());
                txt_edu_Intro.Text = q.Intro;

            }
            else if (WS.RequestString("action") == "del"&&q!=null)
            {
                ent.DeleteObject(q);
                ent.SaveChanges();
                Response.Redirect("ResumeEdu.aspx");
            }

            var list = from l in ent.JobResumeEdu where l.ResumeID == r.ID select l;
            rp_listEdu.DataSource = list;
            rp_listEdu.DataBind();

            ent.Dispose();
        }

        #region 绑定下拉项
        protected void BindDropItems()
        {
            //绑定教育经历
            JobAction.BindEduSpecialty(ddl_edu_Specialty);
            ddl_edu_Edu.Bind(JobAction.Edu);
            ddl_edu_StartTime_Year.BindNumbers(1970, 2012);
            ddl_edu_StartTime_Month.BindNumbers(1, 12);
            ddl_edu_LeftTime_Year.BindNumbers(1970, 2012);
            ddl_edu_LeftTime_Month.BindNumbers(1, 12);

        }

        #endregion

        protected void btn_edu_Save_Click(object sender, EventArgs e)
        {
            DataEntities ent = new DataEntities();
            long id = lb_edu_id.Text.ToInt64();

            JobResumeEdu edu = new JobResumeEdu();
            try
            {
                edu = (from l in ent.JobResumeEdu where l.ID == id select l).First();
            }
            catch { }

            edu.Edu = ddl_edu_Edu.SelectedValue.ToInt32();
            edu.Intro = txt_edu_Intro.Text;
            edu.LeftTime = new DateTime(ddl_edu_LeftTime_Year.SelectedValue.ToInt32(),
                ddl_edu_LeftTime_Month.SelectedValue.ToInt32(),
                1);
            edu.ResumeID = r.ID;
            edu.SchoolName = txt_Edu_SchoolName.Text;
            edu.Specialty = ddl_edu_Specialty.SelectedValue.ToInt32();
            edu.StartTime = new DateTime(ddl_edu_StartTime_Year.SelectedValue.ToInt32(),
                ddl_edu_StartTime_Month.SelectedValue.ToInt32(),
                1);
            if (edu.ID <= 0)
            {
                ent.AddToJobResumeEdu(edu);
            }
            ent.SaveChanges();
            lb_edu_id.Text = "";
            txt_Edu_SchoolName.Text = "";
            txt_edu_Intro.Text = "";
            ent.SaveChanges();
            ent.Dispose();

            Response.Redirect("ResumeEdu.aspx");
        }
    }
}