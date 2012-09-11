using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Voodoo;
using Voodoo.Basement;
using System.IO;

namespace Web.e.api
{
    public partial class getClass : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string ClassName=WS.RequestString("class");
            int Model=WS.RequestInt("m",4);
            if (ClassName.Length == 0)
            {
                return;
            }

            Class cls = ClassAction.Classes.Where(p => p.ClassName == ClassName && p.ModelID == Model).FirstOrDefault();
            if (cls.ID <= 0)
            {
                //cls.ClassForder = PinyinHelper.GetPinyin(ClassName);
                cls.ClassForder = ClassName;
                cls.ClassKeywords = ClassName;
                cls.ClassName = ClassName;
                cls.ModelID = Model;
                cls.IsLeafClass = true;
                cls.ModelID = Model;
                cls.ShowInNav = true;
                using (DataEntities ent = new DataEntities())
                {
                    ent.AddToClass(cls);
                    ent.SaveChanges();
                    Voodoo.Cache.Cache.Clear("_NewClassList");
                }
            }
            Response.Clear();
            Response.Write(Voodoo.IO.XML.Serialize(cls));
        }
    }
}
