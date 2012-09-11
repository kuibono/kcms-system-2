using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Voodoo.Data;
using Voodoo.Data.DbHelper;
using System.Data;
using Voodoo.Basement;
using System.Data.Common;

namespace Web.e.tool
{
    public partial class gettabledata : AdminBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Clear();

            string str_sql = "";
            IDbHelper sql = GetHelper();
            DbDataReader rd = sql.ExecuteReader(CommandType.Text, "select [name] from sysobjects where xtype='U'");
            while (rd.Read())
            {
                string tableName = rd["name"].ToString();
                if (tableName.ToLower() == "sysuser")
                {
                    continue;
                }

                IDbHelper Helper = new SqlHelper(Voodoo.Setting.DataBase.ConnStr);
                DataTable dt = Helper.ExecuteDataTable(CommandType.Text, string.Format("select * from [{0}]",tableName));


                string str_insert = string.Format("SET IDENTITY_INSERT [{0}] ON ;\n insert into [{0}](", tableName);
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    str_insert += "[" + dt.Columns[i].ColumnName + "]";
                    if (i != dt.Columns.Count - 1)
                    {
                        str_insert += ",";
                    }
                }
                str_insert += ") values(";


                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    str_sql += str_insert;
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        str_sql += "N'" + dt.Rows[i][j].ToString().Replace("'", "''") + "'";
                        if (j != dt.Columns.Count - 1)
                        {
                            str_sql += ",";
                        }
                    }
                    str_sql += string.Format(")\n SET IDENTITY_INSERT [{0}] OFF ;\n\n\n",tableName);
                }
            }
            rd.Close();
            rd.Dispose();

            

            //Response.Write(str_sql);
            Voodoo.IO.File.Write(Server.MapPath("~/e/installer/tabledata.txt"), str_sql, System.IO.FileMode.Create);
            Response.Write("已经生成到：" + Server.MapPath("~/e/installer/tabledata.txt"));
            Response.End();

        }
    }
}
