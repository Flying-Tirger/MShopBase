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
    public class ProfileeController : ControllerBase
    {
        /// <summary>
        /// 显示
        /// </summary>
        /// <param name="id">全部数据</param>
        /// <param name="pid">反填</param>
        /// <returns></returns>
        [HttpGet]
        public List<ProfileeModel> GetPf(int id = -1, int pid = -1,int Trudd=0)
        {
            try
            {
                string msg = $"ProfileeController 进行了查询 数据为 id={id},pid={pid},trudd={Trudd}";
                LogHelper.Logger.Info(msg);
                string sql = string.Format("select PfId,PfName,PfAddres,PfPhone,PfState,UserId  from profilee  join userinfo  on profilee.UserId = userinfo.UId where 1 = 1 ");
                //判断数据
                if (id != -1)
                {
                    sql += string.Format(" and  UserId = '{0}' ", id);
                }
                if (pid != -1)
                {
                    //反填
                    sql += string.Format("  and   PfId='{0}'", pid);
                }
                if (Trudd != 0)
                {
                    string.Format(" and profilee.PfState=true");
                }
                List<ProfileeModel> list = DBHelper.GetToList<ProfileeModel>(sql);
                return list;
            }
            catch (Exception ex)
            {
                string msg = $"错误ProfileeController 进行了查询 数据为 id={id},pid={pid},trudd={Trudd}";
                LogHelper.Logger.Error(msg,ex);
                throw;
            }
           
        }

        /// <summary>
        /// 添加地址
        /// </summary>
        /// <param name="list">界面获取的值</param>
        /// <returns>然后传入到sql里进行添加</returns>
        // POST: api/Profilee
        [HttpPost]
        public int PostPf([FromBody]ProfileeModel list, bool zhuang, int uid, int tid)
        {
            try
            {

                zhuang = list.PfState;
                uid = list.UserId;
                tid = list.PfId;
                string msg = $"ProfileeController 进行了添加   数据为 list={JsonConvert.SerializeObject(list)},zhuan={zhuang},uid={uid},tid={tid}";
                LogHelper.Logger.Info(msg);
                string sql = $"insert into Profilee(PfName,pfAddres,PfPhone,PfState,UserId) values('{list.PfName}','{list.PfAddres}','{list.PfPhone}',{list.PfState},'{list.UserId}')";

                if (zhuang == true)
                {
                    string sql1 = $"update Profilee set PfState = false  WHERE PfId!={tid} and UserId = {uid} ";
                    DBHelper.ExecuteNonQuery(sql1);
                }
                int n = DBHelper.ExecuteNonQuery(sql);
                return n;
            }
            catch (Exception ex)
            {
                string msg = $"ProfileeController 进行了添加   数据为 list={JsonConvert.SerializeObject(list)},zhuan={zhuang},uid={uid},tid={tid}";
                LogHelper.Logger.Error(msg,ex);
                throw;
            }
          
        }

        // PUT: api/Profilee/5
        [HttpPut]
        public int PutPf(ProfileeModel list, bool zhuang, int uid, int tid)
        {
            try
            {
                zhuang = list.PfState;
                uid = list.UserId;
                tid = list.PfId;
                string msg = $"ProfileeController 进行了修改   数据为 list={JsonConvert.SerializeObject(list)},zhuan={zhuang},uid={uid},tid={tid}";
                LogHelper.Logger.Info(msg);
                string sql = $"update Profilee set PfName='{list.PfName}',pfAddres='{list.PfAddres}',PfPhone='{list.PfPhone}',PfState={list.PfState} where 1=1  and UserId='{list.UserId}' and PfId='{list.PfId}' ";
                if (zhuang == true)
                {
                    string sql1 = $"update Profilee set PfState = false  WHERE PfId!={tid} and UserId = {uid} ";
                    DBHelper.ExecuteNonQuery(sql1);
                }

                int n = DBHelper.ExecuteNonQuery(sql);
                return n;
            }
            catch (Exception ex)
            {
                string msg = $"错误ProfileeController 进行了修改   数据为 list={JsonConvert.SerializeObject(list)},zhuan={zhuang},uid={uid},tid={tid}";
                LogHelper.Logger.Error(msg,ex);
                throw;
            }
          

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete]
        public int DeletePf(int id)
        {
            try
            {
                string msg = $"ProfileeController 进行了删除数据为 id={id}";
                LogHelper.Logger.Info(msg);
                string sql = $@"delete from Profilee where PfId='{id}'";
                int n = DBHelper.ExecuteNonQuery(sql);
                return n;
            }
            catch (Exception ex)
            {
                string msg = $"错误ProfileeController 进行了删除数据为 id={id}";
                LogHelper.Logger.Error(msg,ex);
                throw;
            }
         
        }
    }
}
