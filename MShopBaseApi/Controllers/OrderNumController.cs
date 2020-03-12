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
    public class OrderNumController : ControllerBase
    {
        [HttpGet]
        public OrderNum GetOrder(int UserId)
        {
            string sql = $"select count(IF(orderstate!=-1,true,null)) as AllNum,count(IF(orderstate=1,true,null)) as OneNum,count(IF(orderstate=2,true,null)) as TwoNum,count(IF(orderstate=3,true,null)) as ThreeNum from orderinfo  where UserId = { UserId } ";
            return DBHelper.GetToList<OrderNum>(sql).FirstOrDefault();
        }
    }
    public class OrderNum
    {
        public Int64 AllNum { get; set; }
        public Int64 OneNum { get; set; }
        public Int64 TwoNum { get; set; }
        public Int64 ThreeNum { get; set; }

    }
}