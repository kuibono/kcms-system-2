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
    public partial class user : AdminBase
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
            ddl_RegisterDefaultGroup.DataSource = UserAction.GetUserGroups();
            ddl_RegisterDefaultGroup.DataTextField = "GroupName";
            ddl_RegisterDefaultGroup.DataValueField = "ID";
            ddl_RegisterDefaultGroup.DataBind();

            SysSetting ss = SystemSetting;
            chk_EnableReg.Checked = ss.EnableReg;
            ddl_RegisterDefaultGroup.SelectedValue = ss.RegisterDefaultGroup.ToString();
            txt_RegCent.Text = ss.RegCent.ToString();
            txt_MinUserName.Text = ss.MinUserName.ToString();
            txt_MaxUserName.Text = ss.MaxUserName.ToString();

            txt_MinPassword.Text = ss.MinPassword.ToString();
            txt_MaxPassword.Text = ss.MaxPassword.ToString();
            chk_EmailCheck.Checked = ss.EmailCheck;
            txt_RegTimeSpan.Text = ss.RegTimeSpan.ToString();
            txt_UserNameFilter.Text = ss.UserNameFilter;

            chk_BackLoginUseVCode.Checked = ss.BackLoginUseVCode;
            txt_BackLoginErrorSize.Text = ss.BackLoginErrorSize.ToString();
            txt_BackLoginErrorTimeSpan.Text = ss.BackLoginErrorTimeSpan.ToString();
            txt_BackCookieTimeOut.Text = ss.BackCookieTimeOut.ToString();
        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            SysSetting ss = SystemSetting;
            ss.EnableReg = chk_EnableReg.Checked;
            ss.RegisterDefaultGroup = ddl_RegisterDefaultGroup.SelectedValue.ToInt32();
            ss.RegCent = txt_RegCent.Text.ToInt32();
            ss.MinUserName = txt_MinUserName.Text.ToInt32();
            ss.MaxUserName = txt_MaxUserName.Text.ToInt32();

            ss.MinPassword = txt_MinPassword.Text.ToInt32();
            ss.MaxPassword = txt_MaxPassword.Text.ToInt32();
            ss.EmailCheck = chk_EmailCheck.Checked;
            ss.RegTimeSpan = txt_RegTimeSpan.Text.ToInt32();
            ss.UserNameFilter = txt_UserNameFilter.Text;

            ss.BackLoginUseVCode = chk_BackLoginUseVCode.Checked;
            ss.BackLoginErrorSize = txt_BackLoginErrorSize.Text.ToInt32();
            ss.BackLoginErrorTimeSpan = txt_BackLoginErrorTimeSpan.Text.ToInt32();
            ss.BackCookieTimeOut = txt_BackCookieTimeOut.Text.ToInt32();

            ss.FileExtNameFilter = "gif,jpg,jpeg,png,bmp";
            ss.MaxPostFileSize = 1024 * 1024;
            ss.FileDir = "/u/file/";
            ss.FileExtNameFilter = "txt,doc,docx,xls,xlsx,ppt,pptx,rar,zip,7z,rtf,gif,jpg,jpeg,png,bmp";
            Voodoo.Basement.Setting.SysSettingDAL.SetSetting(ss);
            Js.AlertAndChangUrl("保存成功！", "?");
        }
    }
}
