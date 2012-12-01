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

namespace Web.e.admin.Product
{
    public partial class List : AdminBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (DataEntities ent = new DataEntities())
            {
                var store = ClassID.GetStore();
                var cls = from l in ent.Class where l.ModelID == 7 select new { l.ID, l.ClassName };
                store.DataSource = cls;
                store.DataBind();
            }
            if (!X.IsAjaxRequest)
            {
                AddTime.Value = DateTime.Now;
                Enable.Checked = true;
                ClickCount.Value = 0;
                OrderIndex.Value = 9999;
               

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

            var n = obj.ToObject<Voodoo.Basement.Product>();
            //n.Content = n.Content.AsciiToNative().HtmlDeCode();
            if (n.ID <= 0)
            {
                ent.AddToProduct(n);
            }
            else
            {
                var n_obj = (from l in ent.Product where l.ID == n.ID select l).First();

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

            var n = (from l in ent.Product where l.ID == id select l).FirstOrDefault();
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
                var n = (from l in ent.Product where l.ID == id select l).First();
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

            var s = from l in ent.Product select l;

            int clsID = WS.RequestInt("class");
            if (clsID > 0)
            {
                s = from l in s where l.ClassID == clsID select l;
            }



            if (s_Name.Text.IsNullOrEmpty() == false) { s = s.Where(p => p.Name.Contains(s_Name.Text)); }

            if (s_Intro.Text.IsNullOrEmpty() == false) { s = s.Where(p => p.Intro.Contains(s_Intro.Text)); }

            if (s_Enable.Text.IsNullOrEmpty() == false)
            {
                bool enable = s_Enable.SelectedItem.Value.ToBoolean();
                s = s.Where(p => p.Enable==enable);
            }
            if (s_SetTop.Text.IsNullOrEmpty() == false)
            {
                bool settop = s_SetTop.SelectedItem.Value.ToBoolean();
                s = s.Where(p => p.SetTop==settop);
            }

            if (s_Key.Text.Length > 0)
            {
                s = from l in s
                    where
                    l.ClassName.Contains(s_Key.Text) ||
                    l.Name.Contains(s_Key.Text) ||
                    l.Specification.Contains(s_Key.Text) ||
                    l.Units.Contains(s_Key.Text) ||
                    l.ProduceLocation.Contains(s_Key.Text) ||
                    l.FaceImage.Contains(s_Key.Text) ||
                    l.Contact.Contains(s_Key.Text) ||
                    l.Tel.Contains(s_Key.Text) ||
                    l.Intro.Contains(s_Key.Text)
                    select l;
            }

            store.DataSource = s.OrderByDescending(p => p.ID).ToList();
            store.DataBind();
        }

        protected void Form_Reset(object sender, DirectEventArgs e)
        {
            FormPanel1.SetValues(new Voodoo.Basement.Product());
            FormPanel1.Title = "新增";
        }

        protected void Form_Save(object sender, DirectEventArgs e)
        {
            using (DataEntities ent = new DataEntities())
            {
                var n = new Voodoo.Basement.Product();
                try
                {
                    int id = ID.Text.ToInt32();
                    n = (from l in ent.Product where l.ID == id select l).First();
                }
                catch { }

                n.AddTime = AddTime.Value.ToDateTime();
                n.ClassID = ClassID.SelectedItem.Value.ToInt32();
                n.ClassName = ClassID.SelectedItem.Text;
                n.ClickCount = ClickCount.Value.ToInt32();
                n.Contact = Contact.Text;
                n.Enable = Enable.Checked;
                //n.FaceImage = "";

                

                n.Intro = Intro.Text;
                n.Name = Name.Text;
                n.OrderIndex = OrderIndex.Value.ToInt32();
                n.Price = Price.Value.ToDecimal();
                n.ProduceLocation = ProduceLocation.Text;
                n.SetTop = SetTop.Checked;
                n.Specification = Specification.Text;
                n.Tel = Tel.Text;
                n.Units = Units.Text;
                if (n.ID <= 0)
                {
                    ent.AddToProduct(n);
                }
                ent.SaveChanges();

                if (FaceImage.HasFile)
                {
                    string fileName = string.Format("/u/products/{0}.jpg", n.ID);
                    Voodoo.Basement.BasePage.UpLoadImage(FaceImage.PostedFile, fileName, 194, 204);
                    ent.SaveChanges();
                }

                this.GridPanel1.Store.Primary.CommitChanges();
                this.BindData();
                TabPanel1.SetActiveTab(0);
                FormPanel1.Title = "新增";
                FormPanel1.Reset();
                X.Msg.Notify("消息", "保存成功！").Show();

            }
        }

        protected void Add_Click(object sender, DirectEventArgs e)
        {
            FormPanel1.SetValues(new Voodoo.Basement.Product());
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
                    var n = (from l in ent.Product where l.ID == id select l).First();
                    ent.DeleteObject(n);
                }
                catch { }
            }
            ent.SaveChanges();
            ent.Dispose();
            this.BindData();
            X.Msg.Notify("消息", "删除成功！").Show();
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

        protected void Cancel_Click(object sender, DirectEventArgs e)
        {
            FormPanel1.SetValues(new Voodoo.Basement.Product());
            FormPanel1.Title = "新增";
            TabPanel1.SetActiveTab(0);
        }
    }
}
