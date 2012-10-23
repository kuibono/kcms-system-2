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
            DataEntities ent = new DataEntities();
            JobResumeInfo r = (from l in ent.JobResumeInfo where l.UserID == u.ID select l).First();

            string fileName = string.Format("/u/Resume/{0}.doc",r.ID);
            BasePage.UpLoadFile(file, fileName);

            JobResumeFile rFile = new JobResumeFile();
            rFile.FileName = file.FileName;
            rFile.FilePath = fileName;
            rFile.ResumeID = r.ID;
            rFile.UserID = u.ID;
            ent.AddToJobResumeFile(rFile);


            Aspose.Words.Document doc = new Aspose.Words.Document(Server.MapPath(fileName));
            string Context = doc.GetText();

            StringBuilder sb = new StringBuilder();

            Match match = new Regex("男|女").Match(Context);
            string str_r = "";
            if (match.Success)
            {
                str_r = match.Groups[0].Value;
                if (str_r == "男")
                {
                    r.IsMale = true;
                }
                else
                {
                    r.IsMale = false;
                }
            }
            match = new Regex("[a-zA-Z\\._]*?@.*?\\.(com|net|org|cn|edu|gov)").Match(Context);
            if (match.Success)
            {
                r.Email = match.Groups[0].Value;
            }
            match = new Regex("姓名.{1,3}[^ ;,\\r]*").Match(Context);
            if (match.Success)
            {
                str_r = match.Groups[0].Value;
                str_r = str_r.Replace("姓名", "");
                r.ChineseName = str_r;
            }
            match = new Regex("[^ ：:]{2,20}?(大学|学院)").Match(Context);
            if (match.Success)
            {
                sb.AppendLine(match.Groups[0].Value);
            }
            match = new Regex("[0-9]{4}[-/年][0-9]{1,2}[-/月][0-9]{1,2}[日]{0,1}").Match(Context);
            if (match.Success)
            {
                str_r = match.Groups[0].Value;
                r.Birthday = str_r.ToDateTime();
            }

            match = new Regex("1[34578][0-9]{9}").Match(Context);
            if (match.Success)
            {
                str_r = match.Groups[0].Value;
                r.Mobile = str_r;
            }

            match = new Regex("0[1-9]{2,3}[- ]{0,1}[0-9]{7,8}").Match(Context);
            if (match.Success)
            {
                str_r = match.Groups[0].Value;
                r.Tel = str_r;
            }
            match = new Regex("(博士|硕士|本科|专科|大专|中专|初中)").Match(Context);
            if (match.Success)
            {
                sb.AppendLine(match.Groups[0].Value);
            }
            match = new Regex("[^ :：\r]+省[^ :：\r]*市[^ :：\r]*").Match(Context);
            if (match.Success)
            {
                str_r = match.Groups[0].Value;
                r.Address = str_r;
            }

            ent.SaveChanges();
            ent.Dispose();

            Js.AlertAndChangUrl("简历上传成功！", "/Dynamic/Job/ResumeBasic.aspx");

        }
    }
}