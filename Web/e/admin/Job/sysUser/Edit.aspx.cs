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

namespace Web.e.admin.Job.sysUser
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

        #region 加载信息
        /// <summary>
        /// 加载信息
        /// </summary>
        protected void LoadInfo()
        {
            DataEntities ent = new DataEntities();
            int id = WS.RequestInt("id");

            if (id > 0)
            {
                txt_Password.EnableNull = true;
                txt_UserName.Enabled = false;

                SysUser user = (from l in ent.SysUser where l.ID == id select l).FirstOrDefault();
                txt_UserName.Text = user.UserName;
                txt_Password.Text = user.UserPass;
                txt_ChineseName.Text = user.ChineseName;
                txt_Email.Text = user.Email;
                txt_TelNumber.Text = user.TelNumber;
                lb_LastLoginTime.Text = user.LastLoginTime.ToString();
                lb_LastLoginIP.Text = user.LastLoginIP;
                lb_LoginCount.Text = user.Logincount.ToString();
                chk_Enable.Checked = user.Enabled.ToBoolean();
            }
            ent.Dispose();
        }
        #endregion

        #region 保存资料
        /// <summary>
        /// 保存资料
        /// </summary>
        protected void SaveInfo()
        {
            SysUser su = SysUserAction.LocalUser;

            DataEntities ent = new DataEntities();
            int id = WS.RequestInt("id");
            SysUser user = new SysUser();
            if (id > 0)
            {

                user = (from l in ent.SysUser where l.ID == id select l).FirstOrDefault();
            }
            else if (txt_Password.Text.Length == 0)
            {
                Js.AlertAndGoback("新增用户时，密码不能为空");
            }

            user.UserName = txt_UserName.Text;
            if (txt_Password.Text.Length > 0)
            {
                user.UserPass = Voodoo.Security.Encrypt.Md5(txt_Password.Text);
            }

            user.Email = txt_Email.Text;
            user.TelNumber = txt_TelNumber.Text;
            user.Department = su.Department;
            user.UserGroup = su.UserGroup;
            user.ChineseName = txt_ChineseName.Text;
            user.Enabled = chk_Enable.Checked;

            if (id <= 0)
            {
                user.LastLoginTime = DateTime.Now;
                user.LastLoginIP = WS.GetIP();
                Result r = SysUserAction.UserAdd(user);

                if (r.Success)
                {
                    Js.AlertAndChangUrl(r.Text, "List.aspx");
                }
                else
                {
                    Js.AlertAndGoback(r.Text);
                }
            }
            else
            {
                ent.SaveChanges();
                Js.AlertAndChangUrl("修改成功！", "List.aspx");
            }
            ent.Dispose();

        }
        #endregion

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            SaveInfo();
        }
    }
}