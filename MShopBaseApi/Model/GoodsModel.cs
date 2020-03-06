using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MShopBaseApi.Model
{
    /// <summary>
    /// 商品表
    /// </summary>
    public class GoodsModel
    {
        public int Gid { get; set; }
        /// <summary>
        /// 商品编号
        /// </summary>
        public string  GHB { get; set; }
        /// <summary>
        /// 商品名称
        /// </summary>
        public string GName { get; set; }
        /// <summary>
        /// 商品价格
        /// </summary>
        public decimal GPrice { get; set; }
        /// <summary>
        /// 商品图片1
        /// </summary>
        public string GImg1 { get; set; }
        /// <summary>
        /// 商品图片2
        /// </summary>
        public string GImg2 { get; set; }
        /// <summary>
        /// 商品图片3
        /// </summary>
        public string GImg3 { get; set; }
        /// <summary>
        /// 商品评分
        /// </summary>
        public float GGrade { get; set; }
        /// <summary>
        /// 商品销量
        /// </summary>
        public int GSales { get; set; }
        /// <summary>
        /// 外键 商品类别
        /// </summary>
        public int GTypeId { get; set; }
        /// <summary>
        /// 商品运费
        /// </summary>
        public decimal GYunfei { get; set; }
        /// <summary>
        /// 商品库存
        /// </summary>
        public int GKucun { get; set; }
        /// <summary>
        /// 商品简介
        /// </summary>
        public string GSxiang { get; set; }

    }
}
