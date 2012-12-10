using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Voodoo;
using Voodoo.Basement;
using Voodoo.Setting;

namespace Web.e.admin.template
{
    public partial class VarTemplateEdit : AdminBase
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
                if (id < 0)
                {
                    return;
                }
                txt_VarName.Enabled = false;
                TemplateVar tl = (from l in ent.TemplateVar where l.ID == id select l).FirstOrDefault();
                txt_VarName.Text = tl.VarName;
                txt_Content.Text = tl.Content;
            }
        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            DataEntities ent = new DataEntities();
            int id = WS.RequestInt("id");
            TemplateVar tl = new TemplateVar();
            try
            {
                tl = (from l in ent.TemplateVar where l.ID == id select l).First();
            }
            catch { }

            tl.VarName = txt_VarName.Text; 
            tl.Content = txt_Content.Text.Replace("'", "''");

            if (tl.ID==null||tl.ID <= 0)
            {
                ent.AddToTemplateVar(tl);
            }
            ent.SaveChanges();

            var pages = (from l in ent.TemplatePage where l.CreateWith == 5 select l).ToList();
            TemplateHelper th = new TemplateHelper();
            foreach (var p in pages)
            {
                try
                {
                    string html = th.GetStatisPage(p.id);
                    Voodoo.IO.File.Write(Server.MapPath(p.FileName), html);
                }
                catch { }
            }

            ent.Dispose();
            Js.AlertAndChangUrl("保存成功！", "VarTemplateList.aspx");

            
        }
    }
}
