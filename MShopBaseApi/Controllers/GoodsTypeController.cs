using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MShopBaseApi.Model;

namespace MShopBaseApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoodsTypeController : ControllerBase
    {
        public List<GoodsTypeModel> Getlb(int id=0)
        {
            string sql = $"SELECT a.GoodsTypeId,a.GoodTypeName,b.GoodsTypeId,b.GoodTypeName as Ername FROM goodstype a LEFT JOIN goodstype b ON b.GoodsTypeId = a.GoodsTypePid where 1=1 ";
            if (id!=0)
            {
                sql += $" and  b.GoodsTypeId={id} ";
            }
            
            List<GoodsTypeModel> good = DBHelper.GetToList<GoodsTypeModel>(sql);
            return good;
        }
    }
}
