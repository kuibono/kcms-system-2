using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Voodoo.Basement
{
    /// <summary>
    /// 采集剧集用到的实体
    /// </summary>
    public class Drama
    {
        public string Title { get; set; }

        public string Url { get; set; }

        /// <summary>
        /// 类型，快播或者百度
        /// </summary>
        public string Type { get; set; }
    }
}
