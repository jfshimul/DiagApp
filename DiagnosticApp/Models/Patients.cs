using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiagnosticApp.Models
{
     [Serializable]
    public class Patients
    {
         public int PatientId { get; set; }

         public string PatientName { get; set; }

         public DateTime DateOfBirth { get; set; }

         public string MobileNo { get; set; }

        public DateTime BillDate { get; set; }

        public string BillNo { get; set; }

        public string RecStatus { get; set; }

        public decimal TotalFee { get; set; }

        public decimal PaidAmount { get; set; }

        public decimal DueAmount { get; set; }

        public decimal Amount { get; set; }
     
    }
}