using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Voodoo;
using Voodoo.Basement;

namespace Web.e.member
{
    public partial class user_panel_ajax : BasePage
    {
        public User u = UserAction.opuser;

        public int id { get; set; }

        public string name { get; set; }

        public int loginCount { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (u.ID > 0)
            {
                id = u.ID;
                name = u.UserName;
                loginCount = u.LoginCount.ToInt32(0);
            }
            else
            {
                id = int.MinValue;
            }
        }
    }
}