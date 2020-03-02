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
            string sql = $"insert into userinfo('Uname','usex','uimg') values('{m.Uname}','{m.Usex}','{m.UImg}')";
            return DBHelper.ExecuteNonQuery(sql);
        }
        /// <summary>
        /// 显示
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]

        public List<UserInfoModel> Get(int id)
        {
            string sql = $"select * from userinfo where Uid ={id}";
            return DBHelper.GetToList<UserInfoModel>(sql);
        }
    }
}
