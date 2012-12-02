using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Voodoo.Basement.Routing
{
    public class RewriteRule
    {

        public ExpAndTarget NewsClass { get; set; }

        public ExpAndTarget NewsPage { get; set; }

        public ExpAndTarget ImageClass { get; set; }

        public ExpAndTarget ImagePage { get; set; }

        public ExpAndTarget QuestionClass { get; set; }

        public ExpAndTarget QuestionPage { get; set; }

        public ExpAndTarget BookClass { get; set; }

        public ExpAndTarget BookInfo { get; set; }

        public ExpAndTarget BookChapter { get; set; }

        public ExpAndTarget BookChapterTxt { get; set; }


        public ExpAndTarget JobClass { get; set; }

        public ExpAndTarget JobPost { get; set; }

        public ExpAndTarget JobCompany { get; set; }


        public ExpAndTarget MovieClass { get; set; }

        public ExpAndTarget MovieInfo { get; set; }

        public ExpAndTarget MovieBaiduPlay { get; set; }

        public ExpAndTarget MovieKuaibPlay { get; set; }

        public ExpAndTarget MovieDramaPlay { get; set; }

        public ExpAndTarget ProductList { get; set; }

        public ExpAndTarget Product { get; set; }


        /// <summary>
        /// 系统参数配置文件路径
        /// </summary>
        private static string settingPath = System.Web.HttpContext.Current.Server.MapPath("~/Config/RewriteRule.xml");


        /// <summary>
        /// 获取
        /// </summary>
        /// <returns></returns>
        public static RewriteRule Get()
        {
            try
            {
                if (Voodoo.Cache.Cache.GetCache("_RewriteRuleSetting") == null)
                {
                    Voodoo.Cache.Cache.SetCache("_RewriteRuleSetting", (RewriteRule)Voodoo.IO.XML.Read(typeof(RewriteRule), settingPath), settingPath);
                }

                return (RewriteRule)Voodoo.Cache.Cache.GetCache("_RewriteRuleSetting");
            }
            catch
            {
                return new RewriteRule();
            }
        }

        /// <summary>
        /// 保存
        /// </summary>
        public void Save()
        {
            Voodoo.IO.XML.SaveSerialize(this, settingPath);
        }
    }
}
