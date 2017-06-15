using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Threading.Tasks;
using IPOS.Dash.Admin.Data;


namespace IPOS.Dash.Admin.Service
{
    public class WipoHagueService
    {
        IposAdminEntities db = new IposAdminEntities();

        public List<FCT_DS_WIPOHague> GetAll()
        {
            return db.FCT_DS_WIPOHague.Where(w => w.IsDeleted != true).ToList();
        }
        
        public void Create(FCT_DS_WIPOHague entry)
        {
           try
            {
                entry.Id = Guid.NewGuid();
                entry.GroupType = "HELLO";
                entry.IsDeleted = false;                            
                entry.CreatedDate = DateTime.Now;
                db.FCT_DS_WIPOHague.Add(entry);
                db.SaveChanges();
            }
            catch
            {
                throw;
            }
        }


        public void Update(FCT_DS_WIPOHague id)
        {
            FCT_DS_WIPOHague edit = db.FCT_DS_WIPOHague.Find(id);

        }


    }
}
