using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IPOS.Dash.Admin.Web.Models
{
    public class WipoHagueViewModel
    {

        public Guid Id { get; set; }

        public string GroupType { get; set; }

        public DateTime ReportingDate { get; set; }

        public int IntlRegistrations { get; set; }

        public int DesignInternationalRegistrations { get; set; }

        public int IntlApplications{ get; set; }

        public int DesignsIntlApplications { get; set; }

        public int Renewals { get; set; }

        public int DesignsRenewals { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime LastUpdateDate { get; set; }

        public bool isDeleted { get; set; }

        public DateTime DeletedDate { get; set; }

        public string FormattedCreatedDate {
            get
            {
                if(CreatedDate == null)
                {
                    return "";
                }

                return CreatedDate.ToShortDateString();
            }
        }


    }
}