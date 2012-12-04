using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Voodoo;

using Voodoo.Security;
using Voodoo.IO;

using System.Text.RegularExpressions;
using System.Reflection;

namespace Voodoo.Basement
{
    public class TemplateHelper : System.Web.UI.Page
    {

        #region 模型替换
        /// <summary>
        /// 获取当前列表模版
        /// </summary>
        /// <param name="cls"></param>
        /// <returns></returns>
        public TemplateList GetListTemplate(Class cls)
        {
            using (DataEntities ent = new DataEntities())
            {
                var temp = from l in ent.TemplateList where l.ID == cls.ListTemplateID select l;
                if (temp.Count() == 0)
                {
                    return (from l in ent.TemplateList where l.SysModel == cls.ModelID select l).FirstOrDefault();
                }
                else
                {
                    return temp.First();
                }
            }
        }
        public TemplateContent GetContentTemplate(Class cls)
        {
            using (DataEntities ent = new DataEntities())
            {
                var temp = from l in ent.TemplateContent where l.ID == cls.ContentTemplateID select l;
                if (temp.Count() == 0)
                {
                    return (from l in ent.TemplateContent where l.SysModel == cls.ModelID select l).FirstOrDefault();
                }
                else
                {
                    return temp.First();
                }
            }
        }

        /// <summary>
        /// 替换新闻
        /// </summary>
        /// <param name="TempString"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public string ReplaceContent(TemplateList temp, string TempString, News n, Class c)
        {
            string _title = "<font color='#" + n.TitleColor + "'>" + n.Title + "</font>";
            if (n.TitleB.ToBoolean() == true)
            {
                _title = "<strong>" + _title + "</strong>";
            }
            if (n.TitleI.ToBoolean() == true)
            {
                _title = "<I>" + _title + "</I>";
            }
            if (n.TitleS.ToBoolean() == true)
            {
                _title = "<STRIKE>" + _title + "</STRIKE>";
            }

            string r = TempString;
            r = r.Replace("[!--news.author--]", n.Author);
            r = r.Replace("[!--news.authorid--]", n.AutorID.ToS());
            r = r.Replace("[!--news.classname--]", c.ClassName);
            r = r.Replace("[!--news.classid--]", n.ClassID.ToS());
            r = r.Replace("[!--news.content--]", n.Content);
            r = r.Replace("[!--news.contenten--]", n.ContentEn);
            r = r.Replace("[!--news.description--]", n.Description);
            r = r.Replace("[!--news.downcount--]", n.DownCount.ToS());
            r = r.Replace("[!--news.filefolder--]", n.FileForder);
            r = r.Replace("[!--news.filename--]", n.FileName);
            r = r.Replace("[!--news.ftile--]", n.FTitle);
            r = r.Replace("[!--news.id--]", n.ID.ToS());
            r = r.Replace("[!--news.keywords--]", n.KeyWords);
            r = r.Replace("[!--news.navurl--]", n.NavUrl);
            r = r.Replace("[!--news.newstime--]", n.NewsTime.ToDateTime().ToString(temp.TimeFormat));
            r = r.Replace("[!--news.source--]", n.Source);
            r = r.Replace("[!--news.title--]", n.Title);
            r = r.Replace("[!--news.oldtitle--]", n.Title);
            r = r.Replace("[!--news.ftitle--]", _title);
            r = r.Replace("[!--news.titlecolor--]", n.TitleColor);
            r = r.Replace("[!--news.titleimage--]", n.TitleImage);
            r = r.Replace("[!--news.ztid--]", n.ZtID.ToS());
            r = r.Replace("[!--news.url--]", BasePage.GetNewsUrl(n, c));

            return r;
        }

        public string ReplaceContent(string TempString, News n, Class c)
        {
            return ReplaceContent(new TemplateList() { TimeFormat = "yyyy-MM-dd HH:mm:ss", CutTitle = 0 }, TempString, n, c);
        }

        /// <summary>
        /// 替换图片
        /// </summary>
        /// <param name="TempString"></param>
        /// <param name="n"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public string ReplaceContent(TemplateList temp, string TempString, ImageAlbum n, Class c)
        {
            string r = TempString;

            r = r.Replace("[!--image.author--]", n.Author);
            r = r.Replace("[!--image.authorid--]", n.AuthorID.ToS());
            r = r.Replace("[!--image.classid--]", n.ClassID.ToS());
            r = r.Replace("[!--image.clickcount--]", n.ClickCount.ToS());
            r = r.Replace("[!--image.createtime--]", n.CreateTime.ToDateTime().ToString(temp.TimeFormat));
            r = r.Replace("[!--image.folder--]", n.Folder);
            r = r.Replace("[!--image.id--]", n.ID.ToS());
            r = r.Replace("[!--image.intro--]", n.Intro);
            r = r.Replace("[!--image.replycount--]", n.ReplyCount.ToS());
            r = r.Replace("[!--image.size--]", n.Size.ToS());
            r = r.Replace("[!--image.title--]", n.Title);
            r = r.Replace("[!--image.updatetime--]", n.UpdateTime.ToDateTime().ToString(temp.TimeFormat));
            r = r.Replace("[!--image.ztid--]", n.ZtID.ToS());
            r = r.Replace("[!--image.url--]", BasePage.GetImageUrl(n, c));

            return r;
        }
        public string ReplaceContent(string TempString, ImageAlbum n, Class c)
        {
            return ReplaceContent(new TemplateList() { TimeFormat = "yyyy-MM-dd HH:mm:ss", CutTitle = 0 }, TempString, n, c);
        }

        /// <summary>
        /// 替换问答
        /// </summary>
        /// <param name="TempString"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public string ReplaceContent(TemplateList temp, string TempString, Question q, Class c)
        {
            using (DataEntities ent = new DataEntities())
            {
                string str_lst = TempString;

                str_lst = str_lst.Replace("[!--question.url--]", BasePage.GetQuestionUrl(q, c));//问题地址
                str_lst = str_lst.Replace("[!--question.asktime--]", q.AskTime.ToDateTime().ToString(temp.TimeFormat));
                str_lst = str_lst.Replace("[!--question.classid--]", q.ClassID.ToS());
                str_lst = str_lst.Replace("[!--question.clickcount--]", q.ClickCount.ToS());
                str_lst = str_lst.Replace("[!--question.content--]", q.Content);
                str_lst = str_lst.Replace("[!--question.id--]", q.ID.ToS());
                str_lst = str_lst.Replace("[!--question.title--]", q.Title);
                str_lst = str_lst.Replace("[!--question.ftitle--]", temp.CutTitle > 0 ? q.Title.CutString(temp.CutTitle.ToInt32()) : q.Title);
                str_lst = str_lst.Replace("[!--question.userid--]", q.UserID.ToS());
                str_lst = str_lst.Replace("[!--question.username--]", q.UserName);
                str_lst = str_lst.Replace("[!--question.ztid--]", q.ZtID.ToS());
                str_lst = str_lst.Replace("[!--question.answercount--]", (from l in ent.Answer where l.QuestionID == q.ID select l).Count().ToS());
                return str_lst;
            }


        }
        public string ReplaceContent(string TempString, Question n, Class c)
        {
            return ReplaceContent(new TemplateList() { TimeFormat = "yyyy-MM-dd HH:mm:ss", CutTitle = 0 }, TempString, n, c);
        }

        public string ReplaceContent(TemplateList temp, string TempString, Product p, Class c)
        {
            using (DataEntities ent = new DataEntities())
            {
                string str_lst = TempString;
                str_lst = str_lst.Replace("[!--productaddtime.--]", p.AddTime.ToDateTime().ToString(temp.TimeFormat));
                str_lst = str_lst.Replace("[!--product.classid--]", p.ClassID.ToS());
                str_lst = str_lst.Replace("[!--product.classname--]", p.ClassName);
                str_lst = str_lst.Replace("[!--product.clickcount--]", p.ClickCount.ToS());
                str_lst = str_lst.Replace("[!--product.contact--]", p.Contact);
                str_lst = str_lst.Replace("[!--product.enable--]", p.Enable.ToBoolean().ToChinese());
                str_lst = str_lst.Replace("[!--product.faceimage--]", p.FaceImage);
                str_lst = str_lst.Replace("[!--product.id--]", p.ID.ToS());
                str_lst = str_lst.Replace("[!--product.intro--]", p.Intro);
                str_lst = str_lst.Replace("[!--product.name--]", p.Name);
                str_lst = str_lst.Replace("[!--product.orderindex--]", p.OrderIndex.ToS());
                str_lst = str_lst.Replace("[!--product.price-]", p.Price.ToDecimal().ToString("#.##"));
                str_lst = str_lst.Replace("[!--product.producelocation--]", p.ProduceLocation);
                str_lst = str_lst.Replace("[!--product.settop--]", p.SetTop.ToBoolean().ToChinese());
                str_lst = str_lst.Replace("[!--product.specification--]", p.Specification);
                str_lst = str_lst.Replace("[!--product.tel--]", p.Tel);
                str_lst = str_lst.Replace("[!--product.units--]", p.Units);
                str_lst = str_lst.Replace("[!--product.url--]", BasePage.GetProductUrl(p, c));

                var files = from l in ent.File where l.ItemID == p.ID select l;
                StringBuilder fileHtml=new StringBuilder();;
                foreach (var file in files)
                {
                    string fTemp = string.Format("<a class=upfile href={0} target=_blank>{1}</a> <br/> ",file.FilePath,file.FileName);
                    fileHtml.Append(fTemp);
                }
                str_lst = str_lst.Replace("[!--product.files--]", fileHtml.ToS());

                return str_lst;
            }
        }

        public string ReplaceContent(string TempString, Product p, Class c)
        {
            return ReplaceContent(new TemplateList() { TimeFormat = "yyyy-MM-dd HH:mm:ss", CutTitle = 0 }, TempString, p, c);
        }

        /// <summary>
        /// 替换小说
        /// </summary>
        /// <param name="TempString"></param>
        /// <param name="q"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public string ReplaceContent(TemplateList temp, string TempString, Book b, Class c)
        {
            string str_lst = TempString;

            str_lst = str_lst.Replace("[!--class.name--]", c.ClassName);
            str_lst = str_lst.Replace("[!--class.id--]", c.ID.ToS());
            str_lst = str_lst.Replace("[!--class.url--]", BasePage.GetClassUrl(c));

            str_lst = str_lst.Replace("[!--book.url--]", BasePage.GetBookUrl(b, b.GetClass()));//书籍
            str_lst = str_lst.Replace("[!--book.lastchapterurl--]", BasePage.GetBookChapterUrl(ObjectExtents.Chapter(b.LastChapterID), b.GetClass()));//书籍
            str_lst = str_lst.Replace("[!--book.id--]", b.ID.ToString());
            str_lst = str_lst.Replace("[!--book.classid--]", b.ClassID.ToS());
            str_lst = str_lst.Replace("[!--book.classname--]", b.ClassName);
            str_lst = str_lst.Replace("[!--book.ztid--]", b.ZtID.ToS());
            str_lst = str_lst.Replace("[!--book.ztname--]", b.ZtName);
            str_lst = str_lst.Replace("[!--book.title--]", temp.CutTitle > 0 ? b.Title.CutString(temp.CutTitle.ToInt32()) : b.Title);
            str_lst = str_lst.Replace("[!--book.oldtitle--]", b.Title);
            str_lst = str_lst.Replace("[!--book.author--]", b.Author);
            str_lst = str_lst.Replace("[!--book.intro--]", b.Intro.HtmlDeCode());
            str_lst = str_lst.Replace("[!--book.length--]", b.Length.ToS());
            str_lst = str_lst.Replace("[!--book.replycount--]", b.ReplyCount.ToS());
            str_lst = str_lst.Replace("[!--book.addtime--]", b.Addtime.ToDateTime().ToString(temp.TimeFormat));
            str_lst = str_lst.Replace("[!--book.status--]", b.Status.ToS());
            str_lst = str_lst.Replace("[!--book.isvip--]", b.IsVip.ToBoolean().ToChinese());
            str_lst = str_lst.Replace("[!--book.faceimage--]", b.FaceImage);
            str_lst = str_lst.Replace("[!--book.savecount--]", b.SaveCount.ToS());
            str_lst = str_lst.Replace("[!--book.enable--]", b.Enable.ToBoolean().ToChinese());
            str_lst = str_lst.Replace("[!--book.isfirstpost--]", b.IsFirstPost.ToBoolean().ToChinese());
            str_lst = str_lst.Replace("[!--book.lastchapterid--]", b.LastChapterID.ToS());
            str_lst = str_lst.Replace("[!--book.lastchaptertitle--]", b.LastChapterTitle);
            str_lst = str_lst.Replace("[!--book.updatetime--]", b.UpdateTime.ToDateTime().ToString(temp.TimeFormat));
            str_lst = str_lst.Replace("[!--book.lastvipchapterid--]", b.LastVipChapterID.ToS());
            str_lst = str_lst.Replace("[!--book.lastvipchaptertitle--]", b.LastVipChapterTitle);
            str_lst = str_lst.Replace("[!--book.vipupdatetime--]", b.VipUpdateTime.ToDateTime().ToString(temp.TimeFormat));
            str_lst = str_lst.Replace("[!--book.corpusid--]", b.CorpusID.ToS());
            str_lst = str_lst.Replace("[!--book.corpustitle--]", b.CorpusTitle);
            str_lst = str_lst.Replace("[!--book.clickcount--]", b.ClickCount.ToS());
            str_lst = str_lst.Replace("[!--book.tjcount--]", b.TjCount.ToS());
            return str_lst;
        }

        public string ReplaceContent(string TempString, Book n, Class c)
        {
            return ReplaceContent(new TemplateList() { TimeFormat = "yyyy-MM-dd HH:mm:ss", CutTitle = 0 }, TempString, n, c);
        }

        /// <summary>
        /// 替换影视
        /// </summary>
        /// <param name="temp"></param>
        /// <param name="TempString"></param>
        /// <param name="m"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public string ReplaceContent(TemplateList temp, string TempString, MovieInfo m, Class c)
        {
            string str_lst = temp.ListVar;
            str_lst = str_lst.Replace("[!--movie.url--]", BasePage.GetMovieUrl(m, m.GetClass()));
            str_lst = str_lst.Replace("[!--movie.actors--]", m.Actors);
            str_lst = str_lst.Replace("[!--movie.classid--]", m.ClassID.ToS());
            str_lst = str_lst.Replace("[!--movie.classname--]", m.ClassName);
            str_lst = str_lst.Replace("[!--movie.director--]", m.Director);
            str_lst = str_lst.Replace("[!--movie.enable--]", m.Enable.ToInt32().ToS());
            str_lst = str_lst.Replace("[!--movie.faceimage--]", m.FaceImage);
            str_lst = str_lst.Replace("[!--movie.id--]", m.id.ToS());
            str_lst = str_lst.Replace("[!--movie.inserttime--]", m.InsertTime.ToDateTime().ToString(temp.TimeFormat));
            str_lst = str_lst.Replace("[!--movie.intro--]", m.Intro.TrimHTML());
            str_lst = str_lst.Replace("[!--movie.ismove--]", m.IsMove.ToInt32().ToS());
            str_lst = str_lst.Replace("[!--movie.lastdramatitle--]", m.LastDramaTitle);
            str_lst = str_lst.Replace("[!--movie.location--]", m.Location);
            str_lst = str_lst.Replace("[!--movie.publicyear--]", m.PublicYear);
            str_lst = str_lst.Replace("[!--movie.status--]", m.Status.ToS());
            str_lst = str_lst.Replace("[!--movie.tags--]", m.Tags);
            str_lst = str_lst.Replace("[!--movie.title--]", m.Title);
            str_lst = str_lst.Replace("[!--movie.updatetimetime--]", m.UpdateTime.ToDateTime().ToString(temp.TimeFormat));
            return str_lst;
        }
        public string ReplaceContent(string TempString, MovieInfo n, Class c)
        {
            return ReplaceContent(new TemplateList() { TimeFormat = "yyyy-MM-dd HH:mm:ss", CutTitle = 0 }, TempString, n, c);
        }

        #endregion



        #region 首页

        public string GetIndex()
        {
            return GetIndex(TempType.首页);
        }

        /// <summary>
        /// 首页
        /// </summary>
        /// <returns></returns>
        public string GetIndex(TempType type)
        {
            SysSetting setting = BasePage.SystemSetting;
            string Content = "";
            Content = GetTempateString(1, type);

            //替换三层公共模版变量
            Content = ReplacePublicTemplate(Content);
            Content = ReplacePublicTemplate(Content);
            Content = ReplacePublicTemplate(Content);

            Content = ReplaceSystemSetting(Content);
            Content = ReplaceTagContent(Content);

            return Content;
        }
        #endregion

        #region 创建列表页面
        /// <summary>
        /// 创建列表页面
        /// </summary>
        /// <param name="c"></param>
        /// <param name="page"></param>
        public string CreateListPage(Class c, int page)
        {
            DataEntities ent = new DataEntities();

            int pagecount = 1;
            int recordCount = 0;
            TemplateList temp = GetListTemplate(c);


            string Content = temp.Content;

            //公共模版变量
            Content = ReplacePublicTemplate(Content);
            Content = ReplacePublicTemplate(Content);
            Content = ReplacePublicTemplate(Content);

            //系统参数
            Content = ReplaceSystemSetting(Content);

            //分类属性
            Content = Content.Replace("[!--class.page--]", page.ToS());
            Content = Content.Replace("[!--class.alter--]", c.Alter);
            Content = Content.Replace("[!--class.classdescription--]", c.ClassDescription);
            Content = Content.Replace("[!--class.classfolder--]", c.ClassForder);
            Content = Content.Replace("[!--class.classicon--]", c.ClassICON);
            Content = Content.Replace("[!--class.classkeywords--]", c.ClassKeywords);
            Content = Content.Replace("[!--class.classname--]", c.ClassName);
            Content = Content.Replace("[!--class.classpageextname--]", c.ClassPageExtName);
            Content = Content.Replace("[!--class.contentpagefolder--]", c.ContentPageForder);
            Content = Content.Replace("[!--class.id--]", c.ID.ToS());
            Content = Content.Replace("[!--class.listpagesize--]", c.ListPageSize.ToS());


            Content = Content.Replace("[!--class.description--]", c.ClassDescription);
            Content = Content.Replace("[!--class.url--]", BasePage.GetClassUrl(c));


            //此处要区分系统模型
            #region 替换列表

            #region 新闻系统模板
            if (c.ModelID == 1)//新闻系统模板
            {
                StringBuilder sb_list = new StringBuilder();
                List<News> ns = (from l in ent.News
                                 //from cp in ent.Class
                                 //from cl in ent.Class
                                 //where cp.ID == cl.ID && cl.ParentID == cp.ID && (l.ClassID == cl.ID || l.ClassID == cp.ID)
                                 where l.ClassID==c.ID
                                 select l).ToList();
                pagecount = (Convert.ToDouble(ns.Count) / Convert.ToDouble(temp.ShowRecordCount)).YueShu();
                recordCount = ns.Count;

                ns = ns.Skip((page - 1) * temp.ShowRecordCount.ToInt32()).Take(temp.ShowRecordCount.ToInt32()).ToList();
                int i = 0;
                foreach (News n in ns)
                {
                    i++;
                    string str_odd = "";
                    if (i % 2 == 0)
                    {
                        str_odd = "odd";
                    }
                    sb_list.AppendLine(ReplaceContent(temp, temp.ListVar, n, c).Replace("{odd}", str_odd));
                }

                Content = Content.Replace("<!--list.var-->", sb_list.ToString());
            }//end 新闻系统模板
            #endregion  新闻系统模板

            #region 图片系统模板
            else if (c.ModelID == 2)//图片系统模板
            {
                StringBuilder sb_list = new StringBuilder();
                List<ImageAlbum> ns = (from l in ent.ImageAlbum
                                       from cp in ent.Class
                                       from cl in ent.Class
                                       where cp.ID == c.ID && cp.ID == cl.ParentID && (l.ClassID == cp.ID || l.ClassID == cl.ID)
                                       select l).ToList();
                pagecount = (Convert.ToDouble(ns.Count) / Convert.ToDouble(temp.ShowRecordCount)).YueShu();
                recordCount = ns.Count;

                ns = ns.Skip((page - 1) * temp.ShowRecordCount.ToInt32()).Take(temp.ShowRecordCount.ToInt32()).ToList();
                int i = 0;
                foreach (ImageAlbum n in ns)
                {
                    i++;
                    string str_odd = "";
                    if (i % 2 == 0)
                    {
                        str_odd = "odd";
                    }
                    sb_list.AppendLine(ReplaceContent(temp, temp.ListVar, n, c).Replace("{odd}",str_odd));
                }

                Content = Content.Replace("<!--list.var-->", sb_list.ToString());
            }
            #endregion  图片系统模板

            #region 问答系统
            else if (c.ModelID == 3)
            {
                StringBuilder sb_list = new StringBuilder();
                List<Question> qs =
                    (from l in ent.Question
                     from cp in ent.Class
                     from cl in ent.Class
                     where cp.ID == c.ID && cl.ParentID == cp.ID && (l.ClassID == cp.ID || l.ClassID == cl.ID)
                     select l
                ).ToList();
                pagecount = (Convert.ToDouble(qs.Count) / Convert.ToDouble(temp.ShowRecordCount)).YueShu();
                recordCount = qs.Count;

                qs = qs.Skip((page - 1) * temp.ShowRecordCount.ToInt32()).Take(temp.ShowRecordCount.ToInt32()).ToList();
                foreach (Question q in qs)
                {
                    sb_list.AppendLine(ReplaceContent(temp, temp.ListVar, q, c));
                }
                Content = Content.Replace("<!--list.var-->", sb_list.ToString());
            }
            #endregion 问答系统

            #region 小说系统
            else if (c.ModelID == 4)
            {
                StringBuilder sb_list = new StringBuilder();
                List<Book> qs =
                    (from l in ent.Book
                     from cp in ent.Class//sub class
                     where
                        (l.ClassID == c.ID && cp.ID == c.ID) ||
                        (l.ClassID == cp.ID && cp.ParentID == c.ID)

                     select l
                ).ToList();
                pagecount = (Convert.ToDouble(qs.Count) / Convert.ToDouble(temp.ShowRecordCount)).YueShu();
                recordCount = qs.Count;

                qs = qs.Skip((page - 1) * temp.ShowRecordCount.ToInt32()).Take(temp.ShowRecordCount.ToInt32()).ToList();
                foreach (Book b in qs)
                {
                    sb_list.AppendLine(ReplaceContent(temp, temp.ListVar, b, c));
                }
                Content = Content.Replace("<!--list.var-->", sb_list.ToString());
            }
            #endregion 小说系统

            #region 分类系统
            else if (c.ModelID == 5)
            {

            }
            #endregion

            #region 影视
            else if (c.ModelID == 6)
            {
                StringBuilder sb_list = new StringBuilder();
                List<MovieInfo> qs =
                    (from l in ent.MovieInfo
                     from cp in ent.Class
                     from cl in ent.Class
                     where cp.ID == c.ID && cl.ParentID == cp.ID && (l.ClassID == cp.ID || l.ClassID == cl.ID)
                     select l
                ).ToList();
                pagecount = (Convert.ToDouble(qs.Count) / Convert.ToDouble(temp.ShowRecordCount)).YueShu();
                recordCount = qs.Count;

                qs = qs.Skip((page - 1) * temp.ShowRecordCount.ToInt32()).Take(temp.ShowRecordCount.ToInt32()).ToList();
                foreach (MovieInfo m in qs)
                {
                    sb_list.AppendLine(ReplaceContent(temp, temp.ListVar, m, c));
                }
                Content = Content.Replace("<!--list.var-->", sb_list.ToString());
            }
            #endregion

            #region 产品系统
            else if (c.ModelID == 7)
            {
                StringBuilder sb_list = new StringBuilder();
                var qs = from l in ent.Product
                         //from cp in ent.Class
                         //from cl in ent.Class
                         where 
                         l.ClassID==c.ID
                         //(l.ClassID == c.ID && cp.ID == c.ID) ||
                         //(l.ClassID == cp.ID && cp.ParentID == c.ID)
                         select l;
                pagecount = (Convert.ToDouble(qs.Count()) / Convert.ToDouble(temp.ShowRecordCount)).YueShu();
                recordCount = qs.Count();

                var results = qs.OrderByDescending(p => p.ID).Skip((page - 1) * temp.ShowRecordCount.ToInt32()).Take(temp.ShowRecordCount.ToInt32()).ToList();
                foreach (var item in results)
                {
                    sb_list.AppendLine(ReplaceContent(temp, temp.ListVar, item, c));
                }
                Content = Content.Replace("<!--list.var-->", sb_list.ToString());
            }
            #endregion
            #endregion


            //替换标签变量
            Content = ReplaceTagContent(Content);

            #region 替换分页模板

            string tmp_pager = GetTempateString(1, TempType.列表分页);



            tmp_pager = tmp_pager.Replace("[!--thispage--]", page.ToS());
            tmp_pager = tmp_pager.Replace("[!--pagenum--]", pagecount.ToS());
            tmp_pager = tmp_pager.Replace("[!--lencord--]", temp.ShowRecordCount.ToS());
            tmp_pager = tmp_pager.Replace("[!--num--]", recordCount.ToS());
            tmp_pager = tmp_pager.Replace("[!--pagelink--]", BuildPagerLink(c, page));
            tmp_pager = tmp_pager.Replace("[!--options--]", BuidPagerOption(c, page));

            if (recordCount <= temp.ShowRecordCount)
            {
                tmp_pager = "";
            }

            Content = Content.Replace("[!--show.listpage--]", tmp_pager);

            #endregion

            //替换导航条
            Content = Content.Replace("[!--newsnav--]", BuildClassNavString(c));

            ent.Dispose();
            return Content;
        }
        #endregion

        #region  静态页面
        /// <summary>
        /// 静态页面
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetStatisPage(int id)
        {
            using (DataEntities ent = new DataEntities())
            {
                TemplatePage tp = (from l in ent.TemplatePage where l.id == id select l).FirstOrDefault();
                string Content = tp.Content;
                //替换三层公共模版变量
                Content = ReplacePublicTemplate(Content);
                Content = ReplacePublicTemplate(Content);
                Content = ReplacePublicTemplate(Content);

                Content = ReplaceSystemSetting(Content);

                Content = ReplaceTagContent(Content);

                Content = Content.Replace("<!--tempvar-->", tp.TempVar);

                return Content;
            }
        }
        #endregion

        #region  生成内容页--影视
        /// <summary>
        /// 生成内容页--影视
        /// </summary>
        /// <param name="album"></param>
        /// <param name="cls"></param>
        public string CreateContentPage(MovieInfo movie, Class cls)
        {
            DataEntities ent = new DataEntities();
            string Content = "";

            TemplateContent temp = GetContentTemplate(cls);



            Content = temp.Content;

            //公共变量
            Content = ReplacePublicTemplate(Content);
            Content = ReplacePublicTemplate(Content);
            Content = ReplacePublicTemplate(Content);

            //系统参数
            Content = ReplaceSystemSetting(Content);

            #region 替换内容

            Content = Content.Replace("[!--class.id--]", cls.ID.ToString());
            Content = Content.Replace("[!--class.name--]", cls.ClassName);
            Content = Content.Replace("[!--class.url--]", BasePage.GetClassUrl(cls));

            Content = ReplaceContent(Content, movie, cls);

            StringBuilder sb = new StringBuilder();
            List<MovieUrlKuaib> qb = (from l in ent.MovieUrlKuaib where l.MovieID == movie.id select l).ToList();
            string list_tmp = GetTempateString(1, TempType.下载地址);
            foreach (MovieUrlKuaib q in qb)
            {
                string row = list_tmp.Replace("[!--url.id--]", q.id.ToS());
                row = row.Replace("[!--url.url--]", q.Url);
                row = row.Replace("[!--url.title--]", q.Title);
                row = row.Replace("[!--url.movieid--]", q.MovieID.ToS());
                row = row.Replace("[!--url.movietitle--]", q.MovieTitle);
                row = row.Replace("[!--url--]", BasePage.GetMovieDramaUrl(q, q.GetClass()));
                sb.Append(row);
            }
            Content = Content.Replace("[!--movie.kuib--]", sb.ToS());


            sb = new StringBuilder();
            List<MovieUrlBaidu> baidu = (from l in ent.MovieUrlBaidu where l.MovieID == movie.id select l).ToList();
            foreach (MovieUrlBaidu q in baidu)
            {
                string row = list_tmp.Replace("[!--url.id--]", q.id.ToS());
                row = row.Replace("[!--url.url--]", q.Url);
                row = row.Replace("[!--url.title--]", q.Title);
                row = row.Replace("[!--url.movieid--]", q.MovieID.ToS());
                row = row.Replace("[!--url.movietitle--]", q.MovieTitle);
                row = row.Replace("[!--url--]", BasePage.GetMovieDramaUrl(q, q.GetClass()));
                sb.Append(row);
            }
            Content = Content.Replace("[!--movie.baidu--]", sb.ToS());

            sb = new StringBuilder();
            List<MovieUrlMag> mag = (from l in ent.MovieUrlMag where l.MovieID == movie.id select l).ToList();
            foreach (MovieUrlMag q in mag)
            {
                string row = list_tmp.Replace("[!--url.id--]", q.id.ToS());
                row = row.Replace("[!--url.url--]", q.Url);
                row = row.Replace("[!--url.title--]", q.Title);
                row = row.Replace("[!--url.movieid--]", q.MovieID.ToS());
                row = row.Replace("[!--url.movietitle--]", q.MovieTitle);
                sb.Append(row);
            }
            Content = Content.Replace("[!--movie.mag--]", sb.ToS());


            #endregion

            Content = ReplaceTagContent(Content);

            //替换导航条
            Content = Content.Replace("[!--newsnav--]", BuildClassNavString(cls));

            ent.Dispose();
            return Content;
        }
        #endregion

        #region 生成播放页面--快播
        /// <summary>
        /// 生成播放页面--快播
        /// </summary>
        /// <param name="kuaib">快播地址</param>
        /// <param name="cls">分类</param>
        public string CreateDramapage(MovieUrlKuaib kuaib, Class cls)
        {
            DataEntities ent = new DataEntities();

            MovieInfo movie = (from l in ent.MovieInfo where l.id == kuaib.MovieID select l).FirstOrDefault();

            string FileName = BasePage.GetMovieDramaUrl(kuaib, cls);
            string Content = "";




            Content = GetTempateString(1, TempType.快播页面);

            Content = ReplacePublicTemplate(Content);
            Content = ReplacePublicTemplate(Content);
            Content = ReplacePublicTemplate(Content);

            Content = ReplaceSystemSetting(Content);




            #region 替换内容

            MovieUrlKuaib next = BasePage.GetNextKuaibo(kuaib);
            if (next == null)
            {
                next = new MovieUrlKuaib();
                next.Url = "";
            }

            Content = Content.Replace("[!--class.id--]", cls.ID.ToString());
            Content = Content.Replace("[!--class.name--]", cls.ClassName);
            Content = Content.Replace("[!--class.url--]", BasePage.GetClassUrl(cls));

            Content = Content.Replace("[!--movie.url--]", BasePage.GetMovieUrl(movie, movie.GetClass()));
            Content = Content.Replace("[!--movie.nextpageurl--]", BasePage.SystemSetting.SiteUrl + BasePage.GetMovieDramaUrl(next, next.GetClass()));

            Content = Content.Replace("[!--drama.title--]", kuaib.Title);
            Content = Content.Replace("[!--drama.url--]", kuaib.Url);
            Content = Content.Replace("[!--drama.updatetime--]", kuaib.UpdateTime.ToString());

            Content = ReplaceContent(Content, movie, cls);


            StringBuilder sb = new StringBuilder();
            List<MovieUrlKuaib> qb = (from l in ent.MovieUrlKuaib where l.MovieID == movie.id select l).ToList();
            string list_tmp = GetTempateString(1, TempType.下载地址);
            foreach (MovieUrlKuaib q in qb)
            {
                string row = list_tmp.Replace("[!--url.id--]", q.id.ToS());
                row = row.Replace("[!--url.url--]", q.Url);
                row = row.Replace("[!--url.title--]", q.Title);
                row = row.Replace("[!--url.movieid--]", q.MovieID.ToS());
                row = row.Replace("[!--url.movietitle--]", q.MovieTitle);
                row = row.Replace("[!--url--]", BasePage.GetMovieDramaUrl(q, q.GetClass()));
                sb.Append(row);
            }
            Content = Content.Replace("[!--movie.kuib--]", sb.ToS());


            sb = new StringBuilder();
            List<MovieUrlBaidu> baidu = (from l in ent.MovieUrlBaidu where l.MovieID == movie.id select l).ToList();
            foreach (MovieUrlBaidu q in baidu)
            {
                string row = list_tmp.Replace("[!--url.id--]", q.id.ToS());
                row = row.Replace("[!--url.url--]", q.Url);
                row = row.Replace("[!--url.title--]", q.Title);
                row = row.Replace("[!--url.movieid--]", q.MovieID.ToS());
                row = row.Replace("[!--url.movietitle--]", q.MovieTitle);
                row = row.Replace("[!--url--]", BasePage.GetMovieDramaUrl(q, q.GetClass()));
                sb.Append(row);
            }
            Content = Content.Replace("[!--movie.baidu--]", sb.ToS());

            sb = new StringBuilder();
            List<MovieUrlMag> mag = (from l in ent.MovieUrlMag where l.MovieID == movie.id select l).ToList();
            foreach (MovieUrlMag q in mag)
            {
                string row = list_tmp.Replace("[!--url.id--]", q.id.ToS());
                row = row.Replace("[!--url.url--]", q.Url);
                row = row.Replace("[!--url.title--]", q.Title);
                row = row.Replace("[!--url.movieid--]", q.MovieID.ToS());
                row = row.Replace("[!--url.movietitle--]", q.MovieTitle);
                sb.Append(row);
            }
            Content = Content.Replace("[!--movie.mag--]", sb.ToS());


            #endregion

            Content = ReplaceTagContent(Content);

            //替换导航条
            Content = Content.Replace("[!--newsnav--]", BuildClassNavString(cls));
            ent.Dispose();

            return Content;
        }
        #endregion 生成播放页面--快播

        #region 生成播放页面--百度
        /// <summary>
        /// 生成播放页面--快播
        /// </summary>
        /// <param name="kuaib">百度影音地址</param>
        /// <param name="cls">分类</param>
        public string CreateDramapage(MovieUrlBaidu kuaib, Class cls)
        {
            DataEntities ent = new DataEntities();

            MovieInfo movie = (from l in ent.MovieInfo where l.id == kuaib.MovieID select l).FirstOrDefault();

            string FileName = BasePage.GetMovieDramaUrl(kuaib, cls);
            string Content = "";

            TemplateContent temp = this.GetContentTemplate(cls);



            Content = GetTempateString(1, TempType.百度影音页面);

            Content = ReplacePublicTemplate(Content);
            Content = ReplacePublicTemplate(Content);
            Content = ReplacePublicTemplate(Content);

            Content = ReplaceSystemSetting(Content);

            PageAttribute pa = new PageAttribute() { Title = movie.Title + "-" + kuaib.Title + "快播在线播放", UpdateTime = DateTime.Now.ToString(), Description = string.Format("电影《{0}》{1} 快播在线播放页面,《{0}》{1}高清版下载。", movie.Title, kuaib.Title) };

            Content = ReplacePageAttribute(Content, pa);



            #region 替换内容

            MovieUrlBaidu next = BasePage.GetNextBaidu(kuaib);
            if (next == null)
            {
                next = new MovieUrlBaidu();
                next.Url = "";
            }

            Content = Content.Replace("[!--class.id--]", cls.ID.ToString());
            Content = Content.Replace("[!--class.name--]", cls.ClassName);
            Content = Content.Replace("[!--class.url--]", BasePage.GetClassUrl(cls));

            Content = Content.Replace("[!--movie.url--]", BasePage.GetMovieUrl(movie, movie.GetClass()));
            Content = Content.Replace("[!--movie.nextpageurl--]",
                ReplaceAll(
                BasePage.SystemSetting.SiteUrl + BasePage.GetMovieDramaUrl(next, next.GetClass()),
                "[\\u4e00-\\u9fa5]",
                "1")
                );

            Content = Content.Replace("[!--drama.title--]", kuaib.Title);
            Content = Content.Replace("[!--drama.url--]", kuaib.Url);
            Content = Content.Replace("[!--drama.updatetime--]", kuaib.UpdateTime.ToDateTime().ToString(temp.TimeFormat));

            Content = ReplaceContent(Content, movie, cls);


            StringBuilder sb = new StringBuilder();
            List<MovieUrlKuaib> qb = (from l in ent.MovieUrlKuaib where l.MovieID == movie.id select l).ToList();
            string list_tmp = GetTempateString(1, TempType.下载地址);
            foreach (MovieUrlKuaib q in qb)
            {
                string row = list_tmp.Replace("[!--url.id--]", q.id.ToS());
                row = row.Replace("[!--url.url--]", q.Url);
                row = row.Replace("[!--url.title--]", q.Title);
                row = row.Replace("[!--url.movieid--]", q.MovieID.ToS());
                row = row.Replace("[!--url.movietitle--]", q.MovieTitle);
                row = row.Replace("[!--url--]", BasePage.GetMovieDramaUrl(q, q.GetClass()));
                sb.Append(row);
            }
            Content = Content.Replace("[!--movie.kuib--]", sb.ToS());


            sb = new StringBuilder();
            List<MovieUrlBaidu> baidu = (from l in ent.MovieUrlBaidu where l.MovieID == movie.id select l).ToList();
            foreach (MovieUrlBaidu q in baidu)
            {
                string row = list_tmp.Replace("[!--url.id--]", q.id.ToS());
                row = row.Replace("[!--url.url--]", q.Url);
                row = row.Replace("[!--url.title--]", q.Title);
                row = row.Replace("[!--url.movieid--]", q.MovieID.ToS());
                row = row.Replace("[!--url.movietitle--]", q.MovieTitle);
                row = row.Replace("[!--url--]", BasePage.GetMovieDramaUrl(q, q.GetClass()));
                sb.Append(row);
            }
            Content = Content.Replace("[!--movie.baidu--]", sb.ToS());

            sb = new StringBuilder();
            List<MovieUrlMag> mag = (from l in ent.MovieUrlMag where l.MovieID == movie.id select l).ToList();
            foreach (MovieUrlMag q in mag)
            {
                string row = list_tmp.Replace("[!--url.id--]", q.id.ToS());
                row = row.Replace("[!--url.url--]", q.Url);
                row = row.Replace("[!--url.title--]", q.Title);
                row = row.Replace("[!--url.movieid--]", q.MovieID.ToS());
                row = row.Replace("[!--url.movietitle--]", q.MovieTitle);
                sb.Append(row);
            }
            Content = Content.Replace("[!--movie.mag--]", sb.ToS());


            #endregion

            Content = ReplaceTagContent(Content);

            //替换导航条
            Content = Content.Replace("[!--newsnav--]", BuildClassNavString(cls));
            ent.Dispose();

            return Content;
        }
        #endregion

        #region 生成播放页面--单集列表页面
        /// <summary>
        /// 生成播放页面--单集列表页面
        /// </summary>
        /// <param name="kuaib">百度影音地址</param>
        /// <param name="cls">分类</param>
        public string CreateDramapage(MovieDrama drama, Class cls)
        {
            DataEntities ent = new DataEntities();

            MovieInfo movie = (from l in ent.MovieInfo where l.id == drama.MovieID select l).FirstOrDefault();

            string FileName = BasePage.GetMovieDramaUrl(drama, cls);
            string Content = "";

            TemplateContent temp = GetContentTemplate(cls);

            Content = GetTempateString(1, TempType.单集列表页面);

            Content = ReplacePublicTemplate(Content);
            Content = ReplacePublicTemplate(Content);
            Content = ReplacePublicTemplate(Content);

            Content = ReplaceSystemSetting(Content);




            #region 替换内容

            MovieDrama next = BasePage.GetNextDrama(drama);
            if (next == null)
            {
                next = new MovieDrama();
            }

            Content = Content.Replace("[!--class.id--]", cls.ID.ToString());
            Content = Content.Replace("[!--class.name--]", cls.ClassName);
            Content = Content.Replace("[!--class.url--]", BasePage.GetClassUrl(cls));

            Content = Content.Replace("[!--movie.url--]", BasePage.GetMovieUrl(movie, movie.GetClass()));
            Content = Content.Replace("[!--movie.nextpageurl--]", BasePage.GetMovieDramaUrl(next, movie.GetClass()));

            Content = Content.Replace("[!--drama.title--]", drama.Title);
            Content = Content.Replace("[!--drama.id--]", drama.id.ToS());
            Content = Content.Replace("[!--drama.updatetime--]", drama.UpdateTime.ToDateTime().ToString(temp.TimeFormat));

            Content = ReplaceContent(Content, movie, cls);



            #endregion

            Content = ReplaceTagContent(Content);

            //替换导航条
            Content = Content.Replace("[!--newsnav--]", BuildClassNavString(cls));
            ent.Dispose();

            return Content;
        }
        #endregion

        #region 生成内容页--新闻
        /// <summary>
        /// 生成内容页
        /// </summary>
        /// <param name="news"></param>
        /// <param name="cls"></param>
        public string CreateContentPage(News news, Class cls)
        {
            if (news.NavUrl.ToS().Trim().Length > 0)//如果是外部连接新闻 则不需要生成
            {
                return string.Format("<script type='text/javascript'>location.href='';</script>", news.NavUrl);
            }

            TemplateContent temp = GetContentTemplate(cls);

            string Content = temp.Content;

            Content = ReplacePublicTemplate(Content);
            Content = ReplacePublicTemplate(Content);
            Content = ReplacePublicTemplate(Content);


            Content = ReplaceSystemSetting(Content);


            Content = Content.Replace("[!--class.id--]", cls.ID.ToString());
            Content = Content.Replace("[!--class.name--]", cls.ClassName);
            Content = Content.Replace("[!--class.url--]", BasePage.GetClassUrl(cls));

            Content = ReplaceContent(Content, news, cls);


            Content = ReplaceTagContent(Content);

            #region 上一篇  下一篇 链接
            News news_pre = BasePage.GetPreNews(news, cls);
            News news_next = BasePage.GetNextNews(news, cls);

            //上一篇
            string pre_link = "<a href=\"javascript:void(0)\">没有了</a>";
            if (news_pre != null)
            {
                pre_link = string.Format("<a id=\"btn_pre\" href=\"{0}\">{1}</a>", BasePage.GetNewsUrl(news_pre, cls), news_pre.Title);
            }
            Content = Content.Replace("[!--news.prelink--]", pre_link);

            //下一篇
            string next_link = "<a href=\"javascript:void(0)\">没有了</a>";
            if (news_next != null)
            {
                next_link = string.Format("<a id=\"btn_next\" href=\"{0}\">{1}</a>", BasePage.GetNewsUrl(news_next, cls), news_next.Title);
            }
            Content = Content.Replace("[!--news.nextlink--]", next_link);

            #endregion

            //替换导航条
            Content = Content.Replace("[!--newsnav--]", BuildClassNavString(cls));

            return Content;
        }
        #endregion

        #region  生成内容页--相册
        /// <summary>
        /// 生成内容页--图片
        /// </summary>
        /// <param name="album"></param>
        /// <param name="cls"></param>
        public string CreateContentPage(ImageAlbum album, Class cls)
        {
            DataEntities ent = new DataEntities();

            TemplateContent temp = GetContentTemplate(cls);
            string Content = temp.Content;

            Content = ReplacePublicTemplate(Content);
            Content = ReplacePublicTemplate(Content);
            Content = ReplacePublicTemplate(Content);

            Content = ReplaceSystemSetting(Content);

            #region 替换内容

            Content = Content.Replace("[!--class.id--]", cls.ID.ToString());
            Content = Content.Replace("[!--class.name--]", cls.ClassName);

            Content = ReplaceContent(Content, album, cls);

            List<Images> imgs = (from l in ent.Images where l.AlbumID == album.ID select l).ToList();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<ul>");
            foreach (Images img in imgs)
            {
                string Description = img.Intro;
                if (Description.IsNullOrEmpty())
                {
                    Description = album.Intro;
                }
                if (Description.IsNullOrEmpty())
                {
                    Description = img.Title;
                }
                if (Description.IsNullOrEmpty())
                {
                    Description = album.Title;
                }
                sb.AppendLine(string.Format("<li><a rel=\"example_group\" href=\"{0}\" title=\"{1}\"><img src=\"{2}\" /><br/>{3}</a></li>",
                    img.FilePath,
                    Description,
                    img.SmallPath,
                    img.Title.IsNullOrEmpty() ? album.Title.CutString(6) : img.Title.CutString(6)
                    ));
            }
            sb.AppendLine("</ul>");

            Content = Content.Replace("[!--image.content--]", sb.ToS());
            #endregion

            Content = ReplaceTagContent(Content);

            #region 上一篇  下一篇 链接
            ImageAlbum news_pre = BasePage.GetPreImage(album, cls);
            ImageAlbum news_next = BasePage.GetNextImages(album, cls);

            //上一篇
            string pre_link = "<a href=\"javascript:void(0)\">没有了</a>";
            if (news_pre != null)
            {
                pre_link = string.Format("<a href=\"{0}\">{1}</a>", BasePage.GetImageUrl(news_pre, cls), news_pre.Title);
            }
            Content = Content.Replace("[!--news.prelink--]", pre_link);

            //下一篇
            string next_link = "<a href=\"javascript:void(0)\">没有了</a>";
            if (news_next != null)
            {
                next_link = string.Format("<a href=\"{0}\">{1}</a>", BasePage.GetImageUrl(news_next, cls), news_next.Title);
            }
            Content = Content.Replace("[!--news.nextlink--]", next_link);

            #endregion

            //替换导航条
            Content = Content.Replace("[!--newsnav--]", BuildClassNavString(cls));

            ent.Dispose();
            return Content;
        }
        #endregion

        #region  生成内容页--问答
        /// <summary>
        /// 生成内容页--图片
        /// </summary>
        /// <param name="album"></param>
        /// <param name="cls"></param>
        public string CreateContentPage(Question qs, Class cls)
        {
            DataEntities ent = new DataEntities();

            TemplateContent temp = GetContentTemplate(cls);

            string Content = temp.Content;
            Content = ReplacePublicTemplate(Content);
            Content = ReplacePublicTemplate(Content);
            Content = ReplacePublicTemplate(Content);

            Content = ReplaceSystemSetting(Content);



            #region 替换内容

            Content = Content.Replace("[!--class.id--]", cls.ID.ToString());
            Content = Content.Replace("[!--class.name--]", cls.ClassName);

            Content = ReplaceContent(Content, qs, cls);

            List<Answer> ans = (from l in ent.Answer where l.QuestionID == qs.ID select l).ToList();
            StringBuilder sb = new StringBuilder();
            string list_tmp = GetTempateString(1, TempType.问答回答列表);

            foreach (Answer an in ans)
            {
                string row = list_tmp.Replace("[!--answer.agree--]", an.Agree.ToS());
                row = row.Replace("[!--answer.answertime--]", an.AnswerTime.ToString());
                row = row.Replace("[!--answer.content--]", an.Content);
                row = row.Replace("[!--answer.id--]", an.ID.ToS());
                row = row.Replace("[!--answer.questionid--]", an.QuestionID.ToS());
                row = row.Replace("[!--answer.userid--]", an.UserID.ToS());
                row = row.Replace("[!--answer.username--]", an.UserName);

                sb.AppendLine(row);
            }

            Content = Content.Replace("[!--answer.list--]", sb.ToS());
            #endregion

            Content = ReplaceTagContent(Content);

            #region 上一篇  下一篇 链接
            Question news_pre = BasePage.GetPreQuestion(qs, cls);
            Question news_next = BasePage.GetNextQuestion(qs, cls);

            //上一篇
            string pre_link = "<a href=\"javascript:void(0)\">没有了</a>";
            if (news_pre != null)
            {
                pre_link = string.Format("<a href=\"{0}\" title=\"{1}\">{2}</a>", BasePage.GetQuestionUrl(news_pre, cls), news_pre.Title, news_pre.Title.CutString(20));
            }
            Content = Content.Replace("[!--news.prelink--]", pre_link);

            //下一篇
            string next_link = "<a href=\"javascript:void(0)\">没有了</a>";
            if (news_next != null)
            {
                next_link = string.Format("<a href=\"{0}\" title=\"{1}\">{2}</a>", BasePage.GetQuestionUrl(news_next, cls), news_next.Title, news_next.Title.CutString(20));
            }
            Content = Content.Replace("[!--news.nextlink--]", next_link);

            #endregion

            //替换导航条
            Content = Content.Replace("[!--newsnav--]", BuildClassNavString(cls));

            ent.Dispose();

            return Content;
        }
        #endregion

        #region  生成内容页--书籍
        /// <summary>
        /// 生成内容页--图片
        /// </summary>
        /// <param name="album"></param>
        /// <param name="cls"></param>
        public string CreateContentPage(Book b, Class cls)
        {
            DataEntities ent = new DataEntities();

            TemplateContent temp = GetContentTemplate(cls);
            string Content = temp.Content;

            Content = ReplacePublicTemplate(Content);
            Content = ReplacePublicTemplate(Content);
            Content = ReplacePublicTemplate(Content);

            Content = ReplaceSystemSetting(Content);




            #region 替换内容

            Content = ReplaceContent(Content, b, cls);

            List<BookChapter> chapters = (from l in ent.BookChapter where l.BookID == b.ID orderby l.ChapterIndex orderby l.ID descending select l).ToList();

            StringBuilder sb = new StringBuilder();
            string list_tmp = GetTempateString(1, TempType.小说章节列表);

            foreach (BookChapter cp in chapters)
            {
                string row = list_tmp.Replace("[!--chapter.url--]", BasePage.GetBookChapterUrl(cp, cls));
                row = row.Replace("[!--chapter.title--]", cp.Title);

                sb.AppendLine(row);
            }


            Content = Content.Replace("[!--chapter.list--]", sb.ToS());
            #endregion

            Content = ReplaceTagContent(Content);

            #region 上一篇  下一篇 链接
            Book news_pre = BasePage.GetPreBook(b, cls);
            Book news_next = BasePage.GetNextBook(b, cls);

            //上一篇
            string pre_link = "<a href=\"javascript:void(0)\">没有了</a>";
            if (news_pre != null)
            {
                pre_link = string.Format("<a id=\"btn_pre\" href=\"{0}\" title=\"{1}\">{2}</a>", BasePage.GetBookUrl(news_pre, cls), news_pre.Title, news_pre.Title.CutString(20));
            }
            Content = Content.Replace("[!--news.prelink--]", pre_link);

            //下一篇
            string next_link = "<a href=\"javascript:void(0)\">没有了</a>";
            if (news_next != null)
            {
                next_link = string.Format("<a id=\"btn_next\" href=\"{0}\" title=\"{1}\">{2}</a>", BasePage.GetBookUrl(news_next, cls), news_next.Title, news_next.Title.CutString(20));
            }
            Content = Content.Replace("[!--news.nextlink--]", next_link);

            #endregion

            //替换导航条
            Content = Content.Replace("[!--newsnav--]", BuildClassNavString(cls));

            return Content;
        }
        #endregion

        #region  生成内容页--产品
        /// <summary>
        /// 生成内容页--图片
        /// </summary>
        /// <param name="album"></param>
        /// <param name="cls"></param>
        public string CreateContentPage(Product p, Class cls)
        {
            DataEntities ent = new DataEntities();

            TemplateContent temp = GetContentTemplate(cls);
            string Content = temp.Content;

            Content = ReplacePublicTemplate(Content);
            Content = ReplacePublicTemplate(Content);
            Content = ReplacePublicTemplate(Content);

            Content = ReplaceSystemSetting(Content);




            #region 替换内容

            Content = ReplaceContent(Content, p, cls);

            #endregion

            Content = ReplaceTagContent(Content);



            //替换导航条
            Content = Content.Replace("[!--newsnav--]", BuildClassNavString(cls));

            return Content;
        }
        #endregion



        #region  创建章节页面
        /// <summary>
        /// 创建章节页面
        /// </summary>
        /// <param name="cp"></param>
        /// <param name="b"></param>
        /// <param name="cls"></param>
        public string CreateBookChapterPage(BookChapter cp, Book b, Class cls)
        {
            string bookurl = BasePage.GetBookUrl(b, cls);
            string Content = GetTempateString(1, TempType.小说章节);

            Content = ReplacePublicTemplate(Content);
            Content = ReplacePublicTemplate(Content);
            Content = ReplacePublicTemplate(Content);

            Content = ReplaceSystemSetting(Content);

            string ChapterContent = Voodoo.IO.File.Read(System.Web.HttpContext.Current.Server.MapPath(BasePage.GetBookChapterTxtUrl(cp, cls)));
            ChapterContent = ChapterContent.Replace("<<", "<br />");
            ChapterContent = ReplaceContentKey(ChapterContent);//伪原创

            //如果章节正在处理中，则填入自定义内容
            if (cp.IsTemp == true)
            {
                ChapterContent = string.Format("{0}的小说{1}最新章节-{2}正在处理中，请稍后访问阅读。同时推荐您阅读以下精品小说<ul id=\"ul_tjlist\">{3}</ul>,<br /><br />阅读{1}最新章节{2},尽在<a href=\"{4}\">{5}</a>",
                    b.Author,
                    b.Title,
                    cp.Title,
                    Functions.Getnovellist("Enable=1 order by clickcount desc", 10, 100, "<li><a href=\"{url}\" title=\"{title}\">{title}</a></li>"),
                    BasePage.SystemSetting.SiteUrl,
                    BasePage.SystemSetting.SiteName
                    );
            }

            PageAttribute pa = new PageAttribute()
            {
                Title = string.Format("{0}-{1}-{2}", b.Title, cp.Title, b.Author),
                UpdateTime = DateTime.Now.ToString(),
                Description = ChapterContent.TrimHTML().Replace("\n", "").CutString(100),
                Keyword = string.Format("{0},{1}最新章节,{1}txt下载,{1}在线阅读", cp.Title, b.Title)
            };

            Content = ReplacePageAttribute(Content, pa);

            #region 替换内容

            //替换栏目
            Content = Content.Replace("[!--class.id--]", cls.ID.ToString());
            Content = Content.Replace("[!--class.name--]", cls.ClassName);
            Content = Content.Replace("[!--class.url--]", BasePage.GetClassUrl(cls));

            Content = Content.Replace("[!--book.url--]", bookurl);

            //替换书籍信息
            Content = ReplaceContent(Content, b, cls);

            //替换章节信息

            Content = Content.Replace("[!--chapter.id--]", cp.ID.ToS());
            Content = Content.Replace("[!--chapter.bookid--]", cp.BookID.ToS());
            Content = Content.Replace("[!--chapter.booktitle--]", cp.BookTitle);
            Content = Content.Replace("[!--chapter.classid--]", cp.ClassID.ToS());
            Content = Content.Replace("[!--chapter.classname--]", cp.ClassName);
            Content = Content.Replace("[!--chapter.valumeid--]", cp.ValumeID.ToS());
            Content = Content.Replace("[!--chapter.valumename--]", cp.ValumeName);
            Content = Content.Replace("[!--chapter.title--]", cp.Title);
            Content = Content.Replace("[!--chapter.isvipchapter--]", cp.IsVipChapter.ToBoolean().ToChinese());
            Content = Content.Replace("[!--chapter.textlength--]", cp.TextLength.ToS());
            Content = Content.Replace("[!--chapter.updatetime--]", cp.UpdateTime.ToS());
            Content = Content.Replace("[!--chapter.enable--]", cp.Enable.ToBoolean().ToChinese());
            Content = Content.Replace("[!--chapter.istemp--]", cp.IsTemp.ToBoolean().ToChinese());
            Content = Content.Replace("[!--chapter.isfree--]", cp.IsFree.ToBoolean().ToChinese());
            Content = Content.Replace("[!--chapter.chapterindex--]", cp.ChapterIndex.ToS());
            Content = Content.Replace("[!--chapter.isimagechapter--]", cp.IsImageChapter.ToBoolean().ToChinese());
            Content = Content.Replace("[!--chapter.content--]", ChapterContent);
            Content = Content.Replace("[!--chapter.clickcount--]", cp.ClickCount.ToS());

            #endregion

            Content = ReplaceTagContent(Content);

            #region 上一篇  下一篇 链接
            BookChapter news_pre = BasePage.GetPreChapter(cp, b);
            BookChapter news_next = BasePage.GetNextChapter(cp, b);

            string preurl = news_pre == null ? bookurl : BasePage.GetBookChapterUrl(news_pre, cls);
            string nexturl = news_next == null ? bookurl : BasePage.GetBookChapterUrl(news_next, cls);

            Content = Content.Replace("[!--chapter.preurl--]", preurl);
            Content = Content.Replace("[!--chapter.nexturl--]", nexturl);
            Content = Content.Replace("[!--chapter.pretitle--]", news_pre == null ? b.Title : news_pre.Title);
            Content = Content.Replace("[!--chapter.nexttitle--]", news_next == null ? b.Title : news_next.Title);

            //上一篇
            string pre_link = "<a href=\"#\">上章：没有了</a>";
            if (news_pre != null)
            {
                pre_link = string.Format("<a id=\"btn_pre\" href=\"{0}\" title=\"{1}\">上章：{2}</a>", nexturl, news_pre.Title, news_pre.Title.CutString(20));
            }
            Content = Content.Replace("[!--news.prelink--]", pre_link);

            //下一篇
            string next_link = "<a href=\"#\">下章：没有了</a>";
            if (news_next != null)
            {
                next_link = string.Format("<a id=\"btn_next\" href=\"{0}\" title=\"{1}\">下章：{2}</a>", nexturl, news_next.Title, news_next.Title.CutString(20));
            }
            Content = Content.Replace("[!--news.nextlink--]", next_link);

            #endregion

            //替换导航条
            Content = Content.Replace("[!--newsnav--]", BuildClassNavString(cls));


            return Content;
        }
        #endregion

        #region 搜索页面
        /// <summary>
        /// 搜索页面
        /// </summary>
        /// <param name="SysModel"></param>
        /// <param name="page"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public string GetSearchResult(int SysModel, int page, string key)
        {
            DataEntities ent = new DataEntities();

            //搜索关键词保存到数据库中
            BasePage.InsertKeyWords(SysModel, key);

            int pagecount = 1;
            int recordCount = 0;

            string Content = GetTempateString(1, TempType.全站搜索);

            //替换三层公共模版变量
            Content = ReplacePublicTemplate(Content);
            Content = ReplacePublicTemplate(Content);
            Content = ReplacePublicTemplate(Content);

            Content = ReplaceSystemSetting(Content);

            if (key.IsNullOrEmpty() && SysModel == 4)
            {
                Content = Content.Replace("[!--search.key--]", "全部书籍");
            }
            Content = Content.Replace("[!--search.key--]", key);

            //此处要区分系统模型
            #region 替换列表


            #region 新闻系统模板
            if (SysModel == 1)//新闻系统模板
            {
                TemplateList temp = GetListTemplate(new Class() { ModelID = 1 });

                StringBuilder sb_list = new StringBuilder();
                List<News> ns = //NewsView.GetModelList(string.Format("Audit=1 and (Title like N'%{0}%' or ftitle like N'%{0}%') order by SetTop desc, id desc", key)).ToList();
                    (from l in ent.News where l.Audit == true && (l.Title.Contains(key) || l.FTitle.Contains(key)) orderby l.SetTop descending orderby l.ID descending select l).ToList();
                pagecount = (Convert.ToDouble(ns.Count) / Convert.ToDouble(20)).YueShu();
                recordCount = ns.Count;

                ns = ns.Skip((page - 1) * 20).Take(20).ToList();
                foreach (News n in ns)
                {

                    sb_list.AppendLine(ReplaceContent(temp.ListVar, n, new Class()));
                }

                Content = Content.Replace("<!--list.var-->", sb_list.ToString());
            }//end 新闻系统模板
            #endregion  新闻系统模板


            #region 小说系统
            if (SysModel == 4)
            {
                StringBuilder sb_list = new StringBuilder();
                var xx = from l in ent.Book
                         where l.Enable == true
                         orderby l.ID descending
                         select l;

                List<Book> qs;
                if (!key.IsNullOrEmpty())
                {
                    xx = from l in xx where l.Title.Contains(key) || l.Author.Contains(key) || l.Intro.Contains(key) orderby l.ID descending select l;
                }
                qs = xx.ToList();

                pagecount = (Convert.ToDouble(qs.Count) / Convert.ToDouble(20)).YueShu();
                recordCount = qs.Count;

                qs = qs.Skip((page - 1) * 20).Take(20).ToList();
                TemplateList temp = GetListTemplate(new Class() { ModelID = 4 });
                foreach (Book b in qs)
                {

                    sb_list.AppendLine(ReplaceContent(temp.ListVar, b, new Class()));
                }

                Content = Content.Replace("<!--list.var-->", sb_list.ToString());
                if (qs.Count() == 1)
                {
                    Book firstBook = qs.First();
                    System.Web.HttpContext.Current.Response.Redirect(BasePage.GetBookUrl(firstBook, firstBook.GetClass()));
                }
            }
            #endregion 小说系统

            #region 影视
            else if (SysModel == 6)
            {
                StringBuilder sb_list = new StringBuilder();
                List<MovieInfo> qs = //MovieInfoView.GetModelList(string.Format("Enable=1 and (Title like N'%{0}%' or Director like N'%{0}%' or Actors like N'%{0}%' or Tags like  N'%{0}%')", key));
                (from l in ent.MovieInfo
                 where l.Enable == true &&
                     (l.Title.Contains(key) || l.Director.Contains(key) || l.Actors.Contains(key) || l.Tags.Contains(key))
                 orderby l.id descending
                 select l).ToList();
                pagecount = (Convert.ToDouble(qs.Count) / Convert.ToDouble(20)).YueShu();
                recordCount = qs.Count;

                qs = qs.Skip((page - 1) * 20).Take(20).ToList();
                TemplateList temp = GetListTemplate(new Class() { ModelID = 6 });
                foreach (MovieInfo m in qs)
                {

                    sb_list.AppendLine(ReplaceContent(temp.ListVar, m, new Class()));
                }
                Content = Content.Replace("<!--list.var-->", sb_list.ToString());
            }
            #endregion

            #endregion

            //替换标签变量
            Content = ReplaceTagContent(Content);

            #region 替换分页模板

            string tmp_pager = GetTempateString(1, TempType.列表分页);
            tmp_pager = tmp_pager.Replace("[!--thispage--]", page.ToS());
            tmp_pager = tmp_pager.Replace("[!--pagenum--]", pagecount.ToS());
            tmp_pager = tmp_pager.Replace("[!--lencord--]", "20");
            tmp_pager = tmp_pager.Replace("[!--num--]", recordCount.ToS());
            tmp_pager = tmp_pager.Replace("[!--pagelink--]", BuildPagerLink(key, page));
            tmp_pager = tmp_pager.Replace("[!--options--]", BuidPagerOption(key, page));

            if (recordCount <= 20)
            {
                tmp_pager = "";
            }

            Content = Content.Replace("[!--show.listpage--]", tmp_pager);

            #endregion

            ent.Dispose();

            return Content;

        }
        public string GetSearchResult(string m_where, int SysModel, int page, string searchword)
        {
            DataEntities ent = new DataEntities();

            int itemcount = 0;
            int pagecount = 1;
            int recordCount = 0;

            string Content = GetTempateString(1, TempType.全站搜索);

            Content = ReplacePublicTemplate(Content);
            Content = ReplacePublicTemplate(Content);
            Content = ReplacePublicTemplate(Content);

            Content = ReplaceSystemSetting(Content);


            //此处要区分系统模型
            #region 替换列表

            TemplateList temp = GetListTemplate(new Class() { ModelID = SysModel });
            #region 小说系统

            if (SysModel == 4)
            {
                StringBuilder sb_list = new StringBuilder();
                List<Book> qs = ent.CreateQuery<Book>(string.Format("select * from Book where {0}", m_where)).ToList();
                itemcount = qs.Count;
                pagecount = (Convert.ToDouble(qs.Count) / Convert.ToDouble(20)).YueShu();
                recordCount = qs.Count;

                qs = qs.Skip((page - 1) * 20).Take(20).ToList();
                foreach (Book b in qs)
                {
                    sb_list.AppendLine(ReplaceContent(temp.ListVar, b, new Class() { ModelID = SysModel }));
                }
                Content = Content.Replace("<!--list.var-->", sb_list.ToString());
            }
            #endregion 小说系统

            #region 影视

            else if (SysModel == 6)
            {
                StringBuilder sb_list = new StringBuilder();
                List<MovieInfo> qs = ent.CreateQuery<MovieInfo>(string.Format("select * from MovieInfo where {0}", m_where)).ToList();
                itemcount = qs.Count;

                pagecount = (Convert.ToDouble(qs.Count) / Convert.ToDouble(50)).YueShu();
                recordCount = qs.Count;

                qs = qs.Skip((page - 1) * 50).Take(50).ToList();
                foreach (MovieInfo m in qs)
                {
                    sb_list.AppendLine(ReplaceContent(temp.ListVar, m, new Class()));
                }
                Content = Content.Replace("<!--list.var-->", sb_list.ToString());
            }
            #endregion

            #endregion

            //替换标签变量
            Content = ReplaceTagContent(Content);

            #region 替换分页模板


            string tmp_pager = GetTempateString(1, TempType.列表分页);
            tmp_pager = tmp_pager.Replace("[!--thispage--]", page.ToS());
            tmp_pager = tmp_pager.Replace("[!--pagenum--]", pagecount.ToS());
            tmp_pager = tmp_pager.Replace("[!--lencord--]", "50");
            tmp_pager = tmp_pager.Replace("[!--num--]", recordCount.ToS());
            tmp_pager = tmp_pager.Replace("[!--pagelink--]",
                BuildPagerLink("<a href=\"/search.aspx?m=6&key=" + searchword + "&p={first}\">首页</a> <a href=\"/search.aspx?m=6&key=" + searchword + "&p={pre}\">上页</a> <a href=\"/search.aspx?m=6&key=" + searchword + "&p={next}\">下页</a> <a href=\"/search.aspx?m=6&key=" + searchword + "&p={end}\">尾页</a>", page, pagecount)
                );
            tmp_pager = tmp_pager.Replace("[!--options--]", "");

            if (recordCount <= 50)
            {
                tmp_pager = "";
            }

            Content = Content.Replace("[!--show.listpage--]", tmp_pager);

            #endregion

            ent.Dispose();

            return Content;

        }
        #endregion



        #region 创建类似google的数字分页
        /// <summary>
        /// 创建类似google的数字分页
        /// </summary>
        /// <param name="c">类</param>
        /// <param name="page">页</param>
        /// <returns></returns>
        public string CreateNumPager(Class c, int page)
        {
            string str = "";

            int recordCount = c.CountItem();
            int tmpid = 0;
            TemplateList temp = GetListTemplate(c);

            int pageCount = (Convert.ToDouble(recordCount) / Convert.ToDouble(temp.ShowRecordCount)).YueShu();

            int lastPage = page + 2 > pageCount ? pageCount : page + 2;
            int prePage = page - 1 == 0 ? 1 : page - 1;
            int nextPage = page + 1 > pageCount ? pageCount : page + 1;

            str += string.Format("<a title=\"{0}第{1}页\" href=\"index_{1}.htm\"><</a> ", c.ClassName, prePage);
            for (int i = 0; i < 5; i++)
            {
                if (lastPage == 0)
                {
                    break;
                }
                str = str + string.Format("<a title=\"{0}第{1}页\" href=\"index_{1}.htm\">{1}</a> ", c.ClassName, lastPage);

                lastPage--;
            }
            str += string.Format("<a title=\"{0}第{1}页\" href=\"index_{1}.htm\">></a> ", c.ClassName, nextPage);
            return str;

        }
        #endregion

        #region 伪原创字符替换--汉字变成拼音
        /// <summary>
        /// 伪原创字符替换--汉字变成拼音
        /// </summary>
        /// <param name="Content"></param>
        /// <returns></returns>
        public string ReplaceContentKey(string Content)
        {
            Content = Content.Replace("垩", "");
            Content = Content.Replace("声音", "shengyin");
            Content = Content.Replace("地方", "difang");
            Content = Content.Replace("这个", "zhege");
            Content = Content.Replace("有些", "youxie");
            Content = Content.Replace("注意", "zhuyi");
            Content = Content.Replace("非常", "feichang");
            Content = Content.Replace("大家", "dajia");
            Content = Content.Replace("衣服", "yifu");
            Content = Content.Replace("自己", "ziji");
            Content = Content.Replace("来不及", "laibuji");
            Content = Content.Replace("意思", "yisi");
            Content = Content.Replace("能力", "nengli");
            Content = Content.Replace("容易", "rongyi");
            Content = Content.Replace("朋友", "pengyou");
            Content = Content.Replace("消息", "xiaoxi");
            Content = Content.Replace("这样", "zheyang");
            Content = Content.Replace("如此", "ruci");
            Content = Content.Replace("说话", "shuohua");
            Content = Content.Replace("：“", "maohaoyinhao");
            Content = Content.Replace("明天", "mingtian");
            Content = Content.Replace("你们", "nimen");
            Content = Content.Replace("没有", "meiyou");
            Content = Content.Replace("激动", "jidong");
            Content = Content.Replace("可以", "keyi");
            Content = Content.Replace("一起", "yiqi");
            Content = Content.Replace("小姐", "xiaojie");
            Content = Content.Replace("不但", "budan");
            Content = Content.Replace("而且", "erqie");
            Content = Content.Replace("其他", "qita");
            Content = Content.Replace("事情", "shiqing");
            Content = Content.Replace("一会", "yihui");
            Content = Content.Replace("一样", "yiyang");
            Content = Content.Replace("儿子", "erzi");
            Content = Content.Replace("应该", "yinggai");
            Content = Content.Replace("时候", "shihou");
            Content = Content.Replace("以前", "yiqian");
            Content = Content.Replace("不是", "bushi");
            Content = Content.Replace("什么", "shenme");
            Content = Content.Replace("怎么", "zenme");
            Content = Content.Replace("成功", "chenggong");
            Content = Content.Replace("如何", "ruhe");
            Content = Content.Replace("过去", "guoqu");
            Content = Content.Replace("出来", "chulai");

            return Content;
        }
        #endregion

        #region 默认模板组
        /// <summary>
        /// 默认模板组
        /// </summary>
        public TemplateGroup DefaultGroup
        {
            get
            {
                using (DataEntities ent = new DataEntities())
                {
                    return (from l in ent.TemplateGroup where l.IsDefault == true select l).FirstOrDefault();
                }
            }
        }
        #endregion

        #region 页面模板类型 enum TempType
        /// <summary>
        /// 页面模板类型 enum TempType
        /// </summary>
        public enum TempType
        {
            首页,
            控制面板,
            全站搜索,
            高级搜索,
            横向搜索JS,
            纵向搜索JS,
            相关信息,
            留言板,
            评论js调用,
            最终下载页,
            下载地址,
            在线播放地址,
            列表分页,
            登陆状态,
            JS调用登陆,
            封面,
            内容,
            列表,
            搜索,
            相册图片列表,
            问答回答列表,
            小说章节列表,
            小说章节,
            快播页面,
            百度影音页面,
            单集列表页面,
            小说首页,
            新闻首页,
            图片首页,
            问答首页,
            人才首页,
            影视首页
        }
        #endregion

        #region 获取模板内容字符串
        /// <summary>
        /// 获取模板内容字符串
        /// </summary>
        /// <param name="TempID">模板的ID</param>
        /// <param name="PageType">模板页面的类型</param>
        /// <returns></returns>
        public string GetTempateString(int TempID, TempType PageType)
        {
            using (DataEntities ent = new DataEntities())
            {

                TemplatePublic tp = (from l in ent.TemplatePublic where l.ID == TempID select l).FirstOrDefault();
                if (TempID <= 0)
                {
                    tp = (from l in ent.TemplatePublic where l.GroupID == DefaultGroup.ID select l).FirstOrDefault();
                }

                switch (PageType)
                {
                    case TempType.JS调用登陆:
                        return tp.JSLogin;
                        break;
                    case TempType.登陆状态:
                        return tp.LoginStatus;
                        break;
                    case TempType.封面:
                        TemplateFace tf = (from l in ent.TemplateFace where l.ID == TempID select l).FirstOrDefault();
                        if (TempID <= 0)
                        {
                            tf = (from l in ent.TemplateFace where l.GroupID == DefaultGroup.ID select l).FirstOrDefault();
                        }
                        return tf.Content;
                        break;
                    case TempType.高级搜索:
                        return tp.AdvancedSearch;
                        break;
                    case TempType.横向搜索JS:
                        return tp.HorizontaSearch;
                        break;
                    case TempType.控制面板:
                        return tp.Controlcontent;
                        break;
                    case TempType.列表:
                        TemplateList tl = (from l in ent.TemplateList where l.ID == TempID select l).FirstOrDefault();
                        if (TempID <= 0)
                        {
                            tl = (from l in ent.TemplateList where l.GroupID == DefaultGroup.ID select l).FirstOrDefault();
                        }
                        return tl.Content;
                    case TempType.列表分页:
                        return tp.ListPager;
                        break;
                    case TempType.留言板:
                        return tp.MessageBoard;
                        break;
                    case TempType.内容:
                        TemplateContent tc = (from l in ent.TemplateContent where l.ID == TempID select l).FirstOrDefault();
                        if (TempID <= 0)
                        {
                            tc = (from l in ent.TemplateContent where l.GroupID == DefaultGroup.ID select l).FirstOrDefault();
                        }
                        return tc.Content;
                        break;
                    case TempType.评论js调用:
                        return tp.Reply;
                        break;
                    case TempType.全站搜索:
                        return tp.SiteSearchContent;
                        break;
                    case TempType.首页:
                        return tp.IndexContent;
                        break;
                    case TempType.搜索:
                        TemplateSearch ts = (from l in ent.TemplateSearch where l.ID == TempID select l).FirstOrDefault();
                        if (TempID <= 0)
                        {
                            ts = (from l in ent.TemplateSearch where l.GroupID == DefaultGroup.ID select l).FirstOrDefault();
                        }
                        return ts.Content;
                        break;
                    case TempType.下载地址:
                        return tp.DownAddress;
                        break;
                    case TempType.相关信息:
                        return tp.RelationInfo;
                        break;
                    case TempType.在线播放地址:
                        return tp.OLPlayaddress;
                        break;
                    case TempType.纵向搜索JS:
                        return tp.VerticalSearch;
                        break;
                    case TempType.最终下载页:
                        return tp.FinalDown;
                        break;
                    case TempType.相册图片列表:
                        return tp.ImageList;
                        break;
                    case TempType.问答回答列表:
                        return tp.AnswerList;
                        break;
                    case TempType.小说章节列表:
                        return tp.ChapterList;
                        break;
                    case TempType.小说章节:
                        return tp.BookChapter;
                        break;
                    case TempType.快播页面:
                        return tp.KuaiboPage;
                        break;
                    case TempType.百度影音页面:
                        return tp.BaiduPage;
                        break;
                    case TempType.单集列表页面:
                        return tp.SingleDrama;
                        break;
                    case TempType.小说首页:
                        return tp.BookIndex;
                        break;
                    case TempType.新闻首页:
                        return tp.NewIndex;
                        break;
                    case TempType.图片首页:
                        return tp.ImageIndex;
                        break;
                    case TempType.问答首页:
                        return tp.QuestionIndex;
                        break;
                    case TempType.人才首页:
                        return tp.JobIndex;
                        break;
                    case TempType.影视首页:
                        return tp.MovieIndex;
                        break;
                    default:
                        return "";
                        break;
                }
            }
        }
        #endregion

        #region  创建 上页 下页 首页 尾页链接
        /// <summary>
        /// 创建分页链接
        /// </summary>
        /// <param name="c"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public string BuildPagerLink(Class c, int page)
        {
            int recordCount = c.CountItem();
            int tmpid = 0;
            TemplateList temp = GetListTemplate(c);

            int pagecount = @int.GetPageCount(recordCount, temp.ShowRecordCount.ToInt32()); //(Convert.ToDouble(recordCount) / Convert.ToDouble(temp.ShowRecordCount)).YueShu();

            string str_first = string.Format("<a href=\"{0}\">首页</a>", page > 1 ? BasePage.GetClassUrl(c,1) : "javascript:void(0)");
            string str_pre = string.Format("<a href=\"{0}\">上页</a>", page > 1 ? BasePage.GetClassUrl(c, page-1) : "javascript:void(0)");
            string str_next = string.Format("<a href=\"{0}\">下页</a>", page < pagecount ? BasePage.GetClassUrl(c, page+1) : "javascript:void(0)");
            string str_end = string.Format("<a href=\"{0}\">尾页</a>", page != pagecount ? BasePage.GetClassUrl(c, pagecount) : "javascript:void(0)");
            return string.Format("{0} {1} {2} {3}", str_first, str_pre, str_next, str_end);
        }

        public string BuildPagerLink(string key, int page)
        {
            DataEntities ent = new DataEntities();
            int recordCount = //BookView.Count(string.Format("Title like '%{0}%' or Author like '%{0}%' or Intro like '%{0}%'", key));
                (from l in ent.Book where l.Title.Contains(key) || l.Author.Contains(key) || l.Intro.Contains(key) select l).Count();
            ent.Dispose();
            int pagecount = @int.GetPageCount(recordCount, 20); //(Convert.ToDouble(recordCount) / Convert.ToDouble(20)).YueShu();

            string str_first = string.Format("<a href=\"{0}\">首页</a>", page > 1 ? "/Search.aspx?m=4&key=" + key : "javascript:void(0)");
            string str_pre = string.Format("<a href=\"{0}\">上页</a>", page > 1 ? "/Search.aspx?m=4&key=" + key + "&p=" + (page - 1).ToS() : "javascript:void(0)");
            string str_next = string.Format("<a href=\"{0}\">下页</a>", page < pagecount ? "/Search.aspx?m=4&key=" + key + "&p=" + (page + 1).ToS() : "javascript:void(0)");
            string str_end = string.Format("<a href=\"{0}\">尾页</a>", page != pagecount ? "/Search.aspx?m=4&key=" + key + "&p=" + pagecount.ToS() : "javascript:void(0)");
            return string.Format("{0} {1} {2} {3}", str_first, str_pre, str_next, str_end);
        }

        public string BuildPagerLink(string TemplateString, int page, int pagecount)
        {
            //<a href="xx.aspx?p={first}">首页</a> <a href="xxx.aspx?p={pre}">上页</a> <a href="xxx.aspx?p={next}">下页</a> <a href="xxx.aspx?p={end}">尾页</a>

            string result = TemplateString;
            result = result.Replace("{first}", "1");
            result = result.Replace("{pre}", (page > 1 ? page - 1 : 1).ToS());
            result = result.Replace("{next}", (page < pagecount ? page + 1 : page).ToS());
            result = result.Replace("{end}", pagecount.ToS());
            return result;
        }

        #endregion

        #region 创建跳转下拉菜单
        /// <summary>
        /// 创建跳转下拉菜单
        /// </summary>
        /// <param name="c"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public string BuidPagerOption(Class c, int page)
        {
            int recordCount = c.CountItem();
            TemplateList temp = GetListTemplate(c);


            int pagecount = (Convert.ToDouble(recordCount) / Convert.ToDouble(temp.ShowRecordCount)).YueShu();


            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<select onchange='location.href=this.value'>");
            for (int i = 1; i <= pagecount; i++)
            {
                if (page == i)
                {
                    sb.AppendLine(string.Format("<option value='{0}' selected>{1}</option>", BasePage.GetClassUrl(c,i) , i.ToS()));
                }
                else
                {
                    sb.AppendLine(string.Format("<option value='{0}'>{1}</option>",  BasePage.GetClassUrl(c, i) , i.ToS()));
                }
            }
            sb.AppendLine("</select>");
            return sb.ToS();
        }

        public string BuidPagerOption(string key, int page)
        {
            DataEntities ent = new DataEntities();

            int recordCount = //BookView.Count(string.Format("Title like '%{0}%' or Author like '%{0}%' or Intro like '%{0}%'", key));
                (from l in ent.Book where l.Title.Contains(key) || l.Author.Contains(key) || l.Intro.Contains(key) select l).Count();
            int tmpid = 0;
            TemplateList temp = new TemplateList();

            temp = GetListTemplate(new Class() { ModelID = 4 });


            int pagecount = (Convert.ToDouble(recordCount) / Convert.ToDouble(20)).YueShu();


            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<select onchange='location.href=this.value'>");
            for (int i = 1; i <= pagecount; i++)
            {
                if (page == i)
                {
                    sb.AppendLine(string.Format("<option value='{0}' selected>{1}</option>", "/Search.aspx?m=4&key=" + key, i));
                }
                else
                {
                    sb.AppendLine(string.Format("<option value='{0}'>{1}</option>", "/Search.aspx?m=4&key=" + key + "&p=" + i, i));
                }
            }
            sb.AppendLine("</select>");
            return sb.ToS();
        }
        #endregion

        #region  创建导航条
        /// <summary>
        /// 创建类导航
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public string BuildClassNavString(Class c)
        {
            string str = "";

            str = string.Format("> <a href=\"{0}\">{1}</a>", BasePage.GetClassUrl(c), c.ClassName);


            var cls = ClassAction.Classes.Where(p => p.ID == c.ParentID && c.ShowInNav == true).ToList();
            if (cls.Count > 0)
            {
                foreach (Class cl in cls)
                {

                    str = BuildClassNavString(cl) + str;
                }
            }
            return str;

        }
        #endregion


        #region 替换公共模版变量
        /// <summary>
        /// 替换公共模版变量
        /// </summary>
        /// <param name="TmpString">模版内容</param>
        /// <returns></returns>
        public string ReplacePublicTemplate(string TmpString)
        {
            if (TmpString.IsNullOrEmpty())
            {
                return "";
            }
            Match mc_pubic = new Regex("\\[\\!--temp.(?<key>.*?)--\\]", RegexOptions.None).Match(TmpString);
            while (mc_pubic.Success)
            {
                TmpString = Regex.Replace(
                    TmpString,
                    string.Format("\\[\\!--temp\\.{0}--\\]", mc_pubic.Groups["key"].Value),
                    GetPublicTemplate(mc_pubic.Groups["key"].Value)
                    );
                mc_pubic = mc_pubic.NextMatch();
            }

            return TmpString;
        }
        #endregion

        #region 替换系统参数
        /// <summary>
        /// 替换系统参数
        /// </summary>
        /// <param name="TmpString"></param>
        /// <returns></returns>
        public string ReplaceSystemSetting(string TmpString)
        {
            Match mc_sys = new Regex("\\[\\!--sys.(?<key>.*?)--\\]", RegexOptions.None).Match(TmpString);
            while (mc_sys.Success)
            {
                TmpString = Regex.Replace(
                    TmpString,
                    string.Format("\\[\\!--sys\\.{0}--\\]", mc_sys.Groups["key"].Value),
                    GetSysSettingContent(mc_sys.Groups["key"].Value)
                    );
                mc_sys = mc_sys.NextMatch();
            }

            return TmpString;
        }
        #endregion

        #region 替换标签
        /// <summary>
        /// 替换标签
        /// </summary>
        /// <param name="TmpString"></param>
        /// <returns></returns>
        public string ReplaceTagContent(string TmpString)
        {
            Match mc = new Regex("\\[(?<key>.*?)\\](?<key2>.*?)\\[/(?<key3>.*?)\\]", RegexOptions.None).Match(TmpString);
            while (mc.Success)
            {
                if (mc.Groups["key"].Value == mc.Groups["key3"].Value)
                {
                    TmpString = TmpString.Replace(
                        mc.Groups[0].Value,
                        GetTagContent(string.Format("[{0}]{1}[/{0}]", mc.Groups["key"].Value, mc.Groups["key2"].Value))
                        );

                }

                mc = mc.NextMatch();
            }

            return TmpString;

        }
        #endregion

        #region 替换页面属性 如页面标题等
        /// <summary> 
        /// 替换页面属性
        /// </summary>
        /// <param name="Content"></param>
        /// <param name="pa"></param>
        /// <returns></returns>
        public string ReplacePageAttribute(string Content, PageAttribute pa)
        {
            Content = Content.Replace("[!--page.title--]", pa.Title);
            Content = Content.Replace("[!--page.updatetime--]", pa.UpdateTime);
            Content = Content.Replace("[!--page.description--]", pa.Description);
            Content = Content.Replace("[!--page.keyword--]", pa.Keyword);
            return Content;
        }
        #endregion

        #region 获取公共模板变量字符串
        /// <summary>
        /// 获取公共模板变量字符串
        /// </summary>
        /// <param name="VarName"></param>
        /// <returns></returns>
        public string GetPublicTemplate(string VarName)
        {
            using (DataEntities ent = new DataEntities())
            {
                string html = (from l in ent.TemplateVar where l.VarName == VarName select l).FirstOrDefault().Content;
                return ReplaceSystemSetting(html);

            }

        }
        #endregion

        #region 系统参数
        /// <summary>
        /// 系统参数
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string GetSysSettingContent(string key)
        {
            SysSetting ss = BasePage.SystemSetting;
            switch (key.ToLower())
            {
                case "siteurl":
                    return ss.SiteUrl;
                    break;
                case "keywords":
                    return ss.KeyWords;
                    break;
                case "description":
                    return ss.Description;
                    break;
                case "copyright":
                    return ss.Copyright;
                    break;
                case "countcode":
                    return ss.CountCode;
                    break;
                case "filedirstring":
                    return ss.FileDirString;
                    break;
                case "extname":
                    return ss.ExtName;
                    break;
                case "siteclosemsg":
                    return ss.SiteCloseMsg;
                    break;
                case "sitename":
                    return ss.SiteName;
                    break;
                case "bookindexurl":
                    return GetBookIndexUrl();
                    break;
                default:
                    return "";
            }
        }
        #endregion

        private string GetBookIndexUrl()
        {
            if (BasePage.SystemSetting.EnableStatic)
            {
                return "/";
            }
            else
            {
                if (BasePage.SystemSetting.DefaultModel == 4)
                {
                    return "/";
                }
                else
                {
                    return "/Book";
                }
            }
        }

        #region 替换标签内容
        /// <summary>
        /// 替换标签内容
        /// </summary>
        /// <param name="tag">标签</param>
        /// <returns>结果</returns>
        public string GetTagContent(string tag)
        {
            //[方法]xx,xx,xx,xx[/方法]
            string functionName = "";
            object[] pars;

            #region  获取方法名
            Match mc_FunctionName = new Regex("\\[(?<key>.*?)\\]", RegexOptions.None).Match(tag);
            if (mc_FunctionName.Success)
            {
                functionName = mc_FunctionName.Groups["key"].Value;
            }
            Match mc_FunctionNameR = new Regex("\\[/(?<key>.*?)\\]", RegexOptions.None).Match(tag);
            if (mc_FunctionNameR.Success)
            {
                if (mc_FunctionName.Groups["key"].Value != mc_FunctionNameR.Groups["key"].Value)
                {
                    functionName = "ERR";
                }
                else
                {
                    functionName = mc_FunctionName.Groups["key"].Value;
                }
            }
            else
            {
                functionName = "ERR";
            }
            #endregion

            #region 获取参数
            Match mc_pars = new Regex("\\[.*\\](?<key>.*?)\\[/.*\\]", RegexOptions.None).Match(tag);
            if (mc_pars.Success)
            {
                pars = mc_pars.Groups["key"].Value.Split(',');

            }
            else
            {
                pars = new object[] { "" };
            }

            #endregion

            try
            {
                return ExecMethod("Voodoo.Basement.Functions", functionName, pars).ToS();
            }
            catch
            {
                return "标签使用错误";
            }

        }
        #endregion


        #region 全部替换
        /// <summary>
        /// 全部替换
        /// </summary>
        /// <param name="str"></param>
        /// <param name="parrten"></param>
        /// <param name="newstr"></param>
        /// <returns></returns>
        protected string ReplaceAll(string str, string parrten, string newstr)
        {
            while (Regex.IsMatch(str, parrten))
            {
                str = Regex.Replace(str, parrten, newstr, RegexOptions.IgnoreCase);
            }
            return str;
        }
        #endregion


        #region 执行某个方法
        /// <summary>
        /// 执行某个方法
        /// </summary>
        /// <param name="className">类，包括命名空间</param>
        /// <param name="methodName">方法名</param>
        /// <param name="objParas">参数</param>
        /// <returns></returns>
        protected object ExecMethod(string className, string methodName, object[] objParas)
        {
            Type t = Type.GetType(className);
            /*实例化这个类*/
            ConstructorInfo constructor = t.GetConstructor(new Type[0]);//将得到的类型传给一个新建的构造器类型变量
            object obj = constructor.Invoke(new object[0]);//使用构造器对象来创建对象
            /*执行Insert方法*/
            MethodInfo m = t.GetMethod(methodName);
            return m.Invoke(obj, objParas);
        }
        #endregion
    }
}
