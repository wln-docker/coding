using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Wlniao;
namespace Demo.Controllers.Api
{
    [Route("api/[controller]/[action]")]
    public class TestController : Controller
    {
        // GET: api/test/list
        [HttpGet]
        public IEnumerable<string> List()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/test/5
        [HttpGet]
        public string Id(int id)
        {
            return "Id=" + id + ",VTime:" + DateTime.Now.ToString();
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        public IActionResult Json()
        {
            var obj = new Obj
            {
                String = "1111"
                ,
                Number = 222
                ,
                Object = new SubObj
                {
                    a = "A"
                    ,
                    b = "B"
                    ,
                    c = "C"
                }
                ,
                List = new List<object>()
                {
                    new { Name="Item1",Sort=1}
                    ,
                    new { Name="Item2",Sort=3}
                    ,
                    new { Name="Item3",Bool=true}
                }
            };
            var str = Wlniao.Json.ToString(obj);
            var obj2 = Wlniao.Json.ToObject<Obj>(str);
            if (obj.Object == obj2.Object)
            {

            }
            return Content(str);
        }

        public IActionResult Convert()
        {
            var str = "";
            str += "\ncvt.IntToHex52(3329837938433200423):" + cvt.IntToHex52(3329837938433200423);
            str += "\ncvt.Hex26ToInt(djowekve):" + cvt.Hex26ToInt("djowekve");
            str += "\ncvt.Hex26ToInt(abcd):" + cvt.Hex26ToInt("abcd");
            str += "\ncvt.Hex26ToInt(Abc):" + cvt.Hex26ToInt("Abc");

            str += "\ncvt.IntToHex52(100):" + cvt.IntToHex52(100);
            var x52 = cvt.IntToHex52(101);
            str += "\ncvt.Hex52ToInt(" + x52 + "):" + cvt.Hex52ToInt(x52);

            str += "\ncvt.IntToHex26(100):" + cvt.IntToHex26(100);
            var x26 = cvt.IntToHex26(101);
            str += "\ncvt.Hex26ToInt(" + x26 + "):" + cvt.Hex26ToInt(x26);           

            log.Fatal("test");
            return Content(str);
        }
    }
    public class SubObj
    {
        public string a { get; set; }
        public string b { get; set; }
        public string c { get; set; }
    }
    public class Obj
    {
        public string String { get; set; }
        public int Number { get; set; }
        public SubObj Object { get; set; }
        public List<object> List { get; set; }
    }
}
