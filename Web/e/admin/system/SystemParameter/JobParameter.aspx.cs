using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Voodoo;
using Voodoo.Data;
using Voodoo.Basement;
using Voodoo.Setting;

namespace Web.e.admin.system.SystemParameter
{
    public partial class JobParameter : AdminBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    LoadInfo();
                }
                catch { }
            }
        }

         /// <summary>
        /// 加载配置
        /// </summary>
        protected void LoadInfo()
        {
            var s = Voodoo.Basement.Model.JobSetting.Get();
            chk_SendMail.Checked = s.SendMail;
            txt_From.Text = s.From;
            txt_FromText.Text = s.FromText;
            txt_LoginName.Text = s.LoginName;
            txt_Password.Text = s.Password;
            txt_SmtpHost.Text = s.SmtpHost;
            txt_Subject.Text = s.Subject;
            txt_MailBody.Text = s.MailBody;
        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            Voodoo.Basement.Model.JobSetting s;
            try
            {
                s = Voodoo.Basement.Model.JobSetting.Get();
            }
            catch {
                s = new Voodoo.Basement.Model.JobSetting();
            }
            s.SendMail = chk_SendMail.Checked;
            s.From = txt_From.Text;
            s.FromText = txt_FromText.Text;
            s.LoginName = txt_LoginName.Text;
            s.Password = txt_Password.Text;
            s.SmtpHost = txt_SmtpHost.Text;
            s.Subject = txt_Subject.Text;
            s.MailBody = txt_MailBody.Text;
            s.Save();
            Js.Alert("保存成功！");
        }
    }
}