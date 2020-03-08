using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace MShopBaseApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpGet]
        public string GetCode(string json_code)
        {
            string serviceAddress = "https://api.weixin.qq.com/sns/jscode2session?appid=" + "wx201d6375fc4fc1ca" + "&secret="
                + "8e1d31d32991bc7275c76168cb6a10b4" + "&js_code=" + json_code + "&grant_type=authorization_code";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(serviceAddress);
            request.Method = "GET";
            request.ContentType = "text/html;charset=utf-8";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, System.Text.Encoding.UTF8);
            string retString = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myResponseStream.Close();
            FormatData d = JsonConvert.DeserializeObject<FormatData>(retString);
            return d.openid;
        }
    }
    class FormatData
    {
        public string session_key { get; set; }

        public string openid { get; set; }
    }
}