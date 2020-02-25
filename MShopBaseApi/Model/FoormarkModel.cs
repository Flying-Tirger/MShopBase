using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MShopBaseApi.Model
{
    /// <summary>
    /// 足迹表
    /// </summary>
    public class FoormarkModel
    {
        /// <summary>
        /// 足迹表idad
        /// </summary>
        public int FId { get; set; }
        /// <summary>
        /// 足迹日期
        /// </summary>
        public DateTime EDate { get; set; }
        /// <summary>
        /// 连接商品表
        /// </summary>
        public int GoodsId { get; set; }
    }
}
