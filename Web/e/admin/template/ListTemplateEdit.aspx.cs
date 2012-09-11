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
    public partial class ListTemplateEdit : AdminBase
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
            ddl_SysModel.DataSource = TemplateAction.AllSysModel;
            ddl_SysModel.DataTextField = "ModelName";
            ddl_SysModel.DataValueField = "ID";
            ddl_SysModel.DataBind();

            int id = WS.RequestInt("id");
            DataEntities ent = new DataEntities();
            TemplateList tl = (from l in ent.TemplateList where l.ID == id select l).FirstOrDefault();
            ent.Dispose();

            txt_TempName.Text = tl.TempName;
            txt_CutKeywords.Text = tl.CutKeywords.ToS();
            txt_CutTitle.Text = tl.CutTitle.ToS();
            txt_ShowRecordCount.Text = tl.ShowRecordCount.ToS();
            txt_TimeFormat.Text = tl.TimeFormat;
            txt_Content.Text = tl.Content;
            txt_Listvar.Text = tl.ListVar;
            ddl_SysModel.SelectedValue = tl.SysModel.ToS();
        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            int id = WS.RequestInt("id");
            DataEntities ent = new DataEntities();
            TemplateList tl = (from l in ent.TemplateList where l.ID == id select l).FirstOrDefault();


            tl.TempName = txt_TempName.Text;
            tl.CutKeywords = txt_CutKeywords.Text.ToInt32();
            tl.CutTitle = txt_CutTitle.Text.ToInt32();
            tl.ShowRecordCount = txt_ShowRecordCount.Text.ToInt32();
            tl.TimeFormat = txt_TimeFormat.Text;
            tl.Content = txt_Content.Text.Replace("'", "''"); ;
            tl.ListVar = txt_Listvar.Text.Replace("'", "''"); ;
            tl.SysModel = ddl_SysModel.SelectedValue.ToInt32();
            if (tl.ID <= 0)
            {
                tl.GroupID = 1;
                tl.SysModel = 1;
                ent.AddToTemplateList(tl);
            }
            ent.SaveChanges();
            ent.Dispose();
            Js.AlertAndGoback("保存成功！");
        }
    }
}
