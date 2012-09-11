using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Text.RegularExpressions;

using Voodoo;
using Voodoo.Model;
using Voodoo.DAL;
using Voodoo.Net;
using Voodoo.Basement;
using Voodoo.Basement.Collect;
using System.IO;


namespace Web.e.tool
{
    public partial class MovieCollector : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Buffer = false;
            Js.ScrollEnd();

            #region 注释 
            //获取所有电影的概况

            //Response.Buffer = false;
            //Js.ScrollEnd();

            //#region 打开列表页面
            //Response.Write(string.Format("打开列表页面获得书籍信息<br />"));
            //Js.ScrollEndStart();

            //var Movies = GetAllMovies("utf-8",
            //    "http://kuaib.tv.sohu.com/html/more_list31.htm",
            //    "<a href='(?<key>[^<>]*?)'>下一页</a>",
            //    "<div class=\"vInfo\">[\\s]*?<div class=\"vPic\">[\\s\\S]*?<img src=\"(?<image>.*?)\".*?/>[\\s\\S]*?<div class=\"vTxt\">[\\s]*?<h4>[\\s]*?<a href=\"(?<url>.*?)\" target=\"_blank\">(?<title>.*?)</a>[\\s\\S]*?<p>主演：<font class=\"highlight\"></font>(?<actors>.*?)</p>[\\s\\S]*?<p>导演：<font class=\"highlight\"></font>(?<director>.*?)</p>[\\S\\s]*?<dd>年份：<a.*?>(?<publicyear>.*?)</a></dd>[\\s\\S]*?<p class=\"detail\".*?>(?<intro>[\\s\\S]*?)<a href=\"",

            //    false);
            //#endregion

            //#region 补充电影的详细内容 剧集

            //Response.Write(string.Format("获取影视详细内容<br />"));
            //Js.ScrollEndStart();

            //var NewMovies = new List<MovieInfo>();
            //foreach (var m in Movies)
            //{
            //    var nm = GetMovieInfo("utf-8",
            //        m,
            //        "<div id=\"introID\">[\\s]*?<p>(?<intro>.*?)</p>[\\s\\S]*?var VRS_AREA=\"(?<location>.*?)\";",
            //        "<div class=\"pList clear\" id=\"playContF\">(?<key>[\\s\\S]*?)</div>",
            //        "",
            //        "<li.*?><a target=\"_self\" href=\"javascript:\" onclick=\".*?\" >(?<title>.*?)</a></li>[\\s]*?<input type=\"hidden\" id='.*?' value=\"(?<url>.*?)\" />",
            //        "");
            //    NewMovies.Add(nm);
            //}

            //Movies = NewMovies;

            //#endregion

            //#region 补充带单集播放页面的资源URL


            //#endregion

            //#region 补充资源URL单独存放的单集信息

            //#endregion

            //#region 保存

            //foreach (var m in Movies)
            //{
            //    SaveMovie(m, false,"搜狐");
            //}

            //#endregion
            #endregion

            FileInfo[] files = new DirectoryInfo(Server.MapPath("~/Config/MovieRule")).GetFiles();
            foreach (var file in files)
            {
                try
                {
                    MovieRule r = (MovieRule)Voodoo.IO.XML.DeSerialize(typeof(MovieRule), Voodoo.IO.File.Read(file.FullName));
                    CollectByRule(r);
                }
                catch(Exception ex)
                {
                    Response.Write(ex.Message);
                }
            }

        }

        #region 旧的电影采集
        /// <summary>
        /// 旧的电影采集
        /// </summary>
        protected void OldCollect()
        {
            Response.Buffer = false;


            //打开列表页面
            Response.Write("打开列表页面<br/>");
            string listUrl = "http://kuaib.tv.sohu.com/html/more_list21.htm";

        openurl:
            string html_List = Url.GetHtml(listUrl, "utf-8");

            //打开信息页面
            Match m_list = html_List.GetMatchGroup("<img src=\"(?<image>.*?)\" width=\"120\" height=\"165\" alt=\"\" />[\\s\\S]*?<h4><a href=\"(?<url>.*?)\" target=\"_blank\">(?<title>.*?)</a></h4>");
            while (m_list.Success)
            {
                //判断是否存在
                if (MovieInfoView.Exist(string.Format("Title=N'{0}'", m_list.Groups["title"].Value)))
                {
                    m_list = m_list.NextMatch();
                    continue;
                }

                Response.Write("下载封面<br/>");
                //如果不存在，则先下载封面，内容页面是没有封面的
                try
                {
                    Url.DownFile(m_list.Groups["image"].Value, Server.MapPath("~/config/movieface.jpg"));
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message + "<br/>");
                }
                //打开内容页面
                Response.Write("打开内容页面<br/>");
                string html_content = Url.GetHtml(m_list.Groups["url"].Value, "utf-8");
                Match m_movie = html_content.GetMatchGroup("<em id='specialID'>《(?<title>.*?)》</em>[\\s\\S]*?<param name='URL' value='(?<url>.*?)'>[\\s\\S]*?<div id=\"introID\">[\\s]*?<p>(?<intro>[\\s\\S]*?)</p>[\\s\\S]*?var VRS_DIRECTOR=\"(?<director>.*?)\";[\\s\\S]*?var VRS_CATEGORY=\"(?<tags>.*?)\";[\\s\\S]*?var VRS_ACTOR=\"(?<actor>.*?)\";[\\s\\S]*?var VRS_AREA=\"(?<location>.*?)\";[\\s\\S]*?var VRS_PLAY_YEAR=\"(?<year>.*?)\";");
                if (!m_movie.Success)
                {
                    Response.Write("!!!!!内容匹配失败<br/>");
                }
                string title = m_movie.Groups["title"].Value;
                string intro = m_movie.Groups["intro"].Value;
                string director = m_movie.Groups["director"].Value;
                string actor = m_movie.Groups["actor"].Value;
                string location = m_movie.Groups["location"].Value;
                string url = m_movie.Groups["url"].Value;
                string year = m_movie.Groups["year"].Value;
                string tags = m_movie.Groups["tags"].Value;

                Response.Write("处理类别:" + location + "<br/>");
                Class cls = ClassView.Find(string.Format("classname=N'{0}'", location));
                if (cls.ID <= 0)
                {
                    cls.Alter = location;
                    cls.ClassKeywords = location + "在线观看";
                    cls.ClassName = location;
                    cls.IsLeafClass = true;
                    cls.ShowInNav = true;
                    cls.ClassForder = location;
                    cls.ModelID = 6;

                    ClassView.Insert(cls);
                }

                MovieInfo mv = new MovieInfo();
                mv.Actors = actor;
                mv.ClassID = cls.ID;
                mv.ClassName = cls.ClassName;
                mv.ClickCount = 0;
                mv.Director = director;
                mv.Enable = true;
                mv.InsertTime = DateTime.Now;
                mv.Intro = intro;
                mv.IsMove = true;
                mv.Location = location;
                mv.PublicYear = year;
                mv.ReplyCount = 0;
                mv.ScoreAvg = 10;
                mv.ScoreTime = 0;
                mv.Status = 1;
                mv.Tags = tags;
                mv.Title = title;
                mv.TjCount = 0;
                mv.UpdateTime = DateTime.Now;

                Response.Write("保存:" + title + "<br/>");
                MovieInfoView.Insert(mv);

                //设置封面
                Response.Write("设置封面<br/>");
                mv.FaceImage = string.Format("/u/MoviekFace/{0}.jpg", mv.Id);
                try
                {
                    Voodoo.IO.File.Move(Server.MapPath("~/config/movieface.jpg"), Server.MapPath(mv.FaceImage));
                }
                catch
                {
                    Voodoo.IO.File.Copy(Server.MapPath("~/config/0.jpg"), Server.MapPath(mv.FaceImage));
                }

                MovieInfoView.Update(mv);

                //添加地址
                Response.Write("添加地址:" + url + "<br/>");
                MovieUrlKuaib mk = new MovieUrlKuaib();
                mk.Enable = true;
                mk.MovieID = mv.Id;
                mk.MovieTitle = mv.Title;
                mk.Title = "全集";
                mk.UpdateTime = DateTime.Now;
                mk.Url = url;
                MovieUrlKuaibView.Insert(mk);

                //生成
                Response.Write("生成<br/>");
                //CreatePage.CreateDramapage(mk,cls);

                //CreatePage.CreateContentPage(mv,cls);

                //CreatePage.CreateListPage(cls,0);

                //CreatePage.GreateIndexPage();

                Response.Write(title + "-完成<br/><br/><br/>");

                m_list = m_list.NextMatch();
            }

            //处理列表下一页

            Match m_next = html_List.GetMatchGroup("<a href='(?<key>[^'/]*?)'>下一页</a>");
            if (m_next.Success)
            {
                listUrl = m_next.Groups["key"].Value.AppendToDomain(listUrl);
                goto openurl;
            }

        }
        #endregion

        #region 获取所有剧集的信息
        /// <summary>
        /// 获取所有剧集的信息
        /// </summary>
        /// <param name="Encoding">编码</param>
        /// <param name="ListPageUrl">列表地址</param>
        /// <param name="NextUrlRule">下一页规则</param>
        /// <param name="InfoRule">信息规则</param>
        /// <returns></returns>
        protected List<MovieInfo> GetAllMovies(string Encoding, string ListPageUrl, string NextUrlRule, string InfoRule, bool IsMovie)
        {
            List<MovieInfo> result = new List<MovieInfo>();

        OpenListPage:
            Response.Write(string.Format("正在打开列表:{0}<br />",ListPageUrl));
        Js.ScrollEndStart();
            string listHtml = Url.GetHtml(ListPageUrl, Encoding);
            Match match_moviesinfo = listHtml.GetMatchGroup(InfoRule);
            while (match_moviesinfo.Success)
            {
                result.Add(new MovieInfo()
                {
                    Actors = match_moviesinfo.Groups["actors"].Value,
                    ClassName = match_moviesinfo.Groups["class"].Value,
                    Director = match_moviesinfo.Groups["director"].Value,
                    FaceImage = match_moviesinfo.Groups["image"].Value.AppendToDomain(ListPageUrl),
                    Intro = match_moviesinfo.Groups["intro"].Value,
                    Location = match_moviesinfo.Groups["location"].Value,
                    PublicYear = match_moviesinfo.Groups["publicyear"].Value,
                    Tags = match_moviesinfo.Groups["tags"].Value,
                    Title = match_moviesinfo.Groups["title"].Value,
                    Url = match_moviesinfo.Groups["url"].Value.AppendToDomain(ListPageUrl),
                    IsMove = IsMovie
                });

                match_moviesinfo = match_moviesinfo.NextMatch();
            }

            if (Regex.IsMatch(listHtml, NextUrlRule))
            {
                //需要key参数
                ListPageUrl = listHtml.GetMatch(NextUrlRule)[0].AppendToDomain(ListPageUrl);
                goto OpenListPage;
            }


            return result;
        }
        #endregion

        #region 获取单个剧集的详细信息
        /// <summary>
        /// 获取单个剧集的详细信息
        /// </summary>
        /// <param name="Encoding">编码</param>
        /// <param name="mv">剧集的大概信息</param>
        /// <param name="InfoRule">剧集信息规则</param>
        /// <param name="KuaibAreaRule">快播区域规则</param>
        /// <param name="BaiduAreaRule">百度影音区域规则</param>
        /// <param name="KuaibDramaRule">快播单集规则</param>
        /// <param name="BaiduDramaRule">百度影音单集规则</param>
        /// <returns></returns>
        protected MovieInfo GetMovieInfo(string Encoding, MovieInfo mv, string InfoRule, string KuaibAreaRule, string BaiduAreaRule, string KuaibDramaRule, string BaiduDramaRule)
        {
            Response.Write(string.Format("打开信息页面：{0}<br />", mv.Title));
            Js.ScrollEndStart();
            string html = Url.GetHtml(mv.Url, Encoding);
            mv.Html = html;
            Match m_info = html.GetMatchGroup(InfoRule);
            if (m_info.Success)
            {
                //开始获取信息
                mv.Actors = mv.Actors.IsNull(m_info.Groups["actors"].Value);
                mv.ClassName = mv.ClassName.IsNull(m_info.Groups["class"].Value);
                mv.Director = mv.Director.IsNull(m_info.Groups["director"].Value);
                mv.Enable = true;
                mv.FaceImage = mv.FaceImage.IsNull(m_info.Groups["image"].Value);
                mv.Intro = mv.Intro.IsNull(m_info.Groups["intro"].Value);
                mv.Location = mv.Location.IsNull(m_info.Groups["location"].Value);
                mv.PublicYear = mv.PublicYear.IsNull(m_info.Groups["publicyear"].Value);
                mv.Tags = mv.Tags.IsNull(m_info.Groups["tags"].Value);
                mv.Title = mv.Title.IsNull(m_info.Groups["title"].Value);
            }
            else
            {
                throw new Exception("电影信息匹配失败！");
            }
            mv.KuaiboDramas = new List<MovieDrama>();
            mv.BaiduDramas = new List<MovieDrama>();

            #region 获取快播剧集地址
            Match m_kuaiboArea = html.GetMatchGroup(KuaibAreaRule);
            if (m_kuaiboArea.Success && KuaibAreaRule.IsNullOrEmpty() == false)
            {
                Match m_drama = m_kuaiboArea.Groups[1].Value.GetMatchGroup(KuaibDramaRule);
                while (m_drama.Success)
                {
                    mv.KuaiboDramas.Add(new MovieDrama()
                    {
                        Title = m_drama.Groups["title"].Value,
                        PlayUrl = m_drama.Groups["playurl"].Value,
                        Url = m_drama.Groups["url"].Value

                    });
                    m_drama = m_drama.NextMatch();
                }
            }
            #endregion

            #region 获取百度影音剧集地址
            Match m_baiduArea = html.GetMatchGroup(BaiduAreaRule);
            if (m_baiduArea.Success && BaiduAreaRule.IsNullOrEmpty() == false)
            {
                Match m_drama = m_kuaiboArea.Groups[1].Value.GetMatchGroup(BaiduDramaRule);
                while (m_drama.Success)
                {
                    mv.BaiduDramas.Add(new MovieDrama()
                    {
                        Title = m_drama.Groups["title"].Value,
                        PlayUrl = m_drama.Groups["playurl"].Value,
                        Url = m_drama.Groups["url"].Value

                    });
                    m_drama = m_drama.NextMatch();
                }
            }
            #endregion

            return mv;

        }

        #endregion

        #region 获取单集资源地址
        protected MovieInfo GetMovieDrama(string Encoding, MovieInfo mv, string BaiduUrlRule, string KuaibUrlRule)
        {
            #region 获取百度Url
            foreach (var drama in mv.BaiduDramas)
            {
                Response.Write(string.Format("获取百度URL:{0}<br />", drama.Title));
                Js.ScrollEndStart();

                if (drama.Url.IsNullOrEmpty() == false)
                {
                    continue;
                }
                else
                {
                    string html = Url.GetHtml(drama.PlayUrl, Encoding);
                    Match m_url = html.GetMatchGroup(BaiduUrlRule);
                    if (m_url.Success)
                    {
                        drama.Url = m_url.Groups["url"].Value;
                        drama.SourceDataUrl = m_url.Groups["source"].Value.AppendToDomain(drama.Url);
                    }
                }

            }
            #endregion

            #region 获取快播Url
            foreach (var drama in mv.KuaiboDramas)
            {
                Response.Write(string.Format("获取快播URL:{0}<br />", drama.Title));
                Js.ScrollEndStart();

                if (drama.Url.IsNullOrEmpty() == false)
                {
                    continue;
                }
                else
                {
                    string html = Url.GetHtml(drama.PlayUrl, Encoding);
                    Match m_url = html.GetMatchGroup(KuaibUrlRule);
                    if (m_url.Success)
                    {
                        drama.Url = m_url.Groups["url"].Value;
                        drama.SourceDataUrl = m_url.Groups["source"].Value.AppendToDomain(drama.Url);
                    }
                }
            }
            #endregion


            return mv;
        }

        #endregion

        #region 获取资源URL单独存放的资源
        /// <summary>
        /// 获取资源URL单独存放的资源
        /// </summary>
        /// <param name="Encoding"></param>
        /// <param name="mv"></param>
        /// <param name="BaiduUrlRule"></param>
        /// <param name="KuaiboUrlRule"></param>
        /// <param name="UrlEncoding"></param>
        /// <returns></returns>
        protected MovieInfo GetMovieSource(string Encoding, MovieInfo mv, string BaiduUrlRule, string KuaiboUrlRule)
        {
            foreach (var drama in mv.KuaiboDramas)
            {
                Response.Write(string.Format("打开资源脚本:{0}<br />", drama.Title));
                Js.ScrollEndStart();

                string html = Url.GetHtml(drama.SourceDataUrl, Encoding);
                Match m_source = html.GetMatchGroup(KuaiboUrlRule);
                if (m_source.Success)
                {
                    Response.Write(string.Format("成功！:-D<br />"));
                    Js.ScrollEndStart();
                    drama.Url = m_source.Groups[1].Value.UrlDecode(System.Text.Encoding.Unicode);
                }
            }
            foreach (var drama in mv.BaiduDramas)
            {
                Response.Write(string.Format("打开资源脚本:{0}<br />", drama.Title));
                Js.ScrollEndStart();
                string html = Url.GetHtml(drama.SourceDataUrl, Encoding);
                Match m_source = html.GetMatchGroup(BaiduUrlRule);
                if (m_source.Success)
                {
                    Response.Write(string.Format("成功！:-D<br />"));
                    Js.ScrollEndStart();
                    drama.Url = m_source.Groups[1].Value.UrlDecode(System.Text.Encoding.Unicode);
                }
            }

            return mv;
        }
        #endregion

        #region 保存影视信息
        /// <summary>
        /// 保存影视信息
        /// </summary>
        /// <param name="mv"></param>
        protected void SaveMovie(MovieInfo mv, bool IsSearchRule, string SiteName)
        {
            #region 处理分类
            Class cls = ClassView.Find(string.Format("ClassName=N'{0}'", mv.ClassName));
            if (cls.ID <= 0)
            {
                cls.IsLeafClass = true;
                cls.Alter = mv.ClassName;
                cls.ClassForder = mv.ClassName;
                cls.ShowInNav = true;
                cls.ParentID = 0;
                cls.ClassName = mv.ClassName;
                cls.ModelID = 6;

                ClassView.Insert(cls);
            }
            mv.ClassID = cls.ID;
            #endregion

            #region 保存影视
            MovieInfo sysMv = MovieInfoView.Find(string.Format("Title=N'{0}' and ClassName=N'{1}'", mv.Title, mv.ClassName));
            if (sysMv.Id <= 0)
            {
                sysMv = mv;
                sysMv.ClickCount = 0;
                sysMv.Enable = true;
                sysMv.InsertTime = DateTime.UtcNow.AddHours(8);
                sysMv.ReplyCount = 0;
                sysMv.ScoreAvg = 10;
                sysMv.ScoreTime = 0;//评分次数
                sysMv.Status = 0;
                sysMv.TjCount = 0;
                sysMv.UpdateTime = DateTime.UtcNow.AddHours(8);

                MovieInfoView.Insert(sysMv);
            }
            else
            {
                sysMv.BaiduDramas = mv.BaiduDramas;
                sysMv.KuaiboDramas = mv.KuaiboDramas;
            }
            #endregion

            #region 下载封面
            try
            {
                Url.DownFile(sysMv.FaceImage, Server.MapPath(string.Format("~/u/MoviekFace/{0}.jpg", sysMv.Id)));
                sysMv.FaceImage = string.Format("/u/MoviekFace/{0}.jpg", sysMv.Id);

            }
            catch
            {
                sysMv.FaceImage = "/u/MoviekFace/0.jpg";
            }

            MovieInfoView.Update(sysMv);
            #endregion

            #region 保存单集资源
            if (IsSearchRule == false)
            {
                #region 不是电影搜索
                foreach (var drama in sysMv.BaiduDramas)
                {
                    var sysDrama = MovieUrlBaiduView.Find(string.Format("MovieID={0} and Title=M'{0}' ", sysMv.Id, drama.Title));
                    if (sysDrama.Id <= 0)
                    {
                        sysDrama.Title = drama.Title;
                        sysDrama.Url = drama.Url;

                        sysDrama.Enable = true;
                        sysDrama.MovieID = sysMv.Id;
                        sysDrama.MovieTitle = sysMv.Title;
                        sysDrama.UpdateTime = DateTime.UtcNow.AddHours(8);

                        MovieUrlBaiduView.Insert(sysDrama);

                        sysMv.LastDramaTitle = sysDrama.Title;
                        sysMv.LastDramaID = sysDrama.Id;
                        MovieInfoView.Update(sysMv);

                        CreatePage.CreateDramapage(sysDrama, cls);//生成

                        Response.Write(string.Format("百度影音《{0}》《{1}》保存成功！:-D<br />", sysDrama.MovieTitle, sysDrama.Title));
                    }
                    else
                    {
                        Response.Write(string.Format("已经存在%>_<%<br />"));
                    }
                }

                foreach (var drama in sysMv.KuaiboDramas)
                {
                    var sysDrama = MovieUrlKuaibView.Find(string.Format("MovieID={0} and Title=N'{0}' ", sysMv.Id, drama.Title));
                    if (sysDrama.Id <= 0)
                    {
                        sysDrama.Title = drama.Title;
                        sysDrama.Url = drama.Url;

                        sysDrama.Enable = true;
                        sysDrama.MovieID = sysMv.Id;
                        sysDrama.MovieTitle = sysMv.Title;
                        sysDrama.UpdateTime = DateTime.UtcNow.AddHours(8);

                        MovieUrlKuaibView.Insert(sysDrama);

                        sysMv.LastDramaTitle = sysDrama.Title;
                        sysMv.LastDramaID = sysDrama.Id;
                        MovieInfoView.Update(sysMv);

                        CreatePage.CreateDramapage(sysDrama, cls);

                        Response.Write(string.Format("快播《{0}》《{1}》保存成功！:-D<br />", sysDrama.MovieTitle, sysDrama.Title));
                    }
                    else
                    {
                        Response.Write(string.Format("已经存在%>_<%<br />"));
                    }
                }
                #endregion
            }
            else
            {
                //电影搜索不需要保存资源地址 只需要保存 新建剧集和播放页面地址
                #region 快播地址
                foreach (var drama in mv.KuaiboDramas)
                {
                    var sysDrama = MovieDramaView.Find(string.Format("MovieTitle=N'{0}' and Title=N'{1}'", drama.MovieTitle, drama.Title));
                    if (sysDrama.Id <= 0)
                    {
                        sysDrama.Enable = true;
                        sysDrama.MovieID = mv.Id;
                        sysDrama.MovieTitle = mv.Title;
                        sysDrama.Title = drama.Title;
                        sysDrama.UpdateTime = DateTime.UtcNow.AddHours(8);
                        MovieDramaView.Insert(sysDrama);
                    }

                    var sysUrl = MovieDramaUrlView.Find(string.Format("MovieID={0} and MovieDramaID={1} and SourceSite=N'{2}'", drama.MovieID, drama.Id, SiteName));
                    if (sysUrl.Id <= 0)
                    {
                        sysUrl.Enable = true;
                        sysUrl.MovieDramaID = drama.Id;
                        sysUrl.MovieDramaTitle = drama.Title;
                        sysUrl.MovieID = mv.Id;
                        sysUrl.MovieTitle = mv.Title;
                        sysUrl.SourceSite = SiteName;
                        sysUrl.Title = drama.Title;
                        sysUrl.UpdateTime = DateTime.UtcNow.AddHours(8);
                        sysUrl.Url = drama.PlayUrl.IsNull(mv.Url);
                    }
                }
                #endregion

                #region 百度影音

                foreach (var drama in mv.BaiduDramas)
                {
                    var sysDrama = MovieDramaView.Find(string.Format("MovieTitle=N'{0}' and Title=N'{1}'", drama.MovieTitle, drama.Title));
                    if (sysDrama.Id <= 0)
                    {
                        sysDrama.Enable = true;
                        sysDrama.MovieID = mv.Id;
                        sysDrama.MovieTitle = mv.Title;
                        sysDrama.Title = drama.Title;
                        sysDrama.UpdateTime = DateTime.UtcNow.AddHours(8);
                        MovieDramaView.Insert(sysDrama);
                    }

                    var sysUrl = MovieDramaUrlView.Find(string.Format("MovieID={0} and MovieDramaID={1} and SourceSite=N'{2}'", drama.MovieID, drama.Id, SiteName));
                    if (sysUrl.Id <= 0)
                    {
                        sysUrl.Enable = true;
                        sysUrl.MovieDramaID = drama.Id;
                        sysUrl.MovieDramaTitle = drama.Title;
                        sysUrl.MovieID = mv.Id;
                        sysUrl.MovieTitle = mv.Title;
                        sysUrl.SourceSite = SiteName;
                        sysUrl.Title = drama.Title;
                        sysUrl.UpdateTime = DateTime.UtcNow.AddHours(8);
                        sysUrl.Url = drama.PlayUrl.IsNull(mv.Url);
                    }
                }

                #endregion
            }


            #endregion

            #region 生成

            Response.Write(string.Format("生成《{0}》信息页<br />", sysMv.Title));
            CreatePage.CreateContentPage(sysMv, cls);

            Response.Write(string.Format("生成“{0}”分类<br />", cls.ClassName));
            CreatePage.CreateListPage(cls, 1);

            #endregion


        }
        #endregion 保存影视信息


        #region  根据采集规则采集
        /// <summary>
        /// 根据采集规则采集
        /// </summary>
        /// <param name="r">规则</param>
        protected void CollectByRule(MovieRule r)
        {
            Response.Buffer = false;
            Js.ScrollEnd();

            #region 打开列表页面
            Response.Write(string.Format("打开列表页面获得书籍信息<br />"));
            Js.ScrollEndStart();

            var Movies = GetAllMovies(r.Encoding,
                r.ListPageUrl,
                r.NextListRule,
                r.ListInfoRule,
                false);
            #endregion

            #region 补充电影的详细内容 剧集

            Response.Write(string.Format("获取影视详细内容<br />"));
            Js.ScrollEndStart();

            var NewMovies = new List<MovieInfo>();
            foreach (var m in Movies)
            {
                var nm = GetMovieInfo(r.Encoding,
                    m,
                    r.InfoRule,
                    r.KuaibAreaRule,
                    r.BaiduAreaRule,
                    r.KuaibDramaRule,
                    r.BaiduDramaRule);
                NewMovies.Add(nm);
            }

            Movies = NewMovies;

            #endregion

            #region 补充带单集播放页面的资源URL
            NewMovies = new List<MovieInfo>();
            foreach (var m in Movies)
            {
                if (r.IsSearchRule)
                {
                    break;//搜索系统不需要采集剧集信息
                }
                var nm = GetMovieDrama(r.Encoding, m, r.DramaPageBaiduRule, r.DramaPageKuaibRule);
                NewMovies.Add(nm);
            }

            Movies = NewMovies;

            #endregion

            #region 补充资源URL单独存放的单集信息
            NewMovies = new List<MovieInfo>();
            foreach (var m in Movies)
            {
                if (r.IsSearchRule)
                {
                    break;//搜索系统不需要采集剧集信息
                }
                var nm = GetMovieSource(r.Encoding, m, r.SourceBaiduRule, r.SourceKuaibRule);
                NewMovies.Add(nm);
            }

            Movies = NewMovies;
            #endregion

            #region 处理默认的分类信息
            NewMovies = new List<MovieInfo>();
            foreach (var m in Movies)
            {
                if (m.ClassName.IsNullOrEmpty())
                {
                    if (r.UseTagAsClass)
                    {
                        m.ClassName = m.Tags;
                    }
                    if (r.UseLocationAsClass)
                    {
                        m.ClassName = m.Location;
                    }
                    if (m.ClassName.IsNullOrEmpty())
                    {
                        m.ClassName = r.DefaultClass;
                    }
                }
                m.IsMove = r.IsMovie;

                NewMovies.Add(m);
            }

            Movies = NewMovies;

            #endregion

            #region 保存
            foreach (var m in Movies)
            {
                SaveMovie(m, r.IsSearchRule,r.SiteName);
            }
            #endregion
        }
        #endregion

    }


}