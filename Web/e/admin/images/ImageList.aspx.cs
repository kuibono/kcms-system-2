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


namespace Web.e.admin.images
{
    public partial class ImageList : AdminBase
    {
        protected static int cls = WS.RequestInt("class", 0);
        protected static int zt = WS.RequestInt("zt", 0);
        protected static string url = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            cls = WS.RequestInt("class", 0);
            zt = WS.RequestInt("zt", 0);
            url = string.Format("?class={0}&zt={1}", cls, zt);
            LoadInfo();
            if (WS.RequestString("action") == "del")
            {
                Button1_Click(sender, e);
            }
        }

        #region 加载列表
        /// <summary>
        /// 加载列表
        /// </summary>
        protected void LoadInfo()
        {
            DataEntities ent = new DataEntities();

            pager.PageSize = SystemSetting.MagageListSize;

            ddl_Class.DataSource = NewsAction.NewsClass.Where(pa => pa.IsLeafClass == true && pa.ModelID == 2).ToList();
            ddl_Class.DataTextField = "ClassName";
            ddl_Class.DataValueField = "ID";
            ddl_Class.DataBind();
            ddl_Class.Items.Add(new ListItem("--所有栏目--", ""));
            ddl_Class.SelectedValue = "";



            ddl_Zt.DataSource = NewsAction.NewsZt;
            ddl_Zt.DataTextField = "ZtName";
            ddl_Zt.DataValueField = "ID";
            ddl_Zt.DataBind();
            ddl_Zt.Items.Add(new ListItem("--所有专题--", ""));
            ddl_Zt.SelectedValue = "";


            ddl_Class_search.DataSource = NewsAction.NewsClass.Where(pa => pa.IsLeafClass == true && pa.ModelID == 2).ToList();
            ddl_Class_search.DataTextField = "ClassName";
            ddl_Class_search.DataValueField = "ID";
            ddl_Class_search.DataBind();
            ddl_Class_search.Items.Add(new ListItem("--新增请选择栏目--", ""));
            ddl_Class_search.SelectedValue = "";

            if (WS.RequestInt("class") > 0)
            {
                ddl_Class_search.SelectedValue = WS.RequestString("class");
            }


            var q = from l in ent.ImageAlbum select l;

            if (ddl_Prop.SelectedValue != "")
            {
                switch (ddl_Prop.SelectedValue)
                {
                    case "SetTop":
                        q = q.Where(p => p.SetTop == true);
                        break;
                }
            }

            if (txt_Key.Text.Trim().Length > 0 && txt_Column.SelectedValue != "")
            {
                string k = txt_Key.Text.Trim();
                q = from l in q where l.Title.Contains(k) select l;
            }

            if (ddl_Class.SelectedValue != "")
            {
                int clsid = ddl_Class.SelectedValue.ToInt32();

                q = q.Where(p => p.ClassID == clsid);
            }

            if (cls > 0)
            {
                q = q.Where(p => p.ClassID == cls);
                ddl_Class_search.Enabled = false;
            }
            if (ddl_Class_search.SelectedValue != "")
            {
                int clsid = ddl_Class_search.SelectedValue.ToInt32();

                q = q.Where(p => p.ClassID == clsid);
            }

            if (zt > 0)
            {
                q = q.Where(p => p.ZtID == zt);
            }


            rp_list.DataSource = q.Skip(pager.CurrentPageIndex - 1).Take(pager.PageSize);
            pager.RecordCount = q.Count();
            rp_list.DataBind();
            ent.Dispose();

        }
        #endregion

        protected void pager_PageChanged(object sender, EventArgs e)
        {

        }

        protected void btn_SetTop_Click(object sender, EventArgs e)
        {

            DataEntities ent = new DataEntities();
            var ids = WS.RequestString("id").Split(',').ToList();
            var q = from l in ent.ImageAlbum where ids.IndexOf(l.ID.ToString()) > 0 select l;
            foreach (var mq in q)
            {
                mq.SetTop = true;
            }
            ent.SaveChanges();

            if (cls > 0)
            {
                CreatePage.CreateListPage(ObjectExtents.Class(cls), 1);
            }
            CreatePage.GreateIndexPage();
            Js.Jump(url);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string ids = WS.RequestString("id");

            ImageAction.DeleteImageAlbum(string.Format("id in ({0})", ids));

            if (cls > 0)
            {
                CreatePage.CreateListPage(ObjectExtents.Class(cls), 1);
            }
            CreatePage.GreateIndexPage();
            Js.AlertAndChangUrl("删除成功！", url);
        }

        protected void btn_Add_Click(object sender, EventArgs e)
        {

        }
    }
}
