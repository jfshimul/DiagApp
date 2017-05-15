using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiagnosticApp.Models
{
    public class TestSetup
    {
        public Int64 TestId { get; set; }

        public string TestName { get; set; }
            
        public decimal Fee { get; set; }

        public int TestTypeId { get; set; }

        public string TestTypeName { get; set; }       
     
    }
}