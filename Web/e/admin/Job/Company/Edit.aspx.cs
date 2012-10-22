using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.EnterpriseServices;
using System.Reflection;

using Voodoo;
using Voodoo.Basement;

namespace Web.e.admin.Job.Company
{
    public partial class Edit :AdminBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadInfo();
            }
        }

        protected void LoadInfo()
        {
            foreach (var item in JobAction.CompanyType)
            {
                ddl_CompanyType.Items.Add(new ListItem(item.Value, item.Key.ToS()));
            }

            foreach (var item in JobAction.EmployeeCount)
            {
                ddl_EmployeeCount.Items.Add(new ListItem(item.Value, item.Key.ToS()));
            }

            int id = WS.RequestInt("id");

            DataEntities ent = new DataEntities();

            var users = from l in ent.User where l.Group == 2 select l;
            foreach (var user in users)
            {
                ddl_User.Items.Add(new ListItem(user.UserName, user.ID.ToS()));
            }

            var company = (from l in ent.JobCompany where l.ID == id select l).FirstOrDefault();
            if (company == null)
            {
                //int userid = WS.RequestInt("uid");
                //if (userid <= 0)
                //{
                //    Js.AlertAndGoback("新增企业参数错误，缺少用户信息");
                //}
                ////lb_user.Text = UserAction.GetUserByID(userid).UserName;
                
                return;
            }

            

            //lb_user.Text = UserAction.GetUserByID(company.UserID.ToInt32()).UserName;
            ddl_User.SelectedValue = company.UserID.ToS();
            txt_CompanyName.Text = company.CompanyName;
            txt_Industry.Text = company.Industry;
            txt_Intro.Text = company.Intro;
            txt_DayClick.Text = company.DayClick.ToS();

            ddl_CompanyType.SelectedValue = company.CompanyType.ToS();
            ddl_EmployeeCount.SelectedValue = company.EmployeeCount.ToS();
        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            int id = WS.RequestInt("id");
            //int userid = WS.RequestInt("uid");
            DataEntities ent = new DataEntities();

            JobCompany com = new JobCompany();
            if (id > 0)
            {
                com = (from l in ent.JobCompany where l.ID == id select l).FirstOrDefault();
            }

            com.CompanyName = txt_CompanyName.Text;
            com.CompanyType = ddl_CompanyType.SelectedValue.ToInt32();
            com.EmployeeCount = ddl_EmployeeCount.SelectedValue.ToInt32();
            com.Industry = txt_Industry.Text;
            com.Intro = txt_Intro.Text;
            com.UserID = ddl_User.SelectedValue.ToInt32();
            com.DayClick = txt_DayClick.Text.ToInt32(0);
            if (id > 0 && com != null)
            {

            }
            else
            {
                //com.UserID = userid;
                ent.AddToJobCompany(com);
            }
            ent.SaveChanges();
            ent.Dispose();
            Js.AlertAndChangUrl("保存成功！","List.aspx");
        }

    }
}