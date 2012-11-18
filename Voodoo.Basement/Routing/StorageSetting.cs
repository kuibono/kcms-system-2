using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Voodoo.Basement.Routing
{
    public class StorageSetting
    {
        public string NewsClass { get; set; }

        public string NewsPage { get; set; }

        public string ImageClass { get; set; }

        public string ImagePage { get; set; }

        public string QuestionClass { get; set; }

        public string QuestionPage { get; set; }

        public string BookClass { get; set; }

        public string BookInfo { get; set; }

        public string BookChapter { get; set; }

        public string BookChapterTxt { get; set; }


        public string JobClass { get; set; }

        public string JobPost { get; set; }

        public string JobCompany { get; set; }


        public string MovieClass { get; set; }

        public string MovieInfo { get; set; }

        public string MovieBaiduPlay { get; set; }

        public string MovieKuaibPlay { get; set; }

        public string MovieDramaPlay { get; set; }


        /// <summary>
        /// 系统参数配置文件路径
        /// </summary>
        private static string settingPath = System.Web.HttpContext.Current.Server.MapPath("~/Config/RoutingSetting.xml");


        /// <summary>
        /// 获取
        /// </summary>
        /// <returns></returns>
        public static StorageSetting Get()
        {
            try
            {
                if (Voodoo.Cache.Cache.GetCache("_StorageSetting") == null)
                {
                    Voodoo.Cache.Cache.SetCache("_StorageSetting", (StorageSetting)Voodoo.IO.XML.Read(typeof(StorageSetting), settingPath), settingPath);
                }

                return (StorageSetting)Voodoo.Cache.Cache.GetCache("_StorageSetting");
            }
            catch
            {
                return new StorageSetting();
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
