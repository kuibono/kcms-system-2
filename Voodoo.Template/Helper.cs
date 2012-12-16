using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NVelocity;
using NVelocity.App;
using NVelocity.Runtime;
using Commons.Collections;
using System.IO;

namespace Voodoo.Template
{
    public class Helper
    {
        public Helper()
        {
            this.Items = new Dictionary<string, object>();
        }
        /// <summary>
        /// 模版变量
        /// </summary>
        public Dictionary<string, object> Items { get; set; }

        /// <summary>
        /// 模版文件
        /// </summary>
        public string TemplateName { get; set; }

        /// <summary>
        /// 生成内容
        /// </summary>
        /// <returns></returns>
        public string GetString()
        {
            VelocityEngine ve = new VelocityEngine();//模板引擎实例化
            ExtendedProperties ep = new ExtendedProperties();//模板引擎参数实例化
            
            ep.AddProperty("file.resource.loader.modificationCheckInterval", (Int64)300); //缓存时间(秒)
            ve.Init(ep);

            VelocityContext vc = new VelocityContext(); //当前的数据信息载体集合
            
            foreach (var item in Items)
            {
                vc.Put(item.Key, item.Value);
            }
            TextWriter writer = new StringWriter();
            ve.MergeTemplate(TemplateName, "utf-8", vc, writer);

            return writer.ToString();
        }
    }
}
