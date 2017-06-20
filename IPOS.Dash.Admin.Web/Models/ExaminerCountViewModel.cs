using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IPOS.Dash.Admin.Web.Models
{
    public class ExaminerCountViewModel 
    {
      public IEnumerable<ExaminerCount> ExaminerCounts { get; set; }

      public ExaminerCount ExaminerCount { get; set; }

    }
}