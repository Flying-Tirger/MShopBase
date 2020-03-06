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
        public List<Gt> Getlb(int id = 0)
        {
            string sql = $"SELECT a.GoodsTypeId,a.GoodTypeName,b.GoodsTypeId as Pid,a.GoodsTypeImg as GoodsTypeImg,b.GoodTypeName as Ername  FROM goodstype a LEFT JOIN goodstype b ON b.GoodsTypeId = a.GoodsTypePid where 1=1 ";
            if (id == 0)
            {
                sql += $" and  a.GoodsTypepId={id} ";
            }
            else
            {
                sql += $" and b.GoodsTypeId={id}";
            }

            List<Gt> good = DBHelper.GetToList<Gt>(sql);
            return good;
        }
        public class Gt
        {
            public int GoodsTypeId { get; set; }
   
            public string GoodTypeName { get; set; }

            public int Pid { get; set; }

            public string GoodsTypeImg { get; set; }

            public string Ername { get; set; }

        }
    }
}
