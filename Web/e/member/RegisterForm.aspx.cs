using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Voodoo;
using Voodoo.Basement;
using Voodoo.Setting;


namespace Web.e.member
{
    public partial class RegisterForm : BasePage
    {
        protected string formString = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            using (DataEntities ent = new DataEntities())
            {
                int groupid = WS.RequestInt("group");

                formString=(from l in ent.UserGroup
                            from p in ent.UserForm
                            where l.ID == groupid
                            && l.RegForm == p.ID
                            select p).FirstOrDefault().Content;

            }
        }
    }
}
