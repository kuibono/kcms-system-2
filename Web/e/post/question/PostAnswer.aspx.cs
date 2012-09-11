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
    public partial class PostAnswer : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataEntities ent = new DataEntities();

            User u = UserAction.opuser;
            if (u.ID <= 0)
            {
                Js.AlertAndGoback("对不起，您没有登录，请登录后回答！");
                return;
            }

            int qid = WS.RequestInt("qid");
            string content = WS.RequestString("content");
            if (qid <= 0)
            {
                Js.AlertAndGoback("对不起，参数错误，如有疑问，请联系管理员！");
                return;
            }

            Question q = (from l in ent.Question where l.ID == qid select l).FirstOrDefault();
            Class cls = q.GetClass();
            if (UserAction.HasPostRight(cls.ID) == false)
            {
                Js.AlertAndGoback("对不起，对于本栏目您没有回答权限，如有疑问，请联系管理员！");
                return;
            }

            Answer a = new Answer();
            a.Agree = 0;
            a.AnswerTime = DateTime.Now;
            a.Content = content;
            a.QuestionID = qid;
            a.UserID = u.ID;
            a.UserName = u.UserName;

            ent.AddToAnswer(a);
            CreatePage.CreateContentPage(q, q.GetClass());//创建内容页


            ent.Dispose();
            string url = BasePage.GetQuestionUrl(q, q.GetClass());

            Js.AlertAndChangUrl("回答成功！", url);
        }
    }
}
