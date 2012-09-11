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
    public partial class BookExist : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string Title = WS.RequestString("title");
            string Author = WS.RequestString("author");
            using (DataEntities ent = new DataEntities())
            {
                Response.Clear();
                Response.Write(Voodoo.IO.XML.Serialize((from l in ent.Book where l.Title == Title && l.Author == Author select l).Count() > 0));
            }
        }
    }
}
