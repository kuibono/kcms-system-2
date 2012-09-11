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
using Voodoo.IO;
namespace Web.e.file
{
    public partial class addselect : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (DataEntities ent = new DataEntities())
            {
                DataList1.DataSource = from l in ent.File select l ;
                DataList1.DataBind();
            }
        }

        protected void btn_UpLoad_Click(object sender, EventArgs e)
        {
            if(FileUpload1.FileName.IsNullOrEmpty())
            {
                return;
            }
            Result r= BasePage.UpLoadFile(Request.Files["FileUpload1"], WS.RequestInt("class", 0));
            if (r.Success)
            {
                Js.Jump("?");
            }
            else
            {
                Js.AlertAndGoback(r.Text);
            }
            
        }
    }
}
