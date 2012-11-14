using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Voodoo;
using Voodoo.Basement;
using Voodoo.Setting;


namespace Web.e.admin.Job.Person
{
    public partial class List : AdminBase
    {
        protected int enable = -1;
        protected int group = -1;
        protected string url = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (WS.RequestString("action") == "del")
            {
                Button1_Click(sender, e);
            }
            if (!IsPostBack)
            {
                BindList();
            }
        }

        protected void BindList()
        {
            DataEntities ent = new DataEntities();

            enable = WS.RequestInt("enable", -1);
            group = WS.RequestInt("group", -1);
            url = string.Format("List.aspx?ebable={0}&group={1}", enable.ToString(), group.ToString());


            ddl_Group.DataSource = UserAction.GetUserGroups();
            ddl_Group.DataTextField = "GroupName";
            ddl_Group.DataValueField = "ID";
            ddl_Group.DataBind();
            ddl_Group.Items.Add(new ListItem("--不限--", ""));
            ddl_Group.SelectedValue = "";

            if (group > -1)
            {
                ddl_Group.SelectedValue = group.ToS();
                ddl_Group.Enabled = false;
            }
            if (enable > -1)
            {
                ddl_Enabled.SelectedValue = enable.ToS();
                ddl_Enabled.Enabled = false;
            }

            pager.PageSize = SystemSetting.MagageListSize;


            var q = from l in ent.User where l.Group==1|| l.Group==3 select l;

            if (!ddl_Group.SelectedValue.IsNullOrEmpty())
            {
                int groupid = ddl_Group.SelectedValue.ToInt32();
                q = q.Where(p => p.Group == groupid);
            }
            if (!ddl_Enabled.SelectedValue.IsNullOrEmpty())
            {
                bool Enable = ddl_Enabled.SelectedValue == "1";
                q = q.Where(p => p.Enable == Enable);
            }


            pager.RecordCount = q.Count();
            pager.PageSize = SystemSetting.MagageListSize;
            rp_list.DataSource = q.OrderByDescending(p => p.ID).Skip((pager.CurrentPageIndex - 1) * pager.PageSize).Take(pager.PageSize);
            rp_list.DataBind();
            ent.Dispose();

        }

        protected string GetGroupNameByID(int id)
        {
            var gs = UserAction.GetUserGroups().Where(p => p.ID == id).ToList();
            if (gs.Count > 0)
            {
                return gs.First().GroupName;
            }
            else
            {
                return "";
            }
        }

        protected void btn_disable_Click(object sender, EventArgs e)
        {
            enable = WS.RequestInt("enable", -1);
            group = WS.RequestInt("group", -1);
            url = string.Format("List.aspx?ebable={0}&group={1}", enable.ToString(), group.ToString());
            var ids = WS.RequestString("id").Split(',').ToList(); ;
            if (WS.RequestString("id").IsNullOrEmpty())
            {
                Js.AlertAndGoback("您没有选择任何项");
                return;
            }

            DataEntities ent = new DataEntities();

            var qs = from l in ent.User where ids.IndexOf(l.ID.ToString()) > 0 select l;
            foreach (var q in qs)
            {
                q.Enable = false;
            }
            ent.Dispose();
            BindList();

            Js.AlertAndChangUrl("设置成功！", url);
        }

        protected void btn_enable_Click(object sender, EventArgs e)
        {
            enable = WS.RequestInt("enable", -1);
            group = WS.RequestInt("group", -1);
            url = string.Format("List.aspx?ebable={0}&group={1}", enable.ToString(), group.ToString());

            var ids = WS.RequestString("id").Split(',').ToList(); ;
            if (WS.RequestString("id").IsNullOrEmpty())
            {
                Js.AlertAndGoback("您没有选择任何项");
                return;
            }

            DataEntities ent = new DataEntities();

            var qs = from l in ent.User where ids.IndexOf(l.ID.ToString()) > 0 select l;
            foreach (var q in qs)
            {
                q.Enable = true;
            }
            ent.Dispose();
            BindList();
            Js.AlertAndChangUrl("设置成功！", url);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            enable = WS.RequestInt("enable", -1);
            group = WS.RequestInt("group", -1);
            url = string.Format("List.aspx?ebable={0}&group={1}", enable.ToString(), group.ToString());

            //删除
            var ids = WS.RequestString("id").Split(',').ToList().ToInt64();
            if (WS.RequestString("id").IsNullOrEmpty())
            {
                Js.AlertAndGoback("您没有选择任何项");
                return;
            }

            DataEntities ent = new DataEntities();

            foreach (var id in ids)
            {
                var q = (from l in ent.User where l.ID == id select l).FirstOrDefault();
                var resumes = from l in ent.JobResumeInfo where l.UserID == q.ID select l;
                var apps = from l in ent.JobApplicationRecord where l.UserID == q.ID select l;

                ent.DeleteObjects(resumes);
                ent.DeleteObjects(apps);
                ent.DeleteObject(q);
            }
            ent.SaveChanges();
            ent.Dispose();

            Js.AlertAndChangUrl("删除成功！", url);
        }

        protected void btn_Search_Click(object sender, EventArgs e)
        {
            BindList();
        }
    }
}