using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.IO;
using System.Data;
using Voodoo;
using Voodoo.Data;
using Voodoo.Basement;
using Voodoo.Setting;

namespace Web.e.admin.Info
{
    public partial class InfoTypeList : AdminBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (WS.RequestString("action") == "del")
            {
                btn_Del_Click(sender, e);
            }
            if (!IsPostBack)
            {
                BindList();
            }
        }

        protected void btn_Del_Click(object sender, EventArgs e)
        {
            var ids = WS.RequestString("id").Split(',').ToList();
            DataEntities ent = new DataEntities();
            var qs = (from l in ent.InfoType where ids.IndexOf(l.id.ToS()) > 0 select l).ToList();
            foreach (var q in qs)
            {
                ent.DeleteObject(q);
            }

            ent.SaveChanges();
            ent.Dispose();
        }
        protected void BindList()
        {
            using (DataEntities ent = new DataEntities())
            {
                rp_list.DataSource = from l in ent.InfoType select l;
                rp_list.DataBind();
            }
        }
    }
}