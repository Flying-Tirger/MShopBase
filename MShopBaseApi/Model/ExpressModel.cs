using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MShopBaseApi.Model
{
    /// <summary>
    /// 物流表
    /// </summary>
    public class ExpressModel
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int ExpressId { get; set; }
        /// <summary>
        /// 物流编号
        /// </summary>
        public string ExpBH { get; set; }
        /// <summary>
        /// 公司名称
        /// </summary>
        public string ExpCompany { get; set; }
        /// <summary>
        /// 物流信息
        /// </summary>
        public string ExpInfo { get; set; }         
    }
}
