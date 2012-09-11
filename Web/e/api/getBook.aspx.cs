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
    public partial class getBook :BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string Title = WS.RequestString("title");
            string Author = WS.RequestString("author");

            DataEntities ent = new DataEntities();

            Book book = (from l in ent.Book where l.Title == Title && l.Author == Author select l).FirstOrDefault();
            ent.Dispose();
            Response.Clear();
            Response.Write(Voodoo.IO.XML.Serialize(book));
        }
    }
}
