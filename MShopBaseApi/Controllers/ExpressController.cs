using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MShopBaseApi.Model;
using Newtonsoft.Json;
namespace MShopBaseApi.Controllers
{
    /// <summary>
    /// 物流表
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ExpressController : ControllerBase
    {
        /// <summary>
        /// 显示
        /// </summary>
        /// <param name="OrderSid"></param>
        /// <returns></returns>
        [HttpGet]
        public List<ExpressModel> GetExpress(int EId = 0)
        {
            try
            {
                string msg = $"ExpressController 进行了查询操作 数据为{EId}";
                LogHelper.Logger.Info(msg);
                string sql = $"SELECT e.ExpBH,e.ExpCompany,e.ExpInfo from express as e WHERE E.ExpressId = {EId}";
                if (EId != 0)
                {
                    sql += $" and ExpressId = {EId}";
                }
                List<ExpressModel> list = DBHelper.GetToList<ExpressModel>(sql);
                return list;
            }
            catch (Exception ex)
            {
                string msg = $"错误ExpressController 进行了查询操作 数据为{EId}";
                LogHelper.Logger.Error(msg,ex);
                throw;
            }

        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public int PostExpress(ExpressModel model)
        {
            try
            {
                string msg = $"ExpressController 进行了添加操作 数据为{JsonConvert.SerializeObject(model)}";
                LogHelper.Logger.Info(msg);
                string sql = $"insert into express VALUES(DEFAULT(express.ExpressId),'{model.ExpBH}','{model.ExpCompany}','{model.ExpInfo}')";

                int n = DBHelper.ExecuteNonQuery(sql);
                return n;
            }
            catch (Exception ex)
            {
                string msg = $"错误ExpressController 进行了添加操作 数据为{JsonConvert.SerializeObject(model)}";
                LogHelper.Logger.Error(msg,ex);
                throw;
            }

        }
    }
}
