using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Voodoo;
using Voodoo.Basement;
using System.IO;

namespace Web.e.api
{
    public partial class GetChapter : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            long id = WS.RequestString("id").ToInt64();
            DataEntities ent = new DataEntities();
            BookChapter c = (from l in ent.BookChapter where l.ID == id select l).FirstOrDefault();
            ent.Dispose();
            Response.Clear();
            Response.Write(Voodoo.IO.XML.Serialize(c));

        }
    }
}
