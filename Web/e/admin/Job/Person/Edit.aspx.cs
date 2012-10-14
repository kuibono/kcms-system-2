using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Voodoo;
using Voodoo.Basement;


namespace Web.e.admin.Job.Person
{
    public partial class Edit : AdminBase
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

            ddl_Group.DataSource = UserAction.GetUserGroups().Where(p=>p.ID!=2);
            ddl_Group.DataTextField = "GroupName";
            ddl_Group.DataValueField = "ID";
            ddl_Group.DataBind();

            int id = WS.RequestInt("id");
            User u = (from l in ent.User where l.ID == id select l).FirstOrDefault();
            if (u == null)
            {
                return;
            }

            txt_UserName.Text = u.UserName;
            txt_Email.Text = u.Email;

            ddl_Group.SelectedValue = u.Group.ToS();
            //txt_Weibo.Text = u.Weibo;

            lb_LastLoginTime.Text = u.LastLoginTime.ToString();
            lb_LastLoginIP.Text = u.LastLoginIP;
            lb_LoginCount.Text = u.LoginCount.ToS();


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
            u.Email = txt_Email.Text;

            u.Group = ddl_Group.SelectedValue.ToInt32();
            //u.Weibo = txt_Weibo.Text;

            u.Enable = chk_Enable.Checked;
            if (u.ID <= 0)
            {
                u.LastLoginTime = DateTime.Now;
                u.LastLoginIP = WS.GetIP();
                ent.AddToUser(u);
            }
            ent.SaveChanges();
            ent.Dispose();

            Js.AlertAndChangUrl("保存成功！", "List.aspx");
        }
    }
}