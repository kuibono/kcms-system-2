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
            ent.Dispose();
            Js.AlertAndGoback("保存成功！");
        }
    }
}
