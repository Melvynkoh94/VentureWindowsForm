using IPOS.Dash.Admin.Data;
using IPOS.Dash.Admin.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;


namespace IPOS.Dash.Admin.Web.Controllers
{

    public class WipohagueController : Controller
    {
        WipoHagueService svc = new WipoHagueService();

        // GET: wipohague
        public ActionResult Index()
        {


            List<FCT_DS_WIPOHague> wipoList = svc.GetAll();

            return View(wipoList);
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
        public ActionResult Edit(int? Id)
        {
            svc.Update(Id);
            return RedirectToAction("Index");
        }

        // POST: wipohague/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
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
