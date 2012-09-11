using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

using Voodoo;
using Voodoo.Basement;
using System.IO;
using System.Data;
using Voodoo.other.SEO;

namespace Web.e.admin.system.Update
{
    public partial class Createpages : AdminBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_Index_Click(object sender, EventArgs e)
        {
            CreatePage.GreateIndexPage();
            Js.AlertAndGoback("成功！");
        }

        protected void btn_List_Click(object sender, EventArgs e)
        {
            var cls = ClassAction.Classes;
            //cls = cls.Where(p => p.IsLeafClass).ToList();
            Response.Buffer = false;
            foreach (var c in cls)
            {
                try
                {
                    Response.Write(string.Format("正在生成列表页：{0}<br/>", c.ClassName));
                    CreatePage.CreateListPage(c, 1);
                }
                catch (Exception ex)
                {
                    Response.Write(string.Format("{0}<br/>{1}<br />", ex.Message, Server.MapPath(BasePage.GetClassUrl(c))));
                }
            }

            Js.AlertAndGoback("成功！");

        }

        protected void btn_Content_Click(object sender, EventArgs e)
        {
            Response.Buffer = false;
            Js.ScrollEnd();
            DataEntities ent = new DataEntities();
            var newses = from l in ent.News where l.Audit == true select l;
            ent.Dispose();

            foreach (var n in newses)
            {
                Response.Write(string.Format("正在生成内容页：{0}<br/>", n.Title));
                try
                {
                    CreatePage.CreateContentPage(n, n.GetClass());
                }
                catch (Exception ex)
                {
                    Response.Write(string.Format("{0}<br/>", ex.Message));
                }
            }

            ent = new DataEntities();
            var imgs = from l in ent.ImageAlbum select l;
            ent.Dispose();
            foreach (var img in imgs)
            {
                try
                {
                    Response.Write(string.Format("正在生成内容页：{0}<br/>", img.Title));
                    CreatePage.CreateContentPage(img, img.GetClass());
                }
                catch (Exception ex)
                {
                    Response.Write(string.Format("{0}<br/>", ex.Message));
                }
            }

            ent = new DataEntities();
            var ques = from l in ent.Question select l;
            ent.Dispose();
            foreach (var q in ques)
            {
                try
                {
                    Response.Write(string.Format("正在生成内容页：{0}<br/>", q.Title));
                    CreatePage.CreateContentPage(q, q.GetClass());
                }
                catch (Exception ex)
                {
                    Response.Write(string.Format("{0}<br/>", ex.Message));
                }
            }

            ent = new DataEntities();
            var books = from l in ent.Book select l;
            ent.Dispose();
            foreach (var b in books)
            {
                try
                {
                    Response.Write(string.Format("正在生成内容页：{0}<br/>", b.Title));
                    CreatePage.CreateContentPage(b, b.GetClass());
                    Js.ScrollEndStart();
                }
                catch (Exception ex)
                {
                    Response.Write(string.Format("{0}<br/>", ex.Message));
                }
            }


            Js.AlertAndGoback("成功！");
        }

        protected void btn_ClearAll_Click(object sender, EventArgs e)
        {
            Response.Buffer = false;

            DirectoryInfo dir = new DirectoryInfo(Server.MapPath("~/Book/"));
            if (dir.Exists)
            {
                FileInfo[] files = dir.GetFiles();
                foreach (FileInfo file in files)
                {
                    Response.Write(string.Format("正在删除文件：{0}<br/>", file.Name));
                    file.Delete();
                }

                DirectoryInfo[] subdirs = dir.GetDirectories();
                foreach (DirectoryInfo subdir in subdirs)
                {
                    Response.Write(string.Format("正在删除目录：{0}<br/>", subdir.Name));
                    subdir.Delete(true);
                }


            }

            dir = new DirectoryInfo(Server.MapPath(SystemSetting.ClassFolder));
            if (dir.Exists)
            {
                FileInfo[] files = dir.GetFiles();
                foreach (FileInfo file in files)
                {
                    Response.Write(string.Format("正在删除文件：{0}<br/>", file.Name));
                    file.Delete();
                }

                DirectoryInfo[] subdirs = dir.GetDirectories();
                foreach (DirectoryInfo subdir in subdirs)
                {
                    Response.Write(string.Format("正在删除目录：{0}<br/>", subdir.Name));
                    subdir.Delete(true);
                }


            }

            Js.AlertAndGoback("成功！");
        }

        protected void btn_Chapter_Click(object sender, EventArgs e)
        {
            Response.Buffer = false;
            DataEntities ent = new DataEntities();
            var chapters = from l in ent.BookChapter select l;
            ent.Dispose();
            foreach (var c in chapters)
            {
                try
                {
                    Response.Write(string.Format("正在生成章节：{0}<br/>", c.Title));
                    CreatePage.CreateBookChapterPage(c, c.GetBook(), c.GetClass());
                    Js.ScrollEndStart();
                }
                catch (Exception ex)
                {
                    Response.Write(string.Format("{0}<br/>", ex.Message));
                }

            }

            Js.AlertAndGoback("成功！");
        }

        protected void btn_Excute_Click(object sender, EventArgs e)
        {
            Voodoo.Data.IDbHelper Helper = Voodoo.Setting.DataBase.GetHelper();
            GridView1.DataSource = Helper.ExecuteDataTable(CommandType.Text, txt_SQL.Text);
            GridView1.DataBind();


        }

        protected void btn_GenSitreMap_Click(object sender, EventArgs e)
        {


            Voodoo.other.SEO.SiteMap sm = new Voodoo.other.SEO.SiteMap();
            sm.url = new List<PageInfo>();

            sm.url.Add(new PageInfo() { changefreq = "always", lastmod = DateTime.Now, loc = SystemSetting.SiteUrl, priority = "1.0" });

            DataEntities ent = new DataEntities();
            List<Voodoo.Basement.Book> bs = //BookView.GetModelList("id>0 order by UpdateTime desc", 100);
                (from l in ent.Book orderby l.UpdateTime descending select l).Take(100).ToList();

            foreach (Voodoo.Basement.Book b in bs)
            {
                sm.url.Add(new PageInfo()
                {
                    changefreq = "daily",
                    lastmod = b.UpdateTime.ToDateTime(),
                    loc = (SystemSetting.SiteUrl + BasePage.GetBookUrl(b, b.GetClass())).Replace("//Book/", "/Book/"),
                    priority = "0.8"
                });
            }

            List<BookChapter> bcs = //BookChapterView.GetModelList("id>0 order by UpdateTime desc", 500);
                (from l in ent.BookChapter orderby l.UpdateTime descending select l).Take(500).ToList();
            foreach (BookChapter bc in bcs)
            {
                sm.url.Add(new PageInfo()
                {
                    changefreq = "monthly",
                    lastmod = bc.UpdateTime,
                    loc = (SystemSetting.SiteUrl + BasePage.GetBookChapterUrl(bc, bc.GetClass())).Replace("//Book/", "/Book/"),
                    priority = "0.7"
                });
            }

            ent.Dispose();
            sm.SaveSiteMap(Server.MapPath("~/sitemapxml/index.xml"));

        }

        protected void btn_Drama_Click(object sender, EventArgs e)
        {
            //Response.Buffer = false;
            //List<MovieUrlKuaib> ks = MovieUrlKuaibView.GetModelList();
            //foreach (var k in ks)
            //{
            //    Response.Write(string.Format("正在生成快播页面：{0}<br/>", k.Title));
            //    CreatePage.CreateDramapage(k, MovieInfoView.GetClass(k));
            //}

            //List<MovieUrlBaidu> bs = MovieUrlBaiduView.GetModelList();
            //foreach (var b in bs)
            //{
            //    Response.Write(string.Format("正在生成百度页面：{0}<br/>", b.Title));
            //    CreatePage.CreateDramapage(b, MovieInfoView.GetClass(b));
            //}

            //List<MovieDrama> ds = MovieDramaView.GetModelList();
            //foreach (var d in ds)
            //{
            //    Response.Write(string.Format("正在生成剧集列表页面：{0}<br/>", d.Title));
            //    CreatePage.CreateDramapage(d, MovieInfoView.GetClass(d));
            //}
        }

        protected void btn_CreatePage_Click(object sender, EventArgs e)
        {
            Response.Buffer = false;
            DataEntities ent = new DataEntities();
            var pages = (from l in ent.TemplatePage select l).ToList();
            ent.Dispose();
            foreach (var page in pages)
            {
                Response.Write(string.Format("正在生成页面：{0}<br/>", page.PageName));
                CreatePage.CreatePages(page);
            }
        }

        protected void btn_Move_Click(object sender, EventArgs e)
        {
            CopyDirectory(Server.MapPath(txt_OldFolder.Text), Server.MapPath(txt_NewFolder.Text));

        }

        /// <summary>
        /// 拷贝文件夹
        ///By Wang Hw  www.pegete.com.cn 
        /// </summary>
        /// <param name="srcdir"></param>
        /// <param name="desdir"></param>
        private void CopyDirectory(string srcdir, string desdir)
        {
            Response.Buffer = false;

            string folderName = srcdir.Substring(srcdir.LastIndexOf("\\") + 1);

            string desfolderdir = desdir + "\\" + folderName;

            if (desdir.LastIndexOf("\\") == (desdir.Length - 1))
            {
                desfolderdir = desdir + folderName;
            }
            string[] filenames = Directory.GetFileSystemEntries(srcdir);

            foreach (string file in filenames)// 遍历所有的文件和目录
            {
                if (Directory.Exists(file))// 先当作目录处理如果存在这个目录就递归Copy该目录下面的文件
                {

                    string currentdir = desfolderdir + "\\" + file.Substring(file.LastIndexOf("\\") + 1);
                    if (!Directory.Exists(currentdir))
                    {
                        Directory.CreateDirectory(currentdir);
                        Response.Write(string.Format("正在创建目录：{0}<br />", currentdir));
                    }

                    CopyDirectory(file, desfolderdir);
                }

                else // 否则直接copy文件
                {
                    string srcfileName = file.Substring(file.LastIndexOf("\\") + 1);

                    srcfileName = desfolderdir + "\\" + srcfileName;


                    if (!Directory.Exists(desfolderdir))
                    {
                        Directory.CreateDirectory(desfolderdir);
                    }
                    FileInfo newFile = new FileInfo(file);
                    if (newFile.Exists)
                    {
                        newFile.Delete();
                    }
                    try
                    {
                        System.IO.File.Copy(file, srcfileName);
                        Response.Write(string.Format("正在复制文件：{0}<br />", srcfileName));
                    }
                    catch (Exception ex)
                    {
                        Response.Write(string.Format("复制文件：{0} 出错：{1}<br />", srcfileName, ex.Message));
                    }
                }
            }//foreach
        }//function end


    }
}
