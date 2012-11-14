using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.SessionState;
using System.Web;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using Voodoo;
using Voodoo.UI;

namespace Web.e.admin.tool
{
    /// <summary>
    /// $codebehindclassname$ 的摘要说明
    /// </summary>
    public class safecode : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext Context)
        {
            VerifyCode vc = new VerifyCode();
            vc.FontSize = 11;
            vc.Padding = 3;
            vc.CreateImageOnPage(vc.CreateForWordCode(), Context);
        }

        // Properties
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
