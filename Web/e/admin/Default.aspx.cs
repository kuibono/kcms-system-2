using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

using System.Web.UI.WebControls;
using Panel = Ext.Net.Panel;
using Ext.Net;

using Voodoo;
using Voodoo.Data;
using Voodoo.Basement;
using Voodoo.Setting;

namespace Web.e.admin
{
    public partial class Default : AdminBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadFrame();

        }

        /// <summary>
        /// 加载窗体框架
        /// </summary>
        protected void LoadFrame()
        {
            //////////////////
            // NORTH REGION //
            //////////////////

            // Make Panel for South Region
            Panel north = new Panel();
            north.ID = "NorthPanel";
            //north.Title = "North";
            north.Height = Unit.Pixel(53);
            north.BodyStyle = "padding:0px;";
            north.Html = "<div id='northPn'><img src='../data/images/cms_logo.png' style='height:53px' /><span id='loginInfoSp'>用户：" + SysUserAction.LocalUser.UserName + "  [<a href='logout.aspx'>退出]</a></span></div>";
            north.Collapsible = false;


            /////////////////
            // WEST REGION //
            /////////////////

            // Make Panel for West Region
            Panel west = new Panel();
            west.ID = "WestPanel";
            west.Title = "导航";
            west.Width = Unit.Pixel(225);


            #region 系统设置
            TreePanel Tree_Sys = new TreePanel();
            Tree_Sys.ID = "t_Sys";
            Tree_Sys.Title = "系统管理";
            Tree_Sys.Icon = Icon.Vcard;
            Tree_Sys.AutoScroll = true;

            Ext.Net.TreeNode _root_sys = new Ext.Net.TreeNode("系统设置");
            _root_sys.Expanded = true;
            //-----------------------------------系统参数-----------------------------------------------//
            Ext.Net.TreeNode root_sys = new Ext.Net.TreeNode("系统参数", Icon.Cog);
            root_sys.Expanded = true;

            Ext.Net.TreeNode n_sys_base = new Ext.Net.TreeNode("基本参数", Icon.CogGo);
            n_sys_base.Listeners.Click.Handler = "openpage('system/SystemParameter/basic.aspx')";
            root_sys.Nodes.Add(n_sys_base);

            Ext.Net.TreeNode n_sys_user = new Ext.Net.TreeNode("用户参数", Icon.UserSuitBlack);
            n_sys_user.Listeners.Click.Handler = "openpage('system/SystemParameter/user.aspx')";
            root_sys.Nodes.Add(n_sys_user);

            Ext.Net.TreeNode n_sys_ftp = new Ext.Net.TreeNode("FTP参数", Icon.ComputerOff);
            root_sys.Nodes.Add(n_sys_ftp);

            Ext.Net.TreeNode n_sys_mail = new Ext.Net.TreeNode("Mail参数", Icon.Mail);
            root_sys.Nodes.Add(n_sys_mail);


            _root_sys.Nodes.Add(root_sys);
            //-----------------------------------系统参数-----------------------------------------------//



            //-----------------------------------数据更新-----------------------------------------------//
            Ext.Net.TreeNode root_dataupdate = new Ext.Net.TreeNode("数据更新", Icon.Database);
            //root_dataupdate.Expanded = true;

            Ext.Net.TreeNode n_du_uc = new Ext.Net.TreeNode("数据更新中心", Icon.DatabaseRefresh);
            n_du_uc.Listeners.Click.Handler = "openpage('system/Update/Createpages.aspx')";
            root_dataupdate.Nodes.Add(n_du_uc);

            Ext.Net.TreeNode n_du_ftp = new Ext.Net.TreeNode("远程发布中心", Icon.ServerLightning);
            root_dataupdate.Nodes.Add(n_du_ftp);

            _root_sys.Nodes.Add(root_dataupdate);
            //-----------------------------------数据更新-----------------------------------------------//


            Ext.Net.TreeNode friend_link = new Ext.Net.TreeNode("友情链接", Icon.UserBrown);
            friend_link.Listeners.Click.Handler = "openpage('system/friendlink/LinkList.aspx')";
            _root_sys.Nodes.Add(friend_link);

            Ext.Net.TreeNode file_manager = new Ext.Net.TreeNode("文件管理", Icon.MonitorEdit);
            file_manager.Listeners.Click.Handler = "openpage('system/Basement/FileManagement.aspx')";
            _root_sys.Nodes.Add(file_manager);

            Ext.Net.TreeNode info_collect = new Ext.Net.TreeNode("采集管理", Icon.MonitorEdit);

            Ext.Net.TreeNode movie_collect = new Ext.Net.TreeNode("<a href=\"javascript:void(0)\" onclick=\"openpage('/e/tool/MovieCollect.htm')\">电影采集</a>|<a href=\"javascript:void(0)\" onclick=\"openpage('/e/tool/MovieRules.aspx')\">规则</a>", Icon.MonitorAdd);
            info_collect.Nodes.Add(movie_collect);

            _root_sys.Nodes.Add(info_collect);

            Tree_Sys.Root.Add(_root_sys);//树根加进去
            #endregion

            #region 模板
            TreePanel Tree_Model = new TreePanel();
            Tree_Model.ID = "t_Model";
            Tree_Model.Title = "模版管理";
            Tree_Model.Icon = Icon.Money;
            Tree_Model.AutoScroll = true;

            Ext.Net.TreeNode root_model = new Ext.Net.TreeNode("模版", Icon.Page);
            root_model.Expanded = true;

            //-----------------------------------封面模版-----------------------------------------------//
            Ext.Net.TreeNode n_model_face = new Ext.Net.TreeNode("封面模版", Icon.Book);
            root_model.Nodes.Add(n_model_face);
            //-----------------------------------封面模版-----------------------------------------------//

            //-----------------------------------列表模版-----------------------------------------------//
            Ext.Net.TreeNode n_model_list = new Ext.Net.TreeNode("列表模版", Icon.Outline);
            n_model_list.Listeners.Click.Handler = "openpage('template/ListTemplateList.aspx')";
            root_model.Nodes.Add(n_model_list);
            //-----------------------------------列表模版-----------------------------------------------//

            //-----------------------------------内容模版-----------------------------------------------//
            Ext.Net.TreeNode n_model_content = new Ext.Net.TreeNode("内容模版", Icon.PageWhite);
            n_model_content.Listeners.Click.Handler = "openpage('template/ContentTemplateList.aspx')";
            root_model.Nodes.Add(n_model_content);
            //-----------------------------------内容模版-----------------------------------------------//

            //-----------------------------------公共模版变量-----------------------------------------------//
            Ext.Net.TreeNode n_model_publicv = new Ext.Net.TreeNode("公共模版变量", Icon.ServerChart);
            n_model_publicv.Listeners.Click.Handler = "openpage('template/VarTemplateList.aspx')";
            root_model.Nodes.Add(n_model_publicv);
            //-----------------------------------公共模版变量-----------------------------------------------//


            var page_mgr = new Ext.Net.TreeNode("页面管理", Icon.Page);
            page_mgr.Listeners.Click.Handler = "openpage('template/PageTemplateList.aspx')";
            root_model.Nodes.Add(page_mgr);


            //-----------------------------------公共模版-----------------------------------------------//
            Ext.Net.TreeNode n_model_public = new Ext.Net.TreeNode("公共模版", Icon.World);
            n_model_public.Expanded = true;


            Ext.Net.TreeNode n_mp_index = new Ext.Net.TreeNode("首页模版", Icon.Page);
            n_mp_index.Listeners.Click.Handler = "openpage('template/PublicTemplate.aspx?action=IndexContent')";
            n_model_public.Nodes.Add(n_mp_index);

            Ext.Net.TreeNode n_mp_control = new Ext.Net.TreeNode("控制面板模板", Icon.MonitorEdit);
            n_mp_control.Listeners.Click.Handler = "openpage('template/PublicTemplate.aspx?action=Controlcontent')";
            n_model_public.Nodes.Add(n_mp_control);

            Ext.Net.TreeNode n_mp_sitesearch = new Ext.Net.TreeNode("全站搜索模板", Icon.Zoom);
            n_mp_sitesearch.Listeners.Click.Handler = "openpage('template/PublicTemplate.aspx?action=SiteSearchContent')";
            n_model_public.Nodes.Add(n_mp_sitesearch);

            Ext.Net.TreeNode n_mp_asearch = new Ext.Net.TreeNode("高级搜索模板", Icon.CameraMagnify);
            n_mp_asearch.Listeners.Click.Handler = "openpage('template/PublicTemplate.aspx?action=AdvancedSearch')";
            n_model_public.Nodes.Add(n_mp_asearch);

            Ext.Net.TreeNode n_mp_HorizontaSearch = new Ext.Net.TreeNode("横向JS搜索模板", Icon.CdMagnify);
            n_mp_HorizontaSearch.Listeners.Click.Handler = "openpage('template/PublicTemplate.aspx?action=HorizontaSearch')";
            n_model_public.Nodes.Add(n_mp_HorizontaSearch);

            Ext.Net.TreeNode n_mp_VerticalSearch = new Ext.Net.TreeNode("纵JS搜索模板", Icon.MapMagnify);
            n_mp_VerticalSearch.Listeners.Click.Handler = "openpage('template/PublicTemplate.aspx?action=VerticalSearch')";
            n_model_public.Nodes.Add(n_mp_VerticalSearch);

            Ext.Net.TreeNode n_mp_RelationInfo = new Ext.Net.TreeNode("相关信息模板", Icon.WorldLink);
            n_mp_RelationInfo.Listeners.Click.Handler = "openpage('template/PublicTemplate.aspx?action=RelationInfo')";
            n_model_public.Nodes.Add(n_mp_RelationInfo);

            Ext.Net.TreeNode n_mp_MessageBoard = new Ext.Net.TreeNode("留言板模板", Icon.Comment);
            n_mp_MessageBoard.Listeners.Click.Handler = "openpage('template/PublicTemplate.aspx?action=MessageBoard')";
            n_model_public.Nodes.Add(n_mp_MessageBoard);

            Ext.Net.TreeNode n_mp_Reply = new Ext.Net.TreeNode("评论JS模板", Icon.CommentDull);
            n_mp_Reply.Listeners.Click.Handler = "openpage('template/PublicTemplate.aspx?action=Reply')";
            n_model_public.Nodes.Add(n_mp_Reply);

            Ext.Net.TreeNode n_mp_FinalDown = new Ext.Net.TreeNode("最终下载页模板", Icon.PackageDown);
            n_mp_FinalDown.Listeners.Click.Handler = "openpage('template/PublicTemplate.aspx?action=FinalDown')";
            n_model_public.Nodes.Add(n_mp_FinalDown);

            Ext.Net.TreeNode n_mp_DownAddress = new Ext.Net.TreeNode("下载地址模板", Icon.Link);
            n_mp_DownAddress.Listeners.Click.Handler = "openpage('template/PublicTemplate.aspx?action=DownAddress')";
            n_model_public.Nodes.Add(n_mp_DownAddress);

            Ext.Net.TreeNode n_mp_OLPlayaddress = new Ext.Net.TreeNode("在线播放地址模板", Icon.PlayGreen);
            n_mp_OLPlayaddress.Listeners.Click.Handler = "openpage('template/PublicTemplate.aspx?action=OLPlayaddress')";
            n_model_public.Nodes.Add(n_mp_OLPlayaddress);

            Ext.Net.TreeNode n_mp_ListPager = new Ext.Net.TreeNode("列表分页模板", Icon.PageHeaderFooter);
            n_mp_ListPager.Listeners.Click.Handler = "openpage('template/PublicTemplate.aspx?action=ListPager')";
            n_model_public.Nodes.Add(n_mp_ListPager);

            Ext.Net.TreeNode n_mp_LoginStatus = new Ext.Net.TreeNode("登录状态模板", Icon.PageLandscape);
            n_mp_LoginStatus.Listeners.Click.Handler = "openpage('template/PublicTemplate.aspx?action=LoginStatus')";
            n_model_public.Nodes.Add(n_mp_LoginStatus);

            Ext.Net.TreeNode n_mp_JSLogin = new Ext.Net.TreeNode("JS调用登录模板", Icon.UserRed);
            n_mp_JSLogin.Listeners.Click.Handler = "openpage('template/PublicTemplate.aspx?action=JSLogin')";
            n_model_public.Nodes.Add(n_mp_JSLogin);

            Ext.Net.TreeNode n_mp_ImageList = new Ext.Net.TreeNode("相册图片列表", Icon.UserRed);
            n_mp_ImageList.Listeners.Click.Handler = "openpage('template/PublicTemplate.aspx?action=ImageList')";
            n_model_public.Nodes.Add(n_mp_ImageList);

            Ext.Net.TreeNode n_mp_AnswerList = new Ext.Net.TreeNode("问答回答列表", Icon.UserRed);
            n_mp_AnswerList.Listeners.Click.Handler = "openpage('template/PublicTemplate.aspx?action=AnswerList')";
            n_model_public.Nodes.Add(n_mp_AnswerList);

            Ext.Net.TreeNode n_mp_ChapterList = new Ext.Net.TreeNode("小说章节列表", Icon.UserRed);
            n_mp_ChapterList.Listeners.Click.Handler = "openpage('template/PublicTemplate.aspx?action=ChapterList')";
            n_model_public.Nodes.Add(n_mp_ChapterList);

            Ext.Net.TreeNode n_mp_BookChapter = new Ext.Net.TreeNode("小说章节", Icon.UserRed);
            n_mp_BookChapter.Listeners.Click.Handler = "openpage('template/PublicTemplate.aspx?action=BookChapter')";
            n_model_public.Nodes.Add(n_mp_BookChapter);

            Ext.Net.TreeNode n_mp_kuaibo = new Ext.Net.TreeNode("快播页面", Icon.PlayBlue);
            n_mp_kuaibo.Listeners.Click.Handler = "openpage('template/PublicTemplate.aspx?action=KuaiboPage')";
            n_model_public.Nodes.Add(n_mp_kuaibo);


            Ext.Net.TreeNode n_mp_baidu = new Ext.Net.TreeNode("百度影音页面", Icon.PlayGreen);
            n_mp_baidu.Listeners.Click.Handler = "openpage('template/PublicTemplate.aspx?action=BaiduPage')";
            n_model_public.Nodes.Add(n_mp_baidu);

            Ext.Net.TreeNode n_mp_singleurl = new Ext.Net.TreeNode("单集列表", Icon.TextListBullets);
            n_mp_singleurl.Listeners.Click.Handler = "openpage('template/PublicTemplate.aspx?action=SingleDrama')";
            n_model_public.Nodes.Add(n_mp_singleurl);

            root_model.Nodes.Add(n_model_public);
            //-----------------------------------公共模版-----------------------------------------------//

            //-----------------------------------搜索模版-----------------------------------------------//
            Ext.Net.TreeNode n_model_search = new Ext.Net.TreeNode("搜索模版", Icon.Magnifier);
            root_model.Nodes.Add(n_model_search);
            //-----------------------------------搜索模版-----------------------------------------------//

            //-----------------------------------评论模版-----------------------------------------------//
            Ext.Net.TreeNode n_model_reply = new Ext.Net.TreeNode("评论模版", Icon.Comments);
            root_model.Nodes.Add(n_model_reply);
            //-----------------------------------评论模版-----------------------------------------------//

            //-----------------------------------标签-----------------------------------------------//
            Ext.Net.TreeNode n_model_tag = new Ext.Net.TreeNode("标签", Icon.PageCode);
            root_model.Nodes.Add(n_model_tag);
            //-----------------------------------标签-----------------------------------------------//

            //-----------------------------------模板组管理-----------------------------------------------//
            Ext.Net.TreeNode n_model_group = new Ext.Net.TreeNode("模板组管理", Icon.PageCopy);
            root_model.Nodes.Add(n_model_group);
            //-----------------------------------模板组管理-----------------------------------------------//

            Tree_Model.Root.Add(root_model);
            #endregion

            #region 栏目管理
            TreePanel Tree_Class = new TreePanel();
            Tree_Class.ID = "t_Class";
            Tree_Class.Title = "栏目管理";
            Tree_Class.Icon = Icon.Ruby;
            Tree_Class.AutoScroll = true;

            Ext.Net.TreeNode root_class = new Ext.Net.TreeNode("栏目管理");
            root_class.Expanded = true;

            #region 信息相关
            //-----------------------------------信息相关-----------------------------------------------//
            Ext.Net.TreeNode n_c_msg = new Ext.Net.TreeNode("信息相关", Icon.Book);
            n_c_msg.Expanded = true;
            //---------------信息相关-----------------------------------------------//
            Ext.Net.TreeNode n_sm_mgr = new Ext.Net.TreeNode("信息管理", Icon.BookmarkEdit);
            //n_sm_mgr.Listeners.Click.Handler = "openpage('news/newslist.aspx')";

            var news_mgr = new Ext.Net.TreeNode("新闻管理", Icon.Newspaper);
            news_mgr.Listeners.Click.Handler = "openpage('news/newslist.aspx')";
            n_sm_mgr.Nodes.Add(news_mgr);

            var image_mgr = new Ext.Net.TreeNode("图片管理", Icon.ImageEdit);
            image_mgr.Listeners.Click.Handler = "openpage('images/ImageList.aspx')";
            n_sm_mgr.Nodes.Add(image_mgr);

            var question_mgr = new Ext.Net.TreeNode("问答管理", Icon.Information);
            question_mgr.Listeners.Click.Handler = "openpage('question/QuestionList.aspx')";
            n_sm_mgr.Nodes.Add(question_mgr);

            var book_mgr = new Ext.Net.TreeNode("小说管理", Icon.Book);
            book_mgr.Listeners.Click.Handler = "openpage('book/BookList.aspx')";
            n_sm_mgr.Nodes.Add(book_mgr);

            var info_mgr = new Ext.Net.TreeNode("分类信息管理", Icon.ApplicationSideList);
            //info_mgr.Listeners.Click.Handler = "openpage('Info/InfoList.aspx')";
            n_sm_mgr.Nodes.Add(info_mgr);

            var movie_mgr = new Ext.Net.TreeNode("影视管理", Icon.MonitorEdit);
            movie_mgr.Listeners.Click.Handler = "openpage('Movie/MovieList.aspx')";
            n_sm_mgr.Nodes.Add(movie_mgr);

            n_c_msg.Nodes.Add(n_sm_mgr);
            //---------------信息相关-----------------------------------------------//

            //---------------审核信息-----------------------------------------------//
            Ext.Net.TreeNode n_sm_aud = new Ext.Net.TreeNode("审核信息", Icon.BookAddressesEdit);
            ////n_c_msg.Nodes.Add(n_sm_aud);
            //---------------审核信息-----------------------------------------------//

            //---------------评论管理-----------------------------------------------//
            Ext.Net.TreeNode n_sm_reply = new Ext.Net.TreeNode("评论管理", Icon.CommentEdit);
            ////n_c_msg.Nodes.Add(n_sm_reply);
            //---------------评论管理-----------------------------------------------//

            root_class.Nodes.Add(n_c_msg);
            //-----------------------------------信息相关-----------------------------------------------//
            #endregion

            //-----------------------------------栏目管理-----------------------------------------------//
            Ext.Net.TreeNode n_class_class = new Ext.Net.TreeNode("栏目管理", Icon.ApplicationSideList);
            n_class_class.Listeners.Click.Handler = "openpage('news/ClassList.aspx')";
            root_class.Nodes.Add(n_class_class);
            //-----------------------------------栏目管理-----------------------------------------------//

            //-----------------------------------专题管理-----------------------------------------------//
            Ext.Net.TreeNode n_class_zt = new Ext.Net.TreeNode("专题管理", Icon.ApplicationOsxTerminal);
            ////root_class.Nodes.Add(n_class_zt);
            //-----------------------------------专题管理-----------------------------------------------//

            Tree_Class.Root.Add(root_class);
            #endregion

            #region 用户管理
            TreePanel Tree_User = new TreePanel();
            Tree_User.ID = "TreePanel1";
            Tree_User.Width = Unit.Pixel(300);
            Tree_User.Height = Unit.Pixel(450);
            Tree_User.Icon = Icon.User;
            Tree_User.Title = "用户管理";
            Tree_User.AutoScroll = true;

            Ext.Net.TreeNode root_user = new Ext.Net.TreeNode("系统用户");
            root_user.Expanded = true;
            //------------用户管理-----------------------------------------------//
            Ext.Net.TreeNode n_user_sys = new Ext.Net.TreeNode("用户管理", Icon.UserGray);

            n_user_sys.Expanded = true;

            //-----------------------------------修改个人资料-----------------------------------------------//
            Ext.Net.TreeNode n_us_modInfo = new Ext.Net.TreeNode("修改个人资料", Icon.PageWhitePaint);
            n_us_modInfo.Listeners.Click.Handler = "openpage('sysuser/SysUserEdit.aspx?id=" + UserAction.opuser.ID + "')";
            n_user_sys.Nodes.Add(n_us_modInfo);
            //-----------------------------------修改个人资料-----------------------------------------------//

            //-----------------------------------管理用户组-----------------------------------------------//
            Ext.Net.TreeNode n_us_group = new Ext.Net.TreeNode("管理用户组", Icon.UserHome);
            ////n_user_sys.Nodes.Add(n_us_group);
            //-----------------------------------管理用户组-----------------------------------------------//

            //-----------------------------------管理用户部门-----------------------------------------------//
            Ext.Net.TreeNode n_us_dep = new Ext.Net.TreeNode("管理用户部门", Icon.Door);
            ////n_user_sys.Nodes.Add(n_us_dep);
            //-----------------------------------管理用户部门-----------------------------------------------//

            //-----------------------------------管理用户-----------------------------------------------//
            Ext.Net.TreeNode n_us_user = new Ext.Net.TreeNode("管理用户", Icon.UserEdit);
            n_us_user.Listeners.Click.Handler = "openpage('sysuser/SysUserList.aspx')";
            n_user_sys.Nodes.Add(n_us_user);
            //-----------------------------------管理用户-----------------------------------------------//

            root_user.Nodes.Add(n_user_sys);
            //------------用户管理-----------------------------------------------//







            //------------会员管理-----------------------------------------------//
            Ext.Net.TreeNode n_user_user = new Ext.Net.TreeNode("会员管理", Icon.User);
            n_user_user.Expanded = true;

            //-----------------------------------管理会员组-----------------------------------------------//
            Ext.Net.TreeNode n_uu_group = new Ext.Net.TreeNode("管理会员组", Icon.UserHome);
            n_uu_group.Listeners.Click.Handler = "openpage('user/GroupList.aspx')";
            n_user_user.Nodes.Add(n_uu_group);
            //-----------------------------------管理会员组-----------------------------------------------//

            //-----------------------------------管理会员-----------------------------------------------//
            Ext.Net.TreeNode n_uu_user = new Ext.Net.TreeNode("管理会员", Icon.UserTick);
            n_uu_user.Listeners.Click.Handler = "openpage('user/userlist.aspx')";
            n_user_user.Nodes.Add(n_uu_user);
            //-----------------------------------管理会员-----------------------------------------------//

            //-----------------------------------管理会员表单-----------------------------------------------//
            Ext.Net.TreeNode n_uu_form = new Ext.Net.TreeNode("管理会员表单", Icon.ApplicationForm);
            n_uu_form.Listeners.Click.Handler = "openpage('user/UserFormList.aspx')";
            n_user_user.Nodes.Add(n_uu_form);
            //-----------------------------------管理会员表单-----------------------------------------------//

            root_user.Nodes.Add(n_user_user);
            //------------会员管理-----------------------------------------------//

            Tree_User.Root.Add(root_user);
            #endregion

            #region 信息管理 此处需要从数据库加载
            TreePanel tree_Message = new TreePanel();
            tree_Message.ID = "tree_m";
            tree_Message.Width = Unit.Pixel(300);
            tree_Message.Height = Unit.Pixel(450);
            tree_Message.Icon = Icon.User;
            tree_Message.Title = "信息管理";
            tree_Message.AutoScroll = true;

            //Ext.Net.TreeNode root_msg = new Ext.Net.TreeNode("信息管理");

            // root_msg.Listeners.Click.Handler = "openpage('Test.aspx')";

            //root_msg.Nodes.Add(GetSubTree(0));


            //tree_Message.Root.Add(root_msg);
            tree_Message.Root.Add(GetSubTree(0));

            #endregion


            // Make Accordion container
            AccordionLayout acc = new AccordionLayout();
            acc.Animate = false;

            // Add Navigation and Settings Panels to Accordion
            acc.Items.Add(tree_Message);
            acc.Items.Add(Tree_Sys);
            acc.Items.Add(Tree_Model);
            acc.Items.Add(Tree_Class);
            acc.Items.Add(Tree_User);

            // Add Accordion to West Panel
            west.Items.Add(acc);




            // Make Tab
            Panel tab1 = new Panel();
            tab1.ID = "Tab2";
            //tab1.Title = "Center";
            tab1.Border = false;
            tab1.BodyStyle = "padding:0px;";
            tab1.Html = "<iframe border='0' name='main' id='main' style='border:solid 0px #FFF' src='about:blank' height='100%' width='100%' />";

            //center.Items.Add(tab1);



            //////////////////
            // 南方 //
            //////////////////

            // Make Panel for South Region
            Panel south = new Panel();
            south.ID = "SouthPanel";
            //south.Title = "South";
            south.Height = Unit.Pixel(30);
            south.BodyStyle = "padding:0px;";
            south.Html = "<div id='southPn' style='background-color:rgb(217,231,248);height:30px;line-height:30px;color:gray;position:relative'><span>" +
                " <a href='javascript:void(0)' onclick=\"openpage('news/NewsEdit.aspx')\" target='main'>增加信息</a>" +
                " <a href='javascript:void(0)' onclick=\"openpage('news/newslist.aspx')\" target='main'>管理信息</a>" +
                " <a href='javascript:void(0)' onclick=\"openpage('system/Update/Createpages.aspx')\"  target='main'>数据更新</a>" +
                //" <a href='javascript:void(0)' onclick=\"openpage('system/Update/Main.aspx')\" target='main'>后台首页</a>" +
                " <a href='/' target='_blank;'>网站首页</a>" +
                " </span><span style='position:absolute;top:2px;right:10px'>&copy; 2011 <a href='mailto:kuibono@163.com'>Kuibono</a></span></div>";


            //////////////
            // VIEWPORT //
            //////////////        

            // Make BorderLayout container for Viewport
            BorderLayout layout = new BorderLayout();

            // Set North Region properties
            layout.North.Split = false;
            layout.North.Collapsible = false;

            // Set West Region properties
            layout.West.MinWidth = Unit.Pixel(225);
            layout.West.MaxWidth = Unit.Pixel(400);
            layout.West.Split = false;
            layout.West.Collapsible = true;



            // Set South Region properties
            //layout.South.Split = true;
            layout.South.Collapsible = false;

            // Add Panels to BorderLayout Regions
            layout.North.Items.Add(north);
            layout.West.Items.Add(west);
            layout.Center.Items.Add(tab1);
            //layout.East.Items.Add(east);
            layout.South.Items.Add(south);

            // Make Viewport to fold everything
            Viewport vp = new Viewport();
            vp.ID = "ViewPort1";

            // Add BorderLayout to Viewport
            vp.Items.Add(layout);

            // Add Viewport to Form
            this.Controls.Add(vp);
        }

        protected Ext.Net.TreeNode GetSubTree(int id)
        {
            Ext.Net.TreeNode node = new Ext.Net.TreeNode();
            node.Expanded = true;

            List<Class> cls = NewsAction.NewsClass;
            List<Class> lpcls = NewsAction.NewsClass.Where(p => p.ID == id).ToList();
            if (lpcls.Count == 0)
            {
                node.Text = "所有栏目";
            }
            else
            {
                Class pcls = lpcls.First();
                node.Text = pcls.ClassName;
                if (pcls.IsLeafClass==true)
                {
                    if (pcls.ModelID == 1)
                    {
                        node.Listeners.Click.Handler = "openpage('news/NewsList.aspx?class=" + pcls.ID + "')";
                    }
                    else if (pcls.ModelID == 2)
                    {
                        node.Listeners.Click.Handler = "openpage('images/ImageList.aspx?class=" + pcls.ID + "')";
                    }
                    else if (pcls.ModelID == 3)
                    {
                        node.Listeners.Click.Handler = "openpage('question/QuestionList.aspx?class=" + pcls.ID + "')";
                    }
                    else if (pcls.ModelID == 4)
                    {
                        node.Listeners.Click.Handler = "openpage('Book/BookList.aspx?class=" + pcls.ID + "')";
                    }
                    else if (pcls.ModelID == 5)
                    {
                        //node.Listeners.Click.Handler = "openpage('Book/BookList.aspx?class=" + pcls.ID + "')";
                    }
                    else if (pcls.ModelID == 6)
                    {
                        node.Listeners.Click.Handler = "openpage('Movie/MovieList.aspx?class=" + pcls.ID + "')";
                    }

                }
            }
            cls = cls.Where(p => p.ParentID == id).ToList();
            foreach (Class c in cls)
            {
                node.Nodes.Add(GetSubTree(c.ID));
            }
            return node;

        }
    }
}
