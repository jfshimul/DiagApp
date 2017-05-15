using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiagnosticApp.Models.ViewModel
{   
    [Serializable]
    public class TestWiseReport
    {
        public int TestId { get; set; }
        public string TestName { get; set; }
        public int TotalTests { get; set; }
        public decimal TotalAmount { get; set; }

        public DateTime fromDate { get; set; }
        public DateTime toDate { get; set; }
    }
}