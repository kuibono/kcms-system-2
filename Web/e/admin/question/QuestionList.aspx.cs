using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Voodoo;
using Voodoo.Data;
using Voodoo.Basement;
using Voodoo.Setting;


namespace Web.e.admin.question
{
    public partial class QuestionList : AdminBase
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
            pager.PageSize = SystemSetting.MagageListSize;

            ddl_Class.DataSource = NewsAction.NewsClass.Where(pa => pa.IsLeafClass == true && pa.ModelID == 3).ToList();
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


            ddl_Class_search.DataSource = NewsAction.NewsClass.Where(pa => pa.IsLeafClass == true && pa.ModelID == 3).ToList();
            ddl_Class_search.DataTextField = "ClassName";
            ddl_Class_search.DataValueField = "ID";
            ddl_Class_search.DataBind();
            ddl_Class_search.Items.Add(new ListItem("--新增请选择栏目--", ""));
            ddl_Class_search.SelectedValue = "";

            if (WS.RequestInt("class") > 0)
            {
                ddl_Class_search.SelectedValue = WS.RequestString("class");
            }

            DataEntities ent = new DataEntities();

            var q = from l in ent.Question select l;
            if (txt_Key.Text.Trim().Length > 0 && txt_Column.SelectedValue != "")
            {
                string k = txt_Key.Text.Trim();

                q = q.Where(p => p.Title.Contains(k) || p.Content.Contains(k));

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

        protected void Button1_Click(object sender, EventArgs e)
        {
            var ids = WS.RequestString("id").Split(',').ToList();
            DataEntities ent = new DataEntities();
            var qs = from l in ent.Question where ids.IndexOf(l.ID.ToString()) > 0 select l;
            foreach (var q in qs)
            {
                ent.DeleteObject(q);
            }
            ent.SaveChanges();
            ent.Dispose();

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

        protected void btn_createPage_Click(object sender, EventArgs e)
        {
            DataEntities ent = new DataEntities();

            string ids = WS.RequestString("id");
            var qus = 
                ent.CreateQuery<Question>(string.Format("select * from Question where id in ({0})", ids)).ToList();
            foreach (var qu in qus)
            {
                CreatePage.CreateContentPage(qu, qu.GetClass());
            }


            CreatePage.CreateListPage(ObjectExtents.Class(cls), 1);

            Js.AlertAndChangUrl("生成成功！", url);
        }
    }
}
