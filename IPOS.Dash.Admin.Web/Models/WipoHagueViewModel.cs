using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IPOS.Dash.Admin.Web.Models
{
    public class WipoHagueViewModel :   BaseView
    {
        BaseView b = new BaseView();

        public Guid Id { get; set; }
        public string GroupType { get; set; }
        public DateTime ReportingDate { get; set; }
        public int IntlRegistrations { get; set; }
        public int DesignsIntlRegistrations { get; set; }
        public int IntlApplications{ get; set; }
        public int DesignsIntlApplications { get; set; }
        public int Renewals { get; set; }
        public int DesignsRenewals { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? LastUpdateDate {get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }

        public string FormatDateCreateDate
        {
            get
            {
                if (CreatedDate != null)
                {
                    return b.FormattedDate(CreatedDate);
                }
                return "-";
            }
        }
        public string FormatDateLastUpdate
        {
            get
            {
                if (LastUpdateDate != null)
                {
                    return b.FormattedDate(LastUpdateDate);
                }
                return "-";
            }
        }
        public string FormatDateDeletedDate
        {
            get
            {
                if (DeletedDate != null)
                {
                    return b.FormattedDate(DeletedDate);
                }
                return "-";
            }
        }
        public string FormatDateReportingDate
        {
            get
            {
                if (ReportingDate != null)
                {
                    return b.FormattedDate(ReportingDate);
                }
                return "-";
            }
        }


    }
}