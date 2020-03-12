using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MShopBaseApi.Model;
using Newtonsoft.Json;
namespace MShopBaseApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserInfoController : ControllerBase
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        [HttpPost]
        public int Post(UserInfoModel m)
        {
            try
            {
                string sql = $"insert into userinfo(Uname,usex,uimg,openId) values('{m.Uname}','{m.Usex}','{m.UImg}','{m.openId}')";
                int n = DBHelper.ExecuteNonQuery(sql);
                string mes = $"UserInfoController 进行添加添加数据为{JsonConvert.SerializeObject(m)}  添加了{n}条数据";
                LogHelper.Logger.Info(mes);
                if (n > 0)
                {
                    int c = Get(m.openId);
                    return c;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                string mes = $"UserInfoController";
                LogHelper.Logger.Error(mes,ex);
                throw;
            }
          
           
        }
        /// <summary>
        /// 显示
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]

        public int Get(string Uname)
        {
            try
            {
                string sql = $"select UId from userinfo where openId ='{openId}'";
                string mes = $"UserInfoController 进行查询openId={openId}的信息";
                LogHelper.Logger.Info(mes);
                if (DBHelper.ExecuteScalar(sql) != null)
                {
                    return Convert.ToInt32(DBHelper.ExecuteScalar(sql));
                }
                else
                {
                    return 0;
                }
               
            }
            catch (Exception ex)
            {
                string mes = $"UserInfoController ";
                LogHelper.Logger.Info(mes,ex);
                throw;
            }
           
        }
    }
}
