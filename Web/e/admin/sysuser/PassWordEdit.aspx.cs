using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Voodoo;
using Voodoo.Basement;

namespace Web.e.admin.sysuser
{
    public partial class PassWordEdit : AdminBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            SysUser u = SysUserAction.LocalUser;
            if(u.UserPass!= Voodoo.Security.Encrypt.Md5(txt_Password.Text))
            {
                Js.AlertAndGoback("原密码输入错误，请重新输入！ ");
                return;
            }
            if (txt_PasswordConfirm.Text != txt_PasswordNew.Text)
            {
                Js.AlertAndGoback("两次密码输入不一致，请重新输入！ ");
                return;
            }

            using (DataEntities ent = new DataEntities())
            {
                SysUser newU = (from l in ent.SysUser where l.ID == u.ID select l).FirstOrDefault();
                newU.UserPass = Voodoo.Security.Encrypt.Md5(txt_PasswordConfirm.Text);
                ent.SaveChanges();
                Js.AlertAndChangUrl("密码修改成功，请退出并重新登录！", "PassWordEdit.aspx");
                Session.Abandon();
            }
        }
    }
}