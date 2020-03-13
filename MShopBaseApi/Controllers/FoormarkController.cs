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
            try
            {
                string msg = $"FoormarkController 进行了添加操作 数据为{JsonConvert.SerializeObject(model)}";
                LogHelper.Logger.Info(msg);
                string sql = string.Format("insert into foormark(EDate,GoodsId,userInfoId) values('{0}','{1}','{2}')", DateTime.Now.ToString("yyyy-MM-dd"), model.GoodsId, model.userInfoId);
                int n = DBHelper.ExecuteNonQuery(sql);
                return n;
            }
            catch (Exception ex)
            {
                string msg = $"错误FoormarkController 进行了添加操作 数据为{JsonConvert.SerializeObject(model)}";
                LogHelper.Logger.Error(msg,ex);
                throw;
            }

        }
        [HttpGet]
        public List<FoortGoods> Get(int id)
        {
            try
            {
                string msg = $"FoormarkController 进行了查询操作 数据为id={id}";
                LogHelper.Logger.Info(msg);
                string sql = $"select FId,GImg1,EDate,GoodsId,userInfoId from foormark join goods on foormark.GoodsId = goods.`Gid` join userinfo on userinfo.UId = foormark.userInfoId where userInfoId = {id}";
                return DBHelper.GetToList<FoortGoods>(sql);
            }
            catch (Exception ex)
            {
                string msg = $"FoormarkController 进行了查询操作 数据为id={id}";
                LogHelper.Logger.Error(msg,ex);
                throw;
            }

        }
        [HttpDelete]
        public int Delete(string id)
        {
            try
            {
                string msg = $"FoormarkController 进行了删除操作 数据为id={id}";
                LogHelper.Logger.Info(msg);
                string sql = $"delete from foormark where FId in ({id})";
                return DBHelper.ExecuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                string msg = $"FoormarkController 进行了删除操作 数据为id={id}";
                LogHelper.Logger.Error(msg,ex);
                throw;
            }

        }
    }

    public class FoortGoods
    {
        /// <summary>
        /// 足迹表id
        /// </summary>
        public int FId { get; set; }
        /// <summary>
        /// 足迹日期
        /// </summary>
        public DateTime EDate { get; set; }
        /// <summary>
        /// 连接商品表
        /// </summary>
        public int GoodsId { get; set; }
        /// <summary>
        /// 连接用户表
        /// </summary>
        public int userInfoId { get; set; }
        /// <summary>
        /// 商品图片
        /// </summary>

        public string GImg1 { get; set; }

    }
}
