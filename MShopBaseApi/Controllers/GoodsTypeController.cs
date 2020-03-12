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

        public List<GoodsTypeModel> Getlb(int id = 0)
        {
            try
            {
                List<GoodsTypeModel> goodtype = new List<GoodsTypeModel>();
                string msg = $"GoodsTypeController 进行了类别显示";
                LogHelper.Logger.Info(msg);
                if (!RedisHelper.Exist("goodtype"))
                {
                    string sql = $"SELECT a.GoodsTypeId,a.GoodTypeName,b.GoodsTypeId as Typeid,b.GoodTypeName as Ername FROM goodstype a LEFT JOIN goodstype b ON b.GoodsTypeId = a.GoodsTypePid";
                    RedisHelper.Set<List<GoodsTypeModel>>("goodtype", DBHelper.GetToList<GoodsTypeModel>(sql));
                    msg = $"GoodsTypeController 向redis存储了数据";
                    LogHelper.Logger.Info(msg);
                }
                if (id != 0)
                {
                    goodtype = RedisHelper.Get<List<GoodsTypeModel>>("goodtype").Where(s => s.Typeid.Equals(id)).ToList();
                }
                return goodtype;
            }
            catch (Exception ex)
            {
                LogHelper.Logger.Error($"GoodsTypeController 方法 用户查看了name={id}类别", ex);
                throw;
            }
        }
    }
}
