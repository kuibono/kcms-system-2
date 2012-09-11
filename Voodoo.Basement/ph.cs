using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Voodoo.Basement
{
    public class ph
    {
        #region 字段
        /// <summary>
        /// 表
        /// </summary>
        public string Tables { get; set; }

        /// <summary>
        /// 主键
        /// </summary>
        public string PrimaryKey { get; set; }

        /// <summary>
        /// 排序语句
        /// </summary>
        public string Sort { get; set; }

        /// <summary>
        /// 当前页码
        /// </summary>
        public int CurrentPage { get; set; }

        /// <summary>
        /// 每页记录数
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// 字段
        /// </summary>
        public string Fields { get; set; }

        /// <summary>
        /// 条件语句
        /// </summary>
        public string Filter { get; set; }

        /// <summary>
        /// 分组语句
        /// </summary>
        public string group { get; set; }
        #endregion

        /// <summary>
        /// 分页后的记录
        /// </summary>
        /// <returns></returns>
        public DataTable GetTable()
        {
            return Voodoo.Setting.DataBase.GetHelper().PageListViewSort(this.Tables,
                this.PrimaryKey,
                this.Sort,
                this.CurrentPage,
                this.PageSize,
                this.Fields,
                this.Filter,
                this.group);
        }

        /// <summary>
        /// 记录条数
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            return Voodoo.Setting.DataBase.GetHelper().PageCountSort(this.Tables,
                this.Filter,
                this.group);
        }
    }
}
