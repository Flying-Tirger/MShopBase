using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MShopBaseApi.Controllers
{
    /// <summary>
    /// 商品表
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class GoodsController : ControllerBase
    {
        /// <summary>
        /// 商品显示
        /// </summary>
        /// <param name="Lid"></param>
        /// <param name="Goname"></param>
        /// <returns></returns>
        public List<GoodsGoodtype> Get(int Lid=0,string Goname=null)
        {
            string sql = $"SELECT * FROM goods join goodstype on goods.GTypeId=goodstype.GoodsTypeId where 1=1 ";
            if (Lid!=0)
            {
                sql+= $" and goods.GTypeId={Lid} ";
            }
            if (Goname!=null)
            {
                Goname = '"' + Goname + '"';
                sql += $" and  LOCATE({Goname},goods.GName)";
            }
            List<GoodsGoodtype> good = DBHelper.GetToList<GoodsGoodtype>(sql);
            return good;
        }
        public class GoodsGoodtype
        {
            public int Gid { get; set; }
            /// <summary>
            /// 商品编号
            /// </summary>
            public string GHB { get; set; }
            /// <summary>
            /// 商品名称
            /// </summary>
            public string GName { get; set; }
            /// <summary>
            /// 商品价格
            /// </summary>
            public float GPrice { get; set; }
            /// <summary>
            /// 商品图片
            /// </summary>
            public string GImg { get; set; }
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
            /// 类型名称
            /// </summary>
            public string GoodTypeName { get; set; }
        }

      
    }
}
