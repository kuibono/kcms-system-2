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

namespace Web.e.admin.user
{
    public partial class UserFormEdit : AdminBase
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
                UserForm f = (from l in ent.UserForm where l.ID == id select l).FirstOrDefault();
                if (f.ID < 0)
                {
                    return;
                }
                txt_FormName.Text = f.FormName;
                txt_Content.Text = f.Content;
            }
        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            DataEntities ent = new DataEntities();
            int id = WS.RequestInt("id");
            UserForm f = (from l in ent.UserForm where l.ID == id select l).FirstOrDefault();
            f.FormName = txt_FormName.Text;
            f.Content = txt_Content.Text.TrimDbDangerousChar();

            if (f.ID <= 0)
            {
                ent.AddToUserForm(f);
            }
            ent.SaveChanges();
            ent.Dispose();

            Js.AlertAndChangUrl("保存成功！", "UserFormList.aspx");
        }
    }
}
