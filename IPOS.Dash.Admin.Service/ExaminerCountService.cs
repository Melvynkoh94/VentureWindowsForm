using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Net;
using System.Threading.Tasks;
using IPOS.Dash.Admin.Data;
using System.Data.Entity;

namespace IPOS.Dash.Admin.Service
{
    public class ExaminerCountService
    {
        private DateTime dateNow = System.DateTime.Now;
        IposAdminEntities db = new IposAdminEntities();

        public List<dw_ExaminerCount> GetAll()
        {
            return db.dw_ExaminerCount.Where(w => w.IsDeleted != true).ToList();
        }

        public bool Create(dw_ExaminerCount entry)
        {
            try
            {
                entry.CreatedDate = dateNow;
                entry.LastUpdateDate = System.DateTime.Now;
                entry.IsDeleted = false;
                entry.ExpiryDate = new DateTime(2099, 01, 01);
                db.dw_ExaminerCount.Add(entry);

                if (db.SaveChanges() > 0)
                {
                    // Entries created
                    return true;
                }
                else
                {
                    // Fail to create
                    return false;
                }
            }
            catch
            {
                throw;
            }
        }


        public bool Update(int? Id, DateTime effectiveDate)
        {
            if (Id == null)
            {
                return false;
            }
            dw_ExaminerCount edit = db.dw_ExaminerCount.Find(Id);
            if (edit == null)
            {
                return false;
            }

            edit.ExpiryDate = effectiveDate.AddDays(-1);
            edit.LastUpdateDate = dateNow;
            System.Diagnostics.Debug.WriteLine("TODO:"+ edit.ExpiryDate);

            db.Entry(edit).State = EntityState.Modified;
            db.SaveChanges();

            return true;
        }


    }
}
