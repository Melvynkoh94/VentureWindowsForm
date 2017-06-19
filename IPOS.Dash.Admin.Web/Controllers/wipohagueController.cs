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
            
            foreach (FCT_DS_WIPOHague item in dataModelList)
            {
                WipoHagueViewModel wipo = MapToWipoHagueViewModel(item);

                wipoHagueList.Add(wipo);
            }

            return View(wipoHagueList);
        }

        private static WipoHagueViewModel MapToWipoHagueViewModel(FCT_DS_WIPOHague item)
        {
            WipoHagueViewModel wipo = new WipoHagueViewModel();
            wipo.Id = item.Id;
            wipo.GroupType = item.GroupType;
            wipo.ReportingDate = item.ReportingDate;
            wipo.IntlRegistrations = item.IntlRegistrations;
            wipo.DesignsIntlRegistrations = item.DesignsIntlRegistrations;

            wipo.IntlApplications = item.IntlApplications;
            wipo.DesignsIntlApplications = item.DesignsIntlApplications;
            wipo.Renewals = item.Renewals;
            wipo.DesignsRenewals = item.DesignsRenewals;

            wipo.CreatedDate = item.CreatedDate;
            wipo.LastUpdateDate = item.LastUpdateDate;
            wipo.IsDeleted = item.IsDeleted;
            wipo.DeletedDate = item.DeletedDate;
            return wipo;
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
            WipoHagueViewModel newEntry = new WipoHagueViewModel();
            return View(newEntry);
        }

        // POST: wipohague/Create
        [HttpPost]

        public ActionResult Create(WipoHagueViewModel newEntry)
        {
            try
            {
                FCT_DS_WIPOHague createNew = new FCT_DS_WIPOHague();
                createNew.IntlRegistrations = newEntry.IntlRegistrations;
                createNew.DesignsIntlRegistrations = newEntry.DesignsIntlRegistrations;
                createNew.IntlApplications = newEntry.IntlApplications;
                createNew.DesignsIntlApplications = newEntry.DesignsIntlApplications;
                createNew.Renewals = newEntry.Renewals;
                createNew.DesignsRenewals = newEntry.DesignsRenewals;

                bool result = svc.Create(createNew);
                if (result == true)
                {
                    return RedirectToAction("Index");
                }
                else
                    return View(newEntry);                
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

            FCT_DS_WIPOHague update = svc.Retrieve(Id);

            vm = MapToWipoHagueViewModel(update);
           
            return View(vm);
        }

        // POST: wipohague/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Update([Bind(Include = "Id,GroupType,ReportingDate,IntlRegistrations,DesignsIntlRegistrations,IntlApplications,"
            +"DesignsIntlApplications,Renewals,DesignsRenewals,CreatedDate,LastUpdateDate,IsDeleted,DeletedDate")] WipoHagueViewModel vm)
        {
            try
            {
                FCT_DS_WIPOHague updatedDB = svc.Retrieve(vm.Id);

                if (!ModelState.IsValid)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
               
                updatedDB.ReportingDate = vm.ReportingDate;
                updatedDB.IntlRegistrations = vm.IntlRegistrations;
                updatedDB.DesignsIntlRegistrations = vm.DesignsIntlRegistrations;
                updatedDB.IntlApplications = vm.IntlApplications;
                updatedDB.DesignsIntlApplications = vm.DesignsIntlApplications;
                updatedDB.Renewals = vm.Renewals;
                updatedDB.DesignsRenewals = vm.Renewals;

                svc.Update(updatedDB);
               
                return RedirectToAction("Index");
            }
            catch
            {
                return View(vm);
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
