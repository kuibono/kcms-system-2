using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Voodoo;
using Voodoo.Basement;

namespace Web.e.Job
{
    public partial class DownResume : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = WS.RequestInt("id");
            DownResumeFile(id);
        }

        protected void DownResumeFile(int userID)
        {
            using(DataEntities ent=new DataEntities())
            {
                var files = from l in ent.JobResumeFile where l.UserID == userID select l;
                if (files.Count() == 0)
                {
                    Js.AlertAndClose("这个用户没有上传简历");
                }
                else
                {
                    Response.Redirect(files.First().FilePath);
                }
            }
        }
    }
}