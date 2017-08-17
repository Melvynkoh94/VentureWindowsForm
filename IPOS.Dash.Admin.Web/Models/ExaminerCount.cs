using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IPOS.Dash.Admin.Web.Models
{
    public class ExaminerCount : BaseView
    {
        BaseView baseView = new BaseView();

        public int Id { get; set; }

        public int Threshold { get; set; }

        public DateTime EffectiveDate { get; set; }

        public DateTime ExpiryDate { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? LastUpdateDate { get; set; }

        public bool? IsDeleted { get; set; }

        public DateTime? DeletedDate { get; set; }

        public string FormatDateEffectiveDate
        {
            get
            {
                if (EffectiveDate != null)
                {
                    return baseView.FormattedDate(EffectiveDate);
                }
                return "-";
            }
        }

        public string FormatDateExpiryDate
        {
            get
            {
                if (ExpiryDate != null)
                {
                    return baseView.FormattedDate(ExpiryDate);
                }
                return "-";
            }
        }

        public string Side { get; set; }

    }
}