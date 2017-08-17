using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IPOS.Dash.Admin.Service;
using IPOS.Dash.Admin.Data;
using IPOS.Dash.Admin.Web.Models;


namespace IPOS.Dash.Admin.Web.Controllers
{
    public class ExaminerCountController : Controller
    {
        ExaminerCountService svc = new ExaminerCountService();
        // GET: ExaminerCount
        [HttpGet]
        public ActionResult Index()
        {

            List<dw_ExaminerCount> dataModelList = svc.GetAll();

            ExaminerCountViewModel examinerVM = new ExaminerCountViewModel();

            examinerVM.ExaminerCounts = MappedToExaminerCountViewModel(dataModelList);
            
            return View(examinerVM);
        }


        [HttpPost]
        public ActionResult Index(ExaminerCountViewModel newExaminerCount)
        {
            try
            { 
                List<dw_ExaminerCount> dataModelList = svc.GetAll();

                // New model to take the previous entry
                dw_ExaminerCount dataModel_prev = new dw_ExaminerCount();
                if (dataModelList.Count() > 0)
                {
                    dataModel_prev = dataModelList.LastOrDefault();
                }

                // Model for creating new entry
                dw_ExaminerCount dataModel = new dw_ExaminerCount();

                dataModel.EffectiveDate = newExaminerCount.ExaminerCount.EffectiveDate;

                dataModel.Threshold = newExaminerCount.ExaminerCount.Threshold;

                svc.Create(dataModel);

                // Update expiry date based on effective date added
                System.Diagnostics.Debug.WriteLine("TODO:" + dataModel_prev.ID);
                if (dataModelList.Count() > 0)
                {
                    svc.Update(dataModel_prev.ID, dataModel.EffectiveDate);
                }
            
                return RedirectToAction("Index");
            }
            catch
            {
                throw;
            }
        }

        private static List<ExaminerCount> MappedToExaminerCountViewModel(List<dw_ExaminerCount> examiner) 
        {
            List<ExaminerCount> examinerCountList = new List<ExaminerCount>();

            foreach (dw_ExaminerCount item in examiner)
            {
                ExaminerCount examCount = new ExaminerCount();
                examCount.Id = item.ID;
                examCount.Threshold = item.Threshold;
                examCount.EffectiveDate = item.EffectiveDate;
                examCount.ExpiryDate = item.ExpiryDate;
                examCount.CreatedDate = item.CreatedDate;
                examCount.LastUpdateDate = item.LastUpdateDate;
                examCount.IsDeleted = item.IsDeleted;
                examCount.DeletedDate = item.DeletedDate;
                examCount.Side = item.Side;

                examinerCountList.Add(examCount);

            }

            return examinerCountList;
        }

    }
}