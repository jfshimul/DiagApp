using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiagnosticApp.Models
{
     [Serializable]
    public class Payments
    {
         public Int64 PaymentId { get; set; }

         public DateTime PaymentDate { get; set; }

         public Int64 PatientId { get; set; }

         public decimal PaidAmount { get; set; }


    }
}