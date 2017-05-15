using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiagnosticApp.Models.ViewModel
{   
    [Serializable]
    public class TypeWiseReport
    {
        public int TestTypeId { get; set; }
        public string TestTypeName { get; set; }

        public int TotalTests { get; set; }
        public decimal TotalAmount { get; set; }

        public DateTime fromDate { get; set; }
        public DateTime toDate { get; set; }
    }
}