using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Voodoo;
using Voodoo.Basement;

namespace Web.e.admin.Ad.AdGroup
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
            var q = from l in ent.AdGroup select l;
            if (txt_Key.Text.Length > 0)
            {
                q = q.Where(p => p.Name.Contains(txt_Key.Text));
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
                var q = (from l in ent.AdGroup where l.ID == id select l).FirstOrDefault();
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