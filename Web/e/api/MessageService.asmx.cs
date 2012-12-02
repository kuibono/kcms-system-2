using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Voodoo;
using Voodoo.Basement;
namespace Web.e.api
{
    /// <summary>
    /// MessageService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class MessageService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public Result SaveMessage()
        {
            Message msg = new Message();
            msg.Chat = WS.RequestString("chat");
            msg.Content = WS.RequestString("content");
            msg.Email = WS.RequestString("email");
            msg.MessageTime = DateTime.Now;
            msg.Tel = WS.RequestString("tel");
            msg.Title = WS.RequestString("title");
            msg.UserName = WS.RequestString("username");

            if (msg.Content.IsNullOrEmpty())
            {
                return new Result {  Success=true };
            }

            try
            {
                DataEntities ent = new DataEntities();
                ent.AddToMessage(msg);
                ent.SaveChanges();
                return new Result { Success = true };
            }
            catch
            {
                return new Result { Success = false };
            }
        }
    }
}
