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
    public partial class Post : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string[] ids = WS.RequestString("id").Split(',');

            var user = UserAction.opuser;
            var resume = user.DefaultResume();
            if (user.ID < 0)
            {
                (new Result { Success = false, Text = "对不起，您还没有登录，请登录或注册后投递简历！" }).ResponseJson();
                return;
            }
            if (resume == null)
            {
                (new Result { Success = false, Text = "您还没有创建简历，请创建简历之后进行投递！" }).ResponseJson();
                return;
            }
            DataEntities ent = new DataEntities();
            foreach (var str_id in ids)
            {
                long postID = str_id.ToInt64();
                JobApplicationRecord r = new JobApplicationRecord();
                r.ApplicationTime = DateTime.Now;
                r.CompanyID = JobExtend.GetCompanyIDByPost(postID);
                r.Message = "";
                r.PostID = postID;
                r.ResumeID = resume.ID;
                r.Status = 0;
                r.UserID = user.ID;
                ent.AddToJobApplicationRecord(r);
            }
            try
            {
                ent.SaveChanges();
                ent.Dispose();
                (new Result { Success = true, Text = "简历投递成功！" }).ResponseJson();
                return;

            }
            catch (Exception ex)
            {
                (new Result { Success = false, Text =ex.Message }).ResponseJson();
                return;
            }


        }
    }
}