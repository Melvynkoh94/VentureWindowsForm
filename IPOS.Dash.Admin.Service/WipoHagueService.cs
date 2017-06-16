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
    public class WipoHagueService
    {
        IposAdminEntities db = new IposAdminEntities();

        public List<FCT_DS_WIPOHague> GetAll()
        {
            return db.FCT_DS_WIPOHague.Where(w => w.IsDeleted != true).ToList();
        }

        public bool Create(FCT_DS_WIPOHague entry)
        {
            try
            {
                entry.Id = Guid.NewGuid();
                entry.GroupType = "HELLO";
                entry.IsDeleted = false;
                entry.CreatedDate = DateTime.Now;
                db.FCT_DS_WIPOHague.Add(entry);
                
                if(db.SaveChanges() > 0)
                {
                    // Save success
                    return true;
                }
                else
                {
                    // Failed Save
                    return false;
                }
            }
            catch
            {
                throw;
            }
        }


        public FCT_DS_WIPOHague Update(int? Id)
        {
            if (Id == null)
            {
                return null;
            }
            FCT_DS_WIPOHague edit = db.FCT_DS_WIPOHague.Find(Id);
            if (edit == null)
            {
                return null;
            }
            return edit;          
        }

        public FCT_DS_WIPOHague Update(FCT_DS_WIPOHague update)
        {
            db.Entry(update).State = EntityState.Modified;
            db.SaveChanges();
            return update;
        }


    }
}
