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
    public partial class GroupEdit : AdminBase
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
            DataEntities ent = new DataEntities();

            ddl_RegForm.DataSource = from l in ent.UserForm select l;
            ddl_RegForm.DataTextField = "FormName";
            ddl_RegForm.DataValueField = "ID";
            ddl_RegForm.DataBind();

            int id = WS.RequestInt("id");
            UserGroup g = (from l in ent.UserGroup where l.ID == id select l).FirstOrDefault();
            if (null==g)
            {
                return;
            }
            txt_GroupName.Text = g.GroupName;
            txt_grade.Text = g.Grade.ToS();
            txt_MaxPost.Text = g.MaxPost.ToS();
            chk_PostAotuAudit.Checked = g.PostAotuAudit.ToBoolean();
            chk_EnableReg.Checked = g.EnableReg.ToBoolean();
            chk_RegAutoAudit.Checked = g.RegAutoAudit.ToBoolean();
            ddl_RegForm.SelectedValue = g.RegForm.ToS();

            ent.Dispose();
        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            DataEntities ent = new DataEntities();
            int id = WS.RequestInt("id");
            UserGroup g = (from l in ent.UserGroup where l.ID == id select l).FirstOrDefault();
            if (g == null)
            {
                g = new UserGroup();
            }

            g.GroupName = txt_GroupName.Text;
            g.Grade = txt_grade.Text.ToInt32();
            g.MaxPost = txt_MaxPost.Text.ToInt32();
            g.PostAotuAudit = chk_PostAotuAudit.Checked;
            g.EnableReg = chk_EnableReg.Checked;
            g.RegAutoAudit = chk_RegAutoAudit.Checked;
            g.RegForm = ddl_RegForm.SelectedValue.ToInt32();

            if (g.ID <= 0)
            {
                ent.AddToUserGroup(g);  
            }
            ent.SaveChanges();
            ent.Dispose();
            Js.AlertAndChangUrl("保存成功！", "GroupList.aspx");

        }
    }
}
