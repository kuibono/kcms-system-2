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

namespace Web.e.post
{
    public partial class PostList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataEntities ent = new DataEntities();

            if (WS.RequestString("action") == "del")
            {
                int id = WS.RequestInt("id");
                var news = (from l in ent.News where l.ID == id select l).FirstOrDefault();

                if (id > 0)
                {
                    ent.DeleteObject(news);
                    ent.SaveChanges();
                }
            }
            ent.Dispose();

            if (!IsPostBack)
            {
                BindList();
            }
        }

        protected void BindList()
        {
            using (DataEntities ent = new DataEntities())
            {
                rp_list.DataSource = //NewsView.GetModelList(string.Format("AutorID={0}", UserAction.opuser.ID));
                    from l in ent.News where l.AutorID == UserAction.opuser.ID select l;
                rp_list.DataBind();
            }
        }
    }
}
