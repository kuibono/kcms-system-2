using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Voodoo;
using Voodoo.Basement;

namespace Web.e.admin.Ad.Ad
{
    public partial class Edit : AdminBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadInfo();
            }
        }

        protected void LoadInfo()
        {
            int group = WS.RequestInt("group");
            long id = WS.RequestLong("id");
            using (DataEntities ent = new DataEntities())
            {
                var gs = from l in ent.AdGroup select l;
                ddl_Group.Items.Clear();
                foreach (var g in gs)
                {
                    ddl_Group.Items.Add(new ListItem(string.Format("{0}({1}*{2})",g.Name,g.width,g.height), g.ID.ToS()));
                }

                if (id > 0)
                {
                    var ad = (from l in ent.Ad where l.ID == id select l).FirstOrDefault();
                    ddl_Group.SelectedValue = ad.GroupID.ToS();
                    txt_Title.Text = ad.Title;
                    txt_Url.Text = ad.Url;
                    Image1.ImageUrl = ad.Image;

                }
            }
        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            long id = WS.RequestLong("id");
            using (DataEntities ent = new DataEntities())
            {
                Voodoo.Basement.Ad ad = new Voodoo.Basement.Ad();
                try
                {
                    ad = (from l in ent.Ad where l.ID == id select l).First();
                }
                catch { }

                ad.GroupID = ddl_Group.SelectedValue.ToInt32();
                ad.Title = txt_Title.Text;
                ad.Url = txt_Url.Text;

                var adgroup = (from l in ent.AdGroup where l.ID == ad.GroupID select l).FirstOrDefault();
                ad.width = adgroup.width;
                ad.height = adgroup.height;

                if (ad.ID <= 0)
                {
                    ent.AddToAd(ad);
                }
                ent.SaveChanges();

                if (FileUpload1.HasFile)
                {
                    string fileName = string.Format("/u/Ad/{0}.jpg", ad.ID.ToS());
                    BasePage.UpLoadImage(FileUpload1.PostedFile, fileName, ad.width.ToInt32(), ad.height.ToInt32());
                    ad.Image = fileName;
                    ent.SaveChanges();
                }

            }

            Js.AlertAndChangUrl("保存成功！", "List.aspx");
        }
    }
}