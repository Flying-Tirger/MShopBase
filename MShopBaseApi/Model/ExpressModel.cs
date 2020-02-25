using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MShopBaseApi.Model
{
    /// <summary>
    /// 收货地址表
    /// </summary>
    public class ExpressModel
    {

        /// <summary>
        /// 地址表Id
        /// </summary>
        public int PfId { get; set; }
        /// <summary>
        /// 联系人名称
        /// </summary>
        public string PfName { get; set; }
        /// <summary>
        ///全面详细地址
        /// </summary>
        public string PfAddres { get; set; }
        /// <summary>
        /// 手机号码
        /// </summary>
        public string PfPhone { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        public bool PfState { get; set; }
        /// <summary>
        /// 连接用户表
        /// </summary>
        public int UserId { get; set; }
    }
}
