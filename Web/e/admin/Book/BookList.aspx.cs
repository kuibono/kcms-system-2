using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.IO;
using System.Data;
using Voodoo;
using Voodoo.Data;
using Voodoo.Basement;
using Voodoo.Setting;

namespace Web.e.admin.Book
{
    public partial class BookList : AdminBase
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

            ddl_Class.DataSource =ClassAction.Classes.Where(pa => pa.IsLeafClass==true && pa.ModelID == 4).ToList();
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


            ddl_Class_search.DataSource = NewsAction.NewsClass.Where(pa => pa.IsLeafClass==true && pa.ModelID == 4).ToList();
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
            var q = from l in ent.Book select l;
            if (ddl_Prop.SelectedValue != "")
            {
                switch (ddl_Prop.SelectedValue)
                {
                    case "IsVip":
                        q = q.Where(p => p.IsVip == true);
                        break;
                    case "Enable":
                        q = q.Where(p => p.Enable == true);
                        break;
                    case "IsFirstPost":
                        q = q.Where(p => p.IsFirstPost == true);
                        break;
                }
            }

            if (txt_Key.Text.Trim().Length > 0 && txt_Column.SelectedValue != "")
            {
                string k=txt_Key.Text.Trim();
                //str_sql += txt_Column.SelectedValue + " like '%" + txt_Key.Text + "%'";
                q = from l in q where l.Title.Contains(k) || l.Author.Contains(k) || l.Intro.Contains(k) select l;
            }

            if (ddl_Class.SelectedValue != "")
            {
                int clsid=ddl_Class.SelectedValue.ToInt32();
                q = q.Where(p => p.ClassID == clsid);
            }

            if (cls > 0)
            {
                q = q.Where(p => p.ClassID == cls);
                //ddl_Class_search.Visible = false;
                ddl_Class_search.Enabled = false;
                ddl_Class.Enabled = false;
            }
            if (ddl_Class_search.SelectedValue != "")
            {
                int clsid = ddl_Class_search.SelectedValue.ToInt32();
                q = q.Where(p => p.ClassID == clsid);
            }


            rp_list.DataSource = q.Skip(pager.CurrentPageIndex-1).Take(pager.PageSize);
            pager.RecordCount = q.Count();
            rp_list.DataBind();


        }
        #endregion

        /// <summary>
        /// 停用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_disable_Click(object sender, EventArgs e)
        {
            string[] ids = WS.RequestString("id").Split(',');
            DataEntities ent = new DataEntities();
            foreach(string id in ids)
            {
                int int_id = id.ToInt32();
                var item = (from l in ent.Book where l.ID == int_id select l).FirstOrDefault();
                item.Enable = false;
            }
            ent.SaveChanges();
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
            string[] ids = WS.RequestString("id").Split(',');
            DataEntities ent = new DataEntities();
            foreach (string id in ids)
            {
                int int_id = id.ToInt32();
                var item = (from l in ent.Book where l.ID == int_id select l).FirstOrDefault();
                item.Enable = true;
            }
            ent.SaveChanges();
            ent.Dispose();

            if (cls > 0)
            {
                CreatePage.CreateListPage(ObjectExtents.Class(cls), 1);
            }
            CreatePage.GreateIndexPage();
            Js.Jump(url);
        }

        protected void btn_Status_Click(object sender, EventArgs e)
        {
            string[] ids = WS.RequestString("id").Split(',');
            DataEntities ent = new DataEntities();
            foreach (string id in ids)
            {
                int int_id = id.ToInt32();
                var item = (from l in ent.Book where l.ID == int_id select l).FirstOrDefault();
                item.Status = 1;
            }
            ent.SaveChanges();
            ent.Dispose();

            if (cls > 0)
            {
                CreatePage.CreateListPage(ObjectExtents.Class(cls), 1);
            }
            CreatePage.GreateIndexPage();
            Js.Jump(url);
        }

        protected void btn_Status0_Click(object sender, EventArgs e)
        {
            string[] ids = WS.RequestString("id").Split(',');
            DataEntities ent = new DataEntities();
            foreach (string id in ids)
            {
                int int_id = id.ToInt32();
                var item = (from l in ent.Book where l.ID == int_id select l).FirstOrDefault();
                item.Status = 0;
            }
            ent.SaveChanges();
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

            #region 删除目录
            List<Voodoo.Basement.Book> books = (from l in ent.Book where ids.IndexOf(l.ID.ToString()) > 0 select l).ToList();
            foreach (var book in books)
            {
                Voodoo.Basement.BookChapter firstChapter = (from l in ent.BookChapter where l.BookID == book.ID select l).FirstOrDefault();

                DirectoryInfo dir = new FileInfo(
                    Server.MapPath(
                        GetBookUrl(
                            book,
                            book.GetClass()
                            )
                       )
                    ).Directory;
                if (dir.Exists)
                {
                    dir.Delete(true);
                }


                DirectoryInfo dirTxt = new FileInfo(
                    Server.MapPath(
                        GetBookChapterTxtUrl(firstChapter, book.GetClass())
                        )
                        ).Directory;
                if (dirTxt.Exists)
                {
                    dirTxt.Delete(true);
                }
            }
            #endregion 删除目录

            GetHelper().ExecuteNonQuery(CommandType.Text, string.Format("delete from  Book where id in({0}); delete from BookChapter where BookId in({0})", ids));
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
                int int_id=id.ToInt32();
                Voodoo.Basement.Book b = (from l in ent.Book where l.ID==int_id select l).FirstOrDefault();
                Voodoo.Basement.CreatePage.CreateContentPage(b, b.GetClass());

                var chapters = (from l in ent.BookChapter where l.BookID == int_id select l).ToList();
                foreach (var c in chapters)
                {
                    Voodoo.Basement.CreatePage.CreateBookChapterPage(c, c.GetBook(), c.GetClass());
                }

            }


            CreatePage.GreateIndexPage();
            Js.Jump(url);
        }

    }
}
