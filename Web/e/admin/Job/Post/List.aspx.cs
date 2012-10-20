using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Voodoo;
using Voodoo.Basement;

namespace Web.e.admin.Job.Post
{
    public partial class List : AdminBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDropItems();
            }
            if (WS.RequestString("action") == "del")
            {
                Button1_Click(sender, e);
            }
            BindList();
        }

        #region 加载搜索下拉框
        /// <summary>
        /// 加载搜索下拉框
        /// </summary>
        protected void LoadDropItems()
        {
            DataEntities ent = new DataEntities();
            var provinces = from l in ent.Province select l;

            foreach (var pro in provinces)
            {
                ddl_Province.Items.Add(new ListItem(pro.province1, pro.ID.ToS()));
            }

            LoadCity();

            foreach (var sal in JobAction.SalaryDegree)
            {
                ddl_Salary.Items.Add(new ListItem(sal.Value, sal.Key.ToS()));
            }

            foreach (var exp in JobAction.Expressions)
            {
                ddl_Expressions.Items.Add(new ListItem(exp.Value, exp.Key.ToS()));
            }

            foreach (var edu in JobAction.Edu)
            {

                ddl_Edu.Items.Add(new ListItem(edu.Value, edu.Key.ToS()));
            }

            ent.Dispose();
        }

        #region 绑定市
        /// <summary>
        /// 绑定市
        /// </summary>
        protected void LoadCity()
        {
            using (DataEntities ent = new DataEntities())
            {
                int pid = ddl_Province.SelectedValue.ToInt32();

                var cts = from l in ent.City where l.ProvinceID == pid select l;
                ddl_City.Items.Clear();
                ddl_City.Items.Add(new ListItem("--不限城市--", ""));
                foreach (var ct in cts)
                {
                    ddl_City.Items.Add(new ListItem(ct.city1, ct.id.ToS()));
                }
            }
        }
        #endregion

        protected void ddl_Province_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCity();
        }
        #endregion 

        #region 绑定列表
        /// <summary>
        /// 绑定列表
        /// </summary>
        protected void BindList()
        {
            DataEntities ent = new DataEntities();

            var q = from l in ent.JobPost
                    from c in ent.City
                    from p in ent.Province
                    from com in ent.JobCompany
                    where
                        l.City == c.id &&
                        l.Province == p.ID &&
                        l.CompanyID == com.ID
                    select
                new {l.CompanyID, l.Title,l.Province,l.City,l.Salary,l.Expressions,l.Edu,l.ID,l.PostTime,l.EmployNumber, p.province1, c.city1, com.CompanyName };

            if (txt_Key.Text.Length > 0)
            {
                q = q.Where(p => p.Title.Contains(txt_Key.Text));
            }

            if (ddl_Province.SelectedValue.Length > 0)
            {
                int pro = ddl_Province.SelectedValue.ToInt32();
                q = q.Where(p => p.Province == pro);
            }
            if (ddl_City.SelectedValue.Length > 0)
            {
                int ct = ddl_City.SelectedValue.ToInt32();
                q = q.Where(p => p.City == ct);
            }
            if (ddl_Salary.SelectedValue.Length > 0)
            {
                int sal = ddl_Salary.SelectedValue.ToInt32();
                q = q.Where(p => p.Salary == sal);
            }
            if (ddl_Expressions.SelectedValue.Length > 0)
            {
                int exp = ddl_Expressions.SelectedValue.ToInt32();
                q = q.Where(p => p.Expressions == exp);
            }
            if (ddl_Edu.SelectedValue.Length > 0)
            {
                int ed = ddl_Edu.SelectedValue.ToInt32();
                q = q.Where(p => p.Edu == ed);
            }

            long companyID = WS.RequestLong("id");
            if (companyID > 0)
            {
                q = q.Where(p => p.CompanyID == companyID);
            }

            pager.RecordCount = q.Count();
            rp_list.DataSource = q.OrderByDescending(p => p.ID)
                .Skip((pager.CurrentPageIndex - 1) * pager.PageSize).Take(pager.PageSize);
            rp_list.DataBind();

            ent.Dispose();
        }
        #endregion


        protected void Button1_Click(object sender, EventArgs e)
        {
            var ids = WS.RequestString("id").Split(',').ToList();
            DataEntities ent = new DataEntities();
            var qs = from l in ent.JobPost where ids.IndexOf(l.ID.ToString()) > 0 select l;
            foreach (var q in qs)
            {
                ent.DeleteObject(q);
            }
            ent.SaveChanges();
            ent.Dispose();
            Js.AlertAndChangUrl("删除成功！", "List.aspx");
        }

        protected void pager_PageChanged(object sender, EventArgs e)
        {

        }
    }
}