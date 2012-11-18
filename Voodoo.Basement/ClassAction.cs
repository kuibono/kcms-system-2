using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Web;
using System.IO;

using Voodoo;
using Voodoo.IO;
namespace Voodoo.Basement
{
    public class ClassAction
    {
        #region 删除栏目
        /// <summary>
        /// 删除栏目
        /// </summary>
        /// <param name="classes"></param>
        /// <returns></returns>
        public static Result DeleteClass(List<Class> classes)
        {
            DataEntities ent = new DataEntities();
            Result r = new Result();
            foreach (var cls in classes)
            {
                DirectoryInfo dir = new DirectoryInfo(HttpContext.Current.Server.MapPath(BasePage.GetClassUrl(cls)));
                if (dir.Exists)
                {
                    dir.Delete(true);
                }
                ent.DeleteObject(cls);
            }
            ent.SaveChanges();
            ent.Dispose();

            r.Success = true;
            r.Text = string.Format("成功删除{0}个栏目",classes.Count);
            return r;
        }
        #endregion 

        /// <summary>
        /// 系统中的所有栏目
        /// </summary>
        public static List<Class> Classes
        {
            get
            {
                using (DataEntities ent = new DataEntities())
                {
                    return (from l in ent.Class select l).ToList();
                }
            }
        }
    }
}
