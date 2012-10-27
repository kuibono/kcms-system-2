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
    public partial class IndexProvinceCitys :AdminBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        protected void BindData()
        {
            DataEntities ent=new DataEntities();
            var areas = (from l in ent.Area select l).ToList();
            var ps = (from l in ent.Province select l).ToList();
            var cs = (from l in ent.City select l).ToList();

            ent.Dispose();
            TreeView1.Nodes.Clear();

            foreach (var area in areas)
            {
                TreeNode n = new TreeNode(area.Name, area.ID.ToS());
                n.Checked = area.ShowInIndex.ToBoolean();
                var subps = from l in ps where l.AreaID == area.ID select l;
                foreach (var subp in subps)
                {
                    TreeNode n_p = new TreeNode(subp.province1, subp.ID.ToS());
                    n_p.Checked = subp.ShowInIndex.ToBoolean();
                    var subcs = from l in cs where l.ProvinceID == subp.ID select l;
                    foreach (var subc in subcs)
                    {
                        TreeNode n_c = new TreeNode(subc.city1, subc.id.ToS());
                        n_c.Checked = subc.ShowInIndex.ToBoolean();
                        n_p.ChildNodes.Add(n_c);
                    }
                    n.ChildNodes.Add(n_p);
                }

                TreeView1.Nodes.Add(n);
            }
            
        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            DataEntities ent = new DataEntities();
            var areas = (from l in ent.Area select l).ToList();
            var ps = (from l in ent.Province select l).ToList();
            var cs = (from l in ent.City select l).ToList();


            foreach (TreeNode n_a in TreeView1.Nodes)
            {
                int aid = n_a.Value.ToInt32();
                var area = areas.Where(o => o.ID == aid).FirstOrDefault();
                area.ShowInIndex = n_a.Checked;

                foreach (TreeNode n_p in n_a.ChildNodes)
                {
                    int pid = n_p.Value.ToInt32();
                    var p = ps.Where(o => o.ID == pid).FirstOrDefault();
                    p.ShowInIndex = n_p.Checked;

                    foreach (TreeNode n_c in n_p.ChildNodes)
                    {
                        int cid = n_c.Value.ToInt32();
                        var c = cs.Where(o => o.id == cid).FirstOrDefault();
                        c.ShowInIndex = n_c.Checked;
                    }
                }
            }
            ent.SaveChanges();
            ent.Dispose();
            Js.AlertAndGoback("保存成功！");
        }
    }
}