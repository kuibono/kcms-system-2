using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Voodoo;
using Voodoo.Security;

namespace Voodoo.Basement
{
    /// <summary>
    /// 所用到的扩展方法
    /// </summary>
    public static class ExtendClass
    {
        #region 通过用户获取群组
        /// <summary>
        /// 通过用户获取群组
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static UserGroup GetGroup(this User user)
        {
            return UserAction.GetUserGroups().Where(p => p.ID == user.Group).First();
        }
        #endregion
    }
}
