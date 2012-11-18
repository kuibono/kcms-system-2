using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Voodoo;
using Voodoo.Basement;
using Voodoo.Basement.Model;

namespace Web.e.admin.Job.Post
{
    public partial class Edit : AdminBase
    {
        public static string refer = "List.aspx";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                refer = Request.UrlReferrer.ToS();
                LoadInfo();
            }
        }

        protected void LoadInfo()
        {
            int id = WS.RequestInt("id");

            DataEntities ent = new DataEntities();

            #region 绑定用户
            var users = from l in ent.User where l.Group == 2 select l;
            foreach (var user in users)
            {
                ddl_User.Items.Add(new ListItem(user.UserName, user.ID.ToS()));
            }
            #endregion

            LoadCompany();

            #region  绑定省
            var provinces = from l in ent.Province select l;
            foreach (var pro in provinces)
            {
                ddl_Province.Items.Add(new ListItem(pro.province1, pro.ID.ToS()));
            }
            #endregion

            LoadCity();

            foreach (var sal in JobAction.SalaryDegree)
            {
                ddl_Salary.Items.Add(new ListItem(sal.Value, sal.Key.ToS()));
            }

            foreach (var exp in JobAction.Expressions)
            {
                ddl_Expressions.Items.Add(new ListItem(exp.Value, exp.Key.ToS()));
            }

            foreach (var edu in JobAction.Edu)
            {

                ddl_Edu.Items.Add(new ListItem(edu.Value, edu.Key.ToS()));
            }

            long companyID = WS.RequestLong("cid");
            if (companyID > 0)
            {
                ddl_Company.SetValue(companyID.ToS());
            }

            //绑定教育
            List<JobPostEduAndEmployeeCount> edus = new List<JobPostEduAndEmployeeCount>();
            foreach (var ed in JobAction.Edu)
            {
                edus.Add(new JobPostEduAndEmployeeCount() { Checked = false, key = ed.Key, Number = 0, Text = ed.Value });
            }

            rp_edu.DataSource = edus;
            rp_edu.DataBind();

            var p = (from l in ent.JobPost where l.ID == id select l).FirstOrDefault();
            if (p == null)
            {
                txt_ExpireTime.Text = DateTime.Now.AddMonths(1).ToString("yyyy-MM-dd HH:mm:ss");
                return;
            }

            try
            {
                List<JobPostEduAndEmployeeCount> existEdus = (List<JobPostEduAndEmployeeCount>)Voodoo.IO.XML.DeSerialize(typeof(List<JobPostEduAndEmployeeCount>), p.Ext1);
                rp_edu.DataSource = existEdus;
                rp_edu.DataBind();
            }
            catch { }

            //ddl_User.SelectedValue=p.u
            ddl_Company.SelectedValue = p.CompanyID.ToS();
            txt_Title.Text = p.Title;
            ddl_Province.SelectedValue = p.Province.ToS();
            ddl_City.SelectedValue = p.City.ToS();
            ddl_Salary.SelectedValue = p.Salary.ToS();
            ddl_Expressions.SelectedValue = p.Expressions.ToS();
            ddl_Edu.SelectedValue = p.Edu.ToS();
            txt_EmployNumber.Text = p.EmployNumber.ToS();
            txt_Intro.Text = p.Intro;
            chk_Settop.Checked = p.IsSetTop.ToBoolean();
            txt_ExpireTime.Text = p.ExpireTime.ToDateTime(DateTime.Now.AddMonths(1)).ToString("yyyy-MM-dd HH:mm:ss");

            ent.Dispose();
        }

        #region 绑定公司列表
        /// <summary>
        /// 绑定公司列表
        /// </summary>
        protected void LoadCompany()
        {
            using (DataEntities ent = new DataEntities())
            {
                int uid=ddl_User.SelectedValue.ToInt32();
                var coms = from l in ent.JobCompany where l.UserID == uid select l;
                ddl_Company.Items.Clear();
                foreach (var com in coms)
                {
                    ddl_Company.Items.Add(new ListItem(com.CompanyName, com.ID.ToS()));
                }
            }
        }
        #endregion

        #region 绑定市
        /// <summary>
        /// 绑定市
        /// </summary>
        protected void LoadCity()
        {
            using (DataEntities ent = new DataEntities())
            {
                int pid=ddl_Province.SelectedValue.ToInt32();

                var cts = from l in ent.City where l.ProvinceID == pid select l;
                ddl_City.Items.Clear();
                foreach (var ct in cts)
                {
                    ddl_City.Items.Add(new ListItem(ct.city1, ct.id.ToS()));
                }
            }
        }
        #endregion

        protected void ddl_User_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCompany();
        }

        protected void ddl_Province_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCity();
        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            DataEntities ent = new DataEntities();

            int id = WS.RequestInt("id");
            JobPost p = new JobPost();
            if (id > 0)
            {
                p = (from l in ent.JobPost where l.ID == id select l).FirstOrDefault();
            }

            p.CompanyID = ddl_Company.SelectedValue.ToInt32();
            p.Title = txt_Title.Text;
            p.Province = ddl_Province.SelectedValue.ToInt32();
            p.City = ddl_City.SelectedValue.ToInt32();
            p.Salary = ddl_Salary.SelectedValue.ToInt32();
            p.Expressions = ddl_Expressions.SelectedValue.ToInt32();
            p.Edu = ddl_Edu.SelectedValue.ToInt32();
            p.EmployNumber = txt_EmployNumber.Text.ToInt32();
            p.Intro = txt_Intro.Text;
            p.PostTime = DateTime.Now;
            p.IsSetTop = chk_Settop.Checked;
            p.SetTopTime = DateTime.Now;
            p.ExpireTime = txt_ExpireTime.Text.ToDateTime();

            //绑定教育
            List<JobPostEduAndEmployeeCount> edus = new List<JobPostEduAndEmployeeCount>();
            foreach (var ed in JobAction.Edu)
            {
                edus.Add(new JobPostEduAndEmployeeCount() { Checked = false, key = ed.Key, Number = 0, Text = ed.Value });
            }
            string[] chk = WS.RequestString("chk").Split(',');
            string[] nums = WS.RequestString("number").Split(',');
            for (int i = 0; i < chk.Length; i++)
            {
                edus[i].Checked = chk[i].ToBoolean();
                edus[i].Number = nums[i].ToInt32();
            }

            p.Ext1 = Voodoo.IO.XML.Serialize(edus);

            if (p.ID <= 0)
            {
                //处理城市热度
                try
                {
                    var ct = (from l in ent.City where l.id == p.City select l).FirstOrDefault();
                    ct.Hot += 1;
                }
                catch { }

                ent.AddToJobPost(p);
            }
            ent.SaveChanges();
            ent.Dispose();

            Js.AlertAndChangUrl("保存成功！", refer);
        }

    }
}