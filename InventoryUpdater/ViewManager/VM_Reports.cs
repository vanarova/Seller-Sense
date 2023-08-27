using SellerSense.Model.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellerSense.ViewManager
{
    internal class VM_Reports
    {

    }

    ////Builder class for Report Model, implements builder pattern.
    //internal class OrderStatusReportBuilder
    //{
    //    private string _currentCompanyCode;
    //    private VM_Companies _vm_companies;
    //    private OrderStatusReport _orderStatusReport;

    //    public OrderStatusReportBuilder(VM_Companies vm_companies, string currentCompanyCode)
    //    {
    //       _vm_companies = vm_companies;
    //       _currentCompanyCode = currentCompanyCode;
    //    }

    //    internal OrderStatusReportBuilder WithWeeklyOrderCount()
    //    {
    //        return default;
    //    }

    //    internal OrderStatusReportBuilder WithTodaysOrderCount()
    //    {
    //        var currentCompany = _vm_companies._companies.FirstOrDefault(c => c._code == _currentCompanyCode);

    //        return default;
    //    }

    

    //    internal OrderStatusReport Build()
    //    {
    //        _orderStatusReport = new OrderStatusReport(_currentCompanyCode);
    //        return _orderStatusReport;
    //    }
    //}
}
