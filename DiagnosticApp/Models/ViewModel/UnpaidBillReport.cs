using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiagnosticApp.Models.ViewModel
{   
    [Serializable]
    public class UnpaidBillReport
    {
        public int PatientId { get; set; }

        public string PatientName { get; set; }

        public string MobileNo { get; set; }

        public string BillNo { get; set; }

        public decimal TotalAmount { get; set; }
        public decimal PaidAmount { get; set; }

        public decimal DueAmount { get; set; }

        public DateTime fromDate { get; set; }
        public DateTime toDate { get; set; }
    }
}