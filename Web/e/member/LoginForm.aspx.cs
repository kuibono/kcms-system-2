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
    public partial class LoginForm :BasePage
    {
        protected string PostLink = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            DataEntities ent = new DataEntities();
            try
            {

                if ((from l in ent.UserGroup where l.ID == UserAction.opuser.Group select l).FirstOrDefault().MaxPost > 0)
                {
                    PostLink = "<a href='/e/post/PostNews.aspx'>投递文章</a>";
                }
            }
            catch { }
            finally
            {
                ent.Dispose();
            }
        }
    }
}
