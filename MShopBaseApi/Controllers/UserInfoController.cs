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

            string sql = $"insert into userinfo(Uname,usex,uimg,openId) values('{m.Uname}','{m.Usex}','{m.UImg}','{m.openId}')";
            int n =  DBHelper.ExecuteNonQuery(sql);
            if (n>0)
            {
               int c=   Get(m.openId);
                return c;
            }
            else
            {
                return 0;
            }
        }
        /// <summary>
        /// 显示
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]

        public int Get(string openId)
        {
            string sql = $"select UId from userinfo where openId ='{openId}'";
            if (DBHelper.ExecuteScalar(sql) != null)
            {
                return Convert.ToInt32(DBHelper.ExecuteScalar(sql));
            }
           else
            {
                return 0;
            }
        }
    }
}
