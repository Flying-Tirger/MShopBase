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
    public class GoodsNumController : ControllerBase
    {
        [HttpGet]
        public List<GoodsNum> Get(string GName)
        {
            string sql = $"SELECT GName FROM GOODS where Gname like '%{GName}%'";
            return DBHelper.GetToList<GoodsNum>(sql);
        }
    }
    public class GoodsNum
    {
        public string GName { get; set; }
    }
}