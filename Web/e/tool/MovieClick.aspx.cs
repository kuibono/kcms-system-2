using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;

using Voodoo;
using Voodoo.Setting;

namespace Web.e.tool
{
    public partial class MovieClick : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = WS.RequestInt("id");
            MovieClickCount(id);
        }

        protected void MovieClickCount(int id)
        {
            StringBuilder sb = new StringBuilder();
            string now=DateTime.UtcNow.AddHours(8).ToString("yyyy-MM-dd HH:mm:ss");
            string yesterday = DateTime.UtcNow.AddHours(8).AddDays(-1).ToString("yyyy-MM-dd 23:59:59");
            string lastweek = DateTime.UtcNow.AddHours(8).LastWeekLastDay().ToString("yyyy-MM-dd 23:59:59");
            string lastMonth = DateTime.UtcNow.AddHours(8).LastMonthLastDay().ToString("yyyy-MM-dd 23:59:59");

            sb.AppendLine(string.Format("update MovieInfo set DayClick=0 where LastClickTime<='{0}'",yesterday));
            sb.AppendLine(string.Format("update MovieInfo set WeekClick=0 where LastClickTime<='{0}'", lastweek));
            sb.AppendLine(string.Format("update MovieInfo set MonthClick=0 where LastClickTime<='{0}'", lastMonth));
            sb.AppendLine(string.Format("update MovieInfo set LastClickTime='{0}'", now));
            sb.AppendLine(string.Format("update MovieInfo set ClickCount=ClickCount+1,MonthClick=MonthClick+1,WeekClick=WeekClick+1,DayClick=DayClick+1,LastClickTime='{0}' where id={1}",
                now,
                id
                ));
            DataBase.GetHelper().ExecuteNonQuery(CommandType.Text, sb.ToS());
        }
    }
}