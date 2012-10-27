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
    public partial class Edit : AdminBase
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

            int id = WS.RequestInt("id");

            DataEntities ent = new DataEntities();

            var q = (from l in ent.AdGroup where l.ID == id select l).FirstOrDefault();
            if (q == null)
            {
                return;
            }
            txt_Name.Text = q.Name;
            txt_Height.Text = q.height.ToS();
            txt_Width.Text = q.width.ToS();
        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            int id = WS.RequestInt("id");
            DataEntities ent = new DataEntities();

            Voodoo.Basement.AdGroup q = new Voodoo.Basement.AdGroup();
            if (id > 0)
            {
                q = (from l in ent.AdGroup where l.ID == id select l).FirstOrDefault();
            }
            q.Name = txt_Name.Text;
            q.height = txt_Height.Text.ToInt32();
            q.width = txt_Width.Text.ToInt32();
            
            if (id > 0 && q != null)
            {

            }
            else
            {
                //com.UserID = userid;
                ent.AddToAdGroup(q);
            }
            ent.SaveChanges();
            ent.Dispose();
            Js.AlertAndChangUrl("保存成功！", "List.aspx");
        }


    }
}