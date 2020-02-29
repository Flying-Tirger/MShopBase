using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MShopBaseApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoodsController : ControllerBase
    {
        public List<GoodsGoodtype> Get(int Lid=0,string Goname=null)
        {
            string sql = $"SELECT * FROM goods join goodstype on goods.GTypeId=goodstype.GoodsTypeId where 1=1 ";
            if (Lid!=0)
            {
                sql+= $" and goods.GTypeId={Lid} ";
            }
            if (Goname!=null)
            {
                sql += $" and  LOCATE('{Goname}',goods.GName )";
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
            public decimal GPrice { get; set; }
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
