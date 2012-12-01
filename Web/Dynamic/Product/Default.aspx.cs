using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Voodoo;
using Voodoo.Basement;

namespace Web.Dynamic.Product
{
    public partial class Default : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (DataEntities ent = new DataEntities())
            {
                int id = WS.RequestInt("id");

                Voodoo.Basement.Product p = (from l in ent.Product where l.ID == id select l).FirstOrDefault();

                TemplateHelper Helper = new TemplateHelper();
                Response.Clear();
                Response.Write(
                Helper.CreateContentPage(p, p.GetClass()));
            }


        }
    }
}