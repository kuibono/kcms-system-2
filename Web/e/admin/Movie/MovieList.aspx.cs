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
namespace Web.e.admin.Movie
{
    public partial class MovieList : AdminBase
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

            ddl_Class.DataSource = ClassAction.Classes.Where(pa => pa.IsLeafClass==true && pa.ModelID == 6).ToList();
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


            ddl_Class_search.DataSource = NewsAction.NewsClass.Where(pa => pa.IsLeafClass==true && pa.ModelID == 6).ToList();
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

            string str_sql = "";

            DataEntities ent = new DataEntities();
            var q = from l in ent.MovieInfo select l;

            if (txt_Key.Text.Trim().Length > 0 && txt_Column.SelectedValue != "")
            {
                string k=txt_Key.Text;
                q = q.Where(p => p.Title.Contains(k));
            }
            if (txt_Key.Text.Trim().Length > 0 && txt_Column.SelectedValue == "")
            {
                string k = txt_Key.Text;
                q = q.Where(p => p.Title.Contains(k) || p.Actors.Contains(k) || p.Director.Contains(k) || p.Intro.Contains(k)||p.Tags.Contains(k));
            }

            if (ddl_Class.SelectedValue != "")
            {

                int clsid=ddl_Class.SelectedValue.ToInt32();
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
            DataEntities ent = new DataEntities();
            var ids = WS.RequestString("id").Split(',').ToList();
            var qs = (from l in ent.MovieInfo where ids.IndexOf(l.id.ToString()) > 0 select l).ToList();
            foreach (var q in qs)
            {
                q.Enable = false;
            }
            ent.SaveChanges();
            ent.Dispose();

            Js.Jump(url);
        }

        protected void btn_enable_Click(object sender, EventArgs e)
        {
            DataEntities ent = new DataEntities();
            var ids = WS.RequestString("id").Split(',').ToList();
            var qs = (from l in ent.MovieInfo where ids.IndexOf(l.id.ToString()) > 0 select l).ToList();
            foreach (var q in qs)
            {
                q.Enable = true;
            }
            ent.SaveChanges();
            ent.Dispose();

            Js.Jump(url);
        }

 

        protected void Button1_Click(object sender, EventArgs e)
        {
            DataEntities ent = new DataEntities();
            var ids = WS.RequestString("id").Split(',').ToList();
            var qs = (from l in ent.MovieInfo where ids.IndexOf(l.id.ToString()) > 0 select l).ToList();
            foreach (var q in qs)
            {
                ent.DeleteObject(q);
            }
            ent.SaveChanges();
            ent.Dispose();

            Js.Jump(url);
        }

        protected void pager_PageChanged(object sender, EventArgs e)
        {
            LoadInfo();
        }

        protected void btn_createPage_Click(object sender, EventArgs e)
        {
            DataEntities ent = new DataEntities();

            Class c = //ClassView.GetModelByID(cls.ToS());
                ObjectExtents.Class(cls);
            string[] ids = WS.RequestString("id").Split(',');
            foreach (string id in ids)
            {
                int intid = id.ToInt32();

                MovieInfo mv = //MovieInfoView.GetModelByID(id);
                    (from l in ent.MovieInfo where l.id == intid select l).FirstOrDefault();
                CreatePage.CreateContentPage(mv,c);
                var kuaibos = //MovieUrlKuaibView.GetModelList(string.Format("MovieID={0}",id));
                    (from l in ent.MovieUrlKuaib where l.MovieID == intid select l).ToList();
                var baidus = //MovieUrlBaiduView.GetModelList(string.Format("MovieID={0}", id));
                    (from l in ent.MovieUrlBaidu where l.MovieID == intid select l).ToList();
                var dramas = //MovieDramaView.GetModelList(string.Format("MovieID={0}", id));
                    (from l in ent.MovieDrama where l.MovieID == intid select l).ToList();
                foreach (var kuaib in kuaibos)
                {
                    CreatePage.CreateDramapage(kuaib, c);
                }
                foreach (var baidu in baidus)
                {
                    CreatePage.CreateDramapage(baidu, c);
                }
                foreach (var drama in dramas)
                {
                    CreatePage.CreateDramapage(drama, c);
                }

            }

            if (cls > 0)
            {
                try
                {
                    CreatePage.CreateListPage(c, 1);
                }
                catch { }
            }
            ent.Dispose();
            CreatePage.GreateIndexPage();
            Js.Jump(url);
        }
    }
}