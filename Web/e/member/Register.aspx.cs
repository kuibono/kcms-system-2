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

namespace Web.e.member
{
    public partial class Register : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            User user = new User();
            user.Address = WS.RequestString("address");
            user.Cent = WS.RequestInt("cent", 0);
            user.ChineseName = WS.RequestString("chinesename");
            user.Email = WS.RequestString("email");
            user.Group = WS.RequestInt("group", SystemSetting.RegisterDefaultGroup);
            user.GTalk = WS.RequestString("gtalk");
            user.ICQ = WS.RequestString("icq");
            user.Image = WS.RequestString("image");
            user.Intro = WS.RequestString("intro");
            user.Mobile = WS.RequestString("mobile");
            user.MSN = WS.RequestString("msn");
            user.QQ = WS.RequestString("qq");
            user.Tel = WS.RequestString("tel");
            user.Twitter = WS.RequestString("twitter");
            user.UserName = WS.RequestString("username");
            user.UserPass = Voodoo.Security.Encrypt.Md5(WS.RequestString("userpass"));
            user.WebSite = WS.RequestString("website");
            //user.Weibo = WS.RequestString("weibo");
            user.ZipCode = WS.RequestString("zipcode");
            user.StudentNo = WS.RequestString("studentno");
            user.TeachNo = WS.RequestString("teachno");

            UserAction ua = new UserAction();
            
            Result r=ua.UserRegister(user);
            if (r.Success)
            {
                ua.UserLogin(user.UserName, WS.RequestString("userpass"), 1);
                Js.AlertAndChangUrl("注册成功！", "/");
            }
            else
            {
                Js.AlertAndGoback(r.Text);
            }

        }
    }
}
