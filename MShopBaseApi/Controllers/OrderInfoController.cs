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
        public List<OrderInfoS> GetOrder(int OrderSid=-1,int OId = 0)
        {
            string sql = $"select g.GImg1,o.OId, o.OrderState,o.OrderBH,o.OrderNum,o.OrderTime,g.GPrice,g.GName,p.pfAddres,p.PfName,p.PfPhone,e.ExpCompany,e.ExpInfo,e.ExpressId from orderinfo as o join goods as g on o.GoodsId=g.Gid JOIN express as e ON o.ExpressId =e.ExpressId JOIN profilee p ON o.ProfileeId = p.PfId JOIN userinfo as u ON o.UserId = u.UId WHERE 1=1";
            if (OrderSid != -1)
            {
                sql += $" and OrderState = {OrderSid}";
            }
            if (OId != 0)
            {
                sql += $" and OId = {OId}";
            }
            List<OrderInfoS> list = DBHelper.GetToList<OrderInfoS>(sql);
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
        public int PutOrder(int Oid)
        {
            string sql = $"update orderinfo set orderinfo.OrderState = 3 where orderinfo.OId='{Oid}'";
            int n = DBHelper.ExecuteNonQuery(sql);
            return n;
        }
        public int DelOrder(int oid) {
            string sql = $"delete from orderinfo where orderinfo.OId='{oid}' ";
            int n = DBHelper.ExecuteNonQuery(sql);
            return n; 
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
    }
}
