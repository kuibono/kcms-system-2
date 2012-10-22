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
    public partial class List : AdminBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (WS.RequestString("action") == "del")
            {
                Button1_Click(sender, e);
            }
            LoadInfo();
        }

        protected void LoadInfo()
        {
            DataEntities ent = new DataEntities();
            var q = from a in ent.JobApplicationRecord
                    from c in ent.JobCompany
                    from u in ent.User
                    from r in ent.JobResumeInfo
                    from p in ent.JobPost
                    where
                    a.UserID == u.ID
                    && a.ResumeID == r.ID
                    && a.PostID == p.ID
                    && a.CompanyID == c.ID
                    select new { 
                        a.ID,
                        u.UserName,
                        c.CompanyName,
                        p.Title,
                        rTitle=r.Title,
                        a.ApplicationTime,
                        a.CompanyID,
                        a.PostID,
                        a.ResumeID,
                        a.UserID
                    };

            if (txt_Key.Text.Length > 0)
            {
                q = from l in q
                    where
                        l.UserName.Contains(txt_Key.Text)
                        || l.CompanyName.Contains(txt_Key.Text)
                        || l.Title.Contains(txt_Key.Text)
                        || l.rTitle.Contains(txt_Key.Text)
                    select l;
            }
            int id = WS.RequestInt("id");
            if (id > 0)
            {
                q = from l in q where l.UserID == id select l;
            }

            pager.RecordCount = q.Count();
            rp_list.DataSource = q.OrderByDescending(p => p.ID).Skip((pager.CurrentPageIndex - 1) * pager.PageSize).Take(pager.PageSize);
            rp_list.DataBind();
            ent.Dispose();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var ids = WS.RequestString("id").Split(',').ToList().ToInt64();
            DataEntities ent = new DataEntities();
            foreach (var id in ids)
            {
                var q = (from l in ent.JobApplicationRecord where l.ID == id select l).FirstOrDefault();
                ent.DeleteObject(q);
            }
            ent.SaveChanges();
            ent.Dispose();
            Js.AlertAndChangUrl("删除成功！", "List.aspx");
        }

        protected void pager_PageChanged(object sender, EventArgs e)
        {
            LoadInfo();
        }
    }
}