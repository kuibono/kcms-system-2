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
            if (user.DefaultResumeFile() == null)
            {
                (new Result { Success = false, Text = "您还没有上传简历，请上传简历之后进行投递！" }).ResponseJson();
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

                #region 发送邮件

                var s = Voodoo.Basement.Model.JobSetting.Get();

                //获取公司邮箱
                var company = (from l in ent.JobCompany
                               from p in ent.JobPost
                               where l.ID == p.CompanyID
                               && p.ID == postID
                               select l).FirstOrDefault();

                if (s.SendMail&&company.MailAddress.IsNullOrEmpty()==false)
                {
                    List<string> str_atts = new List<string>();

                    var atts = (from l in ent.JobResumeFile where l.UserID == user.ID select l).ToList();
                    foreach (var att in atts)
                    {
                        str_atts.Add(Server.MapPath(att.FilePath));
                    }

                    Voodoo.Net.Mail.SMTP.SentMail(s.From,
                        s.LoginName,
                        s.Password,
                        company.MailAddress,//user to
                        s.FromText,
                        s.Subject,
                        s.MailBody,
                        s.SmtpHost,
                        "",
                        str_atts);

                }

                #endregion

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