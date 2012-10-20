using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Voodoo;
using Voodoo.Basement;

namespace Web.Dynamic.Job
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string action = WS.RequestString("action");
            switch (action)
            {
                //case "":
                //    break;
                default:
                    Index();
                    break;
            }
        }

        protected void Index()
        {
            TemplateHelper Helper = new TemplateHelper();
            Response.Clear();
            Response.Write(Helper.GetIndex());
        }
    }
}