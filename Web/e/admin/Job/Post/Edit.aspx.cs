﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Voodoo;
using Voodoo.Basement;

namespace Web.e.admin.Job.Post
{
    public partial class Edit : AdminBase
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

            var p = (from l in ent.JobPost where l.ID == id select l).FirstOrDefault();
            if (p == null)
            {
                return;
            }

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

            if (p.ID <= 0)
            {
                ent.AddToJobPost(p);
            }
            ent.SaveChanges();
            ent.Dispose();

            Js.AlertAndChangUrl("保存成功！", "List.aspx");
        }

    }
}