﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Voodoo;
using Voodoo.Basement;

namespace Web.Dynamic.Job
{
    public partial class Job : BasePage
    {

        public long id { get; set; }
        public int CompanyID = 0;
        public string Title = "";
        public string CompanyName = "";
        public string PostTime = "";
        public string Province = "";
        public string City = "";
        public string Exp = "";
        public string Salary = "";
        public string Edu = "";
        public string EmpCount = "";
        public string Intro = "";
        public string CompIntro = "";
        public string RelaJobs = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            LoadInfo();
        }

        protected void LoadInfo()
        {
            id = WS.RequestLong("id");
            if (id < 0)
            {
                return;
            }

            DataEntities ent = new DataEntities();
            var j = (from l in ent.JobPost where l.ID == id select l).FirstOrDefault();
            var c = (from l in ent.JobCompany where l.ID == j.CompanyID select l).FirstOrDefault();
            Title=j.Title;
            CompanyID = c.ID;
            CompanyName=c.CompanyName;
            PostTime=j.PostTime.ToDateTime().ToString("yyyy-MM-dd");
            Province = JobAction.GetProviceName(j.Province.ToInt32());
            City = JobAction.GetCityName(j.City.ToInt32());
            Exp = JobAction.GetExpressionsName(j.Expressions.ToInt32());
            Salary = JobAction.GetSalaryDegreeName(j.Salary.ToInt32());
            Edu = JobAction.GetEduName(j.Edu.ToInt32());
            EmpCount = j.EmployNumber == 0 ? "若干" : j.EmployNumber.ToS();
            Intro = j.Intro;
            CompIntro = c.Intro;

            RelaJobs = Functions.getpostlist("5", 
                "0", 
                string.Format("t.Title='{0}' and t.Id!={1}",j.Title,j.ID), 
                "t.id desc",
                "<tr><td height=\"80\"style=\"border-bottom: 1px solid #eeeeee\"><table width=\"810\"align=\"center\"border=\"0\"cellspacing=\"0\"cellpadding=\"0\"><tr><td align=\"left\"><table width=\"680\"border=\"0\"cellspacing=\"0\"cellpadding=\"0\"align=\"left\"><tr><td align=\"left\"class=\"job_title\"><a href=\"Job.aspx?id={id}\">{title}</a></td></tr><tr><td align=\"left\"><table width=\"610\"border=\"0\"cellspacing=\"0\"cellpadding=\"0\"><tr><td align=\"left\"class=\"job_compangy\"><a href=\"Company.aspx?id={companyid}\">{companyname}</a></td><td align=\"left\"class=\"job_qt\">规模未知/学历{edu}/经验{expressions}</td><td align=\"left\"class=\"job_qt1\">月薪<span>{salary}</span></td></tr></table></td></tr></table></td><td width=\"100\"align=\"center\"style=\"line-height: 24px; color: #666666\"><input type=\"button\"onclick=\"post({id})\"value=\"一键投递\"style=\"background: url(/skin/job/img/td.gif) no-repeat; width: 60px;height: 22px; color: #FFFFFF; border: 0px;\"/><br/>{posttime}</td></tr></table></td></tr>");
        }
    }
}