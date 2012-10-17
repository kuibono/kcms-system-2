using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Voodoo;
using Voodoo.Basement;

namespace Web.e.admin.Job.Application
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
            long id = WS.RequestLong("id");
            if (id <= 0)
            {
                return;
            }
            DataEntities ent = new DataEntities();
            var q = (from a in ent.JobApplicationRecord
                     from c in ent.JobCompany
                     from u in ent.User
                     from r in ent.JobResumeInfo
                     from p in ent.JobPost
                     where
                     a.UserID == u.ID
                     && a.ResumeID == r.ID
                     && a.PostID == p.ID
                     && a.CompanyID == c.ID
                     select new
                     {
                         a.ID,
                         u.UserName,
                         c.CompanyName,
                         p.Title,
                         rTitle = r.Title,
                         a.ApplicationTime,
                         a.Message
                     }).FirstOrDefault();

            if (q.ID > 0)
            {
                lb_User.Text = q.UserName;
                lb_Company.Text = q.CompanyName;
                lb_Post.Text = q.Title;
                lb_Resume.Text = q.rTitle;
                lb_Time.Text = q.ApplicationTime.ToS();
                txt_Intro.Text = q.Message;
            }

            ent.Dispose();
        }


    }
}