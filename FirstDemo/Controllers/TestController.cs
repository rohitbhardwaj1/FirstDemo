using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstDemo.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(int? id)
        {
            string[] name = new String[] { "kamlesh", "Ramesh", "Manish" };
            string[] name2 = new String[] { "kamlesh2", "Ramesh", "Manish2" };
            //string value = String.Join(",",MergeName.Uni(name, name2));
            //value.ToString();
            TempData["data"] = "Kamlesh";
            return RedirectToAction("Index", "AddTempData");
            
        }
    }
}