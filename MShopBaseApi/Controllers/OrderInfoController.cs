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
    public class OrderInfoController : ControllerBase
    {
        /// <summary>
        /// 显示
        /// </summary>
        /// <param name="OrderSid"></param>
        /// <returns></returns>
        [HttpGet]
        public List<OrderInfoModel> GetOrder(int OrderSid=-1,int OId = -1)
        {
            string sql = $"select o.OrderState,o.OrderBH,o.OrderNum,o.OrderTime,g.GPrice,g.GName,p.pfAddres,p.PfName,p.PfPhone,e.ExpCompany,e.ExpInfo from orderinfo as o join goods as g on o.GoodsId=g.`Gid `JOIN express as e ON o.ExpressId =e.ExpressId JOIN profilee p ON o.ProfileeId = p.PfId JOIN userinfo as u ON o.UserId = u.UId WHERE 1=1";
            if (OrderSid != -1)
            {
                sql += $" and OrderState = {OrderSid}";
            }
            if (OId != -1)
            {
                sql += $" and OId = {OId}";
            }
            List<OrderInfoModel> list = DBHelper.GetToList<OrderInfoModel>(sql);
            return list;
        }   
        /// <summary>
        /// 添加
        /// </summary> 
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public int PostOrder(OrderInfoModel model)
        {
            string sql = $"insert into orderinfo VALUES(DEFAULT(orderinfo.OId),'{model.OrderBH}',{model.GoodsId},{model.OrderNum},'{model.OrderTime}',{model.OrderState},{model.ExpressId},{model.ProfileeId},{model.UserId})";
            int n = DBHelper.ExecuteNonQuery(sql);
            return n; 
        }

}
}
