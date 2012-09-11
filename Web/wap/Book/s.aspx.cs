using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Voodoo;
using Voodoo.Data;

namespace Web.wap.Book
{
    public partial class s : Voodoo.Basement.BasePage
    {
        protected string key;
        protected void Page_Load(object sender, EventArgs e)
        {

            int page = WS.RequestInt("page", 1);

            key = WS.RequestString("key");
            IDbHelper Sql = Voodoo.Setting.DataBase.GetHelper();

            string str_sql = string.Format("Title like N'%{0}%' or Author like N'%{0}%' or Intro like N'%{0}%'",key);

            AspNetPager1.RecordCount = Sql.PageCountSort("Book", str_sql, "");

            Sql = Voodoo.Setting.DataBase.GetHelper();
            rp.DataSource=Sql.PageListViewSort("Book","ID","id desc",page,AspNetPager1.PageSize,"*",str_sql,"");
            rp.DataBind();
        }
    }
}