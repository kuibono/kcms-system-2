using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Voodoo;
using Voodoo.Basement;
namespace Web.Dynamic.Job
{
    public partial class Password : BasePage
    {
        public string ResumeOpen = "";
        public string Image = "";

        User u = UserAction.opuser;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadInfo();
            }
        }

        protected void LoadInfo()
        {
            
            if (u.ID < 0)
            {
                Js.AlertAndChangUrl("您还没有登录，请登录或注册后进入简历管理！", "/");
            }
            DataEntities ent = new DataEntities();
            JobResumeInfo r = new JobResumeInfo();
            try
            {
                r = (from l in ent.JobResumeInfo where l.UserID == u.ID select l).First();
            }
            catch
            {
                r.UserID = u.ID;
                r.IsResumeOpen = true;
                r.Image = "/u/ResumeFace/0.jpg";
                r.Title = u.UserName + "的简历";
                ent.SaveChanges();
            }
            ResumeOpen = r.IsResumeOpen == true ? "简历完全开放" : "简历关闭";
            Image = r.Image;

        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            if (txt_New.Text != txt_NewConf.Text)
            {
                Js.AlertAndGoback("两次密码输入不一致");
                return;
            }
            else if (Voodoo.Security.Encrypt.Md5(txt_Old.Text) != u.UserPass)
            {
                Js.AlertAndGoback("密码错误，请重新输入！");
                return;
            }
            else
            {
                DataEntities ent = new DataEntities();

                var user = (from l in ent.User where l.ID == u.ID select l).FirstOrDefault();
                user.UserPass = Voodoo.Security.Encrypt.Md5(txt_New.Text);
                ent.SaveChanges();
                ent.Dispose();
                Js.AlertAndChangUrl("密码修改成功，请重新登录系统！", "/e/member/Logout.aspx");

            }
        }
    }
}