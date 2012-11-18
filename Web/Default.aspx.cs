using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
//using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

using Voodoo;
using Voodoo.Data;
using Voodoo.Data.DbHelper;
using System.IO;



namespace Web
{
    public partial class _Default : Voodoo.Basement.BasePage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (WS.IsFromMobile())
            {
                //Response.Redirect("~/wap/book/");
                Server.Transfer("~/wap/book/Default.aspx");

                
            }
            else
            {

                string indexurl = "/";

                int model = SystemSetting.DefaultModel;
                if (SystemSetting.EnableStatic)
                {
                    switch (model)
                    {
                        case 1://news
                            break;
                        case 2://image
                            break;
                        case 3: //question
                            break;
                        case 4: //book
                            indexurl = "/Book/";
                            break;
                        case 5://job
                            indexurl = "/Job/";
                            break;
                        case 6://movie
                            indexurl = "/Movie/";
                            break;
                    }
                }
                else
                {
                    switch (model)
                    {
                        case 1://news
                            break;
                        case 2://image
                            break;
                        case 3: //question
                            break;
                        case 4: //book
                            indexurl = "/Dynamic/Book/Default.aspx";
                            break;
                        case 5://job
                            indexurl = "/Dynamic/Job/Default.aspx";
                            break;
                        case 6://movie
                            indexurl = "/Dynamic/Movie/Default.aspx";
                            break;
                    }
                }

                Server.Transfer(indexurl);
            }
        }
    }
}
