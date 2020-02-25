using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MShopBaseApi.Model
{
    /// <summary>
    /// 商品类别表
    /// </summary>
    public class GoodsTypeModel
    {
        public int GoodsTypeId { get; set; }
        /// <summary>
        /// 类型名称
        /// </summary>
        public string GoodTypeName { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        public bool GTState { get; set; }
    }
}
