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

namespace Web.e.admin.template
{
    public partial class ContentTemplateEdit : AdminBase
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

            ddl_SysModel.DataSource = TemplateAction.AllSysModel;
            ddl_SysModel.DataTextField = "ModelName";
            ddl_SysModel.DataValueField = "ID";
            ddl_SysModel.DataBind();

            int id = WS.RequestInt("id");
            TemplateContent tl = (from l in ent.TemplateContent where l.ID == id select l).FirstOrDefault();
            txt_TempName.Text = tl.TempName;
            txt_TimeFormat.Text = tl.TimeFormat;
            txt_Content.Text = tl.Content;
            ddl_SysModel.SelectedValue = tl.SysModel.ToS();
            ent.Dispose();
        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            DataEntities ent = new DataEntities();
            int id = WS.RequestInt("id");
            TemplateContent tl = (from l in ent.TemplateContent where l.ID == id select l).FirstOrDefault();

            tl.TempName = txt_TempName.Text; ;
            tl.TimeFormat = txt_TimeFormat.Text;
            tl.Content = txt_Content.Text.Replace("'", "''");
            tl.SysModel = ddl_SysModel.SelectedValue.ToInt32();
            if (tl.ID <= 0)
            {
                tl.GroupID = 1;
                tl.SysModel = 1;
                ent.AddToTemplateContent(tl);
            }
            ent.SaveChanges();
            ent.Dispose();
            Js.AlertAndGoback("保存成功！");
        }
    }
}
