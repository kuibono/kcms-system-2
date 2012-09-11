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

namespace Web.e.admin.sysuser
{
    public partial class SysUserList : AdminBase
    {
        #region  页面加载事件
        /// <summary>
        /// 页面加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            string ids=WS.RequestString("id");
            switch (WS.RequestString("action"))
            {
                case "disable":
                    Disable(ids);
                    break;
                case "enable":
                    Enable(ids);
                    break;
                case "del":
                    Delete(ids);
                    break;
            }

            LoadList();
        }
        #endregion

        #region 加载列表
        /// <summary>
        /// 加载列表
        /// </summary>
        protected void LoadList()
        {
            pager.PageSize = SystemSetting.MagageListSize;
            DataEntities ent = new DataEntities();
            var q=from l in ent.SysUser select l;

            rp_list.DataSource = q.Skip(pager.CurrentPageIndex).Take(pager.PageSize);
            rp_list.DataBind();
            pager.RecordCount = q.Count();
            ent.Dispose();
        }
        #endregion

        #region 停用
        /// <summary>
        /// 停用
        /// </summary>
        /// <param name="ids"></param>
        protected void Disable(string ids)
        {
            DataEntities ent = new DataEntities();
            var id = ids.Split(',').ToList();
            var qs = from l in ent.SysUser where id.IndexOf(l.ID.ToString()) > 0 select l;
            foreach (var q in qs)
            {
                q.Enabled = false;
            }
            ent.SaveChanges();
            ent.Dispose();

            Js.AlertAndChangUrl("操作成功！", "SysUserList.aspx");
        }
        #endregion

        #region 启用
        /// <summary>
        /// 启用
        /// </summary>
        /// <param name="ids"></param>
        protected void Enable(string ids)
        {
            DataEntities ent = new DataEntities();
            var id = ids.Split(',').ToList();
            var qs = from l in ent.SysUser where id.IndexOf(l.ID.ToString()) > 0 select l;
            foreach (var q in qs)
            {
                q.Enabled = true;
            }
            ent.SaveChanges();
            ent.Dispose();

            Js.AlertAndChangUrl("操作成功！", "SysUserList.aspx");
        }
        #endregion

        #region 删除
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ids"></param>
        protected void Delete(string ids)
        {
            DataEntities ent = new DataEntities();
            var id = ids.Split(',').ToList();
            var qs = from l in ent.SysUser where id.IndexOf(l.ID.ToString()) > 0 select l;
            foreach (var q in qs)
            {
                ent.DeleteObject(q);
            }
            ent.SaveChanges();
            ent.Dispose();

            Js.AlertAndChangUrl("删除成功！", "SysUserList.aspx");
        }
        #endregion

        #region 按钮事件
        protected void btn_disable_Click(object sender, EventArgs e)
        {
            string ids = WS.RequestString("id");
            Disable(ids);
        }

        protected void btn_enable_Click(object sender, EventArgs e)
        {
            string ids = WS.RequestString("id");
            Enable(ids);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string ids = WS.RequestString("id");
            Delete(ids);
        }
        #endregion
    }
}
