using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DiagnosticApp.DAL;
using DiagnosticApp.Models;

namespace DiagnosticApp.BLL
{
    public class UnpaidBillReportManager
    {
        UnpaidBillReportGateway aUnpaidBillReportGateway = new UnpaidBillReportGateway();


        public List<Models.ViewModel.UnpaidBillReport> GetAllUnpaidBillReports(DateTime fromDate, DateTime toDate)
        {
            return aUnpaidBillReportGateway.GetAllUnpaidBillReports(fromDate, toDate);
        }
    }
}