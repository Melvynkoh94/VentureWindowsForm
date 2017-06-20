using IPOS.Dash.Admin.Data;
using IPOS.Dash.Admin.Service;
using IPOS.Dash.Admin.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;


namespace IPOS.Dash.Admin.Web.Controllers
{

    public class WipoHagueController : Controller
    {
        WipoHagueService svc = new WipoHagueService();
      
        public ActionResult Index()
        {

            List<WipoHagueViewModel> wipoHagueList = new List<WipoHagueViewModel>();
            List<FCT_DS_WIPOHague> dataModelList = svc.GetAll();
            
            foreach (FCT_DS_WIPOHague wipo in dataModelList)
            {
                WipoHagueViewModel wipoVM = MapToWipoHagueViewModel(wipo);

                wipoHagueList.Add(wipoVM);
            }

            return View(wipoHagueList);
        }

       
        // GET: wipohague/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        [HttpGet]
        // GET: wipohague/Create
        public ActionResult Create()
        {
            WipoHagueViewModel wipoVM = new WipoHagueViewModel();
            return View(wipoVM);
        }

        // POST: wipohague/Create
        [HttpPost]

        public ActionResult Create(WipoHagueViewModel wipoVM)
        {
            try
            {
                FCT_DS_WIPOHague wipo = new FCT_DS_WIPOHague();
                wipo.ReportingDate = wipoVM.ReportingDate;
                wipo.IntlRegistrations = wipoVM.IntlRegistrations;
                wipo.DesignsIntlRegistrations = wipoVM.DesignsIntlRegistrations;
                wipo.IntlApplications = wipoVM.IntlApplications;
                wipo.DesignsIntlApplications = wipoVM.DesignsIntlApplications;
                wipo.Renewals = wipoVM.Renewals;
                wipo.DesignsRenewals = wipoVM.DesignsRenewals;

                bool result = svc.Create(wipo);
                if (result == true)
                {
                    return RedirectToAction("Index");
                }
                else
                    return View(wipoVM);                
            }
            catch
            {
                throw;
            }
        }

        [HttpGet]
        // GET: wipohague/Update/5
        public ActionResult Update(Guid? Id)
        {
            WipoHagueViewModel wipoVM = new WipoHagueViewModel();

            FCT_DS_WIPOHague wipo = svc.Retrieve(Id);

            wipoVM = MapToWipoHagueViewModel(wipo);
           
            return View(wipoVM);
        }

        // POST: wipohague/Update/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(WipoHagueViewModel wipoVM)
        {
            try
            {
                FCT_DS_WIPOHague wipo = svc.Retrieve(wipoVM.Id);

                if (!ModelState.IsValid)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                wipo.ReportingDate = wipoVM.ReportingDate;
                wipo.IntlRegistrations = wipoVM.IntlRegistrations;
                wipo.DesignsIntlRegistrations = wipoVM.DesignsIntlRegistrations;
                wipo.IntlApplications = wipoVM.IntlApplications;
                wipo.DesignsIntlApplications = wipoVM.DesignsIntlApplications;
                wipo.Renewals = wipoVM.Renewals;
                wipo.DesignsRenewals = wipoVM.DesignsRenewals;

                svc.Update(wipo);
               
                return RedirectToAction("Index");
            }
            catch
            {
                return View(wipoVM);
            }
        }

        // GET: wipohague/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: wipohague/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        private static WipoHagueViewModel MapToWipoHagueViewModel(FCT_DS_WIPOHague wipo)
        {
            WipoHagueViewModel wipoVM = new WipoHagueViewModel();
            wipoVM.Id = wipo.Id;
            wipoVM.GroupType = wipo.GroupType;
            wipoVM.ReportingDate = wipo.ReportingDate;
            wipoVM.IntlRegistrations = wipo.IntlRegistrations;
            wipoVM.DesignsIntlRegistrations = wipo.DesignsIntlRegistrations;
            wipoVM.IntlApplications = wipo.IntlApplications;
            wipoVM.DesignsIntlApplications = wipo.DesignsIntlApplications;
            wipoVM.Renewals = wipo.Renewals;
            wipoVM.DesignsRenewals = wipo.DesignsRenewals;
            wipoVM.CreatedDate = wipo.CreatedDate;
            wipoVM.LastUpdateDate = wipo.LastUpdateDate;
            wipoVM.IsDeleted = wipo.IsDeleted;
            wipoVM.DeletedDate = wipo.DeletedDate;
            return wipoVM;
        }

    }
}
