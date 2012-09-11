using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using CookComputing.XmlRpc;

using Voodoo;
using Voodoo.Net;
using Voodoo.IO;


namespace Voodoo.Basement.Client
{
   
    public class RpcBookHelper
    {

        public void test()
        {
            IMath im = XmlRpcProxyGen.Create<IMath>();
            im.Url = "http://www.fuck.com/e/api/xmlrpcV2.aspx";
            var r = im.SearchBook("极品仙府", "", "");
            
        }
    }



    public interface IMath : IXmlRpcProxy
    {
        [XmlRpcMethod("SearchBook")]
        [return: XmlRpcReturnValue(Description = "搜索书籍")]
        string SearchBook(string a,string b,string c);

        [XmlRpcMethod("BookExist")]
        [return: XmlRpcReturnValue(Description = "书籍是否存在")]
        string BookExist(string Title, string Author);

        [XmlRpcMethod("GetBook")]
        [return: XmlRpcReturnValue(Description = "获取书籍")]
        string GetBook(string Title, string Author);

        [XmlRpcMethod("BookAdd")]
        [return: XmlRpcReturnValue(Description = "添加书籍")]
        string BookAdd(string Title, string Author, int ClassID, string Intro, long Length);



    }
}
