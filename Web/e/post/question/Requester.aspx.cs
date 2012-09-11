using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Voodoo;
using Voodoo.Basement;

namespace Web.e.post.question
{
    public partial class Requester : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int questionID = WS.RequestInt("qid", 1);
            string userName = WS.RequestString("name").TrimDbDangerousChar();
            string tel = WS.RequestString("tel").TrimDbDangerousChar();
            string content = WS.RequestString("content").TrimDbDangerousChar();

            SaveAnswer(questionID, userName, tel, content);
        }

        protected void SaveAnswer(int QuestionID, string UserName, string Tel, string Content)
        {
            DataEntities ent = new DataEntities();
            Answer a = new Answer();
            a.Agree = 0;
            a.AnswerTime = DateTime.UtcNow.AddHours(8);
            a.Content = Content;
            //a.Email = "";
            a.QuestionID = QuestionID;
            //a.Tel = Tel;
            a.UserName = UserName;
            a.UserID = 0;

            ent.AddToAnswer(a);
            ent.SaveChanges();
            ent.Dispose();
            Js.AlertAndGoback("消息已经发送，感谢您的支持！");
        }
    }
}