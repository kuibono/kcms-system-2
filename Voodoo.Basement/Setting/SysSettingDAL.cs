using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

using Voodoo;
using Voodoo.Cache;

namespace Voodoo.Basement.Setting
{
    public class SysSettingDAL
    {
        /// <summary>
        /// 系统参数配置文件路径
        /// </summary>
        protected static string settingPath = System.Web.HttpContext.Current.Server.MapPath("~/Config/SysSetting.xml");

        /// <summary>
        /// 反序列化系统参数
        /// </summary>
        /// <returns></returns>
        public static SysSetting GetSetting()
        {
            if (Voodoo.Cache.Cache.GetCache("_SysSetting") == null)
            {
                Voodoo.Cache.Cache.SetCache("_SysSetting", (SysSetting)Voodoo.IO.XML.Read(typeof(SysSetting), settingPath), settingPath);
            }

            return (SysSetting)Voodoo.Cache.Cache.GetCache("_SysSetting");
        }

        /// <summary>
        /// 设置系统参数序列化
        /// </summary>
        /// <param name="set"></param>
        public static void SetSetting(SysSetting set)
        {
            Voodoo.IO.XML.SaveSerialize(set, settingPath);
        }


    }
}
