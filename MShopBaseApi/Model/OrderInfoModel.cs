using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MShopBaseApi.Model
{
    /// <summary>
    /// 订单表
    /// </summary>
    public class OrderInfoModel
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int OId { get; set; }
        /// <summary>
        /// 订单编号
        /// </summary>
        public string OrderBH { get; set; }
        /// <summary>
        /// 连接商品表
        /// </summary>
        public int GoodSId { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public int GoodNum { get; set; }
        /// <summary>
        /// 下单时间
        /// </summary>
        public DateTime OrderTime { get; set; }
        /// <summary>
        /// 支付状态
        /// </summary>
        public int OrderState { get; set; }
        /// <summary>
        /// 连接物流表
        /// </summary>
        public int ExpressId { get; set; }
        /// <summary>
        /// 连接地址表
        /// </summary>
        public int ProfileeId { get; set; }
        /// <summary>
        /// 连接用户表
        /// </summary>
        public int UserId { get; set; }           
    }
}
