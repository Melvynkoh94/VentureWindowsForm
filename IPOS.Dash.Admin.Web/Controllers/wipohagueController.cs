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

        // GET: wipohague
        public ActionResult Index()
        {

            List<WipoHagueViewModel> wipoHagueList = new List<WipoHagueViewModel>();
            List<FCT_DS_WIPOHague> dataModelList = svc.GetAll();
            
            foreach (FCT_DS_WIPOHague item in dataModelList)
            {
                // Do mapping here
                WipoHagueViewModel wipo = new WipoHagueViewModel();
                wipo.Id = item.Id;
                wipo.GroupType = item.GroupType;
                wipo.ReportingDate = item.ReportingDate;
                wipo.DesignsIntlRegistrations = item.DesignsIntlRegistrations;
            
                wipo.IntlApplications = item.IntlApplications;
                wipo.DesignsIntlApplications = item.DesignsIntlApplications;
                wipo.Renewals = item.Renewals;
                wipo.DesignsRenewals = item.DesignsRenewals;

                wipo.CreatedDate = item.CreatedDate;
                if (item.LastUpdateDate != null) {
                    wipo.LastUpdateDate = item.LastUpdateDate;
                }
                             
                wipo.IsDeleted = item.IsDeleted;
                wipo.DeletedDate = item.DeletedDate;


                wipoHagueList.Add(wipo);                
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
            FCT_DS_WIPOHague info = new FCT_DS_WIPOHague();
            return View(info);
        }

        // POST: wipohague/Create
        [HttpPost]

        public ActionResult Create(FCT_DS_WIPOHague createnew)
        {
            try
            {
                svc.Create(createnew);
                return RedirectToAction("Index");
            }
            catch
            {
                throw;
            }
        }

        [HttpGet]
        // GET: wipohague/Edit/5
        public ActionResult Update(Guid? Id)
        {
            WipoHagueViewModel vm = new WipoHagueViewModel();

            FCT_DS_WIPOHague update = svc.Update(Id);
            vm.GroupType = update.GroupType;
            vm.ReportingDate = update.ReportingDate;
            vm.DesignsIntlRegistrations = update.DesignsIntlRegistrations;
            vm.IntlApplications = update.IntlApplications;
            vm.DesignsIntlApplications = update.DesignsIntlApplications;
            vm.Renewals = update.Renewals;
            vm.DesignsRenewals = update.DesignsRenewals;
            vm.CreatedDate = update.CreatedDate;
            vm.LastUpdateDate = update.LastUpdateDate;
            vm.IsDeleted = update.IsDeleted;
            vm.DeletedDate = update.DeletedDate;
            return View(vm);
        }

        // POST: wipohague/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Update([Bind(Include = "Id,GroupType,ReportingDate,IntlRegistrations,DesignsIntlRegistrations,IntlApplications,DesignsIntlApplications,"+
            "Renewals,DesignsRenewals,CreatedDate,LastUpdateDate,IsDeleted,DeletedDate")] FCT_DS_WIPOHague update)
        {
            try
            {
                FCT_DS_WIPOHague updated = svc.Update(update);
                if (updated == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View(update);
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
    }
}
