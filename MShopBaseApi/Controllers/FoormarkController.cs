using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MShopBaseApi.Model;
namespace MShopBaseApi.Controllers
{
    /// <summary>
    /// 足迹表
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class FoormarkController : ControllerBase
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model">添加时获取的数据</param>
        /// <returns></returns>
        [HttpPost]
        public int PostFr(FoormarkModel model)
        {
            string sql = string.Format("insert into foormark(EDate,GoodsId,userInfoId) values('{0}','{1}','{2}')", DateTime.Now.ToString("yyyy-MM-dd"), model.GoodsId, model.userInfoId);
            int n = DBHelper.ExecuteNonQuery(sql);
            return n;
        }
    }
}
