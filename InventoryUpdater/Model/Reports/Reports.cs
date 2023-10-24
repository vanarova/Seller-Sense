
using SellerSense.Helper;
using SellerSense.Model.InvUpdate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellerSense.Model.Reports
{


    //Builder class for Report Model, implements builder pattern.
    internal class OrderStatusReportBuilder
    {
        private M_Product _m_productCompany1;
        private M_Product _m_productCompany2;
        private M_OrderStatusReport _orderStatusReport;
        //private int _todaysOrders;

        public OrderStatusReportBuilder(M_Product m_productCompany1, M_Product m_productCompany2)
        {
           // _vm_companies = vm_companies;
           _m_productCompany1 = m_productCompany1;
            _m_productCompany2 = m_productCompany2;
            _orderStatusReport = new M_OrderStatusReport();
            
        }

        internal OrderStatusReportBuilder WithWeeklyOrderCount()
        {
            return default;
        }

        internal OrderStatusReportBuilder WithTodaysOrderCount()
        {
            //var currentCompany = _vm_companies._companies.FirstOrDefault(c => c._code == _currentCompanyCode);
            (int allOrdersAmz, int allOrdersFk,int allOrdersSpd, int allOrdersMso)  = 
                CompareSnapShotAndGetTodaysOrders(_m_productCompany1);

            _orderStatusReport.TotalOrders_Today = 
                new M_OrderStatusReport.TotalOrdersToday(allOrdersAmz+ allOrdersFk+ allOrdersSpd+ allOrdersMso);
            _orderStatusReport.TotalOrders_Today.CompanyA.AmzOrderCount = allOrdersAmz.ToString();
            _orderStatusReport.TotalOrders_Today.CompanyA.FkOrderCount = allOrdersFk.ToString();
            _orderStatusReport.TotalOrders_Today.CompanyA.SpdOrderCount = allOrdersSpd.ToString();
            _orderStatusReport.TotalOrders_Today.CompanyA.MsoOrderCount = allOrdersMso.ToString();
            _orderStatusReport.TotalOrders_Today.CompanyA.Company = _m_productCompany1._companyCode;

            (allOrdersAmz, allOrdersFk, allOrdersSpd, allOrdersMso) =
               CompareSnapShotAndGetTodaysOrders(_m_productCompany2);
            _orderStatusReport.TotalOrders_Today.TotalOrder = _orderStatusReport.TotalOrders_Today.TotalOrder +
                (allOrdersAmz + allOrdersFk + allOrdersSpd + allOrdersMso);
            _orderStatusReport.TotalOrders_Today.CompanyB.AmzOrderCount = allOrdersAmz.ToString();
            _orderStatusReport.TotalOrders_Today.CompanyB.FkOrderCount = allOrdersFk.ToString();
            _orderStatusReport.TotalOrders_Today.CompanyB.SpdOrderCount = allOrdersSpd.ToString();
            _orderStatusReport.TotalOrders_Today.CompanyB.MsoOrderCount = allOrdersMso.ToString();
            _orderStatusReport.TotalOrders_Today.CompanyB.Company = _m_productCompany2._companyCode;


            return this;
        }

        private (int,int,int,int) CompareSnapShotAndGetTodaysOrders(M_Product productModel)
        {
            _orderStatusReport.Daily_Orders = new M_OrderStatusReport.DailyOrders();
            M_Snapshot _m_invSnapShotModel_Amz = new M_Snapshot(productModel._companyCode, M_Snapshot.Site.amz);
            M_Snapshot _m_invSnapShotModel_Spd = new M_Snapshot(productModel._companyCode, M_Snapshot.Site.spd);
            M_Snapshot _m_invSnapShotModel_Fk = new M_Snapshot(productModel._companyCode, M_Snapshot.Site.fk);
            M_Snapshot _m_invSnapShotModel_Mso = new M_Snapshot(productModel._companyCode, M_Snapshot.Site.mso);

            IList<InvSnapshotEntry> lastSnapShot = _m_invSnapShotModel_Amz.GetLastDayInvSnapshot();
            IList<InvSnapshotEntry> TodaysSnapShot = _m_invSnapShotModel_Amz.GetTodaysLastSavedInvSnapshot();
            int allOrdersAmz = GetOrders(lastSnapShot, TodaysSnapShot);

            IList<InvSnapshotEntry> lastSnapShotfk = _m_invSnapShotModel_Fk.GetLastDayInvSnapshot();
            IList<InvSnapshotEntry> TodaysSnapShotfk = _m_invSnapShotModel_Fk.GetTodaysLastSavedInvSnapshot();
            int allOrdersFk = GetOrders(lastSnapShotfk, TodaysSnapShotfk);

            IList<InvSnapshotEntry> lastSnapShotSpd = _m_invSnapShotModel_Spd.GetLastDayInvSnapshot();
            IList<InvSnapshotEntry> TodaysSnapShotSpd = _m_invSnapShotModel_Spd.GetTodaysLastSavedInvSnapshot();
            int allOrdersSpd = GetOrders(lastSnapShotSpd, TodaysSnapShotSpd);

            IList<InvSnapshotEntry> lastSnapShotMso = _m_invSnapShotModel_Mso.GetLastDayInvSnapshot();
            IList<InvSnapshotEntry> TodaysSnapShotMso = _m_invSnapShotModel_Mso.GetTodaysLastSavedInvSnapshot();
            int allOrdersMso = GetOrders(lastSnapShotMso, TodaysSnapShotMso);

            return (allOrdersAmz, allOrdersFk, allOrdersSpd, allOrdersMso);

        }

        private static int GetOrders(IList<InvSnapshotEntry> lastSnapShot, IList<InvSnapshotEntry> TodaysSnapShot)
        {
            if (lastSnapShot == null || lastSnapShot.Count == 0 || TodaysSnapShot == null)
                return default;
            int allOrdersForThisCompany = 0;
            foreach (var lastItem in lastSnapShot)
            {
                foreach (var TodaysItem in TodaysSnapShot)
                {
                    if (lastItem.asin == TodaysItem.asin)
                    {
                        int.TryParse(lastItem.InvSysCount, out int lastAmzorder);
                        int.TryParse(TodaysItem.InvSysCount, out int todaysAmzOrder);
                        int orders = (lastAmzorder - todaysAmzOrder);
                        allOrdersForThisCompany = allOrdersForThisCompany + orders;
                    }
                    // get order for each product, add all
                }
            }

            return allOrdersForThisCompany;
        }

        internal M_OrderStatusReport Build()
        {
            
            return _orderStatusReport;
        }
    }

    internal class M_OrderStatusReport
    {
        internal DateTime Date { get; set; }
        internal TotalOrdersToday TotalOrders_Today { get; set; }
        internal DailyOrders Daily_Orders { get; set; }
        internal LastWeekHighSellingItems lastWeek_HighSellingItems { get; set; }

        public M_OrderStatusReport()
        {
            Date = DateTime.Now;
        }


        internal class TotalOrdersToday
        {
            public int TotalOrder { get; set; }
            public OrderSite CompanyA { get; set; }
            public OrderSite CompanyB { get; set; }


            public DateTime _lastFileDate { get; set; } // add dates, so that user, can see what dates were compared in snapshots
            public DateTime _lastToLastFileDate { get; set; }
            public TotalOrdersToday(int totalOrder) { 
                TotalOrder = totalOrder;
                CompanyA = new OrderSite();
                CompanyB = new OrderSite();
            }

            public class OrderSite
            {
                public string Company { get; set; }
                public string AmzOrderCount { get; set; }
                public string FkOrderCount { get; set; }
                public string SpdOrderCount { get; set; }
                public string MsoOrderCount { get; set; }
            }
        }

        internal class DailyOrders {

            internal List<OrderItem> TodaysOrderCount { get; set; }

            public DailyOrders()
            {
                TodaysOrderCount = new List<OrderItem>();
            }
            internal class OrderItem
            {
                internal string Product { get; set; }
                internal int OrderCount { get; set; }
                internal string ImagePath { get; set; }
            }
        }


        internal class LastWeekHighSellingItems
        {
            internal List<OrderItem> WeeklyOrderCount { get; set; }

            internal class OrderItem
            {
                internal string Product { get; set; }
                internal DateTime Date { get; set; }
                internal int OrderCount { get; set; }
                internal string ImagePath { get; set; }
            }
        }


    }
}
