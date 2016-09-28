using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace Demo.Controllers
{
    public class XServerController : Wlniao.XServer.XController
    {
        public IActionResult Index()
        {
            var rlt = new Wlniao.ApiResult<Object>();
            rlt.success = true;
            rlt.data = new
            {
                key = GetRequest("key")
                ,
                value = GetRequest("value")
            };
            return Json(rlt);
        }
    }
}
