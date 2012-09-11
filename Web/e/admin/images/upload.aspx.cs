using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Voodoo;
using Voodoo.Basement;

namespace Web.e.admin.images
{
    public partial class upload :AdminBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpPostedFile file = Request.Files[0];

            ImageAction.UpLoadImage(file, WS.RequestInt("id"));
        }
    }
}
