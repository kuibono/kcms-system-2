using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Voodoo.Basement.Collect
{
    public class MovieRule
    {
        public string Name { get; set; }

        public string SiteName { get; set; }

        public bool IsMovie { get; set; }

        /// <summary>
        /// 是否搜索系统规则
        /// </summary>
        public bool IsSearchRule { get; set; }

        /// <summary>
        /// 使用Tag作为分类
        /// </summary>
        public bool UseTagAsClass { get; set; }

        /// <summary>
        /// 使用地区作为分类
        /// </summary>
        public bool UseLocationAsClass { get; set; }

        /// <summary>
        /// 默认分类名称
        /// </summary>
        public string DefaultClass { get; set; }

        /// <summary>
        /// 编码
        /// </summary>
        public string Encoding { get; set; }

        /// <summary>
        /// 列表页面地址
        /// </summary>
        public string ListPageUrl { get; set; }

        /// <summary>
        /// 下一个列表规则
        /// </summary>
        public string NextListRule { get; set; }

        /// <summary>
        /// 列表中的影视信息规则
        /// </summary>
        public string ListInfoRule { get; set; }

        /// <summary>
        /// 内容页面的剧集信息规则
        /// </summary>
        public string InfoRule { get; set; }

        /// <summary>
        /// 快播区域规则
        /// </summary>
        public string KuaibAreaRule { get; set; }

        /// <summary>
        /// 百度影音区域规则
        /// </summary>
        public string BaiduAreaRule { get; set; }

        /// <summary>
        /// 快播剧集规则
        /// </summary>
        public string KuaibDramaRule { get; set; }

        /// <summary>
        /// 百度影音剧集规则
        /// </summary>
        public string BaiduDramaRule { get; set; }

        /// <summary>
        /// 播放页面快播地址规则
        /// </summary>
        public string DramaPageKuaibRule { get; set; }

        /// <summary>
        /// 播放页面百度地址规则
        /// </summary>
        public string DramaPageBaiduRule { get; set; }

        /// <summary>
        /// 资源文件中的快播地址规则
        /// </summary>
        public string SourceKuaibRule { get; set; }

        /// <summary>
        /// 资源文件中的百度影音地址规则
        /// </summary>
        public string SourceBaiduRule { get; set; }

        ///实体复制
        public MovieRule Clone()
        {
            return (MovieRule)this.MemberwiseClone();
        }
    }
}
