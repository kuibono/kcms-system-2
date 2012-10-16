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
                LoadEdus();
                LoadCer();
                LoadLanguages();
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

        #region 加载工作经验
        /// <summary>
        /// 加载工作经验
        /// </summary>
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
        #endregion

        #region 加载教育经历
        /// <summary>
        /// 加载教育经历
        /// </summary>
        protected void LoadEdus()
        {
            long id = WS.RequestLong("id");
            if (id > 0)
            {
                using (DataEntities ent = new DataEntities())
                {
                    var q = from l in ent.JobResumeEdu where l.ResumeID == id select l;
                    rp_listEdu.DataSource = q;
                    rp_listEdu.DataBind();
                }
            }
        }
        #endregion

        #region 加载培训经历
        /// <summary>
        /// 加载培训经历
        /// </summary>
        protected void LoadTrains()
        {
            long id = WS.RequestLong("id");
            if (id > 0)
            {
                using (DataEntities ent = new DataEntities())
                {
                    var q = from l in ent.JobResumeTrain where l.ResumeID == id select l;
                    rp_listTrain.DataSource = q;
                    rp_listTrain.DataBind();
                }
            }
        }
        #endregion

        #region 加载证书
        /// <summary>
        /// 加载证书
        /// </summary>
        protected void LoadCer()
        {
            long id = WS.RequestLong("id");
            if (id > 0)
            {
                using (DataEntities ent = new DataEntities())
                {
                    var q = from l in ent.JobResumeCertificate where l.ResumeID == id select l;
                    rp_listCer.DataSource = q;
                    rp_listCer.DataBind();
                }
            }
        }
        #endregion

        #region 加载语言能力
        /// <summary>
        /// 加载语言能力
        /// </summary>
        protected void LoadLanguages()
        {
            long id = WS.RequestLong("id");
            if (id > 0)
            {
                using (DataEntities ent = new DataEntities())
                {
                    var q = from l in ent.JobResumeLanguage where l.ResumeID == id select l;

                    rp_listLanguage.DataSource = q;
                    rp_listLanguage.DataBind();
                }
            }
        }
        #endregion

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

            //绑定教育经历
            JobAction.BindEduSpecialty(ddl_edu_Specialty);
            ddl_edu_Edu.Bind(JobAction.Edu);
            ddl_edu_StartTime_Year.BindNumbers(1970, 2012);
            ddl_edu_StartTime_Month.BindNumbers(1, 12);
            ddl_edu_LeftTime_Year.BindNumbers(1970, 2012);
            ddl_edu_LeftTime_Month.BindNumbers(1, 12);

            //培新经历
            ddl_train_StartTime_Year.BindNumbers(1970, 2012);
            ddl_train_StartTime_Month.BindNumbers(1, 12);
            ddl_train_LeftTime_Year.BindNumbers(1970, 2012);
            ddl_train_LeftTime_Month.BindNumbers(1, 12);

            //证书
            ddl_cer_gettime_Year.BindNumbers(1970, 2012);
            ddl_cer_gettime_Month.BindNumbers(1, 12);

            //语言
            ddl_language_type.Bind(JobAction.Languages);
            ddl_language_SpeakingAbility.Bind(JobAction.LanguageDegree);
            ddl_language_WritingAbility.Bind(JobAction.LanguageDegree);

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

        #region 经验删除和修改
        /// <summary>
        /// 经验删除和修改
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
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
        #endregion

        #region 教育删除和修改
        /// <summary>
        /// 教育删除和修改
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void rp_listEdu_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            LinkButton clickedButton = ((LinkButton)e.CommandSource);
            long id = ((Label)e.Item.FindControl("lab_typeID")).Text.ToInt64();

            DataEntities ent = new DataEntities();
            var q = (from l in ent.JobResumeEdu where l.ID == id select l).FirstOrDefault();
            if (clickedButton.ID == "btn_Edit")
            {
                lb_id.Text = q.ID.ToS();
                txt_Edu_SchoolName.Text = q.SchoolName;

                ddl_edu_StartTime_Year.SetValue(q.StartTime.ToDateTime().Year.ToS());
                ddl_edu_StartTime_Month.SetValue(q.StartTime.ToDateTime().Month.ToS());
                ddl_edu_LeftTime_Year.SetValue(q.LeftTime.ToDateTime().Year.ToS());
                ddl_edu_LeftTime_Month.SetValue(q.LeftTime.ToDateTime().Month.ToS());
                ddl_edu_Edu.SetValue(q.Edu.ToS());
                ddl_edu_Specialty.SetValue(q.Specialty.ToS());
                txt_edu_Intro.Text = q.Intro;
            }
            if (clickedButton.ID == "btn_Del")
            {
                ent.DeleteObject(q);
                ent.SaveChanges();
                LoadEdus();

            }
            ent.Dispose();
        }
        #endregion

        #region 保存教育
        /// <summary>
        /// 保存教育
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_edu_Save_Click(object sender, EventArgs e)
        {
            long id = lb_edu_id.Text.ToInt64();
            DataEntities ent = new DataEntities();
            JobResumeEdu ex = new JobResumeEdu();
            if (id > 0)
            {
                ex = (from l in ent.JobResumeEdu where l.ID == id select l).FirstOrDefault();
            }
            ex.ResumeID = WS.RequestLong("id");
            ex.SchoolName = txt_Edu_SchoolName.Text;
            ex.Intro = txt_edu_Intro.Text;
            ex.Edu = ddl_edu_Edu.SelectedValue.ToInt32();
            ex.Specialty = ddl_edu_Specialty.SelectedValue.ToInt32();

            ex.StartTime = new DateTime(ddl_edu_StartTime_Year.SelectedValue.ToInt32(), ddl_edu_StartTime_Month.SelectedValue.ToInt32(), 1);
            ex.LeftTime = new DateTime(ddl_edu_LeftTime_Year.SelectedValue.ToInt32(), ddl_edu_LeftTime_Month.SelectedValue.ToInt32(), 1);
            if (id < 0)
            {
                ent.AddToJobResumeEdu(ex);
            }
            ent.SaveChanges();

            txt_Edu_SchoolName.Text = "";
            txt_edu_Intro.Text = "";

            lb_edu_id.Text = "";
            ddl_edu_Edu.SetValue("");
            ddl_edu_Specialty.SetValue("");

            ddl_edu_StartTime_Year.SetValue("");
            ddl_edu_StartTime_Month.SetValue("");
            ddl_edu_LeftTime_Year.SetValue("");
            ddl_edu_LeftTime_Month.SetValue("");

            ent.Dispose();
            LoadEdus();
        }
        #endregion

        #region 培训的删除和修改
        /// <summary>
        /// 培训的删除和修改
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void rp_listTrain_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            LinkButton clickedButton = ((LinkButton)e.CommandSource);
            long id = ((Label)e.Item.FindControl("lab_typeID")).Text.ToInt64();

            DataEntities ent = new DataEntities();
            var q = (from l in ent.JobResumeTrain where l.ID == id select l).FirstOrDefault();
            if (clickedButton.ID == "btn_Edit")
            {
                lb_edu_id.Text = q.ID.ToS();
                txt_train_Title.Text = q.Title;
                txt_train_CertificateName.Text = q.CertificateName;
                txt_train_OrganizationName.Text = q.OrganizationName;
                txt_train_Intro.Text = q.Intro;


                ddl_train_StartTime_Year.SetValue(q.StartTime.ToDateTime().Year.ToS());
                ddl_train_StartTime_Month.SetValue(q.StartTime.ToDateTime().Month.ToS());
                ddl_train_LeftTime_Year.SetValue(q.LeftTime.ToDateTime().Year.ToS());
                ddl_train_LeftTime_Month.SetValue(q.LeftTime.ToDateTime().Month.ToS());

            }
            if (clickedButton.ID == "btn_Del")
            {
                ent.DeleteObject(q);
                ent.SaveChanges();
                LoadTrains();

            }
            ent.Dispose();
        }
        #endregion

        #region 保存培训
        /// <summary>
        /// 保存培训
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_train_Save_Click(object sender, EventArgs e)
        {
            long id = lb_train_id.Text.ToInt64();
            DataEntities ent = new DataEntities();
            JobResumeTrain ex = new JobResumeTrain();
            if (id > 0)
            {
                ex = (from l in ent.JobResumeTrain where l.ID == id select l).FirstOrDefault();
            }
            ex.ResumeID = WS.RequestLong("id");
            ex.Title = txt_train_Title.Text;
            ex.OrganizationName = txt_train_OrganizationName.Text;
            ex.CertificateName = txt_train_CertificateName.Text;
            ex.Intro = txt_train_Intro.Text;

            ex.StartTime = new DateTime(ddl_train_StartTime_Year.SelectedValue.ToInt32(), ddl_train_StartTime_Month.SelectedValue.ToInt32(), 1);
            ex.LeftTime = new DateTime(ddl_train_LeftTime_Year.SelectedValue.ToInt32(), ddl_train_LeftTime_Month.SelectedValue.ToInt32(), 1);
            if (id < 0)
            {
                ent.AddToJobResumeTrain(ex);
            }
            ent.SaveChanges();

            lb_train_id.Text = "";
            txt_train_Title.Text = "";
            txt_train_OrganizationName.Text = "";
            txt_train_CertificateName.Text = "";
            txt_train_Intro.Text = "";

            ddl_train_StartTime_Year.SetValue("");
            ddl_train_StartTime_Month.SetValue("");
            ddl_train_LeftTime_Year.SetValue("");
            ddl_train_LeftTime_Month.SetValue("");

            ent.Dispose();
            LoadTrains();
        }
        #endregion

        #region 证书的删除和修改
        /// <summary>
        /// 证书的删除和修改
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void rp_listCer_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            LinkButton clickedButton = ((LinkButton)e.CommandSource);
            long id = ((Label)e.Item.FindControl("lab_typeID")).Text.ToInt64();

            DataEntities ent = new DataEntities();
            var q = (from l in ent.JobResumeCertificate where l.ID == id select l).FirstOrDefault();
            if (clickedButton.ID == "btn_Edit")
            {
                lb_edu_id.Text = q.ID.ToS();
                txt_cerName.Text = q.CertificateName;
                txt_cer_Intro.Text = q.Intro;

                ddl_cer_gettime_Year.SetValue(q.GetTime.ToDateTime().Year.ToS());
                ddl_cer_gettime_Month.SetValue(q.GetTime.ToDateTime().Month.ToS());


            }
            if (clickedButton.ID == "btn_Del")
            {
                ent.DeleteObject(q);
                ent.SaveChanges();
                LoadCer();

            }
            ent.Dispose();
        }
        #endregion

        #region 证书保存
        /// <summary>
        /// 证书保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_cer_Save_Click(object sender, EventArgs e)
        {
            long id = lb_cer_id.Text.ToInt64();
            DataEntities ent = new DataEntities();
            JobResumeCertificate ex = new JobResumeCertificate();
            if (id > 0)
            {
                ex = (from l in ent.JobResumeCertificate where l.ID == id select l).FirstOrDefault();
            }
            ex.ResumeID = WS.RequestLong("id");
            ex.CertificateName = txt_cerName.Text;
            ex.Intro = txt_cer_Intro.Text;

            ex.GetTime = new DateTime(ddl_cer_gettime_Year.SelectedValue.ToInt32(), ddl_cer_gettime_Month.SelectedValue.ToInt32(), 1);


            if (id < 0)
            {
                ent.AddToJobResumeCertificate(ex);
            }
            ent.SaveChanges();

            lb_cer_id.Text = "";
            txt_cer_Intro.Text = "";
            txt_cerName.Text = "";

            ddl_cer_gettime_Year.SetValue("");
            ddl_cer_gettime_Month.SetValue("");

            ent.Dispose();
            LoadCer();
        }
        #endregion

        #region 语言删除修改
        /// <summary>
        /// 语言删除修改
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void rp_listLanguage_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            LinkButton clickedButton = ((LinkButton)e.CommandSource);
            long id = ((Label)e.Item.FindControl("lab_typeID")).Text.ToInt64();

            DataEntities ent = new DataEntities();
            var q = (from l in ent.JobResumeLanguage where l.ID == id select l).FirstOrDefault();
            if (clickedButton.ID == "btn_Edit")
            {
                lb_language_id.Text = q.ID.ToS();

                ddl_language_type.SetValue(q.LanguageType.ToS());
                ddl_language_SpeakingAbility.SetValue(q.SpeakingAbility.ToS());
                ddl_language_WritingAbility.SetValue(q.WritingAbility.ToS());

            }
            if (clickedButton.ID == "btn_Del")
            {
                ent.DeleteObject(q);
                ent.SaveChanges();
                LoadLanguages();

            }
            ent.Dispose();
        }
        #endregion

        #region 语言保存
        /// <summary>
        /// 语言保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_language_Save_Click(object sender, EventArgs e)
        {
            long id = lb_cer_id.Text.ToInt64();
            DataEntities ent = new DataEntities();
            JobResumeLanguage ex = new JobResumeLanguage();
            if (id > 0)
            {
                ex = (from l in ent.JobResumeLanguage where l.ID == id select l).FirstOrDefault();
            }
            ex.ResumeID = WS.RequestLong("id");
            ex.LanguageType = ddl_language_type.SelectedValue.ToInt32();
            ex.SpeakingAbility = ddl_language_SpeakingAbility.SelectedValue.ToInt32();
            ex.WritingAbility = ddl_language_WritingAbility.SelectedValue.ToInt32();


            if (id < 0)
            {
                ent.AddToJobResumeLanguage(ex);
            }
            ent.SaveChanges();

            ent.Dispose();
            LoadLanguages();
        }
        #endregion
    }
}