using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MShopBaseApi.Model
{
    /// <summary>
    /// 订单表
    /// </summary>
    public class OrderInfoModel
    {
            public int OId { get; set; }            //主键
            public string OrderBH { get; set; }     //订单编号
            public int GoodSId { get; set; }        //连接商品表
            public int GoodNum { get; set; }        //数量
            public DateTime OrderTime { get; set; } //下单时间
            public int OrderState { get; set; }     //支付状态
            public int ExpressId { get; set; }      //连接物流表
            public int ProfileeId { get; set; }     //连接地址表
            public int UserId { get; set; }         //连接用户表  
    }
}
