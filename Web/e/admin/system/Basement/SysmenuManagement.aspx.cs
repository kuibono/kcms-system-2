using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Voodoo.Basement;
using Voodoo;
namespace Web.e.admin.system.Basement
{
    public partial class SysmenuManagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadPanelTree();


                foreach (Ext.Net.Icon icon in Enum.GetValues(typeof(Ext.Net.Icon)))
                {
                    ddl_ph_icon.Items.Add(icon.ToS());
                    ddl_tree_icon.Items.Add(icon.ToS());
                }
                DataEntities ent = new DataEntities();
                var groupList = from l in ent.SysGroup select l;
                foreach (var group in groupList)
                {
                    cbl_pn_group.Items.Add(new ListItem(group.GroupName, group.ID.ToS()));
                    cbl_tree_group.Items.Add(new ListItem(group.GroupName, group.ID.ToS()));
                }
                ent.Dispose();

            }
        }

        protected void LoadPanelTree()
        {
            DataEntities ent = new DataEntities();

            var panelList = from l in ent.SysNavPanel orderby l.OrderIndex select l;
            foreach (var pn in panelList)
            {
                TreeNode tree = new TreeNode(pn.Title, pn.ID.ToString());
                PanelTree.Nodes.Add(tree);
            }

            ent.Dispose();
        }

        protected void PanelTree_SelectedNodeChanged(object sender, EventArgs e)
        {
            DataEntities ent = new DataEntities();

            int id = PanelTree.SelectedNode.Value.ToInt32();
            SysNavPanel pn = (from l in ent.SysNavPanel where l.ID == id select l).FirstOrDefault();

            txt_pn_title.Text = pn.Title;
            txt_pn_orderindex.Text = pn.OrderIndex.ToS();
            ddl_ph_icon.SelectedValue = pn.Icon;
            cbl_pn_group.SetValue(pn.Group.Split(','));

            List<SysNavTree> trees = (from l in ent.SysNavTree select l).ToList();
            var nodes = GetSubNode(trees, id, 0);
            SubTree.Nodes.Clear();
            foreach (TreeNode node in nodes)
            {
                SubTree.Nodes.Add(node);
            }


            ent.Dispose();




        }

        protected TreeNodeCollection GetSubNode(List<SysNavTree> trees, int PanelID, int ParentID)
        {
            TreeNodeCollection result = new TreeNodeCollection();
            var nodeList = from l in trees where l.PanelID == PanelID && l.ParentID == ParentID select l;
            foreach (var node in nodeList)
            {
                TreeNode n = new TreeNode(node.Title, node.ID.ToS());

                var sublist = from l in trees where l.PanelID == PanelID && l.ParentID == node.ID select l;
                if (sublist.Count() > 0)
                {
                    var subnodes = GetSubNode(trees, PanelID, node.ID);
                    foreach (TreeNode subnode in subnodes)
                    {
                        n.ChildNodes.Add(subnode);
                    }

                }
                result.Add(n);
            }

            return result;
        }

        /// <summary>
        /// 新增Panel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Pn_new_Click(object sender, EventArgs e)
        {
            SysNavPanel pn = new SysNavPanel();
            pn.Group = cbl_pn_group.GetValues();
            pn.Icon = ddl_ph_icon.SelectedValue;
            pn.OrderIndex = txt_pn_orderindex.Text.ToInt32();
            pn.Title = txt_pn_title.Text;
            DataEntities ent = new DataEntities();
            ent.AddToSysNavPanel(pn);
            ent.SaveChanges();
            ent.Dispose();
            Js.AlertAndChangUrl("新增成功", "SysmenuManagement.aspx");
        }

        protected void btn_Save_pn_Click(object sender, EventArgs e)
        {
            DataEntities ent = new DataEntities();
            int id = PanelTree.SelectedNode.Value.ToInt32();
            SysNavPanel pn = (from l in ent.SysNavPanel where l.ID == id select l).FirstOrDefault();
            pn.Group = cbl_pn_group.GetValues();
            pn.Icon = ddl_ph_icon.SelectedValue;
            pn.OrderIndex = txt_pn_orderindex.Text.ToInt32();
            pn.Title = txt_pn_title.Text;
            ent.SaveChanges();
            ent.Dispose();
            Js.AlertAndChangUrl("保存成功", "SysmenuManagement.aspx");
        }

        protected void btn_tree_new_Click(object sender, EventArgs e)
        {
            int pnID = PanelTree.SelectedNode.Value.ToInt32(0);
            int parentID = 0;
            try
            {
                parentID=SubTree.SelectedNode.Value.ToInt32(0);
            }
            catch
            {

            }

            SysNavTree tree = new SysNavTree();
            tree.Group = cbl_tree_group.GetValues();
            tree.Icon = ddl_tree_icon.SelectedValue;
            tree.InnerHtml = txt_tree_html.Text;
            tree.OrderIndex = txt_tree_orderindex.Text.ToInt32();
            tree.PanelID = pnID;
            tree.ParentID = parentID;
            tree.Title = txt_tree_title.Text;
            tree.Url = txt_tree_url.Text;
            DataEntities ent = new DataEntities();
            ent.AddToSysNavTree(tree);
            ent.SaveChanges();
            ent.Dispose();
            Js.AlertAndChangUrl("新增成功", "SysmenuManagement.aspx");
        }

        protected void btn_Save_tree_Click(object sender, EventArgs e)
        {

        }
    }
}