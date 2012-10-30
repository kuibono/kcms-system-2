using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Voodoo;
using Voodoo.Basement;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.IO;


namespace Web.e.admin.system.Basement
{
    public partial class AreaManagement : AdminBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.ToS() == "loadarea")
            {
                LoadAreas();
            }
        }

        protected void LoadAreas()
        {
            DataEntities ent = new DataEntities();
            var areas = from l in ent.Area select l;
            var provinces = from l in ent.Province select l;
            var citis = from l in ent.City select l;

            var ars=new List<A>();
            foreach (var a in areas)
            {
                var subps = from l in provinces where l.AreaID == a.ID select l;
                var aa = new A();
                aa.children=new List<A>();

                foreach (var subp in subps)
                {
                    var ap = new A();
                    var subcs = from l in citis where l.ProvinceID == subp.ID select l;
                    ap.children = new List<A>();
                    foreach (var subc in subcs)
                    {
                        var ac = new A();
                        ac.children = null;
                        ac.id = subc.id;
                        ac.Name = subc.city1;
                        ac.ShowInIndex = subc.ShowInIndex.ToBoolean();
                        ac.ShowInNav = subc.ShowInNav.ToBoolean();
                        ac.type = "city";
                        ap.children.Add(ac);
                    }
                    ap.id = subp.ID;
                    ap.Name = subp.province1;
                    ap.ShowInIndex = subp.ShowInIndex.ToBoolean();
                    ap.ShowInNav = false;
                    ap.type = "province";
                    aa.children.Add(ap);
                }
                aa.id = a.ID;
                aa.Name = a.Name;
                aa.ShowInIndex = a.ShowInIndex.ToBoolean();
                aa.ShowInNav = false;
                aa.type = "area";
                ars.Add(aa);
            }


            JsonSerializer s = new JsonSerializer();
            StringWriter r = new StringWriter();
            s.Serialize(r, ars);
            Response.Clear();
            Response.Write(r.ToS());
            Response.End();
            ent.Dispose();
            
        }

    }

    public class A
    {
        public List<A> children { get; set; }

        public int id { get; set; }

        public string Name { get; set; }

        public bool ShowInIndex { get; set; }

        public bool ShowInNav { get; set; }

        public string type { get; set; }
    }
}