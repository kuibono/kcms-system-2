using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Voodoo;
using Voodoo.Basement;

namespace Web.e.admin.Job.Resume
{
    public partial class Edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            long id = WS.RequestLong("id");
            if (id > 0)
            {
                btn_Exp_Save.Enabled = true;
            }
            else
            {
                btn_Exp_Save.Enabled = false;
            }
            if (!IsPostBack)
            {
                BindDropItems();
                LoadInfo();
                LoadExps();
            }

        }

        #region 加载简历
        /// <summary>
        /// 加载简历
        /// </summary>
        protected void LoadInfo()
        {
            long id = WS.RequestLong("id");
            if (id <= 0)
            {
                return;
            }
            DataEntities ent = new DataEntities();
            var rs = (from l in ent.JobResumeInfo where l.ID == id select l).FirstOrDefault();
            ent.Dispose();

            ddl_User.ForceSetValue(rs.UserID.ToS(), UserAction.GetUserNameByID(rs.UserID.ToInt32()));
            txt_Title.Text = rs.Title;
            txt_ChineseName.Text = rs.ChineseName;
            txt_Birthday.Text = rs.Birthday.ToS();
            ckl_sex.SetValue(rs.IsMale==true ? "1" : "0");
            ddl_Province.SetValue(rs.Province.ToS());
            ddl_City.SetValue(rs.City.ToS());
            txt_Mobile.Text = rs.Mobile;
            txt_Email.Text = rs.Email;
            txt_Country.Text = rs.Country;
            ddl_CardType.SetValue(rs.CardType.ToS());
            txt_CardNo.Text = rs.CardNumber;
            //ddl_ProvinceHome.SetValue(rs.Province.ToS());
            ddl_CityWork.ForceSetValue(rs.WorkPlace.ToS(), "");
            ddl_CityHome.ForceSetValue(rs.HomeCity.ToS(),"");
            ddl_Nation.SetValue(rs.Nation.ToS());
            ddl_Political.SetValue(rs.Political.ToS());
            txt_QQ.Text = rs.QQ;
            txt_MSN.Text = rs.MSN;
            txt_Address.Text = rs.Address;
            txt_Tel.Text = rs.Tel;
            txt_Intro.Text = rs.Intro;
            chk_Enable.Checked = rs.IsResumeOpen==true;
            if (!rs.Image.IsNullOrEmpty())
            {
                Image1.ImageUrl = rs.Image;
            }

        }
        #endregion

        protected void LoadExps()
        {
            long id = WS.RequestLong("id");
            if (id > 0)
            {
                using (DataEntities ent = new DataEntities())
                {
                    var q = from l in ent.JobResumeExperience where l.ResumeID == id select l;
                    rp_listExperience.DataSource = q;
                    rp_listExperience.DataBind();
                }
            }
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
                ddl_ProvinceHome.Items.Add(new ListItem(pro.province1, pro.ID.ToS()));
                ddl_ProvinceWork.Items.Add(new ListItem(pro.province1, pro.ID.ToS()));
            }
            #endregion

            JobAction.BindCity(ddl_City, ddl_Province.SelectedValue.ToInt32());
            JobAction.BindCity(ddl_CityHome, ddl_Province.SelectedValue.ToInt32());
            JobAction.BindCity(ddl_CityWork, ddl_Province.SelectedValue.ToInt32());

            ddl_Marriage.Bind(JobAction.Marrage);
            ddl_CardType.Bind(JobAction.CardType);
            ddl_Nation.Bind(JobAction.Nation);
            ddl_Political.Bind(JobAction.Political);
            ent.Dispose();

            //绑定工作经历编辑区域

            JobAction.BindIndustry(ddl_exp_Post);
            ddl_exp_StartTime_Year.BindNumbers(1970, 2012);
            ddl_exp_StartTime_Month.BindNumbers(1, 12);
            ddl_exp_LeftTime_Year.BindNumbers(1970, 2012);
            ddl_exp_LeftTime_Month.BindNumbers(1, 12);

        }


        protected void ddl_Province_SelectedIndexChanged(object sender, EventArgs e)
        {
            JobAction.BindCity(ddl_City, ddl_Province.SelectedValue.ToInt32());
        }

        protected void ddl_ProvinceHome_SelectedIndexChanged(object sender, EventArgs e)
        {
            JobAction.BindCity(ddl_CityHome, ddl_Province.SelectedValue.ToInt32());
        }

        protected void ddl_ProvinceWork_SelectedIndexChanged(object sender, EventArgs e)
        {
            JobAction.BindCity(ddl_CityWork, ddl_Province.SelectedValue.ToInt32());
        }

        #endregion

        #region 搜索用户
        /// <summary>
        /// 搜索用户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_search_Click(object sender, EventArgs e)
        {
            DataEntities ent = new DataEntities();
            var qs = from l in ent.User where l.Group == 1 || l.Group == 3 select l;
            ddl_User.Items.Clear();
            foreach (var q in qs)
            {
                ddl_User.Items.Add(new ListItem(q.UserName, q.ID.ToS()));
            }
            ent.Dispose();
        }
        #endregion

        #region 保存简历
        /// <summary>
        /// 保存简历
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Save_Click(object sender, EventArgs e)
        {
            DataEntities ent = new DataEntities();

            long id = WS.RequestLong("id");

            JobResumeInfo r = new JobResumeInfo();
            if (id > 0)
            {
                r = (from l in ent.JobResumeInfo where l.ID == id select l).FirstOrDefault();
            }
            r.Title = txt_Title.Text;
            r.UserID = ddl_User.SelectedValue.ToInt32();
            r.ChineseName = txt_ChineseName.Text;
            r.Birthday = txt_Birthday.Text.ToDateTime();
            r.IsMale = ckl_sex.SelectedValue == "1";
            r.Province = ddl_Province.SelectedValue.ToInt32();
            r.City = ddl_City.SelectedValue.ToInt32();
            r.WorkPlace = ddl_CityWork.SelectedValue.ToInt32();
            r.Address = txt_Address.Text;
            r.Tel = txt_Tel.Text;
            r.Marriage = ddl_Marriage.SelectedValue.ToInt32();
            r.Mobile = txt_Mobile.Text;
            r.Email = txt_Email.Text;
            r.Country = txt_Country.Text;
            r.CardType = ddl_CardType.SelectedValue.ToInt32();
            r.CardNumber = txt_CardNo.Text;
            r.HomeCity = ddl_CityHome.SelectedValue.ToInt32();
            r.Nation = ddl_Nation.SelectedValue;
            r.Political = ddl_Political.SelectedValue.ToInt32();
            r.QQ = txt_QQ.Text;
            r.MSN = txt_MSN.Text;
            r.Intro = txt_Intro.Text;
            r.IsResumeOpen = chk_Enable.Checked;

            if (r.ID <= 0)
            {
                ent.AddToJobResumeInfo(r);
            }
            ent.SaveChanges();

            if (file_Face.HasFile)
            {
                string path = string.Format("/u/ResumeFace/{0}.jpg",r.ID.ToS());
                var result = BasePage.UpLoadImage(file_Face.PostedFile,path, 96, 96);
                if (result.Success)
                {
                    r.Image = path;
                }
                ent.SaveChanges();
            }

            ent.Dispose();

            Js.AlertAndChangUrl("保存成功！", "List.aspx");

        }
        #endregion

        #region 保存经验
        /// <summary>
        /// 保存经验
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Exp_Save_Click(object sender, EventArgs e)
        {
            long id = lb_id.Text.ToInt32();
            DataEntities ent = new DataEntities();
            JobResumeExperience ex = new JobResumeExperience();
            if (id > 0)
            {
                ex = (from l in ent.JobResumeExperience where l.ID == id select l).FirstOrDefault();
            }
            ex.ResumeID = WS.RequestLong("id");
            ex.CompanyName = txt_Exp_CompanyName.Text;
            ex.Intro = txt_Exp_Intro.Text;
            ex.Post = ddl_exp_Post.SelectedValue.ToInt32();
            ex.StartTime = new DateTime(ddl_exp_StartTime_Year.SelectedValue.ToInt32(), ddl_exp_StartTime_Month.SelectedValue.ToInt32(), 1);
            ex.LeftTime = new DateTime(ddl_exp_LeftTime_Year.SelectedValue.ToInt32(), ddl_exp_LeftTime_Month.SelectedValue.ToInt32(), 1);
            if (id < 0)
            {
                ent.AddToJobResumeExperience(ex);
            }
            ent.SaveChanges();

            txt_Exp_Intro.Text = "";
            txt_Exp_CompanyName.Text = "";
            lb_id.Text = "";
            ddl_exp_Post.SetValue("");
            ddl_exp_StartTime_Year.SetValue("");
            ddl_exp_StartTime_Month.SetValue("");
            ddl_exp_LeftTime_Year.SetValue("");
            ddl_exp_LeftTime_Month.SetValue("");

            ent.Dispose();
            LoadExps();
        }
        #endregion

        protected void rp_listExperience_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            LinkButton clickedButton = ((LinkButton)e.CommandSource);
            long id = ((Label)e.Item.FindControl("lab_typeID")).Text.ToInt64();

            DataEntities ent = new DataEntities();
            var q = (from l in ent.JobResumeExperience where l.ID == id select l).FirstOrDefault();
            if (clickedButton.ID == "btn_Edit")
            {
                lb_id.Text = q.ID.ToS();
                txt_Exp_CompanyName.Text = q.CompanyName;
                ddl_exp_StartTime_Year.SetValue(q.StartTime.ToDateTime().Year.ToS());
                ddl_exp_StartTime_Month.SetValue(q.StartTime.ToDateTime().Month.ToS());
                ddl_exp_LeftTime_Year.SetValue(q.LeftTime.ToDateTime().Year.ToS());
                ddl_exp_LeftTime_Month.SetValue(q.LeftTime.ToDateTime().Month.ToS());
                ddl_exp_Post.SetValue(q.Post.ToS());
                txt_Exp_Intro.Text = q.Intro;
            }
            if (clickedButton.ID == "btn_Del")
            {
                ent.DeleteObject(q);
                ent.SaveChanges();
                LoadExps();
               
            }
            ent.Dispose();

        }



    }
}