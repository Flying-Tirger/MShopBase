using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MShopBaseApi.Model
{
    /// <summary>
    /// 用户表
    /// </summary>
    public class UserInfoModel
    {
        /// <summary>
        /// 用户编号
        /// </summary>
        public int Uid { get; set; }
        /// <summary>
        /// 用户昵称
        /// </summary>
        public string Uname { get; set; }
        /// <summary>
        /// 用户性别
        /// </summary>
        public bool Usex { get; set; }
        /// <summary>
        /// 头像
        /// </summary>
        public string UImg { get; set; }
        /// <summary>
        /// 用户唯一标识
        /// </summary>
        public string openId { get; set; }

    }
}
