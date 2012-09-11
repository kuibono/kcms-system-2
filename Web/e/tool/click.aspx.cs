using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

using Voodoo;
using Voodoo.Data;
using Voodoo.Basement;
using Voodoo.Setting;


namespace Web.e.tool
{
    public partial class click : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataEntities ent = new DataEntities();

            #region 阅读统计
            int model = WS.RequestInt("m");
            int id = WS.RequestInt("id");

            SysModel sm = //SysModelView.GetModelByID(model.ToS());
                (from l in ent.SysModel where l.ID == model select l).FirstOrDefault();
            if (sm.ID < 0)
            {
                return;
            }
            if (id < 0)
            {
                return;
            }
            string tableName = sm.TableName;
            string str_sql = string.Format("update {0} set ClickCount=ClickCount+1 where ID={1}; select ClickCount from {0}  where ID={1}", tableName, id);
            Response.Clear();
            Response.Write(string.Format("document.write('{0}')",GetHelper().ExecuteScalar(CommandType.Text, str_sql)));
            //Response.End();
            #endregion

            #region 阅读历史记录

            //string bookids = "";
            //if (Voodoo.Cookies.Cookies.GetCookie("history") != null)
            //{
            //    bookids = Voodoo.Cookies.Cookies.GetCookie("history").Value;
            //}
            //string[] ids = bookids.Split(',');

            //var tids = ids.ToList();
            //tids.Add(id.ToS());
            //tids = tids.Distinct(p => p).ToList();
            //tids = tids.Where(p => p.Trim().Length > 0).ToList();
            //tids = tids.Take(5).ToList();

            //bookids = "";
            //foreach (string str in tids)
            //{
            //    if (str.Trim().Length > 0)
            //    {
            //        bookids += str + ",";
            //    }
            //}
            //bookids=bookids.TrimEnd(',');

            //HttpCookie cookie = new HttpCookie("history", bookids);
            //Voodoo.Cookies.Cookies.SetCookie(cookie);

            #endregion

            ent.Dispose();
        }
    }
}
