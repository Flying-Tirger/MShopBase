using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MShopBaseApi.Model
{
    /// <summary>
    /// 售后表
    /// </summary>
    public class AfterSaleModel
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int Asid { get; set; }
        /// <summary>
        /// 售后状态
        /// </summary>
        public int AsState { get; set; }
        /// <summary>
        /// 申请说明
        /// </summary>
        public string AsRemark { get; set; }
        /// <summary>
        /// 链接用户表
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// 链接订单表  外键
        /// </summary>
        public int OrderId { get; set; }
        /// <summary>
        /// 申请时间
        /// </summary>
        public DateTime ApplyTime { get; set; }
        /// <summary>
        /// 联系方式
        /// </summary>
        public string AsPhone { get; set; }
        /// <summary>
        /// 图片凭证
        /// </summary>
        public string AsImg { get; set; }
       
    }
}
