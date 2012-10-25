using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

using Voodoo;
using Voodoo.Basement;

namespace Web.e.admin.system.Basement
{
    public partial class CityManagement : AdminBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadInfo();
                ddl_Province_SelectedIndexChanged(sender, e);
            }
        }

        protected void LoadInfo()
        {
            using (DataEntities ent = new DataEntities())
            {

                var qs = from l in ent.Province select l;
                foreach (var q in qs)
                {
                    ddl_Province.Items.Add(new ListItem(q.province1, q.ID.ToS()));
                }
            }
        }

        protected void ddl_Province_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectID = ddl_Province.SelectedValue.ToInt32();
            StringBuilder sb = new StringBuilder();

            using (DataEntities ent = new DataEntities())
            {
                var qs=from l in ent.City where l.ProvinceID==selectID select l;
                foreach(var q in qs)
                {
                    sb.AppendLine(q.city1);
                }
            }

            txt_Provinces.Text = sb.ToS();
        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            int selectID = ddl_Province.SelectedValue.ToInt32();
            string selectText = ddl_Province.SelectedItem.Text;
            var ps = txt_Provinces.Text.Split('\n');

            using (DataEntities ent = new DataEntities())
            {
                var cts = (from l in ent.City where l.ProvinceID==selectID select l).ToList();
                foreach (var p in ps)
                {
                    var str_p = p.Trim();
                    if (cts.Where(o => o.city1 == str_p).Count() == 0)
                    {
                        var ct = new City();
                        ct.city1 = str_p;
                        ct.Hot = 0;
                        ct.ProvinceID = selectID;
                        ct.Rome = "";
                        ct.state = selectText;
                        ct.sz_code = "";
                        ct.zm_code = "";

                        ent.AddToCity(ct);
                    }
                }

                ent.SaveChanges();
                Js.AlertAndGoback("保存成功！");
            }


        }


    }
}