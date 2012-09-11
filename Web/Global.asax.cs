using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Routing;
using Voodoo.Basement;

namespace Web
{
    public class Global : System.Web.HttpApplication
    {
        protected void RegisterRoutes(RouteCollection routes)
        {
            //http://hi.baidu.com/roleya/blog/item/9a4aeafa9a87b4c9b58f312d.html
            //使用路由功能需要修改Web.Config
            //<httpModules>
            // <add name="ScriptModule" type="System.Web.Handlers.ScriptModule, System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35"/>
            // <add name="Session" type="System.Web.SessionState.SessionStateModule"/>
            // <add name="UrlRoutingModule" type="System.Web.Routing.UrlRoutingModule,System.Web.Routing,Version=3.5.0.0,Culture=neutral,PublicKeyToken=31BF3856AD364E35"/>
            //</httpModules>
            routes.Add(new Route("category/{id}",new RouteHandler("~/Default.aspx")));
            routes.Add(new Route("news/{id}/{page}",new RouteHandler("~/Default.aspx")));
            routes.Add(new Route("news/{year}/{month}/{day}", new RouteHandler("~/Default.aspx")));
            routes.Add(new Route("search", new RouteHandler("~/Default.aspx")));
        }
        protected void Application_Start(object sender, EventArgs e)
        {
            RegisterRoutes(RouteTable.Routes); //RouteTable.Routes就是路由规则的集合，RouteTable就是系统定义的全局的静态路由表了
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}