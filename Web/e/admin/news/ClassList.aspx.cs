using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Voodoo;
using Voodoo.Data;
using Voodoo.Basement;
using Voodoo.Setting;
using Ext.Net;

namespace Web.e.admin.news
{
    public partial class ClassList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (WS.RequestString("action") == "del")
            {
                DataEntities ent = new DataEntities();
                var ids = WS.RequestString("id").Split(',').ToList();
                var qs = from l in ent.Class where ids.IndexOf(l.ID.ToString()) > 0 select l;
                foreach (var q in qs)
                {
                    ent.DeleteObject(q);
                }

                ent.SaveChanges();
                ent.Dispose();

                Voodoo.Cache.Cache.SetCache("_NewClassList", null);
            }

            if (!IsPostBack)
            {
                LoadList();
            }
        }


        protected void LoadList()
        {
            List<Class> cls =ClassAction.Classes;
            rp_list.DataSource = cls;
            rp_list.DataBind();
        }

        protected void btn_order_Click(object sender, EventArgs e)
        {
            //顺序修改
        }


    }
}
