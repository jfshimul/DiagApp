using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DiagnosticApp.DAL;
using DiagnosticApp.Models;

namespace DiagnosticApp.BLL
{
    public class TypeWiseReportManager
    {
        TypeWiseReportGateway aTypeWiseReportGateway = new TypeWiseReportGateway();


        public List<Models.ViewModel.TypeWiseReport> GetAllTypeWiseReport(DateTime fromDate, DateTime toDate)
        {
            return aTypeWiseReportGateway.GetAllTypeWiseReport(fromDate,toDate);
        }
    }
}