using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiagnosticApp.Models
{
     [Serializable]
    public class TestRequestEntry
    {
        public Int64 TestReqestId { get; set; }
        
        public int TestId { get; set; }
        
        public string TestName { get; set; }       
        
        public decimal Fee { get; set; }
        
        public decimal TotalAmount { get; set; }
     
    }
}