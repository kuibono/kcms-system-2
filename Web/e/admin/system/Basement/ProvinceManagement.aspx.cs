using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Voodoo;
using Voodoo.Basement;
using System.Text;

namespace Web.e.admin.system.Basement
{
    public partial class ProvinceManagement : AdminBase
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
            StringBuilder sb = new StringBuilder();
            using (DataEntities ent = new DataEntities())
            {
                
                var qs = from l in ent.Province select l;
                foreach (var q in qs)
                {
                    sb.AppendLine(q.province1);
                }
            }
            txt_Provinces.Text = sb.ToS();

        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            var ps = txt_Provinces.Text.Split('\n');
            using (DataEntities ent = new DataEntities())
            {
                var qs = (from l in ent.Province select l).ToList();
                foreach (var p in ps)
                {
                    var str_p=p.Trim();
                    if (qs.Where(o => o.province1 == str_p).Count() == 0)
                    {
                        var pro = new Province();
                        pro.province1 = str_p;
                        pro.sz_code = "";
                        pro.Rome = "";
                        pro.zm_code = "";
                        ent.AddToProvince(pro);
                    }
                }

                ent.SaveChanges();
                Js.AlertAndGoback("保存成功！");
            }
        }
    }
}