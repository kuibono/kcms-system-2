using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Voodoo;
using Voodoo.Data;
using Voodoo.Basement;

namespace Web.wap.Book
{
    public partial class cls : Voodoo.Basement.BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataEntities ent=new DataEntities();

            int id = WS.RequestInt("id", 1);
            int page = WS.RequestInt("page", 1);

            var q = from p in ent.Class
                    from c in ent.Class
                    from l in ent.Book
                    where p.ID == id && c.ParentID == id &&
                    (l.ClassID == p.ID || l.ClassID == c.ID)
                    select l;

            rp.DataSource = q.Skip(page - 1).Take(AspNetPager1.PageSize);
            rp.DataBind();
        }
    }
}