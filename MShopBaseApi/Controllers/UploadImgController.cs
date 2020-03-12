using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MShopBaseApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadImgController : Controller
    {
        public JsonResult Post()
        {
            uploadFile _uploadFile = new uploadFile();
            try
            {
                //获取文件
                var file = Request.Form.Files[0];
                //获取文件名称
                var filecombin = file.FileName.Split('.');
                //判断文件是否为空
                if (file == null || string.IsNullOrEmpty(file.Name) || file.Length == 0 || filecombin.Length < 2)
                {
                    _uploadFile.code = -1;
                    _uploadFile.data = new { src = "" };
                    _uploadFile.msg = "上传错误,请上传正确信息~";
                    return Json(_uploadFile);

                }
                string filePathName = string.Empty;
                //获取文件的绝对路径
                string loaclPath = Directory.GetCurrentDirectory() + "/wwwroot/Upload/img";
                string tempName = Directory.GetCurrentDirectory() + "/wwwroot/Upload/img";
                //获取文件名称
                var tmp = file.FileName;
                var tempIndex = 0;

                while (Directory.Exists(tempName + tmp))
                {
                    tmp = filecombin[0] + "_" + ++tempIndex + "." + filecombin[1];
                }
                filePathName = tmp;
                if (!Directory.Exists(loaclPath))
                    Directory.CreateDirectory(loaclPath);
                //写入文件 将文件复制到文件流保存
                using (var fs = new FileStream(Path.Combine(tempName, filePathName), FileMode.Create))
                {
                    fs.Flush();
                    file.CopyTo(fs);
                }
                _uploadFile.code = 0;
                _uploadFile.data = new { src = Path.Combine("/Upload/img/", filePathName) };  //name = Path.GetFileNameWithoutExtension(file.FileName),   // 获取文件名不含后缀名  
                _uploadFile.msg = "上传成功";
                return Json(_uploadFile.data);
                //return Json("123");
            }
            catch (Exception)
            {
                return Json(_uploadFile);
            }

        }

        public class uploadFile
        {
            public int code { get; set; }
            public string msg { get; set; }
            public dynamic data { get; set; }

        }
    }
}