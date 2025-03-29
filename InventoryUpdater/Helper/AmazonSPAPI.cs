using FikaAmazonAPI.Parameter.Report;
using FikaAmazonAPI.Utils;
using FikaAmazonAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static FikaAmazonAPI.Utils.Constants;
using FikaAmazonAPI.AmazonSpApiSDK.Models.Reports;
using FikaAmazonAPI.Parameter.Report;
using FikaAmazonAPI.Utils;
using static FikaAmazonAPI.Utils.Constants;
using CommonUtil;

namespace SellerSense.Helper
{
    internal class AmazonSPAPI
    {

        static AmazonConnection amazonConnection;
        public static void Init(string companyCode)
        {
            if (companyCode == ProjIO.GetUserSetting(CommonUtil.Constants.AmazonCompACode))
            {
                if (string.IsNullOrEmpty(ProjIO.GetUserSetting(CommonUtil.Constants.AmazonCompAKey))
                    || string.IsNullOrEmpty(ProjIO.GetUserSetting(CommonUtil.Constants.AmazonCompASecret)))
                    return;
                amazonConnection = new AmazonConnection(new AmazonCredential()
                {
                    //ClientId = "amzn1.application-oa2-client.e27f3264fc084d2293049e5eab091e94",
                    ClientId = ProjIO.GetUserSetting(CommonUtil.Constants.AmazonCompAKey),
                    ClientSecret = ProjIO.GetUserSetting(CommonUtil.Constants.AmazonCompASecret),
                    RefreshToken = ProjIO.GetUserSetting(CommonUtil.Constants.AmazonCompAToken),
                    MarketPlace = MarketPlace.India, //MarketPlace.GetMarketPlaceByID("A2VIGQ35RCS4UG") 
                });
            }
            if (companyCode == ProjIO.GetUserSetting(CommonUtil.Constants.AmazonCompBCode))
            {
                if (string.IsNullOrEmpty(ProjIO.GetUserSetting(CommonUtil.Constants.AmazonCompBKey))
                    || string.IsNullOrEmpty(ProjIO.GetUserSetting(CommonUtil.Constants.AmazonCompBSecret)))
                    return;
                amazonConnection = new AmazonConnection(new AmazonCredential()
                {
                    ClientId = ProjIO.GetUserSetting(CommonUtil.Constants.AmazonCompBKey),
                    ClientSecret = ProjIO.GetUserSetting(CommonUtil.Constants.AmazonCompBSecret),
                    RefreshToken = ProjIO.GetUserSetting(CommonUtil.Constants.AmazonCompBToken),
                    MarketPlace = MarketPlace.India, //MarketPlace.GetMarketPlaceByID("A2VIGQ35RCS4UG") 
                });
            }
        }


        public async static Task<string> CreateReport_GET_MERCHANT_LISTINGS_ALL_DATA()
        {
          return await Task<string>.Run(async () => {
                var parameters = new ParameterCreateReportSpecification();
                parameters.reportType = ReportTypes.GET_MERCHANT_LISTINGS_ALL_DATA;

                parameters.marketplaceIds = new MarketplaceIds();
                parameters.marketplaceIds.Add(MarketPlace.India.ID);

                parameters.reportOptions = new FikaAmazonAPI.AmazonSpApiSDK.Models.Reports.ReportOptions();


                var reportId = amazonConnection.Reports.CreateReport(parameters);
                var filePath = string.Empty;
                string ReportDocumentId = string.Empty;

                while (string.IsNullOrEmpty(ReportDocumentId))
                {
                    var reportData = amazonConnection.Reports.GetReport(reportId);
                  if (!string.IsNullOrEmpty(reportData.ReportDocumentId))
                  {
                      filePath = amazonConnection.Reports.GetReportFile(reportData.ReportDocumentId);
                      break;
                  }
                  else await Task.Delay(10000); //Thread.Sleep(1000 * 60);
              }

                return filePath;

            });
            
        }



        public async static Task<string> CreateReport_ORDERS(string days)
        {
            return await Task<string>.Run(async () => {
                int ndays = Convert.ToInt32(days);
                var parameters = new ParameterCreateReportSpecification();
                parameters.reportType = ReportTypes.GET_FLAT_FILE_ALL_ORDERS_DATA_BY_ORDER_DATE_GENERAL;
                parameters.dataStartTime =DateTime.Now.AddDays(-ndays);
                parameters.dataEndTime =DateTime.Now;
                parameters.marketplaceIds = new MarketplaceIds();
                parameters.marketplaceIds.Add(MarketPlace.India.ID);

                parameters.reportOptions = new FikaAmazonAPI.AmazonSpApiSDK.Models.Reports.ReportOptions();


                var reportId = amazonConnection.Reports.CreateReport(parameters);
                var filePath = string.Empty;
                string ReportDocumentId = string.Empty;

                while (string.IsNullOrEmpty(ReportDocumentId))
                {
                    var reportData = amazonConnection.Reports.GetReport(reportId);
                    if (!string.IsNullOrEmpty(reportData.ReportDocumentId))
                    {
                        filePath = amazonConnection.Reports.GetReportFile(reportData.ReportDocumentId);
                        break;
                    }
                    else await Task.Delay(10000);
                }

                return filePath;

            });

        }

    }
}
