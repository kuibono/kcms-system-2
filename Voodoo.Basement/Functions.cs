﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

using Voodoo;
using Voodoo.Security;

namespace Voodoo.Basement
{
    public class Functions
    {
        #region 新闻列表 cmsnewslist
        /// <summary>
        /// 新闻列表
        /// </summary>
        /// <param name="ClassID">栏目ID</param>
        /// <param name="TitlePreChar">标题前字符</param>
        /// <param name="count">索取条数</param>
        /// <param name="TitleLength">标题保留长度</param>
        /// <param name="ExtSql">额外的Sql条件</param>
        /// <param name="Order">排序语句</param>
        /// <returns></returns>
        public string cmsnewslist(string ClassID, string TitlePreChar, string count, string TitleLength, string showTime, string ExtSql, string Order)
        {
            Class cls = NewsAction.NewsClass.Where(p => p.ID.ToString() == ClassID).First();

            DataEntities ent = new DataEntities();

            if (cls.ModelID == 1)
            {

                string str_sql = string.Format("t.classID in ({0})", GetAllSubClass(ClassID.ToInt32()));
                if (ExtSql.Length > 1)
                {
                    str_sql += " and " + ExtSql;
                }
                str_sql += Order;


                List<News> nlist = ent.CreateQuery<News>(string.Format("select Value t from News as t where {1} Order by t.id desc take {0}", count, str_sql)).ToList();
                StringBuilder sb = new StringBuilder();
                foreach (News n in nlist)
                {
                    string title = n.Title;
                    if (TitleLength.ToInt32() > 0)
                    {
                        title = title.CutString(TitleLength.ToInt32());
                    }
                    string timespan = "";
                    if (showTime.ToInt32() > 0)
                    {
                        timespan = string.Format("<span class=\"news_time_span\">{0}</span>", n.NewsTime.ToDateTime().ToString("yyyy/MM/dd"));
                    }

                    sb.AppendLine(string.Format("<li>{0}{1}<a href='{2}' title='{3}'>{4}</a></li>", TitlePreChar, timespan, BasePage.GetNewsUrl(n, n.GetClass()), n.Title, title));
                }
                return sb.ToS();
            }//Model=1 新闻
            else if (cls.ModelID == 2)
            {
                return "图";
            }
            else if (cls.ModelID == 3)//问答
            {
                string str_sql = string.Format("t.classID in ({0})", GetAllSubClass(ClassID.ToInt32()));
                if (ExtSql.Length > 1)
                {
                    str_sql += " and " + ExtSql;
                }
                str_sql += Order;
                List<Question> qlist = ent.CreateQuery<Question>(string.Format("select VALUE t from Question as t where {1} orderby t.id desc take {0}", count, str_sql)).ToList();
                StringBuilder sb = new StringBuilder();
                foreach (Question q in qlist)
                {
                    string title = q.Title;
                    if (TitleLength.ToInt32() > 0)
                    {
                        title = title.CutString(TitleLength.ToInt32());
                    }
                    string timespan = "";
                    if (showTime.ToInt32() > 0)
                    {
                        timespan = string.Format("<span class=\"news_time_span\">{0}</span>", q.AskTime.ToDateTime().ToString("yyyy/MM/dd"));
                    }

                    sb.AppendLine(string.Format("<li>{0}{1}<a href='{2}' title='{3}'>{4}</a></li>", TitlePreChar, timespan, BasePage.GetQuestionUrl(q, q.GetClass()), q.Title, title));
                }
                return sb.ToS();
            }
            else
            {
                return "未知模型";
            }
        }

        /// <summary>
        /// 获取所有子栏目
        /// </summary>
        /// <param name="ClassID"></param>
        /// <returns></returns>
        protected string GetAllSubClass(int ClassID)
        {
            var cls = ClassAction.Classes.Where(p => p.ParentID == ClassID);
            StringBuilder sb = new StringBuilder();
            foreach (var c in cls)
            {
                sb.Append(c.ID + ",");
            }
            sb.Append(ClassID);
            return sb.ToS();
        }
        #endregion

        #region 通过关键词读取新闻
        /// <summary>
        /// 通过关键词读取新闻
        /// </summary>
        /// <param name="count"></param>
        /// <param name="TitleLength"></param>
        /// <param name="showTime"></param>
        /// <param name="key"></param>
        /// <param name="Order"></param>
        /// <returns></returns>
        public string getnewsbykeywords(string count, string TitleLength, string showTime, string key, string Order)
        {
            DataEntities ent = new DataEntities();

            string str_sql = "";
            str_sql += "(";
            string[] keys = Regex.Replace(key, "\\s+", ",").Split(',');
            foreach (string k in keys)
            {
                str_sql += " t.keywords like '%" + k + "%' or ";
            }
            str_sql += " 1=2)";



            List<News> nlist = ent.CreateQuery<News>(string.Format("select VALUE t from News as t where {1} {2} order by t.id desc take {0}", count, str_sql, Order)).ToList();
            StringBuilder sb = new StringBuilder();
            foreach (News n in nlist)
            {
                string title = n.Title;
                if (TitleLength.ToInt32() > 0)
                {
                    title = title.CutString(TitleLength.ToInt32());
                }
                string timespan = "";
                if (showTime.ToInt32() > 0)
                {
                    timespan = string.Format("<span class=\"news_time_span\">{0}</span>", n.NewsTime.ToDateTime().ToString("yyyy/MM/dd"));
                }

                sb.AppendLine(string.Format("<li>{0}{1}<a href='{2}' title='{3}'>{4}</a></li>", "", timespan, BasePage.GetNewsUrl(n, n.GetClass()), n.Title, title));
            }
            ent.Dispose();

            return sb.ToS();

        }
        #endregion

        #region 轮播Flash
        /// <summary>
        /// 轮播Flash
        /// </summary>
        /// <param name="ClassID"></param>
        /// <param name="count"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="showTitle"></param>
        /// <param name="titleLength"></param>
        /// <param name="interval"></param>
        /// <param name="ExtSql"></param>
        /// <param name="Order"></param>
        /// <returns></returns>
        public static string cmsflashpic(string ClassID, string count, string width, string height, string showTitle, string titleLength, string interval, string ExtSql, string Order)
        {
            DataEntities ent = new DataEntities();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<!--开始FLASH-->");
            sb.AppendLine("<div class=\"flash\">");
            sb.AppendLine("<script type=\"text/javascript\">");
            sb.AppendLine("<!--");

            sb.AppendLine(string.Format("var interval_time={0};", interval));
            sb.AppendLine(string.Format("var focus_width={0};", width));
            sb.AppendLine(string.Format("var focus_height={0};", height));
            if (showTitle.ToInt32() > 0)
            {
                sb.AppendLine("var text_height=20;");
            }
            else
            {
                sb.AppendLine("var text_height=0;");
            }
            sb.AppendLine("var text_align=\"center\";");
            sb.AppendLine("var swf_height = focus_height+text_height;");
            sb.AppendLine("var swfpath=\"/e/data/images/pixviewer.swf\";");
            sb.AppendLine("var swfpatha=\"/e/data/images/pixviewer.swf\";");

            StringBuilder sb_pics = new StringBuilder();
            StringBuilder sb_links = new StringBuilder();
            StringBuilder sb_texts = new StringBuilder();

            #region 图片变量
            sb_pics.Append("var pics=\"");
            sb_links.Append("var links=\"");
            sb_texts.Append("var texts=\"");

            string str_sql = string.Format("(ZtID='{0}' or ClassID='{1}') and len(TitleImage)>0", ClassID, ClassID);
            if (ExtSql.Length > 0)
            {
                str_sql += " and " + ExtSql;
            }
            if (Order.Length > 0)
            {
                str_sql += " order by " + Order;
            }

            List<News> newses = //NewsView.GetModelList(str_sql, count.ToInt32());
                ent.CreateQuery<News>(string.Format("select top {0} * from News where {1}", count, str_sql)).ToList();

            newses = newses.Where(p => p.TitleImage.IndexOf(".gif") < 0).ToList();//不支持GIF文件
            foreach (News n in newses)
            {
                sb_pics.Append(n.TitleImage + "|");
                sb_links.Append(BasePage.GetNewsUrl(n, n.GetClass()) + "|");
                sb_texts.Append(n.Title.CutString(titleLength.ToInt32()) + "|");
            }
            sb_pics = sb_pics.TrimEnd('|');
            sb_links = sb_links.TrimEnd('|');
            sb_texts = sb_texts.TrimEnd('|');

            sb_pics.Append("\";\n");
            sb_links.Append("\";\n");
            sb_texts.Append("\";\n");

            sb.Append(sb_pics.ToString());
            sb.Append(sb_links.ToString());
            sb.Append(sb_texts.ToString());
            #endregion

            #region 输出Flash
            sb.AppendLine("document.write('<object classid=\"clsid:d27cdb6e-ae6d-11cf-96b8-444553540000\" codebase=\"http://fpdownload.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=8,0,0,0\" width=\"'+ focus_width +'\" height=\"'+ swf_height +'\">'); ");
            sb.AppendLine("document.write('<param name=\"movie\" value=\"'+swfpath+'\"><param name=\"quality\" value=\"high\"><param name=\"bgcolor\" value=\"#ffffff\">'); ");
            sb.AppendLine("document.write('<param name=\"menu\" value=\"false\"><param name=wmode value=\"opaque\">'); ");
            sb.AppendLine("document.write('<param name=\"FlashVars\" value=\"pics='+pics+'&links='+links+'&texts='+texts+'&borderwidth='+focus_width+'&borderheight='+focus_height+'&textheight='+text_height+'&text_align='+text_align+'&interval_time='+interval_time+'\">'); ");
            sb.AppendLine("document.write('<embed src=\"'+swfpath+'\" wmode=\"opaque\" FlashVars=\"pics='+pics+'&links='+links+'&texts='+texts+'&borderwidth='+focus_width+'&borderheight='+focus_height+'&textheight='+text_height+'&text_align='+text_align+'&interval_time='+interval_time+'\" menu=\"false\" bgcolor=\"#ffffff\" quality=\"high\" width=\"'+ focus_width +'\" height=\"'+ swf_height +'\" allowScriptAccess=\"sameDomain\" type=\"application/x-shockwave-flash\" pluginspage=\"http://www.macromedia.com/go/getflashplayer\" />');");
            sb.AppendLine("document.write('</object>');");
            #endregion

            sb.AppendLine("//-->");
            sb.AppendLine("</script>");
            sb.AppendLine("</div>");
            ent.Dispose();

            return sb.ToString();
        }
        #endregion

        #region 获取栏目列表
        /// <summary>
        /// 获取栏目列表
        /// </summary>
        /// <param name="TitlePreChar">前置字符串</param>
        /// <param name="TitleLength">栏目名截取长度</param>
        /// <returns></returns>
        public static string cmsclasslist(string TitlePreChar, string TitleLength)
        {

            int cutString = TitleLength.ToInt32(50);
            StringBuilder sb = new StringBuilder();
            List<Class> cls = ClassAction.Classes.Where(p => p.IsLeafClass == true && p.ShowInNav == true).ToList();
            foreach (Class c in cls)
            {
                sb.AppendLine(string.Format("<li>{0}<a href=\"{1}\">{2}</a></li>",
                    TitlePreChar,
                    BasePage.GetClassUrl(c),
                    c.ClassName.CutString(cutString)
                    ));
            }
            return sb.ToString();
        }
        #endregion

        #region 根据条件获取分类列表
        /// <summary>
        /// 根据条件获取分类列表
        /// </summary>
        /// <param name="m_where">条件语句</param>
        /// <returns></returns>
        public static string getclassbyfilter(string m_where)
        {
            DataEntities ent = new DataEntities();

            List<Class> cls = //ClassView.GetModelList(m_where);
                ent.CreateQuery<Class>(string.Format("select VALUE t from Class as t where {0}", m_where)).ToList();
            StringBuilder sb = new StringBuilder();
            foreach (Class c in cls)
            {
                sb.AppendLine(string.Format("<a href=\"{0}\">{1}</a> ",
                    BasePage.GetClassUrl(c),
                    c.ClassName
                    ));
            }

            ent.Dispose();

            return sb.ToString();
        }

        /// <summary>
        /// 根据条件获取分类列表
        /// </summary>
        /// <param name="m_where">条件语句</param>
        /// <param name="Model">字符拼接模板</param>
        /// <returns></returns>
        public static string Getclassbyfilter(string m_where, string Model)
        {
            DataEntities ent = new DataEntities();

            List<Class> cls = ent.CreateQuery<Class>(string.Format("select VALUE t from Class as t where {0}", m_where)).ToList();
            StringBuilder sb = new StringBuilder();
            foreach (Class c in cls)
            {
                string str = Model.Replace("{classname}", c.ClassName);
                str = str.Replace("{id}", c.ID.ToS());
                str = str.Replace("{url}", BasePage.GetClassUrl(c));
                sb.Append(str);
            }
            ent.Dispose();
            return sb.ToString();
        }
        #endregion

        #region 获取子栏目
        /// <summary>
        /// 获取子栏目
        /// </summary>
        /// <param name="TitlePreChar">前置字符串</param>
        /// <param name="TitleLength"></param>
        /// <param name="ClassID">栏目名截取长度</param>
        /// <returns></returns>
        public static string GetSubClass(string TitlePreChar, string TitleLength, string ClassID)
        {
            int cutString = TitleLength.ToInt32(50);
            StringBuilder sb = new StringBuilder();
            List<Class> cls = ObjectExtents.Class(ClassID.ToInt32()).GetSubClass(); ;
            foreach (Class c in cls)
            {
                sb.AppendLine(string.Format("<li>{0}<a href=\"{1}\">{2}</a></li>",
                    TitlePreChar,
                    BasePage.GetClassUrl(c),
                    c.ClassName.CutString(cutString)
                    ));
            }

            return sb.ToString();
        }
        #endregion

        #region  创建菜单
        /// <summary>
        /// 创建菜单
        /// </summary>
        /// <param name="parentID"></param>
        /// <returns></returns>
        public static string buildmenustring(string parentID)
        {
            StringBuilder sb = new StringBuilder();

            var cls = ClassAction.Classes.Where(p => p.ShowInNav == true && p.ParentID.ToString() == parentID).ToList();
            if (cls.Count > 0)
            {
                foreach (Class cl in cls)
                {
                    sb.AppendLine("<li>");
                    if (cl.IsLeafClass == true)
                    {
                        sb.AppendLine(string.Format("<span><a href=\"{0}\">{1}</a></span>", BasePage.GetClassUrl(cl), cl.ClassName));
                    }
                    else
                    {
                        sb.AppendLine(string.Format("<span><a href=\"{0}\">{1}</a></span>", BasePage.GetClassUrl(cl), cl.ClassName));
                    }


                    if (ClassAction.Classes.Where(p => p.ParentID == cl.ID).Count() > 0)
                    {
                        sb.AppendLine("<ul>" + buildmenustring(cl.ID.ToString()) + "</ul>");
                    }
                    sb.AppendLine("</li>");

                }
            }

            return sb.ToString();

        }
        #endregion

        #region 友情链接
        /// <summary>
        /// 友情链接
        /// </summary>
        /// <returns></returns>
        public static string getlink(string n)
        {
            using (DataEntities ent = new DataEntities())
            {
                StringBuilder sb = new StringBuilder("");
                var links =// LinkView.GetModelList("id>0 order by [Index]");
                    (from l in ent.Link orderby l.Index select l).ToList();
                foreach (var l in links)
                {
                    sb.AppendLine(string.Format("<a href=\"{0}\" target=\"_blank\">{1}</a>|", l.Url, l.LinkTitle));
                }

                return sb.TrimEnd('|').ToString();
            }
        }
        #endregion

        #region 生成新闻缩略图
        /// <summary>
        /// 生成新闻缩略图
        /// </summary>
        /// <param name="NewsID"></param>
        /// <returns></returns>
        public static string getnewsshortimg(string NewsID)
        {
            DataEntities ent = new DataEntities();
            int _intID = NewsID.ToInt32();
            News news = (from l in ent.News where l.ID == _intID select l).FirstOrDefault();


            var files = //FileView.Find(string.Format("FilePath='{0}'", news.TitleImage));
                (from l in ent.File where l.FilePath == news.TitleImage select l).ToList();

            ent.Dispose();
            string result = "<img src='{0}' alt='{1}' />";
            if (files.Count > 0)//有缩略图
            {
                result = string.Format(result, files[0].SmallPath, news.Title);
            }
            else
            {
                result = "";
            }
            return result;
        }
        #endregion

        #region 获取小说栏目列表
        /// <summary>
        /// 获取小说栏目列表
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string getallnovelclass(string str)
        {
            List<Class> cls = ClassAction.Classes.Where(p => p.ModelID == 4).ToList();
            StringBuilder sb = new StringBuilder();
            foreach (Class c in cls)
            {
                sb.Append(string.Format("<a href=\"{0}\">{1}</a> ", BasePage.GetClassUrl(c), c.ClassName));
            }
            return sb.ToS();
        }
        #endregion 获取小说栏目列表

        #region 获取最新更新的书籍
        /// <summary>
        /// 获取最新更新的书籍 Metro风格
        /// </summary>
        /// <param name="top"></param>
        /// <returns></returns>
        public string getnoveltopmetroupdate(string top)
        {
            DataEntities ent = new DataEntities();

            int i_top = top.ToInt32();
            List<Book> bs = //BookView.GetModelList("Enable=1 order by UpdateTime desc", i_top);
                (from l in ent.Book where l.Enable == true orderby l.UpdateTime descending select l).Take(i_top).ToList();
            StringBuilder sb = new StringBuilder();
            int i = 1;
            foreach (Book b in bs)
            {
                Class c = b.GetClass();
                sb.AppendLine(string.Format("<li style=\" background-color:{0};\"><div class=\"item\"><h1><a href=\"{1}\">" + i + ".{2}</a></h1><div><div class=\"lastchapter\"><a href=\"{5}\">{6}</a></div></div></div><div class=\"item\"><h1><a href=\"{1}\">阅读书籍</a></h1><div><div class=\"lastchapter\"><a href=\"{5}\" title=\"{6}\">阅读最新章节</a></div><div class=\"class\">分类：<a href=\"{3}\">{4}</a></div><div class=\"author\">作者：{8}</div><div class=\"time\">更新时间：{9}</div></div></div></li>",
                    BasePage.RandomBGColor(),
                    BasePage.GetBookUrl(b, c),
                    b.Title,
                    BasePage.GetClassUrl(c),
                    b.ClassName,
                    BasePage.GetBookChapterUrl(ObjectExtents.Chapter(b.LastChapterID), c),
                    b.LastChapterTitle,
                    b.LastChapterTitle.CutString(12),
                    b.Author,
                    b.UpdateTime.ToDateTime().ToString("MM-dd HH:mm")
                    ));
                i++;
            }
            ent.Dispose();

            return sb.ToS();
        }

        /// <summary>
        /// 获取最新更新的书籍
        /// </summary>
        /// <param name="top"></param>
        /// <returns></returns>
        public string getnoveltopupdate(string top)
        {
            DataEntities ent = new DataEntities();
            int i_top = top.ToInt32();
            List<Book> bs = (from l in ent.Book where l.Enable == true && l.LastChapterID>0 orderby l.UpdateTime descending select l).Take(i_top).ToList();
            StringBuilder sb = new StringBuilder();

            //foreach (Book b in bs)
            for (int i = 0; i < bs.Count; i++)
            {
                Book b = bs[i];
                Class c = b.GetClass();
                string str_style = "";
                if (i % 2 == 0)
                {
                    str_style = " style=\"background-color: #f5f5f5\"";
                }

                sb.AppendLine(string.Format("<tr" + str_style + "><td>[<a target=\"_blank\" href=\"{0}\" class=\"sort\">{1}</a>]</td><td><a class=\"name\" target=\"_blank\" href=\"{2}\">{3}</a> <a target=\"_blank\" href=\"{4}\" class=\"chapter\">{5}</a></td><td><a target=\"_blank\" href=\"/Search.aspx?m=4&key={6}\" class=\"author\">{6}</a></td><td style=\"color: #666666\">{7}</td></tr>",
                    BasePage.GetClassUrl(c),
                    b.ClassName,
                    BasePage.GetBookUrl(b, c),
                    b.Title,
                     BasePage.GetBookChapterUrl(ObjectExtents.Chapter(b.LastChapterID), c),
                    b.LastChapterTitle,
                    b.Author,
                    b.UpdateTime.ToDateTime().ToString("MM-dd HH:mm")
                    ));
            }
            ent.Dispose();
            return sb.ToS();
        }

        #endregion 获取最新更新的书籍

        #region 获取小说列表
        /// <summary>
        /// 获取小说列表
        /// </summary>
        /// <param name="m_where"></param>
        /// <returns></returns>
        public static string getnovellist(string m_where, string Top, string CutTitle, string firstClass, string ShowClickCount)
        {
            DataEntities ent = new DataEntities();

            StringBuilder sb = new StringBuilder();

            var NovelList = //BookView.GetModelList(m_where, Top.ToInt32());
                ent.CreateQuery<Book>(string.Format("select VALUE t from Book as t where {1} order by t.id desc take {0}", Top, m_where)).ToList();
            ent.Dispose();

            foreach (var b in NovelList)
            {
                string str_cls = "";
                if (firstClass.Length > 0 && b == NovelList.First())
                {
                    str_cls = " class=\"" + firstClass + "\"";
                }

                string str_clickcount = "";
                if (ShowClickCount.ToBoolean())
                {
                    str_clickcount = string.Format("<span>{0}</span>", b.ClickCount);
                }

                sb.Append(string.Format("<li" + str_cls + "><a title=\"{0}\" href=\"{1}\">{2}</a>{3}</li>", b.Title, BasePage.GetBookUrl(b, b.GetClass()), b.Title.CutString(CutTitle.ToInt32(10)), str_clickcount));
            }

            return sb.ToS();
        }

        public static string getnovellist(string m_where,string Order, string Top, string CutTitle, string firstClass, string ShowClickCount)
        {
            DataEntities ent = new DataEntities();

            StringBuilder sb = new StringBuilder();

            var NovelList = //BookView.GetModelList(m_where, Top.ToInt32());
                ent.CreateQuery<Book>(string.Format("select VALUE t from Book as t where {1} order by {2} take {0}", Top, m_where,Order)).ToList();
            ent.Dispose();

            foreach (var b in NovelList)
            {
                string str_cls = "";
                if (firstClass.Length > 0 && b == NovelList.First())
                {
                    str_cls = " class=\"" + firstClass + "\"";
                }

                string str_clickcount = "";
                if (ShowClickCount.ToBoolean())
                {
                    str_clickcount = string.Format("<span>{0}</span>", b.ClickCount);
                }

                sb.Append(string.Format("<li" + str_cls + "><a title=\"{0}\" href=\"{1}\">{2}</a>{3}</li>", b.Title, BasePage.GetBookUrl(b, b.GetClass()), b.Title.CutString(CutTitle.ToInt32(10)), str_clickcount));
            }

            return sb.ToS();
        }

        public static string Getnovellist(string m_where, int Top, int CutTitle, string Model)
        {
            StringBuilder sb = new StringBuilder();
            DataEntities ent = new DataEntities();
            var NovelList = ent.CreateQuery<Book>(string.Format("select VALUE t from Book as t where {1} order by t.id desc take {0}", Top, m_where)).ToList();
            ent.Dispose();

            foreach (var b in NovelList)
            {
                string str = Model;
                str = str.Replace("{id}", b.ID.ToS());
                str = str.Replace("{title}", b.Title.CutString(CutTitle));
                str = str.Replace("{author}", b.Author);
                str = str.Replace("{classid}", b.ClassID.ToS());
                str = str.Replace("{classname}", b.ClassName);
                str = str.Replace("{clickcount}", b.ClickCount.ToS());
                str = str.Replace("{lastchapterid}", b.LastChapterID.ToS());
                str = str.Replace("{lastchaptertitle}", b.LastChapterTitle);
                str = str.Replace("{tjcount}", b.TjCount.ToS());
                str = str.Replace("{url}", BasePage.GetBookUrl(b, b.GetClass()));

                sb.Append(str);
            }

            return sb.ToS();
        }
        #endregion

        #region 获取系统搜索关键词
        /// <summary>
        /// 获取系统搜索关键词
        /// </summary>
        /// <param name="Top"></param>
        /// <returns></returns>
        public static string getsearchkey(string Top, string ModelID)
        {
            StringBuilder sb = new StringBuilder();
            DataEntities ent = new DataEntities();

            var list = //SysKeywordView.GetModelList(string.Format("ModelID={0} order by ClickCount desc", ModelID), Top.ToInt32(10));
                ent.CreateQuery<SysKeyword>(string.Format("select VALUE t from SysKeyword as t where t.ModelID={1} order by t.ClickCount desc limit  {0}", Top, ModelID)).AsCache();
            ent.Dispose();

            foreach (var item in list)
            {
                sb.Append(string.Format("<a href=\"/Book/Search/?key={0}\">{0}</a>&nbsp;", item.Keyword, ModelID));
            }
            return sb.ToS();
        }

        public static string Getsearchkey(string m_where, int Top, string Model)
        {
            StringBuilder sb = new StringBuilder();
            DataEntities ent = new DataEntities();
            var list = ent.CreateQuery<SysKeyword>(string.Format("select VALUE t from SysKeyword as t where {1} order by t.ClickCount desc limit  {0}", Top, m_where)).ToList();
            ent.Dispose();

            foreach (var item in list)
            {
                string str = Model;
                str = str.Replace("{clickcount}", item.ClickCount.ToS());
                str = str.Replace("{id}", item.ID.ToS());
                str = str.Replace("{keyword}", item.Keyword);
                sb.Append(str);
            }
            return sb.ToS();
        }
        #endregion

        #region 获取小说分类新闻
        /// <summary>
        /// 获取小说分类新闻
        /// </summary>
        /// <param name="ClassID">分类ID</param>
        /// <param name="Top">所取条数</param>
        /// <returns></returns>
        public static string getclassnews(string ClassID, string Top)
        {
            DataEntities ent = new DataEntities();

            int int_cls = ClassID.ToInt32();
            List<Book> qs = (from l in ent.Book
                             from cp in ent.Class
                             from cl in ent.Class
                             where cp.ID == int_cls && cl.ParentID == cp.ID && (l.ClassID == cp.ID || l.ClassID == cl.ID)
                             select l
                ).Take(Top.ToInt32()).ToList();
            ent.Dispose();

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < qs.Count; i++)
            {
                if (i == 0)
                {
                    sb.AppendLine(string.Format("<ul class=\"picList\"><li><a href=\"{0}\" title=\"{1}\" class=\"ablum\"><img src=\"{3}\" alt=\"{1}\" width=\"120\" height=\"160\" /></a><div class=\"text\"><h2 class=\"h22\"><a href=\"{0}\" title=\"{1}\" target=\"_blank\">《{1}》</a></h2><p>{2}</p></div></li>",
                        BasePage.GetBookUrl(qs[i], qs[i].GetClass()),
                        qs[i].Title,
                        qs[i].Intro.TrimHTML().CutString(150),
                        qs[i].FaceImage.IsNull("/Book/Bookface/0.jpg")
                        ));
                }
                else if (i == 1)
                {
                    sb.AppendLine(string.Format("<li><a href=\"{0}\" title=\"{1}\" class=\"ablum\"><img src=\"{3}\" alt=\"{1}\" width=\"120\" height=\"160\" /></a><div class=\"text\"><h2 class=\"h22\"><a href=\"{0}\" title=\"{1}\" target=\"_blank\">《{1}》</a></h2><p>{2}</p></div></li></ul>",
                        BasePage.GetBookUrl(qs[i], qs[i].GetClass()),
                        qs[i].Title,
                        qs[i].Intro.TrimHTML().CutString(150),
                        qs[i].FaceImage.IsNull("/Book/Bookface/0.jpg")
                        ));
                }
                else if (i == 2)
                {
                    sb.AppendLine(string.Format("<ul class=\"newsList\"><li><a target=\"_blank\" title=\"{1}\" href=\"{0}\">{1}：{2}</a></li>",
                        BasePage.GetBookUrl(qs[i], qs[i].GetClass()),
                        qs[i].Title,
                        qs[i].Intro.TrimHTML().CutString(25)
                        ));
                }
                else
                {
                    sb.AppendLine(string.Format("<li><a target=\"_blank\" title=\"{1}\" href=\"{0}\">{1}：{2}</a></li>",
                        BasePage.GetBookUrl(qs[i], qs[i].GetClass()),
                        qs[i].Title,
                        qs[i].Intro.TrimHTML().CutString(25)
                        ));
                }

            }//end for
            sb.AppendLine("</ul>");
            return sb.ToS();
        }
        #endregion

        #region 根据类别获取书籍排行
        /// <summary>
        /// 根据类别获取书籍排行
        /// </summary>
        /// <param name="top"></param>
        /// <param name="custitle"></param>
        /// <param name="cls"></param>
        /// <param name="htmlTemp"></param>
        /// <returns></returns>
        public static string gettopbookbyclass(string top,string custitle, string cls, string htmlTemp)
        {
            int i_top = top.ToInt32();
            int cid = cls.ToInt32();

             StringBuilder sb = new StringBuilder();
             using (DataEntities ent = new DataEntities())
             {
                 var list = (from l in ent.Book
                            from c in ent.Class
                            where
                            (l.ClassID == cid && c.ID == cid) ||
                            (l.ClassID == c.ID && c.ParentID == cid)
                            orderby l.ClickCount descending
                            select l).Take(i_top);
                 if (cid < 0)
                 {
                     list = (from l in ent.Book orderby l.ClickCount descending select l).Take(i_top);
                 }
                 var i = 0;
                 foreach (var q in list)
                 {
                     i++;
                     string item = htmlTemp;
                     item = item.Replace("{addtime}", q.Addtime.ToDateTime().ToString("yyyy-MM-dd"));
                     item = item.Replace("{author}", q.Author);
                     item = item.Replace("{classid}", q.ClassID.ToS());
                     item = item.Replace("{classname}", q.ClassName);
                     item = item.Replace("{clickcount}", q.ClickCount.ToS());
                     item = item.Replace("{corpusid}", q.CorpusID.ToS());
                     item = item.Replace("{corpustitle}", q.CorpusTitle);
                     item = item.Replace("{enable}", q.Enable.ToBoolean().ToChinese());
                     item = item.Replace("{faceimage}", q.FaceImage);
                     item = item.Replace("{id}", q.ID.ToS());
                     item = item.Replace("{intro}", q.Intro);
                     item = item.Replace("{isfirstpost}", q.IsFirstPost.ToBoolean().ToChinese());
                     item = item.Replace("{isvip}", q.IsVip.ToBoolean().ToChinese());
                     item = item.Replace("{lastchapterid}", q.LastChapterID.ToS());
                     item = item.Replace("{lastchaptertitle}", q.LastChapterTitle);
                     item = item.Replace("{lastvipchapterid}", q.LastVipChapterID.ToS());
                     item = item.Replace("{lastvipchaptertitle}", q.LastVipChapterTitle);
                     item = item.Replace("{length}", q.Length.ToS());
                     item = item.Replace("{replycount}", q.ReplyCount.ToS());
                     item = item.Replace("{savecount}", q.SaveCount.ToS());
                     item = item.Replace("{status}", q.Status == 0 ? "连载中" : "已完结");
                     item = item.Replace("{title}", q.Title);
                     item = item.Replace("{tjcount}", q.TjCount.ToS());
                     item = item.Replace("{updatetime}", q.UpdateTime.ToDateTime().ToString("yyyy-MM-dd"));
                     item = item.Replace("{vipupdatetime}", q.VipUpdateTime.ToDateTime().ToString("yyyy-MM-dd"));
                     item = item.Replace("{ztid}", q.ZtID.ToS());
                     item = item.Replace("{ztname}", q.ZtName);
                     item = item.Replace("{title}", q.Title);
                     item = item.Replace("{url}", BasePage.GetBookUrl(q, q.GetClass()));
                     item = item.Replace("{ftitle}", custitle.ToInt32() > 0 ? q.Title.CutString(custitle.ToInt32()) : q.Title);
                     item = item.Replace("{index}", (i - 1).ToS());
                     item = item.Replace("{rownum}", (i).ToS());
                     sb.Append(item);
                 }
                 return sb.ToS();
             }
        }
        #endregion 


        #region 获取类别列表
        /// <summary>
        /// 获取类别列表
        /// </summary>
        /// <param name="top">获取的条数</param>
        /// <param name="custitle">标题截取长度</param>
        /// <param name="m_where">条件语句</param>
        /// <param name="htmlTemp">模板</param>
        /// <returns></returns>
        public static string getclasslist(string top, string custitle, string m_where, string htmlTemp)
        {
            StringBuilder sb = new StringBuilder();
            DataEntities ent = new DataEntities();
            List<Class> cls = ent.CreateQuery<Class>(string.Format("select VALUE t from Class as t where {1} order by t.id desc limit {0}", top, m_where)).ToList();
            ent.Dispose();

            foreach (Class c in cls)
            {
                string item = htmlTemp;
                item = item.Replace("{url}", BasePage.GetClassUrl(c));
                item = item.Replace("{alter}", c.Alter);
                item = item.Replace("{classdescription}", c.ClassDescription);
                item = item.Replace("{classfolder}", c.ClassForder);
                item = item.Replace("{classicon}", c.ClassICON);
                item = item.Replace("{classkeywords}", c.ClassKeywords);
                item = item.Replace("{classname}", c.ClassName);
                item = item.Replace("{fclassname}", c.ClassName.CutString(custitle.ToInt32(10)));
                item = item.Replace("{classpageextname}", c.ClassPageExtName);
                item = item.Replace("{id}", c.ID.ToS());
                sb.Append(item);
            }
            return sb.ToS();
        }
        #endregion

        #region 获取导演列表
        /// <summary>
        /// 获取导演列表
        /// </summary>
        /// <param name="m_where"></param>
        /// <param name="top"></param>
        /// <param name="templatestring"></param>
        /// <returns></returns>
        public static string getdirectorlist(string cutstring, string m_where, string top, string templatestring)
        {
            StringBuilder sb = new StringBuilder();
            DataEntities ent = new DataEntities();
            var movies = //MovieInfoView.GetModelList(m_where).Where(p => p.Director.IndexOf("不详") == -1);
                ent.CreateQuery<MovieInfo>(string.Format("select * from MovieInfo where {0}", m_where)).ToList();
            ent.Dispose();

            var directors = movies.GroupBy(p => p.Director).OrderByDescending(p => p.Count()).Take(top.ToInt32(10));

            foreach (var dir in directors)
            {
                string tmp = templatestring;
                tmp = tmp.Replace("{name}", dir.Key.Replace(":", ""));
                tmp = tmp.Replace("{fname}", dir.Key.Replace(":", "").CutString(cutstring.ToInt32(100)));
                sb.AppendLine(tmp);
            }

            return sb.ToS();
        }
        #endregion

        #region 获取Tag列表
        /// <summary>
        /// 获取Tag列表
        /// </summary>
        /// <param name="m_where"></param>
        /// <param name="top"></param>
        /// <param name="templatestring"></param>
        /// <returns></returns>
        public static string gettaglist(string cutstring, string m_where, string top, string templatestring)
        {
            StringBuilder sb = new StringBuilder();

            DataEntities ent = new DataEntities();
            var movies = //MovieInfoView.GetModelList(m_where);
                 ent.CreateQuery<MovieInfo>(string.Format("select * from MovieInfo where {0}", m_where)).ToList();
            ent.Dispose();

            var tags = movies.GroupBy(p => p.Tags).OrderByDescending(p => p.Count()).Take(top.ToInt32(10));

            foreach (var tag in tags)
            {
                string tmp = templatestring;
                tmp = tmp.Replace("{name}", tag.Key.Replace(":", ""));
                tmp = tmp.Replace("{fname}", tag.Key.Replace(":", "").CutString(cutstring.ToInt32(100)));
                sb.AppendLine(tmp);
            }

            return sb.ToS();
        }
        #endregion

        #region 获取地区列表
        /// <summary>
        /// 获取地区列表
        /// </summary>
        /// <param name="m_where"></param>
        /// <param name="top"></param>
        /// <param name="templatestring"></param>
        /// <returns></returns>
        public static string getlocationlist(string cutstring, string m_where, string top, string templatestring)
        {
            StringBuilder sb = new StringBuilder();

            DataEntities ent = new DataEntities();
            var movies = //MovieInfoView.GetModelList(m_where);
                 ent.CreateQuery<MovieInfo>(string.Format("select * from MovieInfo where {0}", m_where)).ToList();
            ent.Dispose();

            var locations = movies.GroupBy(p => p.Location).OrderByDescending(p => p.Count()).Take(top.ToInt32(10));

            foreach (var location in locations)
            {
                string tmp = templatestring;
                tmp = tmp.Replace("{name}", location.Key.Replace(":", ""));
                tmp = tmp.Replace("{fname}", location.Key.Replace(":", "").CutString(cutstring.ToInt32(100)));
                sb.AppendLine(tmp);
            }

            return sb.ToS();
        }
        #endregion

        #region 获取年代列表
        /// <summary>
        /// 获取年代列表
        /// </summary>
        /// <param name="m_where"></param>
        /// <param name="top"></param>
        /// <param name="templatestring"></param>
        /// <returns></returns>
        public static string getyearlist(string cutstring, string m_where, string top, string templatestring)
        {
            StringBuilder sb = new StringBuilder();

            DataEntities ent = new DataEntities();
            var movies = //MovieInfoView.GetModelList(m_where);
                 ent.CreateQuery<MovieInfo>(string.Format("select * from MovieInfo where {0}", m_where)).ToList();
            ent.Dispose();

            var years = movies.GroupBy(p => p.PublicYear).OrderByDescending(p => p.Count()).Take(top.ToInt32(10));

            foreach (var year in years)
            {
                string tmp = templatestring;
                tmp = tmp.Replace("{name}", year.Key.Replace(":", ""));
                tmp = tmp.Replace("{fname}", year.Key.Replace(":", "").CutString(cutstring.ToInt32(100)));
                sb.AppendLine(tmp);
            }

            return sb.ToS();
        }
        #endregion

        #region 获取演员列表
        /// <summary>
        /// 获取演员列表
        /// </summary>
        /// <param name="top"></param>
        /// <param name="m_where"></param>
        /// <param name="templatestring"></param>
        /// <returns></returns>
        public static string getactorlist(string cutstring, string m_where, string top, string templatestring)
        {
            StringBuilder sb = new StringBuilder();
            DataEntities ent = new DataEntities();
            var movies = //MovieInfoView.GetModelList(m_where);
                 ent.CreateQuery<MovieInfo>(string.Format("select * from MovieInfo where {0}", m_where)).ToList();
            ent.Dispose();
            List<string> results = new List<string>();

            var actors = movies.GroupBy(p => p.Actors).OrderByDescending(p => p.Count()).Take(top.ToInt32(10));
            foreach (var actor in actors)
            {
                string[] acts = actor.Key.Split('/', ':', ',');
                foreach (string str in acts)
                {
                    results.Add(str);
                }
            }

            //分组处理最终结果
            var al_result = results.GroupBy(p => p.ToString()).OrderByDescending(p => p.Count());

            foreach (var str in al_result)
            {
                string tmp = templatestring;
                tmp = tmp.Replace("{name}", str.Key.ToS());
                tmp = tmp.Replace("{fname}", str.Key.ToS().CutString(cutstring.ToInt32(100)));
                sb.AppendLine(tmp);
            }
            return sb.ToS();
        }
        #endregion

        #region 获取搜索系统中，剧集播放页面的地址
        /// <summary>
        /// 获取搜索系统中，剧集播放页面的地址
        /// </summary>
        /// <param name="top"></param>
        /// <param name="custitle"></param>
        /// <param name="m_where"></param>
        /// <param name="htmlTemp"></param>
        /// <returns></returns>
        public static string getmoviedramaurllist(string top, string custitle, string m_where, string htmlTemp)
        {
            DataEntities ent = new DataEntities();
            var itemList = //MovieDramaUrlView.GetModelList(m_where, top.ToInt32(100));
                ent.CreateQuery<MovieDramaUrl>(string.Format("select top {0} * from MovieDramaUrl where {1}", top, m_where)).ToList();
            ent.Dispose();
            StringBuilder sb = new StringBuilder();

            foreach (var item in itemList)
            {
                string itemTemp = htmlTemp;
                itemTemp = itemTemp.Replace("{id}", item.id.ToS());
                itemTemp = itemTemp.Replace("{moviedramaid}", item.MovieDramaID.ToString());
                itemTemp = itemTemp.Replace("moviedramatitle", item.MovieDramaTitle);
                itemTemp = itemTemp.Replace("movieid", item.MovieID.ToS());
                itemTemp = itemTemp.Replace("{movietitle}", item.MovieTitle);
                itemTemp = itemTemp.Replace("{title}", item.Title);
                itemTemp = itemTemp.Replace("{ftitle}", item.Title.CutString(custitle.ToInt32(10)));
                itemTemp = itemTemp.Replace("{updatetime}", item.UpdateTime.ToS());
                itemTemp = itemTemp.Replace("{url}", item.Url);

                sb.Append(itemTemp);
            }
            return sb.ToString();
        }
        #endregion



        #region 获取JOB系统 首页右侧的城市列表
        /// <summary>
        /// 获取JOB系统 首页右侧的城市列表
        /// </summary>
        /// <param name="linkTemp"></param>
        /// <returns></returns>
        public static string GetIndexCitys(string linkTemp)
        {
            StringBuilder sb = new StringBuilder();
            using (DataEntities ent = new DataEntities())
            {
                var cts = (from l in ent.City orderby l.Hot descending select l).AsCache().Take(5);
                int i = 0;
                foreach (var ct in cts)
                {
                    if (i % 5 == 0)
                    {
                        sb.AppendLine("<tr><td><table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" height=\"22\"><tr>");
                    }
                    i++;
                    string tmp = linkTemp.Replace("{city1}", ct.city1).Replace("市", "");
                    tmp = tmp.Replace("{id}", ct.id.ToS());

                    string item = string.Format("<td width=\"16%\" align=\"center\">{0}</td>", tmp);
                    sb.AppendLine(item);
                    if (i == cts.Count())
                    {
                        for (int j = 0; j < cts.Count() % 5; j++)
                        {
                            sb.AppendLine("<td width=\"16%\" align=\"center\">&nbsp;</td>");
                        }
                        sb.AppendLine("</tr></table></td></tr>");
                    }
                    if (i % 5 == 0)
                    {
                        sb.AppendLine("</tr></table></td></tr>");
                    }

                }
            }

            return sb.ToS();
        }
        #endregion

        #region 获取JOB系统 首页下面的行业列表
        /// <summary>
        /// 获取JOB系统 首页下面的行业列表
        /// </summary>
        /// <returns></returns>
        public static string GetIndexIndustrys(string nn)
        {
            StringBuilder sb = new StringBuilder();

            using (DataEntities ent = new DataEntities())
            {
                var qs = (from l in ent.JobIndustry where l.IsLeaf == false select l).AsCache();

                var parents = qs.Where(p => p.ParentID == 0);
                foreach (var p in parents)
                {
                    sb.Append("<li>");
                    sb.Append(string.Format("<b>{0}</b>：", p.Name));
                    var subs = qs.Where(o => o.ParentID == p.ID);
                    foreach (var s in subs)
                    {
                        sb.AppendFormat("<a target=\"_blank\" href=\"{0}\">{1}</a>", s.ID, s.Name);
                    }

                    sb.Append("</li>");
                }
            }

            return sb.ToS();
        }
        #endregion

        #region 获取首页专业树
        /// <summary>
        /// 获取首页专业树
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string getindexSpelist(string s)
        {
            StringBuilder sb = new StringBuilder();
            DataEntities ent = new DataEntities();
            var list = (from l in ent.JobEduSpecialty select l).AsCache();

            var parents = from l in list
                          from t in list
                          where l.ParentID == t.ID
                          && t.ParentID == 0
                          select l;
            foreach (var p in parents)
            {
                sb.AppendFormat("<li><b>{0}</b>：", p.Name);
                var subs = from l in list where l.ParentID == p.ID select l;
                foreach (var sub in subs)
                {
                    sb.AppendFormat("<a target=\"_blank\" href=\"Search.aspx?sp={0}\">{1}</a>", sub.ID, sub.Name);
                }

                sb.Append("</li>");
            }


            return sb.ToS();


            ent.Dispose();
        }
        #endregion

        #region 获取城市列表
        /// <summary>
        /// 获取城市列表
        /// </summary>
        /// <param name="top"></param>
        /// <param name="custitle"></param>
        /// <param name="m_where"></param>
        /// <param name="orderby"></param>
        /// <param name="htmlTemp"></param>
        /// <returns></returns>
        public static string getcitylist(string top, string custitle, string m_where, string orderby, string htmlTemp)
        {
            StringBuilder sb = new StringBuilder();
            using (DataEntities ent = new DataEntities())
            {
                var ads = ent.CreateQuery<City>(string.Format("select VALUE t from City as t where {1} order by {2} limit {0}", top, m_where, orderby)).ToList();
                var i = 0;
                foreach (var q in ads)
                {
                    i++;
                    string item = htmlTemp;

                    item = item.Replace("{id}", q.id.ToS());
                    item = item.Replace("{hot}", q.Hot.ToS());
                    item = item.Replace("{city1}", q.city1);

                    item = item.Replace("{rownum}", i.ToS());
                    item = item.Replace("{index}", (i - 1).ToS());
                    sb.Append(item);
                }

            }

            return sb.ToS();
        }
        #endregion


        #region 获取电影列表
        /// <summary>
        /// 获取电影列表
        /// </summary>
        /// <param name="top">条数</param>
        /// <param name="custitle">标题截取</param>
        /// <param name="m_where">条件语句</param>
        /// <param name="htmlTemp">模板</param>
        /// <returns></returns>
        public static string getmovielist(string top, string custitle, string m_where, string htmlTemp)
        {
            StringBuilder sb = new StringBuilder();
            using (DataEntities ent = new DataEntities())
            {
                List<MovieInfo> movies = ent.CreateQuery<MovieInfo>(string.Format("select top {0} * from MovieInfo where {1}", top, m_where)).ToList();
                var i = 0;
                foreach (MovieInfo m in movies)
                {
                    i++;
                    string item = htmlTemp;
                    item = item.Replace("{url}", BasePage.GetMovieUrl(m, m.GetClass()));
                    item = item.Replace("{id}", m.id.ToS());
                    item = item.Replace("{authors}", m.Actors);
                    item = item.Replace("{classid}", m.ClassID.ToS());
                    item = item.Replace("{classname}", m.ClassName);
                    item = item.Replace("{director}", m.Director);
                    item = item.Replace("{faceimage}", m.FaceImage);
                    item = item.Replace("{inserttime}", m.InsertTime.ToDateTime().ToString("yyyy-MM-dd"));
                    item = item.Replace("{intro}", m.Intro);
                    item = item.Replace("{ismovie}", m.IsMove == true ? "电影" : "电视剧");
                    item = item.Replace("{lastdramatitle}", m.LastDramaTitle);
                    item = item.Replace("{location}", m.Location);
                    item = item.Replace("{publicyear}", m.PublicYear);
                    item = item.Replace("{status}", m.Status == 0 ? "更新中" : "完结");
                    item = item.Replace("{tags}", m.Tags);
                    item = item.Replace("{title}", m.Title);
                    item = item.Replace("{ftitle}", m.Title.CutString(custitle.ToInt32()));
                    item = item.Replace("{updatetime}", m.UpdateTime.ToDateTime().ToString("yyyy-MM-dd"));
                    item = item.Replace("{clickcount}", m.ClickCount.ToS());
                    item = item.Replace("{replycount}", m.ReplyCount.ToS());
                    item = item.Replace("{scoreavg}", m.ScoreAvg.ToS());
                    item = item.Replace("{rownum}", i.ToS());
                    item = item.Replace("{index}", (i - 1).ToS());
                    sb.Append(item);

                }
            }
            return sb.ToS();
        }
        #endregion

        #region 职位申请列表
        /// <summary>
        /// 职位申请列表
        /// </summary>
        /// <param name="top"></param>
        /// <param name="custitle"></param>
        /// <param name="m_where"></param>
        /// <param name="htmlTemp"></param>
        /// <returns></returns>
        public static string getjobapplicationlist(string top, string custitle, string m_where, string orderby, string htmlTemp)
        {
            StringBuilder sb = new StringBuilder();
            using (DataEntities ent = new DataEntities())
            {
                List<JobApplicationRecord> list = ent.CreateQuery<JobApplicationRecord>(string.Format("select VALUE t from JobApplicationRecord as t where {1} order by {2} limit {0}", top, m_where, orderby)).ToList();
                var qs = from a in list
                         from c in ent.JobCompany
                         from u in ent.User
                         from r in ent.JobResumeInfo
                         from p in ent.JobPost
                         where
                         a.UserID == u.ID
                         && a.ResumeID == r.ID
                         && a.PostID == p.ID
                         && a.CompanyID == c.ID
                         select new
                         {
                             a.ID,
                             u.UserName,
                             c.CompanyName,
                             p.Title,
                             rTitle = r.Title,
                             a.ApplicationTime,
                             a.CompanyID,
                             a.PostID,
                             a.ResumeID,
                             a.UserID
                         };
                var i = 0;
                foreach (var q in qs)
                {
                    i++;
                    string item = htmlTemp;
                    item = item.Replace("{applicationtime}", q.ApplicationTime.ToDateTime().ToString("yyyy-MM-dd"));
                    item = item.Replace("{companyid}", q.CompanyID.ToS());
                    item = item.Replace("{companyname}", q.CompanyName);
                    item = item.Replace("{id}", q.ID.ToS());
                    item = item.Replace("{postid}", q.PostID.ToS());
                    item = item.Replace("{resumeid}", q.ResumeID.ToS());
                    item = item.Replace("{rtitle}", q.rTitle);
                    item = item.Replace("{title}", q.Title);
                    item = item.Replace("{userid}", q.UserID.ToS());
                    item = item.Replace("{username}", q.UserName);
                    item = item.Replace("{index}", (i - 1).ToS());
                    sb.Append(item);
                }
                return sb.ToS();
            }
        }
        #endregion

        #region 获取公司列表
        /// <summary>
        /// 获取公司列表
        /// </summary>
        /// <param name="top"></param>
        /// <param name="custitle"></param>
        /// <param name="m_where"></param>
        /// <param name="orderby"></param>
        /// <param name="htmlTemp"></param>
        /// <returns></returns>
        public static string getcompanylist(string top, string custitle, string m_where, string orderby, string htmlTemp)
        {
            StringBuilder sb = new StringBuilder();
            using (DataEntities ent = new DataEntities())
            {
                List<JobCompany> list = ent.CreateQuery<JobCompany>(string.Format("select VALUE t from JobCompany as t where {1} order by {2} limit {0}", top, m_where, orderby)).ToList();

                var i = 0;
                foreach (var q in list)
                {
                    i++;
                    string item = htmlTemp;
                    item = item.Replace("{companyname}", custitle.ToInt32() > 0 ? q.CompanyName.CutString(custitle.ToInt32()) : q.CompanyName);
                    item = item.Replace("{fcompanyname}", q.CompanyName);
                    item = item.Replace("{companytype}", JobAction.GetCompanyTypeName(q.CompanyType.ToInt32()));
                    item = item.Replace("{employeecount}", JobAction.GetEmployeeCountName(q.EmployeeCount.ToInt32()));
                    item = item.Replace("{id}", q.ID.ToS());
                    item = item.Replace("{Industry}", JobAction.GetIndustryName(q.Industry.ToInt32()));
                    item = item.Replace("{intro}", q.Intro);
                    item = item.Replace("{userid}", q.UserID.ToS());
                    item = item.Replace("{dayclick}", q.DayClick.ToS());

                    item = item.Replace("{rownum}", i.ToS());
                    item = item.Replace("{index}", (i - 1).ToS());
                    sb.Append(item);
                }
                return sb.ToS();
            }
        }
        #endregion

        #region 获取行业列表
        /// <summary>
        /// 获取行业列表
        /// </summary>
        /// <param name="top"></param>
        /// <param name="custitle"></param>
        /// <param name="m_where"></param>
        /// <param name="orderby"></param>
        /// <param name="htmlTemp"></param>
        /// <returns></returns>
        public static string getindustrylist(string top, string custitle, string m_where, string orderby, string htmlTemp)
        {
            StringBuilder sb = new StringBuilder();
            using (DataEntities ent = new DataEntities())
            {
                List<JobIndustry> list = ent.CreateQuery<JobIndustry>(string.Format("select VALUE t from JobIndustry as t where {1} order by {2} limit {0}", top, m_where, orderby)).ToList();

                var i = 0;
                foreach (var q in list)
                {
                    i++;
                    string item = htmlTemp;
                    item = item.Replace("{id}", q.ID.ToS());
                    item = item.Replace("{name}", q.Name);
                    item = item.Replace("{parentid}", q.ParentID.ToS());
                    item = item.Replace("{isleaf}", q.IsLeaf.ToS());

                    item = item.Replace("{index}", (i - 1).ToS());
                    sb.Append(item);
                }
                return sb.ToS();
            }
        }
        #endregion

        #region 获取职位列表

        public static string getpostlist(string top, string custitle, string m_where, string orderby, string htmlTemp)
        {
            return getpostlistkip("0", top, custitle, m_where, orderby, htmlTemp);
        }

        /// <summary>
        /// 获取职位列表
        /// </summary>
        /// <param name="top"></param>
        /// <param name="custitle"></param>
        /// <param name="m_where"></param>
        /// <param name="orderby"></param>
        /// <param name="htmlTemp"></param>
        /// <returns></returns>
        public static string getpostlistkip(string skip, string top, string custitle, string m_where, string orderby, string htmlTemp)
        {
            StringBuilder sb = new StringBuilder();
            using (DataEntities ent = new DataEntities())
            {
                List<JobPost> list = ent.CreateQuery<JobPost>(string.Format("select VALUE t from JobPost as t where {0} order by {1} skip {2} limit {3}", m_where, orderby, skip, top)).ToList();
                List<JobCompany> coms = (from l in ent.JobCompany select l).ToList();

                var i = 0;
                foreach (var q in list)
                {
                    i++;

                    var com = coms.Where(p => p.ID == q.CompanyID).FirstOrDefault();

                    string item = htmlTemp;
                    item = item.Replace("{city}", JobAction.GetCityName(q.City.ToInt32()));
                    item = item.Replace("{companyid}", q.CompanyID.ToS());
                    item = item.Replace("{companyname}", com.CompanyName);
                    item = item.Replace("{employeecount}", JobAction.GetEmployeeCountName(com.EmployeeCount.ToInt32()));
                    item = item.Replace("{edu}", JobAction.GetEduName(q.Edu.ToInt32()));
                    item = item.Replace("{employeenumber}", q.EmployNumber == 0 ? "若干" : q.EmployNumber.ToS());
                    item = item.Replace("{expressions}", JobAction.GetExpressionsName(q.Expressions.ToInt32()));
                    item = item.Replace("{id}", q.ID.ToS());
                    item = item.Replace("{intro}", q.Intro);
                    item = item.Replace("{posttime}", q.PostTime.ToDateTime().ToString("yyyy-MM-dd"));
                    item = item.Replace("{province}", JobAction.GetProviceName(q.Province.ToInt32()));
                    item = item.Replace("{salary}", JobAction.GetSalaryDegreeName(q.Salary.ToInt32()));
                    item = item.Replace("{title}", q.Title);
                    item = item.Replace("{ftitle}", custitle.ToInt32() > 0 ? q.Title.CutString(custitle.ToInt32()) : q.Title);
                    item = item.Replace("{ext1}", q.GetPostEduAndNumber());
                    item = item.Replace("{postedu}", q.GetPostEdu());

                    item = item.Replace("{index}", (i - 1).ToS());
                    sb.Append(item);
                }
                return sb.ToS();
            }
        }
        #endregion

        #region 获取广告列表
        /// <summary>
        /// 获取广告列表
        /// </summary>
        /// <param name="top"></param>
        /// <param name="custitle"></param>
        /// <param name="m_where"></param>
        /// <param name="orderby"></param>
        /// <param name="htmlTemp"></param>
        /// <returns></returns>
        public string getadlist(string top, string custitle, string m_where, string orderby, string htmlTemp)
        {
            StringBuilder sb = new StringBuilder();
            using (DataEntities ent = new DataEntities())
            {
                var ads = ent.CreateQuery<Ad>(string.Format("select VALUE t from Ad as t where {1} order by {2} limit {0}", top, m_where, orderby)).ToList();
                var i = 0;
                foreach (var q in ads)
                {
                    i++;
                    string item = htmlTemp;

                    item = item.Replace("{id}", q.ID.ToS());
                    item = item.Replace("{title}", q.Title);
                    item = item.Replace("{groupid}", q.GroupID.ToS());
                    item = item.Replace("{image}", q.Image);
                    item = item.Replace("{url}", q.Url);

                    item = item.Replace("{rownum}", i.ToS());
                    item = item.Replace("{index}", (i - 1).ToS());
                    sb.Append(item);
                }

            }

            return sb.ToS();
        }
        #endregion

        #region 获取单个广告
        /// <summary>
        /// 获取单个广告
        /// </summary>
        /// <param name="id"></param>
        /// <param name="htmlTemp"></param>
        /// <returns></returns>
        public static string getad(string id, string htmlTemp)
        {
            long l_id = id.ToInt64();

            string item = htmlTemp;
            using (DataEntities ent = new DataEntities())
            {
                var q = (from l in ent.Ad where l.ID == l_id select l).FirstOrDefault();
                item = item.Replace("{id}", q.ID.ToS());
                item = item.Replace("{title}", q.Title);
                item = item.Replace("{groupid}", q.GroupID.ToS());
                item = item.Replace("{image}", q.Image);
                item = item.Replace("{url}", q.Url);
            }

            return item;

        }
        #endregion

        #region 书籍列表
        /// <summary>
        /// 书籍列表
        /// </summary>
        /// <param name="top"></param>
        /// <param name="custitle"></param>
        /// <param name="m_where"></param>
        /// <param name="orderby"></param>
        /// <param name="htmlTemp"></param>
        /// <returns></returns>
        public static string booklist(string top, string custitle, string m_where, string orderby, string htmlTemp)
        {
             StringBuilder sb = new StringBuilder();
             using (DataEntities ent = new DataEntities())
             {
                 
                 var list = ent.CreateQuery<Book>(string.Format("select VALUE t from Book as t where {0} order by {1} limit {2}",m_where,orderby,top));
                 var i = 0;
                 foreach (var q in list)
                 {
                     i++;
                     string item = htmlTemp;
                     item = item.Replace("{addtime}", q.Addtime.ToDateTime().ToString("yyyy-MM-dd"));
                     item=item.Replace("{author}",q.Author);
                     item=item.Replace("{classid}",q.ClassID.ToS());
                     item=item.Replace("{classname}",q.ClassName);
                     item=item.Replace("{clickcount}",q.ClickCount.ToS());
                     item=item.Replace("{corpusid}",q.CorpusID.ToS());
                     item=item.Replace("{corpustitle}",q.CorpusTitle);
                     item=item.Replace("{enable}",q.Enable.ToBoolean().ToChinese());
                     item=item.Replace("{faceimage}",q.FaceImage);
                     item=item.Replace("{id}",q.ID.ToS());
                     item=item.Replace("{intro}",q.Intro);
                     item=item.Replace("{isfirstpost}",q.IsFirstPost.ToBoolean().ToChinese());
                     item=item.Replace("{isvip}",q.IsVip.ToBoolean().ToChinese());
                     item=item.Replace("{lastchapterid}",q.LastChapterID.ToS());
                     item=item.Replace("{lastchaptertitle}",q.LastChapterTitle);
                     item=item.Replace("{lastvipchapterid}",q.LastVipChapterID.ToS());
                     item=item.Replace("{lastvipchaptertitle}",q.LastVipChapterTitle);
                     item=item.Replace("{length}",q.Length.ToS());
                     item=item.Replace("{replycount}",q.ReplyCount.ToS());
                     item=item.Replace("{savecount}",q.SaveCount.ToS());
                     item=item.Replace("{status}",q.Status==0?"连载中":"已完结");
                     item=item.Replace("{title}",q.Title);
                     item=item.Replace("{tjcount}",q.TjCount.ToS());
                     item=item.Replace("{updatetime}",q.UpdateTime.ToDateTime().ToString("yyyy-MM-dd"));
                     item=item.Replace("{vipupdatetime}",q.VipUpdateTime.ToDateTime().ToString("yyyy-MM-dd"));
                     item=item.Replace("{ztid}",q.ZtID.ToS());
                     item=item.Replace("{ztname}",q.ZtName);
                     item=item.Replace("{title}",q.Title);
                     item=item.Replace("{url}",BasePage.GetBookUrl(q,q.GetClass()));
                     item = item.Replace("{ftitle}", custitle.ToInt32() > 0 ? q.Title.CutString(custitle.ToInt32()) : q.Title);
                     item = item.Replace("{index}", (i - 1).ToS());
                     item = item.Replace("{rownum}", (i).ToS());
                     sb.Append(item);
                 }
             }
             return sb.ToS();
        }
        #endregion 

        #region 首页底部地区树
        /// <summary>
        /// 首页底部地区树
        /// </summary>
        /// <param name="ss"></param>
        /// <returns></returns>
        public static string getindexbottomareas(string ss)
        {
            StringBuilder sb = new StringBuilder();
            DataEntities ent = new DataEntities();
            var areas = (from l in ent.Area where l.ShowInIndex == true select l).ToList();
            var ps = (from l in ent.Province where l.ShowInIndex == true select l).ToList();
            var cs = (from l in ent.City where l.ShowInIndex == true select l).ToList();

            ent.Dispose();

            foreach (var area in areas)
            {
                sb.AppendLine("<li>");
                sb.AppendFormat("<span class=\"fl\"><b>{0}：</b></span>", area.Name);

                var subps = from l in ps where l.AreaID == area.ID select l;
                foreach (var subp in subps)
                {
                    sb.AppendFormat("<a href=\"Search.aspx?l={0}\" target=\"_blank\">{0}</a>", subp.province1);

                    var subcs = from l in cs where l.ProvinceID == subp.ID select l;
                    if (subcs.Count() > 0)
                    {
                        sb.Append("(");
                    }
                    foreach (var subc in subcs)
                    {
                        sb.AppendFormat("<a href=\"Search.aspx?l={0}\" target=\"_blank\">{0}</a>", subc.city1);
                    }
                    if (subcs.Count() > 0)
                    {
                        sb.Append(")");
                    }
                }

                sb.AppendLine("</li>");
            }
            return sb.ToS();
        }
        #endregion
    }
}
