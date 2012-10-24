using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Voodoo;
using Voodoo.Basement;

namespace Web.e.admin.Job.Company
{
    public partial class List : AdminBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (WS.RequestString("action") == "del")
            {
                Button1_Click(sender, e);
            }
            if (!IsPostBack)
            {
                foreach (var item in JobAction.CompanyType)
                {
                    ddl_Type.Items.Add(new ListItem(item.Value, item.Key.ToS()));
                }
                foreach (var item in JobAction.EmployeeCount)
                {
                    ddl_EmployeeCount.Items.Add(new ListItem(item.Value, item.Key.ToS()));
                }

                
            }
            LoadInfo();
        }

        protected void LoadInfo()
        {
            DataEntities ent = new DataEntities();
            var q = from l in ent.JobCompany select l;
            if (txt_Key.Text.Length > 0)
            {
                q = q.Where(p => p.CompanyName.Contains(txt_Key.Text));
            }
            if (ddl_EmployeeCount.SelectedValue.Length > 0)
            {
                int ec = ddl_EmployeeCount.SelectedValue.ToInt32();
                q = q.Where(p => p.EmployeeCount == ec);
            }
            if (ddl_Type.SelectedValue.Length > 0)
            {
                int tp = ddl_Type.SelectedValue.ToInt32();
                q = q.Where(p => p.CompanyType == tp);
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
                var q = (from l in ent.JobCompany where l.ID == id select l).FirstOrDefault();
                var posts = from l in ent.JobPost where l.CompanyID == q.ID select l;
                var apps = from l in ent.JobApplicationRecord where l.CompanyID == q.ID select l;

                ent.DeleteObjects(apps);
                ent.DeleteObjects(posts);
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