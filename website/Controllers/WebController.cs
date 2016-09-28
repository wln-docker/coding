using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Wlniao;

namespace Demo.Controllers
{
    public class WebController : XCoreController
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            ViewBag.UseTime = "0ms";
            ViewBag.Title = "Page Title";
            ViewBag.SiteName = " - My Ideploy Application";
            ViewBag.MetaKeyWords = "";
            ViewBag.MetaDescription = "";
            ViewBag.StartTime = DateTime.Now;
            base.OnActionExecuting(context);
        }
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if (ViewBag.StartTime != null)
            {
                TimeSpan ts = DateTime.Now.Subtract(ViewBag.StartTime);
                ViewBag.UseTime = ts.TotalMilliseconds.ToString("F2") + "ms";
            }
            base.OnActionExecuted(context);
        }
        #region Path:/
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IActionResult Home()
        {
            //Wlniao.Caching.Cache.Set("test", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), 30);
            //var test = Wlniao.Caching.Cache.Get("test");
            //var str = "abcd1234";
            //var s1 = Wlniao.Encryptor.AesEncrypt(str, "abcd1234abcd1234");
            //if (!string.IsNullOrEmpty(s1))
            //{
            //    var s2 = Wlniao.Encryptor.AesDecrypt(s1, "abcd1234abcd1234");
            //    if (!string.IsNullOrEmpty(s2))
            //    {
            //    }
            //}

            //ViewBag.Title = "Home";
            return View();
        }
        #endregion

        #region Path:/about
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IActionResult About()
        {
            ViewBag.Title = "About";
            return View();
        }
        #endregion

        #region Path:/contact
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IActionResult Contact()
        {
            ViewBag.Title = "Contact";
            var Name = "未来鸟";
            ViewBag.CnName = Name;
            ViewBag.EnName = Wlniao.OpenApi.Tool.GetChineseSpell(Name);
            return View();
        }
        #endregion


        public IActionResult SysInfo()
        {
            var str = "";
            if (System.Environment.StackTrace == "")
            {
            }
            var en = System.Environment.GetEnvironmentVariables().GetEnumerator();
            while (en.MoveNext())
            {
                str += en.Key + "=" + en.Value + "\n";
            }
            return Content(str);
        }




        #region Path:/debug
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IActionResult Debug()
        {
            var rlt = Wlniao.OpenApi.Wx.GetAccessToken("wxb55a9c37f89941f2", "wlniao");
            return Json(rlt);
        }
        #endregion
    }
}
