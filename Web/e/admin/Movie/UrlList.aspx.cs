using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;

using Voodoo;
using Voodoo.Basement;
using Voodoo.Setting;


namespace Web.e.admin.Movie
{
    public partial class UrlList : AdminBase
    {
        protected int id = WS.RequestInt("movieid");
        protected string type = WS.RequestString("type");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindList();
            }
            if (WS.RequestString("action") == "del")
            {
                Button1_Click(sender, e);
            }
        }

        protected void BindList()
        {
            DataEntities ent = new DataEntities();

            switch (type)
            {
                case "kuaib":
                    var cpl = from l in ent.MovieUrlKuaib where l.MovieID == id select l;
                    rp_List.DataSource = cpl;
                    rp_List.DataBind();
                    break;
                case "baidu":
                    var cpl_baidu = from l in ent.MovieUrlBaidu where l.MovieID == id select l;
                    rp_List.DataSource = cpl_baidu;
                    rp_List.DataBind();
                    break;
                case "mag":
                    var cpl_mag = from l in ent.MovieUrlMag where l.MovieID == id select l;
                    rp_List.DataSource = cpl_mag;
                    rp_List.DataBind();
                    break;
                default:
                    var df = from l in ent.MovieUrlKuaib where l.MovieID == id select l;
                    rp_List.DataSource = df;
                    rp_List.DataBind();
                    break;
            }
            ent.Dispose();
        }

        protected void btn_disable_Click(object sender, EventArgs e)
        {
            
        }

        protected void btn_enable_Click(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var ids = WS.RequestString("id").Split(',').ToList();
            DataEntities ent = new DataEntities();

            switch (type)
            {
                case "kuaib":
                    var qs = from l in ent.MovieUrlKuaib where ids.IndexOf(l.id.ToString()) > 0 select l;
                    foreach (var q in qs)
                    {
                        ent.DeleteObject(q);
                    }
                    break;
                case "baidu":
                    var bs = from l in ent.MovieUrlBaidu where ids.IndexOf(l.id.ToString()) > 0 select l;
                    foreach (var q in bs)
                    {
                        ent.DeleteObject(q);
                    }
                    break;
                case "mag":
                    var ms = from l in ent.MovieUrlMag where ids.IndexOf(l.id.ToString()) > 0 select l;
                    foreach (var q in ms)
                    {
                        ent.DeleteObject(q);
                    }
                    break;
            }
            ent.SaveChanges();
            ent.Dispose();
            Response.Redirect(string.Format("UrlList.aspx?bookid={0}", id));
        }
    }
}