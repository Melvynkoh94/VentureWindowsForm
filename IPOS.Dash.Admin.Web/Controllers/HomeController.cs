using IPOS.Dash.Admin.Data;
using IPOS.Dash.Admin.Service;
using IPOS.Dash.Admin.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IPOS.Dash.Admin.Web.Controllers
{
    public class WipoHagueController : Controller
    {
        public ActionResult List()
        {
            WipoHagueService service = new WipoHagueService();
            List<FCT_DS_WIPOHague> dataList = service.GetAll();

            List<WipoHagueViewModel> wipoList = new List<WipoHagueViewModel>();
            foreach(FCT_DS_WIPOHague currentData in dataList)
            {
                WipoHagueViewModel wipo = new WipoHagueViewModel();
                wipo.Id = currentData.Id;                
                wipo.InternationalRegistrations = currentData.IntlRegistrations;
                wipoList.Add(wipo);
            }

            return View(wipoList);
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