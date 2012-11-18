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
                rbl_BookList.SelectedValue = s.BookClass.id;
                rbl_BookInfo.SelectedValue = s.BookInfo.id;
                rbl_Chapter.SelectedValue = s.BookChapter.id;
            }
            catch { }
            
        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            var s = RewriteRule.Get();

            
            s.BookClass = new ExpAndTarget() { id=rbl_BookList.SelectedValue, Exp = rbl_BookList.SelectedItem.Text }; //new KeyValuePair<string,string>(txt_BookClass.Text,txt2_BookClass.Text);
            s.BookInfo = new ExpAndTarget() { id=rbl_BookInfo.ID, Exp = rbl_BookInfo.SelectedItem.Text }; //new KeyValuePair<string,string>(txt_BookInfo.Text,txt2_BookInfo.Text);
            s.BookChapter = new ExpAndTarget() { id=rbl_Chapter.ID, Exp = rbl_Chapter.SelectedItem.Text }; //new KeyValuePair<string,string>(txt_BookChapter.Text,txt2_BookChapter.Text);
            
            s.Save();
            Js.AlertAndChangUrl("保存成功！", "RewriteSetting.aspx");
        }
    }
}