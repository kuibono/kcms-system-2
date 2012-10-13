using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Voodoo;
using Voodoo.Basement;
using Voodoo.Setting;

namespace Web.e.admin.user
{
    public partial class UserEdit : AdminBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadInfo();
            }
        }

        protected void LoadInfo()
        {
            DataEntities ent = new DataEntities();

            ddl_Group.DataSource = UserAction.GetUserGroups();
            ddl_Group.DataTextField = "GroupName";
            ddl_Group.DataValueField = "ID";
            ddl_Group.DataBind();

            int id = WS.RequestInt("id");
            User u = (from l in ent.User where l.ID == id select l).FirstOrDefault();
            if (u==null)
            {
                return;
            }

            txt_UserName.Text = u.UserName;
            txt_ChineseName.Text = u.ChineseName;
            txt_Email.Text = u.Email;
            txt_TelNumber.Text = u.Tel;
            txt_Mobile.Text = u.Mobile;
            txt_Website.Text = u.WebSite;
            txt_Image.Text = u.Image;
            txt_Address.Text = u.Address;
            txt_Zipcode.Text = u.ZipCode;
            txt_Intro.Text = u.Intro;

            ddl_Group.SelectedValue = u.Group.ToS();
            txt_Cent.Text = u.Cent.ToS();
            txt_PostCount.Text = u.PostCount.ToS();
            txt_QQ.Text = u.QQ;
            txt_Gtalk.Text = u.GTalk;
            txt_ICQ.Text = u.ICQ;
            //txt_Weibo.Text = u.Weibo;

            lb_LastLoginTime.Text = u.LastLoginTime.ToString();
            lb_LastLoginIP.Text = u.LastLoginIP;
            lb_LoginCount.Text = u.LoginCount.ToS();

            txt_StudentNo.Text = u.StudentNo;
            txt_TeachNo.Text = u.TeachNo;

            chk_Enable.Checked = u.Enable.ToBoolean();
            ent.Dispose();
        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            DataEntities ent = new DataEntities();
            int id = WS.RequestInt("id");
            User u = (from l in ent.User where l.ID == id select l).FirstOrDefault();
            if (u == null)
            {
                u = new User();
            }
            u.UserName = txt_UserName.Text;
            u.ChineseName = txt_ChineseName.Text;
            u.Email = txt_Email.Text;
            u.Tel = txt_TelNumber.Text;
            u.Mobile = txt_Mobile.Text;
            u.WebSite = txt_Website.Text;
            u.Image = txt_Image.Text;
            u.Address = txt_Address.Text;
            u.ZipCode = txt_Zipcode.Text;
            u.Intro = txt_Intro.Text;

            u.Group = ddl_Group.SelectedValue.ToInt32();
            u.Cent = txt_Cent.Text.ToInt32(0);
            u.PostCount = txt_PostCount.Text.ToInt32(0);
            u.QQ = txt_QQ.Text;
            u.GTalk = txt_Gtalk.Text;
            u.ICQ = txt_ICQ.Text;
            //u.Weibo = txt_Weibo.Text;

            u.StudentNo = txt_StudentNo.Text.TrimDbDangerousChar();
            u.TeachNo = txt_TeachNo.Text.TrimDbDangerousChar();

            u.Enable = chk_Enable.Checked;
            if (u.ID <= 0)
            {
                u.LastLoginTime = DateTime.Now;
                u.LastLoginIP = WS.GetIP();
                ent.AddToUser(u);
            }
            ent.SaveChanges();
            ent.Dispose();

            Js.AlertAndChangUrl("保存成功！", "UserList.aspx");
        }
    }
}
