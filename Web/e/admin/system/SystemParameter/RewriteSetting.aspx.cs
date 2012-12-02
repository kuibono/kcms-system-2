using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Voodoo;
using Voodoo.Basement;

using Voodoo.Basement.Routing;
namespace Web.e.admin.system.SystemParameter
{
    public partial class RewriteSetting : AdminBase
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

            var s = RewriteRule.Get();
            try
            {
                rbl_NewsList.SelectedValue = s.NewsClass.id;
                rbl_News.SelectedValue = s.NewsPage.id;

                rbl_BookList.SelectedValue = s.BookClass.id;
                rbl_BookInfo.SelectedValue = s.BookInfo.id;
                rbl_Chapter.SelectedValue = s.BookChapter.id;

                rbl_ProductList.SelectedValue = s.ProductList.id;
                rbl_Product.SelectedValue = s.Product.id;
            }
            catch { }
            
        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            var s = RewriteRule.Get();

            s.NewsClass = new ExpAndTarget { id=rbl_NewsList.SelectedValue, Exp=rbl_NewsList.SelectedItem.Text };
            s.NewsPage = new ExpAndTarget { id=rbl_News.SelectedValue, Exp=rbl_News.SelectedItem.Text };
            
            s.BookClass = new ExpAndTarget() { id=rbl_BookList.SelectedValue, Exp = rbl_BookList.SelectedItem.Text }; //new KeyValuePair<string,string>(txt_BookClass.Text,txt2_BookClass.Text);
            s.BookInfo = new ExpAndTarget() { id=rbl_BookInfo.SelectedValue, Exp = rbl_BookInfo.SelectedItem.Text }; //new KeyValuePair<string,string>(txt_BookInfo.Text,txt2_BookInfo.Text);
            s.BookChapter = new ExpAndTarget() { id=rbl_Chapter.SelectedValue, Exp = rbl_Chapter.SelectedItem.Text }; //new KeyValuePair<string,string>(txt_BookChapter.Text,txt2_BookChapter.Text);

            s.ProductList = new ExpAndTarget { id = rbl_ProductList.SelectedValue, Exp = rbl_ProductList.SelectedItem.Text };
            s.Product = new ExpAndTarget { id=rbl_Product.SelectedValue, Exp=rbl_Product.SelectedItem.Text };
            s.Save();
            Js.AlertAndChangUrl("保存成功！", "RewriteSetting.aspx");
        }
    }
}