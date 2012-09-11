using System;
using System.Collections;
using System.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Reflection;

using System.IO;
using Voodoo;
using Voodoo.other;
using Voodoo.IO;
using Voodoo.other.SEO;
using Voodoo.Basement;
using Voodoo.Net.XmlRpc;

namespace Web.e.api
{
    public partial class xmlrpcV2 : System.Web.UI.Page
    {
        //protected void Page_Load(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        var req = WS.RequestPing();
        //        List<object> parms = new List<object>();
        //        foreach (var par in req.@params)
        //        {
        //            parms.Add(
        //                par.value.DeSerializeTo(Type.GetType(par.type))
        //            );
        //        }
        //        var result = ExecMethod("Web.e.api.xmlrpcV2", req.methodName, parms.ToArray());

                
        //        methodResponse mr = new methodResponse();
        //        mr.result = result.SerializeToXML();
        //        mr.type = result.GetType().ToS();


        //        Response.Clear();
        //        Response.Write(mr.SerializeToXML());
        //    }
        //    catch { }

        //}

        ///// <summary>
        ///// 执行某个方法
        ///// </summary>
        ///// <param name="className">类，包括命名空间</param>
        ///// <param name="methodName">方法名</param>
        ///// <param name="objParas">参数</param>
        ///// <returns></returns>
        //protected object ExecMethod(string className, string methodName, object[] objParas)
        //{
        //    Type t = typeof(xmlrpcV2);
        //    /*实例化这个类*/
        //    ConstructorInfo constructor = t.GetConstructor(new Type[0]);//将得到的类型传给一个新建的构造器类型变量
        //    object obj = constructor.Invoke(new object[0]);//使用构造器对象来创建对象
        //    /*执行Insert方法*/
        //    MethodInfo m = t.GetMethod(methodName);
        //    return m.Invoke(obj, objParas);
        //}

        ///// <summary>
        ///// 搜索书籍
        ///// </summary>
        ///// <param name="str_sql"></param>
        ///// <returns></returns>
        //public List<Book> FindBook(string str_sql)
        //{
        //    return BookView.GetModelList(str_sql);
        //}

        ///// <summary>
        ///// 验证书籍是否存在
        ///// </summary>
        ///// <param name="str_sql"></param>
        ///// <returns></returns>
        //public bool BookExit(string str_sql)
        //{
        //    return  BookView.Exist(str_sql);
        //}

        //public string BookAdd(Book book)
        //{
        //    BookView.Insert(book);
        //    return XML.Serialize(true);
        //}

        //public string BookEdit(Book book)
        //{
        //    BookView.Update(book);
        //    return XML.Serialize(true);
        //}

    
    }
}