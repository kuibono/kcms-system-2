using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;

using Voodoo;
using Voodoo.Data;
using Voodoo.Data.DbHelper;

namespace Web.e.intaller
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Voodoo.IO.File.Exists(Server.MapPath("~/e/installer/intaller.off")))
            {
                Response.Clear();
                Response.Write("系统已经安装，不得重复安装！");
                Response.End();
                return;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {


            //尝试连接数据库服务器
            string master_conn_str = string.Format("Data Source={0};Initial Catalog=master;Persist Security Info=True;User ID={1};Password={2}", txt_Server.Text, txt_Username.Text, txt_Password.Text);
            string ConnStr = string.Format("Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3}", txt_Server.Text, txt_DbName.Text, txt_Username.Text, txt_Password.Text);
            SqlConnection master_conn = new SqlConnection(master_conn_str);
            try
            {
                master_conn.Open();
            }
            catch
            {
                Js.AlertAndGoback("数据库服务器连接失败，请重试！");
            }
            finally
            {
                if (master_conn.State == ConnectionState.Open)
                {
                    master_conn.Close();
                }
            }
            IDbHelper Helper = new SqlHelper(master_conn_str);
            try
            {
                //判断数据库是否存在

                DbDataReader dr = Helper.ExecuteReader(CommandType.Text, string.Format("select 0 From master.dbo.sysdatabases where name='{0}' ", txt_DbName.Text));
                if (!dr.Read())
                {
                    //不存在的话创建
                    dr.Close();
                    dr.Dispose();
                    Helper = new SqlHelper(master_conn_str);
                    Helper.ExecuteNonQuery(CommandType.Text, string.Format("CREATE DATABASE {0}", txt_DbName.Text));

                }
                dr.Close();
                dr.Dispose();
            }
            catch (Exception ex)
            {
                //无法写入数据库
            }


            //写入连接字符串
            try
            {
                Voodoo.Config.Info.SetAppSetting("ConnStr", ConnStr);
            }
            catch { }

            //导入表

            string str_sql = Voodoo.IO.File.Read(Server.MapPath("~/e/installer/tablescript.txt"));
            Helper = new SqlHelper(ConnStr);
            Helper.ExecuteNonQuery(CommandType.Text, str_sql);

            //导入数据
            if (chk_WithData.Checked)
            {
                string str_data = Voodoo.IO.File.Read(Server.MapPath("~/e/installer/tabledata.txt"));
                Helper = new SqlHelper(ConnStr);
                Helper.ExecuteNonQuery(CommandType.Text, str_data);
            }


            //导入管理员
            Helper = new SqlHelper(ConnStr);
            Helper.ExecuteNonQuery(CommandType.Text, string.Format("insert into [SysUser]([UserName],[UserPass],[Logincount],[LastLoginTime],[LastLoginIP],[SafeQuestion],[SafeAnswer],[Department],[ChineseName],[UserGroup],[Email],[TelNumber],[Enabled]) values('{0}','{1}','0','2011-11-21 12:38:50','127.0.0.1','','','1','超管','1','admin@admin.com','13813894138','True')", txt_AdminName.Text, Voodoo.Security.Encrypt.Md5(txt_AdminPass.Text)));

            Voodoo.IO.File.Write(Server.MapPath("~/e/installer/intaller.off"), "1");
            Js.AlertAndChangUrl("安装完成！马上进入登陆界面！", "/e/admin/");
        }
    }
}
