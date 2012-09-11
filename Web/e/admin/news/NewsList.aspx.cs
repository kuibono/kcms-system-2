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

namespace Web.e.admin.news
{
    public partial class NewsList : AdminBase
    {
        protected static int cls = WS.RequestInt("class",0);
        protected static int zt = WS.RequestInt("zt", 0);
        protected static string url = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            cls = WS.RequestInt("class",0);
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
            pager.PageSize = SystemSetting.MagageListSize;

            ddl_Class.DataSource = NewsAction.NewsClass.Where(pa => pa.IsLeafClass==true && pa.ModelID == 1).ToList();
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
            //ddl_Zt.SelectedValue = "";


            ddl_Class_search.DataSource = NewsAction.NewsClass.Where(pa => pa.IsLeafClass==true && pa.ModelID == 1).ToList();
            ddl_Class_search.DataTextField = "ClassName";
            ddl_Class_search.DataValueField = "ID";
            ddl_Class_search.DataBind();
            ddl_Class_search.Items.Add(new ListItem("--新增请选择栏目--", ""));
            ddl_Class_search.SelectedValue = "";

            if (WS.RequestInt("class") > 0)
            {
                ddl_Class_search.SelectedValue = WS.RequestString("class");
                ddl_Class.SelectedValue = WS.RequestString("class");
            }


            DataEntities ent = new DataEntities();

            var q = from l in ent.News select l;

            if (ddl_Prop.SelectedValue != "")
            {
                switch (ddl_Prop.SelectedValue)
                {
                    case "SetTop":
                        q = q.Where(p => p.SetTop == true);
                        break;
                    case "Tuijian":
                        q = q.Where(p => p.Tuijian == true);
                        break;
                    case "Toutiao":
                        q = q.Where(p => p.Toutiao == true);
                        break;
                    case "Audit":
                        q = q.Where(p => p.Audit == true);
                        break;
                    case "UnAudit":
                        q = q.Where(p => p.Audit == false);
                        break;
                }
            }

            if (txt_Key.Text.Trim().Length > 0 && txt_Column.SelectedValue != "")
            {
                q = q.Where(p => p.Title.Contains(txt_Key.Text.Trim()));
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
                ddl_Class.Enabled = false;
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

        /// <summary>
        /// 停用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_disable_Click(object sender, EventArgs e)
        {
            var ids = WS.RequestString("id").Split(',').ToList();
            DataEntities ent = new DataEntities();
            var qs = from l in ent.News where ids.IndexOf(l.ID.ToString()) > 0 select l;
            foreach (var q in qs)
            {
                q.Audit = true;
            }
            ent.SaveChanges(); ;
            ent.Dispose();

            if (cls > 0)
            {
                CreatePage.CreateListPage(ObjectExtents.Class(cls), 1);
            }
            CreatePage.GreateIndexPage();
            Js.Jump(url);
        }

        protected void btn_enable_Click(object sender, EventArgs e)
        {
            var ids = WS.RequestString("id").Split(',').ToList();
            DataEntities ent = new DataEntities();
            var qs = from l in ent.News where ids.IndexOf(l.ID.ToString()) > 0 select l;
            foreach (var q in qs)
            {
                q.Audit = false;
            }
            ent.SaveChanges(); ;
            ent.Dispose();

            if (cls > 0)
            {
                CreatePage.CreateListPage(ObjectExtents.Class(cls), 1);
            }
            CreatePage.GreateIndexPage();
            Js.Jump(url);
        }

        protected void btn_Tj_Click(object sender, EventArgs e)
        {
            var ids = WS.RequestString("id").Split(',').ToList();
            DataEntities ent = new DataEntities();
            var qs = from l in ent.News where ids.IndexOf(l.ID.ToString()) > 0 select l;
            foreach (var q in qs)
            {
                q.Tuijian = true;
            }
            ent.SaveChanges(); ;
            ent.Dispose();

            if (cls > 0)
            {
                CreatePage.CreateListPage(ObjectExtents.Class(cls), 1);
            }
            CreatePage.GreateIndexPage();
            Js.Jump(url);
        }

        protected void btn_First_Click(object sender, EventArgs e)
        {
            var ids = WS.RequestString("id").Split(',').ToList();
            DataEntities ent = new DataEntities();
            var qs = from l in ent.News where ids.IndexOf(l.ID.ToString()) > 0 select l;
            foreach (var q in qs)
            {
                q.Toutiao = true;
            }
            ent.SaveChanges(); ;
            ent.Dispose();

            if (cls > 0)
            {
                CreatePage.CreateListPage(ObjectExtents.Class(cls), 1);
            }
            CreatePage.GreateIndexPage();
            Js.Jump(url);
        }

        protected void btn_SetTop_Click(object sender, EventArgs e)
        {
            var ids = WS.RequestString("id").Split(',').ToList();
            DataEntities ent = new DataEntities();
            var qs = from l in ent.News where ids.IndexOf(l.ID.ToString()) > 0 select l;
            foreach (var q in qs)
            {
                q.SetTop = true;
            }
            ent.SaveChanges(); ;
            ent.Dispose();

            if (cls > 0)
            {
                CreatePage.CreateListPage(ObjectExtents.Class(cls), 1);
            }
            CreatePage.GreateIndexPage();
            Js.Jump(url);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var ids = WS.RequestString("id").Split(',').ToList();
            DataEntities ent = new DataEntities();
            var qs = from l in ent.News where ids.IndexOf(l.ID.ToString()) > 0 select l;
            foreach (var q in qs)
            {
                ent.DeleteObject(q);
            }
            ent.SaveChanges(); ;
            ent.Dispose();


            if (cls > 0)
            {
                CreatePage.CreateListPage(ObjectExtents.Class(cls), 1);
            }
            CreatePage.GreateIndexPage();
            Js.AlertAndChangUrl("删除成功！", url);
        }

        protected void pager_PageChanged(object sender, EventArgs e)
        {
            LoadInfo();
        }

        protected void btn_createPage_Click(object sender, EventArgs e)
        {
            DataEntities ent = new DataEntities();

            string[] ids = WS.RequestString("id").Split(',');
            foreach (string id in ids)
            {
                int int_id = id.ToInt32();
                News n = //NewsView.GetModelByID(id);
                    (from l in ent.News where l.ID == int_id select l).FirstOrDefault();

                CreatePage.CreateContentPage(n, n.GetClass());

                News news_pre = GetPreNews(n, n.GetClass());

                if (news_pre != null)
                {
                    CreatePage.CreateContentPage(news_pre, n.GetClass());
                }
            }

            if (cls > 0)
            {
                try
                {
                    CreatePage.CreateListPage(ObjectExtents.Class(cls), 1);
                }
                catch { }
            }
            CreatePage.GreateIndexPage();
            Js.Jump(url);
        }
    }
}
