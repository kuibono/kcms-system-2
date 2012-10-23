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
    public partial class App : BasePage
    {
        public string ResumeOpen = "";
        public string Image = "";

        public string count = "0";

        User u = UserAction.opuser;

        protected void Page_Load(object sender, EventArgs e)
        {
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

            ResumeOpen = r.IsResumeOpen == true ? "简历完全开放" : "简历关闭";
            Image = r.Image;

            var list = from l in ent.JobApplicationRecord
                       from com in ent.JobCompany
                       from p in ent.JobPost
                       where
                          l.UserID == u.ID
                          && l.CompanyID == com.ID
                          && l.PostID == p.ID
                       select new { 
                         l.ID,
                         l.CompanyID,
                         com.CompanyName,
                         Pid=p.ID,
                         p.Title,
                         l.ApplicationTime

                       };
            pager.RecordCount = list.Count();
            count = pager.RecordCount.ToS();
            int page=WS.RequestInt("page",1);
            rp_lis.DataSource = list.OrderByDescending(p => p.ApplicationTime).Skip((page - 1) * pager.PageSize).Take(pager.PageSize);
            rp_lis.DataBind();

        }
    }
}