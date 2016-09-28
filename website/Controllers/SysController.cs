using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    public class SysController : Controller
    {
        #region /sys        后台首页
        public IActionResult Index()
        {
            if (Request.Cookies.ContainsKey("Login") && Request.Cookies["Login"].ToString() == "true")
            {
                return View();
            }
            else
            {
                return View("Login");
            }
        }
        #endregion
    }
}
