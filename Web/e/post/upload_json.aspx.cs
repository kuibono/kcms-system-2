using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Voodoo;
using Voodoo.Basement;

namespace Web.e.post
{
    public partial class upload_json : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Result r = new Result();

            HttpPostedFile file = Request.Files[0];
            if (file == null)
            {
                r.Success = false;
                r.Text = "没有任何文件需要上传";
            }
            else
            {
                r = BasePage.UpLoadFile(file, WS.RequestInt("class", 0));
            }

            string json="";
            if (r.Success == false)
            {
                json = "{\"error\":1,\"message\":\"" + r.Text + "\"}";
            }
            else
            {
                json = "{\"error\":0,\"url\":\"" + r.Text + "\"}";
            }

            Response.Clear();
            Response.Write(json);

        }
    }
}
