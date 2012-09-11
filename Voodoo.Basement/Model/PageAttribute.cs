using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Voodoo.Basement
{
    public class PageAttribute
    {
        /// <summary>
        /// 页面标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public string UpdateTime { get; set; }

        /// <summary>
        /// 关键词
        /// </summary>
        public string Keyword { get; set; }

        /// <summary>
        /// 说明
        /// </summary>
        public string Description { get; set; }

    }
}
