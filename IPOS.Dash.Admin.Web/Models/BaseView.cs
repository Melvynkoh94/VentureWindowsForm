using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IPOS.Dash.Admin.Web.Models
{
    public class BaseView
    {
        public const string format = "yyyy-MM-dd";

        public string FormattedDate(DateTime date)
        {
            if (date == null)
            {
                return date.ToString();
            }
            return date.ToString(format);
        }

    
    }
}