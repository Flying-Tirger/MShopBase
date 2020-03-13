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
            try
            {
                List<GoodsNum> list = new List<GoodsNum>();
                string msg = $"GoodsNumController 进行了查询 数据为 GName={GName}";
                LogHelper.Logger.Info(msg);
                if (RedisHelper.Exist("GoodsNum"))
                {
                    string sql = $"SELECT GName FROM GOODS";
                    RedisHelper.Set<List<GoodsNum>>("GoodsNum", DBHelper.GetToList<GoodsNum>(sql));
                    msg = $"GoodsNumController 进行了对redis中GoodsNum 数据机芯更新";
                    LogHelper.Logger.Info(msg);
                }
                return list.Where(s => s.GName.Contains(GName)).Take(10).ToList();
            }
            catch (Exception ex)
            {
                string msg = $"错误GoodsNumController 进行了查询 数据为 GName={GName}";
                LogHelper.Logger.Info(msg,ex);
                throw;
            }      

        }
    }
    public class GoodsNum
    {
        public string GName { get; set; }
    }
}