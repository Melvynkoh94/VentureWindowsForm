using IPOS.Dash.Admin.Data;
using IPOS.Dash.Admin.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IPOS.Dash.Admin.Web.Controllers
{
    public class HomeController : Controller
    {


        public ActionResult Index()
        {
            WipoHagueService wservice = new WipoHagueService();

            List<FCT_DS_WIPOHague> list = wservice.GetAll();


            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}