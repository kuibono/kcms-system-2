using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

using Voodoo;
using Voodoo.Basement;
using Voodoo.IO;

namespace Web.e.admin.system.Basement
{
    public partial class FileManagement : AdminBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindTree();
            }
        }

        /// <summary>
        /// 绑定树
        /// </summary>
        protected void BindTree()
        {
            var node=new TreeNode();
            node.Text="root";
            node.Value=Server.MapPath("~/");
            
            //AppendSubNode(new DirectoryInfo(Server.MapPath("~/")), node);
            node.ChildNodes.Add(new TreeNode("正在加载"));
            TreeView1.Nodes.Add(node);
        }

        /// <summary>
        /// 递归获取所有目录和文件
        /// </summary>
        /// <param name="dir"></param>
        /// <returns></returns>
        protected void AppendSubNode(DirectoryInfo dir,TreeNode root)
        {
            var subdirs = dir.GetDirectories();
            foreach (var subdir in subdirs)
            {
                TreeNode n = new TreeNode();
                n.Text = subdir.Name;
                n.Expanded = false;
                n.Value = subdir.FullName;
                n.ChildNodes.Add(new TreeNode("正在加载"));
                root.ChildNodes.Add(n);
            }

            var files = dir.GetFiles();
            foreach (var file in files)
            {
                TreeNode n = new TreeNode();
                n.Text = file.Name;
                n.Value = file.FullName;
                root.ChildNodes.Add(n);

            }

            //TreeNode root = new TreeNode();
            //root.Text = dir.Name;
            //root.Value = Server.MapPath("~/");

            //var subdirs = dir.GetDirectories();
            //foreach (var subdir in subdirs)
            //{
            //    //root.ChildNodes.Add(AppendSubNode(subdir));
            //    TreeNode n = new TreeNode();
            //    n.Text = subdir.Name;
            //    n.Expanded = false;
            //    n.Value = subdir.FullName;
            //    n.ChildNodes.Add(new TreeNode("正在加载"));
            //    root.ChildNodes.Add(n);
            //}


            //var files = dir.GetFiles();
            //foreach (var file in files)
            //{
            //    TreeNode n = new TreeNode();
            //    n.Text = file.Name;
            //    n.Value = file.FullName;
            //    root.ChildNodes.Add(n);

            //}
            //return root;
        }

        protected void TreeView1_TreeNodeExpanded(object sender, TreeNodeEventArgs e)
        {
            if (e.Node.ChildNodes.Count > 0)
            {
                e.Node.ChildNodes.Clear();
                DirectoryInfo dir = new DirectoryInfo(e.Node.Value);
                AppendSubNode(dir,e.Node);
            }
        }

        protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
        {
            lb_Path.Text = TreeView1.SelectedNode.Value;
            txt_Content.Text = Voodoo.IO.File.Read(TreeView1.SelectedNode.Value);
        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            Voodoo.IO.File.Write(lb_Path.Text, txt_Content.Text);

        }

        protected void btn_Upload_Click(object sender, EventArgs e)
        {
            string filename=Path.GetFileName(FileUpload1.FileName);
            DirectoryInfo dir=new DirectoryInfo(TreeView1.SelectedNode.Value);
            FileInfo file=new FileInfo(TreeView1.SelectedNode.Value);

            string filepath="";
            if(dir.Exists)
            {
                filepath=dir.FullName+"\\"+filename;
            }
            else if(file.Exists)
            {
                filepath=file.DirectoryName+"\\"+filename;
            }
            else
            {
                filepath=Server.MapPath("~/"+filename);
            }
            FileUpload1.SaveAs(filepath);
        }
    }
}