using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Web;

using Voodoo.Basement;
using System.ServiceModel.Activation;

using System.IO;

namespace Web.e.api
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“ClientService”。
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class ClientService : IClientService
    {
        public List<Book> BookSearch(string str_sql)
        {
            using (DataEntities ent = new DataEntities())
            {
                return ent.CreateQuery<Book>(string.Format("select * from Book where {0}",str_sql)).ToList();
            }
        }

        public bool BookExist(string str_sql)
        {
            using (DataEntities ent = new DataEntities())
            {
                return ent.CreateQuery<Book>(string.Format("select * from Book where {0}", str_sql)).Count()>0;
            }
        }

        public Book BookFind(string str_sql)
        {
            using (DataEntities ent = new DataEntities())
            {
                return ent.CreateQuery<Book>(string.Format("select * from Book where {0}", str_sql)).FirstOrDefault();
            }
        }

        public Book GetBookByID(int id)
        {
            using (DataEntities ent = new DataEntities())
            {
                return (from l in ent.Book where l.ID == id select l).FirstOrDefault();
            }
        }

        public Book BookInsert(Book book)
        {
            using (DataEntities ent = new DataEntities())
            {
                ent.AddToBook(book);
                ent.SaveChanges();
                return book;
            }
        }

        public void BookUpdate(Book book)
        {
            using (DataEntities ent = new DataEntities())
            {
                var b = (from l in ent.Book where l.ID == book.ID select l).FirstOrDefault();
                b = book;
                ent.SaveChanges();
            }
        }

        public void BookDelete(string str_sql)
        {
            //删除文件
            DataEntities ent = new DataEntities();
            var books = ent.CreateQuery<Book>(string.Format("select * from Book where {0}", str_sql)).ToList();
            foreach (var book in books)
            {
                DirectoryInfo dir = new FileInfo(System.Web.HttpContext.Current.Server.MapPath(BasePage.GetBookUrl(book, book.GetClass()))).Directory;
                if (dir.Exists)
                {
                    dir.Delete(true);
                }
                ent.DeleteObject(book);
            }

            ent.SaveChanges();
            ent.Dispose();
        }


        public List<Class> ClassSearch(string str_sql)
        {
            using (DataEntities ent = new DataEntities())
            {
                return ent.CreateQuery<Class>(string.Format("select * from Class where {0}", str_sql)).ToList();
            }
        }

        public Class ClassFind(string str_sql)
        {
            using (DataEntities ent = new DataEntities())
            {
                return ent.CreateQuery<Class>(string.Format("select * from Class where {0}", str_sql)).FirstOrDefault();
            }
        }

        public Class GetClassByID(int id)
        {
            using (DataEntities ent = new DataEntities())
            {
                return (from l in ent.Class where l.ID == id select l).FirstOrDefault();
            }
        }

        public Class ClassInsert(Class cls)
        {
            using (DataEntities ent = new DataEntities())
            {
                ent.AddToClass(cls);
                ent.SaveChanges();
                return cls;
            }
        }

        public void ClassUpdate(Class cls)
        {
            using (DataEntities ent = new DataEntities())
            {
                var c = (from l in ent.Class where l.ID == cls.ID select l).FirstOrDefault();
                c = cls;
                ent.SaveChanges();
            }
        }

        public void ClassDelete(string str_sql)
        {
            DataEntities ent = new DataEntities();
            var books = ent.CreateQuery<Book>(string.Format("select * from Book where {0}", str_sql));
            foreach (var b in books)
            {
                ent.DeleteObject(b);
            }
            ent.SaveChanges();
            ent.Dispose();

        }



        public List<BookChapter> ChapterSearch(string str_sql)
        {
            using (DataEntities ent = new DataEntities())
            {
                return ent.CreateQuery<BookChapter>(string.Format("select * from BookChapter where {0}", str_sql)).ToList();
            }
        }

        public bool ChapterExist(string str_sql)
        {
            using (DataEntities ent = new DataEntities())
            {
                return ent.CreateQuery<BookChapter>(string.Format("select * from BookChapter where {0}", str_sql)).Count()>0;
            }

        }

        public BookChapter ChapterFind(string str_sql)
        {
            using (DataEntities ent = new DataEntities())
            {
                return ent.CreateQuery<BookChapter>(string.Format("select * from BookChapter where {0}", str_sql)).FirstOrDefault();
            }
        }

        public BookChapter GetChapterByID(long id)
        {
            using (DataEntities ent = new DataEntities())
            {
                return (from l in ent.BookChapter where l.ID == id select l).FirstOrDefault();
            }
        }

        public void ChapterInsert(BookChapter chapter, string Content)
        {
            DataEntities ent = new DataEntities();
            ent.AddToBookChapter(chapter);
            ent.SaveChanges();
            ent.Dispose();

            ///保存文件
            Class cls = chapter.GetClass(); ;
            string txtPath = HttpContext.Current.Server.MapPath(BasePage.GetBookChapterTxtUrl(chapter, cls));
            Voodoo.IO.File.Write(txtPath, Content);

            //生成页面
            Voodoo.Basement.CreatePage.CreateBookChapterPage(chapter,chapter.GetBook(), cls);
        }

        public void ChapterUpdate(BookChapter chapter, string Content)
        {
            using (DataEntities ent = new DataEntities())
            {
                var cpt = (from l in ent.BookChapter where l.ID == chapter.ID select l).FirstOrDefault();
                cpt = chapter;
                ent.SaveChanges();
            }
            ///保存文件
            Class cls = chapter.GetClass();
            string txtPath = AppDomain.CurrentDomain.BaseDirectory + BasePage.GetBookChapterTxtUrl(chapter, cls).Replace("/", "\\");

            Voodoo.IO.File.Write(txtPath, Content);

            //生成页面
            Voodoo.Basement.CreatePage.CreateBookChapterPage(chapter, chapter.GetBook(), cls);
        }

        public void ChapterDelete(string str_sql)
        {
            //删除文件
            DataEntities ent = new DataEntities();

            var chapters = ent.CreateQuery<BookChapter>(string.Format("select * from BookChapter where {0}",str_sql));
            foreach (var chapter in chapters)
            {
                string htmlPath = HttpContext.Current.Server.MapPath(BasePage.GetBookChapterUrl(chapter, chapter.GetClass()));
                string txtPath = HttpContext.Current.Server.MapPath(BasePage.GetBookChapterTxtUrl(chapter, chapter.GetClass()));

                Voodoo.IO.File.Delete(htmlPath);
                Voodoo.IO.File.Delete(txtPath);
                ent.DeleteObject(chapter);
            }
            ent.SaveChanges();
            ent.Dispose();

        }

        public string GetChapterText(BookChapter chapter)
        {
            return Voodoo.IO.File.Read(System.Web.HttpContext.Current.Server.MapPath(BasePage.GetBookChapterTxtUrl(chapter, chapter.GetClass())));
        }

        #region 生成首页
        /// <summary>
        /// 生成首页
        /// </summary>
        public void CreateIndex()
        {
            try
            {
                Voodoo.Basement.CreatePage.GreateIndexPage();
            }
            catch (System.Exception e)
            {
            }

        }
        #endregion

        #region 创建列表页面
        /// <summary>
        /// 创建列表页面
        /// </summary>
        public void CreateClassPage()
        {
            try
            {
                var cls = ClassAction.Classes;
                foreach (var c in cls)
                {
                    Voodoo.Basement.CreatePage.CreateListPage(c, 1);
                }
            }
            catch (System.Exception e)
            {
            }


        }
        #endregion

        public void CreateBookPage(Book book)
        {
            Voodoo.Basement.CreatePage.CreateContentPage(book, book.GetClass());
        }
    }
}
