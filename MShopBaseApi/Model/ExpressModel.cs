using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MShopBaseApi.Model
{
    /// <summary>
    /// 物流表
    /// </summary>
    public class ExpressModel
    {
            public int ExpressId { get; set; }         //主键
            public string ExpBH { get; set; }          //物流编号
            public string ExpCompany { get; set; }     //公司名称
            public string ExpInfo { get; set; }        //物流信息 
    }
}
