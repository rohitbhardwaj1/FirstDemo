using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstDemo.Controllers
{
    public class AddTempDataController : Controller
    {
        // GET: AddTempData
        public ActionResult Index()
        {
            string name = TempData["data"].ToString();
            return View();
        }
    }
}