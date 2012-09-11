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


namespace Web.e.admin.system.friendlink
{
    public partial class LinkEdit : AdminBase
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
            using (DataEntities ent = new DataEntities())
            {
                int id = WS.RequestInt("id");
                Link l = (from ls in ent.Link where ls.ID == id select ls).FirstOrDefault();
                txt_Index.Text = l.Index.ToS();
                txt_LinkTitle.Text = l.LinkTitle;
                txt_Url.Text = l.Url;
            }

        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            DataEntities ent = new DataEntities();

            int id = WS.RequestInt("id");
            Link l = (from ls in ent.Link where ls.ID == id select ls).FirstOrDefault();

            l.Index = txt_Index.Text.ToInt32();
            l.LinkTitle = txt_LinkTitle.Text.TrimDbDangerousChar();
            l.Url = txt_Url.Text.TrimDbDangerousChar();

            if (id <= 0)
            {
                ent.AddToLink(l);
            }
            ent.SaveChanges();
            ent.Dispose();

            CreatePage.GreateIndexPage();

            Js.AlertAndChangUrl("保存成功！","LinkList.aspx");
        }
    }
}
