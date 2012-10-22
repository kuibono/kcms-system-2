using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

using Voodoo;
using Voodoo.Data;
using Voodoo.Basement;
using Voodoo.Setting;
using Voodoo.LinqExt;

namespace Web.e.admin.template
{
    public partial class PageTemplateList : AdminBase
    {
        protected string[] CREATE_WITH = "不生成,首页,列表,内容,章节/播放/图片".Split(',');
        protected void Page_Load(object sender, EventArgs e)
        {
            if (WS.RequestString("action") == "del")
            {
                btn_Del_Click(sender, e);
            }
            if (!IsPostBack)
            {
                BindList();
            }
        }

        protected void BindList()
        {
            using (DataEntities ent = new DataEntities())
            {
                rp_list.DataSource = from l in ent.TemplatePage select l;
                rp_list.DataBind();
            }
        }

        protected void btn_Del_Click(object sender, EventArgs e)
        {
            
            DataEntities ent = new DataEntities();
            var ids = WS.RequestString("id").Split(',').ToList().ToInt32();

            foreach (var id in ids)
            {
                var page = (from l in ent.TemplatePage where l.id == id select l).FirstOrDefault();
                ent.DeleteObject(page);
                FileInfo f = new FileInfo(Server.MapPath(page.FileName));
                if (f.Exists)
                {
                    try
                    {
                        f.Delete();
                    }
                    catch { }
                }
            }

            ent.SaveChanges();
            ent.Dispose();
            BindList();
        }
    }
}