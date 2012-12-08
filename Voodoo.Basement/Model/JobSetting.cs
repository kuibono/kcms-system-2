using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Voodoo.Basement.Model
{
    public class JobSetting
    {
        /// <summary>
        /// 申请职位的时候是否发送邮件
        /// </summary>
        public bool SendMail { get; set; }

        /// <summary>
        /// 发件邮箱地址
        /// </summary>
        public string From { get; set; }

        /// <summary>
        /// 发件人姓名
        /// </summary>
        public string FromText { get; set; }

        /// <summary>
        /// 登录帐号
        /// </summary>
        public string LoginName { get; set; }

        /// <summary>
        /// 登录密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// SMTP服务器
        /// </summary>
        public string SmtpHost { get; set; }

        /// <summary>
        /// 邮件标题
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// 邮件内容
        /// </summary>
        public string MailBody { get; set; }

        /// <summary>
        /// 获取该站点的Job配置参数
        /// </summary>
        /// <returns></returns>
        public static JobSetting Get()
        {
            if (Voodoo.Cache.Cache.GetCache("_JobSetting") == null)
            {
                string path = System.Web.HttpContext.Current.Server.MapPath("~/Config/JobSetting.xml");
                var settings=(JobSetting)Voodoo.IO.XML.DeSerialize(typeof(JobSetting), Voodoo.IO.File.Read(path));
                Voodoo.Cache.Cache.SetCache("_JobSetting", settings, path);
            }
            return (JobSetting)Voodoo.Cache.Cache.GetCache("_JobSetting");
            
        }

        /// <summary>
        /// 保存参数
        /// </summary>
        public void Save()
        {
            string path = System.Web.HttpContext.Current.Server.MapPath("~/Config/JobSetting.xml");
            Voodoo.IO.XML.SaveSerialize(this, path);
        }
    }
}
