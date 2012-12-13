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

            string extName = Path.GetExtension(file.FileName).ToLower();
            int size = file.ContentLength;
            if (extName != ".doc" && extName != ".docx")
            {
                Js.AlertAndGoback("对不起，简历文件只允许上传微软Word格式(.doc|.docx)");
                return;
            }
            if (size > 500 * 1024)
            {
                Js.AlertAndGoback("对不起，简历大小请限制在500K以内！");
                return;
            }

            JobAction.SaveResume(file, u.ID);

            Js.AlertAndChangUrl("简历上传成功！", "/Dynamic/Job/ResumeBasic.aspx");

        }
    }
}