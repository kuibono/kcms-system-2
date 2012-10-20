using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Reflection;
using Voodoo;
using Voodoo.Basement;
namespace Web.e
{
    public partial class Test : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (DataEntities ent = new DataEntities())
            {
                var xx = from l in ent.JobCompany select l;
                Response.Write(xx.GetType());
            }

        }

        public string Tests(string a, int b)
        {
            return "good" + a + b;
        }

        protected object ExecMethod(string className, string methodName, object[] objParas)
        {
            Type t = Type.GetType(className);
            /*实例化这个类*/
            ConstructorInfo constructor = t.GetConstructor(new Type[0]);//将得到的类型传给一个新建的构造器类型变量
            object obj = constructor.Invoke(new object[0]);//使用构造器对象来创建对象
            /*执行Insert方法*/
            MethodInfo m = t.GetMethod(methodName);
            return m.Invoke(obj, objParas);
        }



        protected void Button1_Click(object sender, EventArgs e)
        {
            //Class cls = ClassView.GetModelList().First();
            //Voodoo.Html.Class.ClassPage cp = new Voodoo.Html.Class.ClassPage();
            //string path = cp.GetHtml(cls);
            //Response.Write(path);

        }
    }

    public class Contact
    {
        public string UserName { get; set; }

        public string Tel { get; set; }
    }
}
