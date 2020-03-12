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
    [Route("api/[controller]")]
    [ApiController]
    public class OrderInfoController : ControllerBase
    {
       [HttpGet]


        /// <summary>
        /// 显示
        /// </summary>
        /// <param name="OrderSid"></param>
        /// <returns></returns>
        public List<OrderInfoS> GetOrder(int OrderSid=-1,int OId = -1)
        {
            try
            {
                string msg = $"OrderInfoController 进行了查询操作 条件为OrderSid={OrderSid} and OId={OId}";
                LogHelper.Logger.Info(msg);
                    string sql = $"select g.Gid, g.GImg1,o.OId, o.OrderState,o.OrderBH,o.OrderNum,o.OrderTime,g.GPrice,g.GName,p.PfAddres,p.PfName,p.PfPhone,e.ExpCompany,e.ExpInfo,e.ExpressId from orderinfo as o join goods as g on o.GoodsId=g.Gid JOIN express as e ON o.ExpressId =e.ExpressId JOIN profilee p ON o.ProfileeId = p.PfId JOIN userinfo as u ON o.UserId = u.UId where 1=1";     
                if (OrderSid != -1)
                {
                    sql += $" and OrderState = {OrderSid}"; 
                }
                if (OId != -1)
                {
                    sql += $" and OId = {OId}";
                }

                List<OrderInfoS> list = DBHelper.GetToList<OrderInfoS>(sql);
                return list;
            }
            catch (Exception ex)
            {
                LogHelper.Logger.Error($"错误OrderInfoController Get方法 OrderSid={OrderSid} ,OId={OId}", ex);
                throw;
            }
        }   
        /// <summary>
        /// 添加
        /// </summary> 
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public int PostOrder(OrderInfoModel model)
        {
            try
            {
                string sql = $"insert into orderinfo VALUES(DEFAULT(orderinfo.OId),'{model.OrderBH}',{model.GoodsId},{model.OrderNum},NOW(),{model.OrderState},{model.ExpressId},{model.ProfileeId},{model.UserId})";
                int n = DBHelper.ExecuteNonQuery(sql);
                string ordera = $"OrderInfoController 进行添加添加数据为{JsonConvert.SerializeObject(model)}  添加了{n}条数据";
                LogHelper.Logger.Info(ordera);
                return n;
            }
            
            catch (Exception ex)
            {
                LogHelper.Logger.Error($"错误OrderInfoController Post方法 数据为{model.ToString()}", ex);
                throw;
            }
        }
        [HttpDelete]
        public int DelOrder(int aid)
        {

            try
            {
                string sql = $"delete from orderinfo where orderinfo.oid='{aid}'";
                int n = DBHelper.ExecuteNonQuery(sql);
                string orders = $"OrderInfoController 进行了删除数据 条件为oid={aid}";
                LogHelper.Logger.Info(orders);
                return n;
            }

            catch (Exception ex)
            {
                LogHelper.Logger.Error($"错误OrderInfoController Delete方法 oid={aid}", ex);
                throw;
            }
            
        }
}

  

    public class OrderInfoS
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int OId { get; set; }
        /// <summary>
        /// 订单编号
        /// </summary>
        public string OrderBH { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public int OrderNum { get; set; }
        /// <summary>
        /// 下单时间
        /// </summary>
        public DateTime OrderTime { get; set; }
        /// <summary>
        /// 支付状态
        /// </summary>
        public int OrderState { get; set; }
        /// <summary>
        /// 商品名称
        /// </summary>
        public string GName { get; set; }
        /// <summary>
        /// 商品价格
        /// </summary>
        public decimal GPrice { get; set; }
        /// <summary>
        /// 联系人名称
        /// </summary>
        public string PfName { get; set; }
        /// <summary>
        ///全面详细地址
        /// </summary>
        public string PfAddres { get; set; }
        /// <summary>
        /// 手机号码
        /// </summary>
        public string PfPhone { get; set; }
        /// <summary>
        /// 公司名称
        /// </summary>
        public string ExpCompany { get; set; }
        /// <summary>
        /// 物流信息
        /// </summary>
        public string ExpInfo { get; set; }
        /// <summary>
        /// 物流Id
        /// </summary>
        public int ExpressId { get; set; }
        /// 商品图片
        /// </summary>
        public string GImg1 { get; set; }
        /// <summary>
        /// 商品Id
        /// </summary>
        public int Gid { get; set; }
    }
}
