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
            if (!IsPostBack)
            {
                BindDropItems();
                LoadInfo();
            }
        }

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


    }
}