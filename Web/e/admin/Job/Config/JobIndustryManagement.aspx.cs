using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Voodoo;
using Voodoo.Basement;

namespace Web.e.admin.Job.Config
{
    public partial class JobIndustryManagement :AdminBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadTree();
            }
        }

        protected void LoadTree()
        {
            DataEntities ent = new DataEntities();
            List<JobIndustry> lst = (from l in ent.JobIndustry select l).ToList();
            ent.Dispose();

            foreach (var j in lst.Where(p => p.ParentID == 0))
            {

                Spe_Tree.Nodes.Add(GetNode(lst, j.ID));
            }

        }

        protected TreeNode GetNode(List<JobIndustry> lst, long id)
        {
            TreeNode result = new TreeNode();
            result.Expanded = false;
            var q_node = (from l in lst where l.ID == id select l).First();
            result.Value = q_node.ID.ToS();
            result.Text = q_node.Name;

            var q_subs = from l in lst where l.ParentID == id select l;
            if (q_subs.Count() > 0)
            {
                foreach (JobIndustry j in q_subs)
                {
                    result.ChildNodes.Add(GetNode(lst, j.ID));
                }
            }

            return result;
        }

        protected void Spe_Tree_SelectedNodeChanged(object sender, EventArgs e)
        {
            Btn_Save.Enabled = false;
        }

        protected void Btn_Edit_Click(object sender, EventArgs e)
        {
            Btn_Save.Enabled = true;
            chk_Edit.Checked = true;
            txt_Name.Text = Spe_Tree.SelectedNode.Text;
        }

        protected void Btn_Add_Click(object sender, EventArgs e)
        {
            Btn_Save.Enabled = true;
            chk_Edit.Checked = false;
            txt_Name.Text = "";
        }

        protected void Btn_Save_Click(object sender, EventArgs e)
        {
            DataEntities ent = new DataEntities();
            int id = 0;
            try
            {
                id = Spe_Tree.SelectedNode.Value.ToInt32(0);
            }
            catch
            {
            }
            if (chk_Edit.Checked)
            {
                var q = (from l in ent.JobIndustry where l.ID == id select l).FirstOrDefault();
                q.Name = txt_Name.Text;
            }
            else
            {
                JobIndustry spe = new JobIndustry();
                spe.ParentID = id;
                spe.Name = txt_Name.Text;
                ent.AddToJobIndustry(spe);
            }
            ent.SaveChanges();
            ent.Dispose();
            Spe_Tree.Nodes.Clear();
            LoadTree();
        }
    }
}