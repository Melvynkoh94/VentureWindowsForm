using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

    }
}
