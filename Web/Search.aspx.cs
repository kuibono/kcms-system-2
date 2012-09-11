using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Voodoo;
using Voodoo.Data;
using Voodoo.Data.DbHelper;
using System.IO;


namespace Web
{
    public partial class Search : Voodoo.Basement.BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string Key = WS.RequestString("key");
            int Model = WS.RequestInt("m", 1);
            int page = WS.RequestInt("p", 1);

            if (Model == 6)
            {
                string director = WS.RequestString("d");
                string actor = WS.RequestString("a");
                string year = WS.RequestString("y");
                string location = WS.RequestString("l");
                string type = WS.RequestString("t");

                string searchword = "";
                if (!Key.IsNullOrEmpty())
                {
                    searchword = Key;
                }
                else if (!director.IsNullOrEmpty())
                {
                    searchword = director;
                }
                else if (!actor.IsNullOrEmpty())
                {
                    searchword = actor;
                }
                else if (!year.IsNullOrEmpty())
                {
                    searchword = year;
                }
                else if (!location.IsNullOrEmpty())
                {
                    searchword = location;
                }
                else
                {
                    searchword = type;
                }


                string m_where = string.Format("Director like N'%{0}%' and Actors like N'%{1}%' and tags like N'%{2}%' and PublicYear like N'%{3}%' and Location like N'%{4}%' and (Title like N'%{5}%' or Intro like N'%{5}%' or Director like N'%{5}%' or Actors like N'%{5}%' or tags like N'%{5}%' or PublicYear like N'%{5}%' or Location like N'%{5}%')",
                    director,
                    actor,
                    type,
                    year,
                    location,
                    Key
                    );

                Response.Clear();
                Response.Write(Voodoo.Basement.CreatePage.GetSearchResult(m_where,Model, page,searchword));
            }
            else
            {

                Response.Clear();
                Response.Write(Voodoo.Basement.CreatePage.GetSearchResult(Model, page, Key));
            }
        }
    }
}
