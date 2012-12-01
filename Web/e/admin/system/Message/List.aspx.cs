
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using System.Reflection;
using Newtonsoft.Json.Linq;
using System.Text;
using System.IO;
using Voodoo;
using Voodoo.Basement;

namespace Web.e.admin.system.Message
{
    public partial class List : AdminBase
    {
         protected void Page_Load(object sender, EventArgs e)
        {
            if (!X.IsAjaxRequest)
            {
                this.BindData();
            }
        }
        protected void MyData_Refresh(object sender, StoreRefreshDataEventArgs e)
        {
            this.BindData();
        }

        [DirectMethod(Namespace = "server")]
        public void AfterEdit(JObject obj)
        {
            DataEntities ent = new DataEntities();

            var n = obj.ToObject<Voodoo.Basement.Message>();
            //n.Content = n.Content.AsciiToNative().HtmlDeCode();
            if (n.ID <= 0)
            {
                ent.AddToMessage(n);
            }
            else
            {
                var n_obj = (from l in ent.Message where l.ID == n.ID select l).First();

                PropertyInfo[] ps = n.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
                foreach (PropertyInfo p in ps)
                {
                    object value = p.GetValue(n, null);
                    if (value == null)
                    {
                        continue;
                    }
                    try
                    {
                        p.SetValue(n_obj, value, null);
                    }
                    catch { }

                }

            }
            ent.SaveChanges();

            StringBuilder sb = new StringBuilder();


            this.GridPanel1.Store.Primary.CommitChanges();
            this.BindData();
            TabPanel1.SetActiveTab(0);
            FormPanel1.Title = "新增";
            FormPanel1.Reset();
			 X.Msg.Notify("消息", "保存成功！").Show();
        }

        [DirectMethod(Namespace = "server")]
        public void LoadForm(int id)
        {
            DataEntities ent = new DataEntities();

            var n = (from l in ent.Message where l.ID == id select l).FirstOrDefault();
            FormPanel1.SetValues(n);
            ent.Dispose();
            TabPanel1.SetActiveTab(1);
            FormPanel1.Title = "编辑";
        }

        [DirectMethod(Namespace = "server")]
        public void DeleteItem(int id)
        {
            using (DataEntities ent = new DataEntities())
            {
                var n = (from l in ent.Message where l.ID == id select l).First();
                ent.DeleteObject(n);
                ent.SaveChanges();
            }
            this.BindData();
            X.Msg.Notify("消息", "删除成功！").Show();
        }

        [DirectMethod(Namespace = "server")]
        public void BindData()
        {
            DataEntities ent = new DataEntities();

            var store = this.GridPanel1.GetStore();

            var s = from l in ent.Message select l;




			if (s_UserName.Text.IsNullOrEmpty() == false){ s=s.Where(p=>p.UserName.Contains(s_UserName.Text)); }
			if (s_Email.Text.IsNullOrEmpty() == false){ s=s.Where(p=>p.Email.Contains(s_Email.Text)); }
			if (s_Tel.Text.IsNullOrEmpty() == false){ s=s.Where(p=>p.Tel.Contains(s_Tel.Text)); }
			if (s_Title.Text.IsNullOrEmpty() == false){ s=s.Where(p=>p.Title.Contains(s_Title.Text)); }
			if (s_Chat.Text.IsNullOrEmpty() == false){ s=s.Where(p=>p.Chat.Contains(s_Chat.Text)); }
			if (s_Content.Text.IsNullOrEmpty() == false){ s=s.Where(p=>p.Content.Contains(s_Content.Text)); }

            if (s_Key.Text.Length > 0)
            {
                s = from l in s
                    where 
					l.UserName.Contains(s_Key.Text) ||
					l.Email.Contains(s_Key.Text) ||
					l.Tel.Contains(s_Key.Text) ||
					l.Title.Contains(s_Key.Text) ||
					l.Chat.Contains(s_Key.Text) ||
					l.Content.Contains(s_Key.Text) 
                    select l;
            }

            store.DataSource = s.OrderByDescending(p => p.ID).ToList();
            store.DataBind();
        }
		
		protected void Search(object sender, DirectEventArgs e)
        {
            this.BindData();
        }
		 protected void Cancel_Search(object sender, DirectEventArgs e)
        {
            foreach (var ctr in FormPanel1.Controls)
            {
                if (ctr.GetType() == typeof(TextField))
                {
                    ((TextField)ctr).Text = "";
                }
                if (ctr.GetType() == typeof(ComboBox))
                {
                    ((ComboBox)ctr).Text = "";
                }
            }
            Search(sender, e);

        }
		
        protected void Form_Reset(object sender, DirectEventArgs e)
        {
            FormPanel1.SetValues(new Voodoo.Basement.Message());
            FormPanel1.Title = "新增";
        }

        protected void Add_Click(object sender, DirectEventArgs e)
        {
            FormPanel1.SetValues(new Voodoo.Basement.Message());
            FormPanel1.Title = "新增";
            TabPanel1.SetActiveTab(1);
        }

        protected void On_Remove(object sender, DirectEventArgs e)
        {
            RowSelectionModel sm = this.GridPanel1.SelectionModel.Primary as RowSelectionModel;
            DataEntities ent = new DataEntities();

            foreach (SelectedRow row in sm.SelectedRows)
            {
                try
                {
                    int id = row.RecordID.ToInt32();
                    var n = (from l in ent.Message where l.ID == id select l).First();
                    ent.DeleteObject(n);
                }
                catch { }
            }
            ent.SaveChanges();
            ent.Dispose();
            this.BindData();
			X.Msg.Notify("消息", "删除成功！").Show();
        }

        protected void Cancel_Click(object sender, DirectEventArgs e)
        {
            FormPanel1.SetValues(new Voodoo.Basement.Message());
            FormPanel1.Title = "新增";
            TabPanel1.SetActiveTab(0);
        }
    }
    
}