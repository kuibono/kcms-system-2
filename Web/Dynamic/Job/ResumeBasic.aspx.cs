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
    public partial class ResumeBasic : BasePage
    {
        public string ResumeOpen = "";
        public string Image = "";
        public string file_resume = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDropItems();
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

            var file = u.DefaultResumeFile();
            if (u.ID > 0 && file != null && file.ID > 0)
            {
                file_resume = string.Format("<a href='{0}' target='_blank'>{1}</a>", file.FilePath, file.FileName);
            }
            else
            {
                file_resume = "还没有上传简历";
            }

            txt_ChineseName.Text = r.ChineseName;
            ckl_sex.SetValue(r.IsMale == true ? "1" : "0");
            ddl_Province.SetValue(r.Province.ToS());
            ddl_City.SetValue(r.City.ToS());
            txt_Mobile.Text = r.Mobile;
            txt_Email.Text = r.Email;
            ddl_CityWork.ForceSetValue(r.WorkPlace.ToS(), "");
            ckl_Enable.SetValue(r.IsResumeOpen == true ? "1" : "0");
            ddl_Year.SetValue(r.Birthday.ToDateTime().Year.ToString());
            ddl_Month.SetValue(r.Birthday.ToDateTime().Month.ToString());
            ddl_Day.SetValue(r.Birthday.ToDateTime().Day.ToString());
            txt_Keywords.Text = r.Keywords;

            ResumeOpen = r.IsResumeOpen == true ? "简历完全开放" : "简历关闭";
            Image = r.Image;
        }

        #region 绑定下拉项
        protected void BindDropItems()
        {
            DataEntities ent = new DataEntities();

            #region  绑定省
            var provinces = from l in ent.Province select l;

            foreach (var pro in provinces)
            {
                ddl_Province.Items.Add(new ListItem(pro.province1, pro.ID.ToS()));
                ddl_ProvinceWork.Items.Add(new ListItem(pro.province1, pro.ID.ToS()));
            }
            #endregion

            JobAction.BindCity(ddl_City, ddl_Province.SelectedValue.ToInt32());
            JobAction.BindCity(ddl_CityWork, ddl_Province.SelectedValue.ToInt32());
            ent.Dispose();

            //绑定工作经历编辑区域

            ddl_Year.BindNumbers(1970, 2012);
            ddl_Month.BindNumbers(1, 12);
            ddl_Day.BindNumbers(1, 31);


        }


        protected void ddl_Province_SelectedIndexChanged(object sender, EventArgs e)
        {
            JobAction.BindCity(ddl_City, ddl_Province.SelectedValue.ToInt32());
        }



        protected void ddl_ProvinceWork_SelectedIndexChanged(object sender, EventArgs e)
        {
            JobAction.BindCity(ddl_CityWork, ddl_Province.SelectedValue.ToInt32());
        }

        #endregion


        protected void btn_Save_Click(object sender, EventArgs e)
        {
            DataEntities ent = new DataEntities();

            long id = WS.RequestLong("id");

            JobResumeInfo
                r = (from l in ent.JobResumeInfo where l.UserID == UserAction.opuser.ID select l).FirstOrDefault();

            r.ChineseName = txt_ChineseName.Text;
            r.Birthday = new DateTime(ddl_Year.SelectedValue.ToInt32(),
                ddl_Month.SelectedValue.ToInt32(),
                ddl_Day.SelectedValue.ToInt32());
            r.IsMale = ckl_sex.SelectedValue == "1";
            r.Province = ddl_Province.SelectedValue.ToInt32();
            r.City = ddl_City.SelectedValue.ToInt32();
            r.WorkPlace = ddl_CityWork.SelectedValue.ToInt32();
            r.Mobile = txt_Mobile.Text;
            r.Email = txt_Email.Text;
            r.IsResumeOpen = ckl_Enable.SelectedValue == "1";
            r.Keywords = txt_Keywords.Text;

            if (r.ID <= 0)
            {
                ent.AddToJobResumeInfo(r);
            }
            ent.SaveChanges();

            if (file_Face.HasFile)
            {
                string path = string.Format("/u/ResumeFace/{0}.jpg", r.ID.ToS());
                var result = BasePage.UpLoadImage(file_Face.PostedFile, path, 96, 96);
                if (result.Success)
                {
                    r.Image = path;
                }
                ent.SaveChanges();
            }

            ent.Dispose();

            Js.AlertAndChangUrl("保存成功！", "Home.aspx");
        }
    }
}