using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using Voodoo;
using Voodoo.Basement;
using Voodoo.Setting;
using System.IO;
using Voodoo.IO;

namespace Web.e.post.question
{
    public partial class NewQuestion : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataEntities ent = new DataEntities();
            User u = UserAction.opuser;
            if (u.ID <= 0)
            {
                Js.AlertAndChangUrl("对不起，您没有登录，请登陆后进行提问！", "/");
                return;

            }

            UserGroup g = (from l in ent.UserGroup where l.ID == u.Group select l).FirstOrDefault();
            if (g.MaxPost <= 0)
            {
                Js.AlertAndGoback("对不起，您没有提问的权限！如有疑问，请联系管理员");
                return;
            }

            

            if (!IsPostBack)
            {
                var cls = NewsAction.NewsClass;
                cls = cls.Where(p => p.EnablePost==true && p.IsLeafClass==true && p.ModelID == 3).ToList();
                ddl_Class.DataSource = cls;
                ddl_Class.DataTextField = "ClassName";
                ddl_Class.DataValueField = "id";
                ddl_Class.DataBind();

                int rclass = WS.RequestInt("class");
                if (rclass > 0)
                {
                    ddl_Class.SelectedValue = rclass.ToS();
                    ddl_Class.Enabled = false;
                }
            }
            ent.Dispose();
        }

        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            DataEntities ent = new DataEntities();

            if (UserAction.HasPostRight(ddl_Class.SelectedValue.ToInt32()) == false)
            {
                Js.AlertAndGoback("对不起，对于本栏目您没有提问的权限！如有疑问，请联系管理员");
                ent.Dispose();
                return;
            }

            User u=UserAction.opuser;
            int rclass = WS.RequestInt("ddl_Class", WS.RequestInt("class"));
            string content = WS.RequestString("txt_Content").TrimDbDangerousChar().Trim().HtmlDeCode();
            string title = WS.RequestString("txt_Title").TrimDbDangerousChar().Trim();

            if (rclass < 0)
            {
                Js.AlertAndGoback("栏目不能为空");
                return;
            }
            if (content.IsNullOrEmpty())
            {
                Js.AlertAndGoback("提问内容不能为空");
                return;
            }
            if (title.IsNullOrEmpty())
            {
                Js.AlertAndGoback("标题不能为空");
                return;
            }

            Question qs = new Question();
            qs.AskTime = DateTime.Now;
            qs.ClassID = rclass;
            qs.ClickCount = 0;
            qs.Content = content;
            qs.Title = title;
            qs.UserID = u.ID;
            qs.UserName = u.UserName;
            qs.ZtID = 0;
            ent.AddToQuestion(qs);
            ent.SaveChanges();

            CreatePage.CreateContentPage(qs, qs.GetClass());
            CreatePage.CreateListPage(qs.GetClass(), 1);
            string url = BasePage.GetQuestionUrl(qs, qs.GetClass());
            ent.Dispose();

            Js.AlertAndChangUrl("提问发布成功！", url);
        }
    }
}
