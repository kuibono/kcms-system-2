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


namespace Web.e.admin.Job
{
    public partial class Default : AdminBase
    {
        private SysUser currentUser
        {
            get
            {
                return SysUserAction.LocalUser;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            LoadFrame();
        }

        protected Ext.Net.TreeNode GetTree(List<SysNavTree> trees, int PanelID, int ID = 0)
        {
            Ext.Net.TreeNode result = new Ext.Net.TreeNode();
            result.Expanded = true;

            var q_node = from l in trees where l.PanelID == PanelID && l.ID == ID select l;
            if (ID == 0)
            {
                q_node = from l in trees where l.PanelID == PanelID select l;
            }
            if (q_node.Count() == 0)
            {
                return new Ext.Net.TreeNode();
            }

            var node = q_node.FirstOrDefault();

            //if (!node.Group.Split(',').Contains(currentUser.UserGroup.ToString()))
            //{
            //    return new Ext.Net.TreeNode();
            //}

            foreach (Ext.Net.Icon icon in Enum.GetValues(typeof(Ext.Net.Icon)))
            {
                if (icon.ToS() == node.Icon)
                {
                    result.Icon = icon;
                }
            }

            result.Text = node.Title;

            if (!node.InnerHtml.IsNullOrEmpty())
            {
                result = new Ext.Net.TreeNode(node.InnerHtml);
            }

            if (!node.Url.IsNullOrEmpty())
            {
                result.Listeners.Click.Handler = string.Format("openpage('{0}');", node.Url);
            }

            var q_subs = from l in trees where l.PanelID == PanelID && l.ParentID == node.ID select l;
            foreach (SysNavTree q_sub in q_subs)
            {
                result.Nodes.Add(GetTree(trees, PanelID, q_sub.ID));
            }

            return result;
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
            north.Html = "<div id='northPn'><img src='../../data/images/cms_logo.png' style='height:53px' /><span id='loginInfoSp'>用户：" + SysUserAction.LocalUser.UserName + "  [<a href='logout.aspx'>退出]</a></span></div>";
            north.Collapsible = false;


            /////////////////
            // WEST REGION //
            /////////////////

            // Make Panel for West Region
            Panel west = new Panel();
            west.ID = "WestPanel";
            west.Title = "导航";
            west.Width = Unit.Pixel(225);

            AccordionLayout acc = new AccordionLayout();
            acc.Animate = false;



            TreePanel tree_Message = new TreePanel();
            tree_Message.ID = "tree_m";
            tree_Message.Width = Unit.Pixel(300);
            tree_Message.Height = Unit.Pixel(450);
            tree_Message.Icon = Icon.User;
            tree_Message.Title = "信息管理";
            tree_Message.AutoScroll = true;


            tree_Message.Root.Add(GetSubTree(0));

            if (SystemSetting.ShowMenuMessage)
            {
                acc.Items.Add(tree_Message);
            }

            DataEntities ent = new DataEntities();
            var pnS = from l in ent.SysNavPanel select l;
            var treeS = from l in ent.SysNavTree select l;


            foreach (var pn in pnS)
            {
                //if (!pn.Group.Split(',').Contains(currentUser.UserGroup.ToString()))
                //{
                //    continue;
                //}

                TreePanel p = new TreePanel();
                p.ID = pn.ID.ToS();
                p.Title = pn.Title;
                p.AutoScroll = true;

                foreach (Ext.Net.Icon icon in Enum.GetValues(typeof(Ext.Net.Icon)))
                {
                    if (pn.Icon == icon.ToString())
                    {
                        p.Icon = icon;
                    }
                }
                //ICON

                p.Root.Add(GetTree(treeS.ToList(), pn.ID));

                acc.Items.Add(p);

            }
            ent.Dispose();
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
                if (pcls.IsLeafClass == true)
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