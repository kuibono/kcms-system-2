using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Voodoo;
using Voodoo.Basement;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace Web.e.Job
{
    public partial class UploadResume : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            User u=UserAction.opuser;
            if (u.ID <= 0)
            {
                Js.AlertAndGoback("对不起，您还没有登录，不能上传简历！");
            }
            

            HttpPostedFile file = Request.Files[0];
            JobAction.SaveResume(file, u.ID);

            Js.AlertAndChangUrl("简历上传成功！", "/Dynamic/Job/ResumeBasic.aspx");

        }
    }
}