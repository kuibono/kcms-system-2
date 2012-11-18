using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Voodoo;
using Voodoo.Basement;
namespace Web.Dynamic.Book
{
    public partial class Class : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                int id = WS.RequestInt("id");
                string name = WS.RequestString("name");
                int page = WS.RequestInt("page", 1);
                var cls = ClassAction.Classes.Where(p => p.ID == id||p.ClassName==name).First();

                TemplateHelper th = new TemplateHelper();
                Response.Clear();
                Response.Write(th.CreateListPage(cls, page));
            }
            catch
            {
                throw new Exception("没有找到这个分类");
            }
        }
    }
}