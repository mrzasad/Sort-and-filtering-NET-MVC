using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using trustedi10_mvc_Assessment_asad.Models;

namespace trustedi10_mvc_Assessment_asad.Controllers
{
    public class HomeController : Controller
    {
        Helper.HomeBLL homeBLL = new Helper.HomeBLL();
        public ActionResult Index()
        {
            List<recDetailsModel> list = new List<recDetailsModel>();
            list = homeBLL.GetRecDetails();
            return View(list);
        }        
    }
}