using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

using Voodoo;
using Voodoo.Data;
using Voodoo.Basement;
using Voodoo.Setting;


namespace Web.e.member
{
    public partial class ChangeRegister : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected string GetUserGroupString()
        {
            DataEntities ent = new DataEntities();

            List<UserGroup> gs = (from l in ent.UserGroup select l).ToList();
            ent.Dispose();
            gs = gs.Where(p => p.EnableReg==true).ToList();

            StringBuilder sb = new StringBuilder();
            sb.Append("<tr>");
            foreach (var g in gs)
            {
                sb.AppendLine("<td style='color:#000;width:100px'><input type=\"radio\" name=\"group\" id=\"" + g.ID + "\" value=\"" + g.ID + "\" /><label for=\"" + g.ID + "\">" + g.GroupName + "</label></td>");
            }
            sb.Append("</tr>");
            return sb.ToS();
        }
    }
}
