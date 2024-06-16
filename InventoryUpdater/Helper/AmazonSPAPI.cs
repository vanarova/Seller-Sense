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

namespace SellerSense.Helper
{
    internal class AmazonSPAPI
    {

        static AmazonConnection amazonConnection;
        static AmazonSPAPI()
        {
            amazonConnection = new AmazonConnection(new AmazonCredential()
            {
                ClientId = "amzn1.application-oa2-client.e27f3264fc084d2293049e5eab091e94",
                ClientSecret = "amzn1.oa2-cs.v1.394228fdcf48b8123f3d2f3d15a46c0e31402e25f61584b1bcbb533ae3a62228",
                RefreshToken = "Atzr|IwEBIGDxdjhUpoHZrxgK3eVqPENcX57NnenEBTny8rQa3SH8nSZuDoJMy3Vi_cIXxDbP-BDbqhUhv4VKDajB9qAYnP1dyun7La6vqOZnt7CoaoZZv47WWu_Sv3WFpH7UX-4W9lJEluXolWoAQCzTWKyS5rG0RMPxtpssTWUzCZSuEKso11omlCbY7T6m-Gyz_fvKGNaQN0G_Ff-FbeZKGB4GZG4bQhuncDZSqDQItuGReVid6bA_t5flliGHEuhNQT90JKwtGyWI82uY_Jt3xAbQ195sIRsNIskA36qhCuqSBMX0ZGaANeHuWCzYIF8a54km6FFzJZiv9Xq-NgpgOBUlYBrc",
                MarketPlace = MarketPlace.India, //MarketPlace.GetMarketPlaceByID("A2VIGQ35RCS4UG") 
            });
            //this.amazonConnection = amazonConnection;
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
                  else await Task.Delay(20000); //Thread.Sleep(1000 * 60);
              }

                return filePath;

            });
            
        }



        public async static Task<string> CreateReport_ORDERS()
        {
            return await Task<string>.Run(async () => {
                var parameters = new ParameterCreateReportSpecification();
                parameters.reportType = ReportTypes.GET_FLAT_FILE_ALL_ORDERS_DATA_BY_ORDER_DATE_GENERAL;
                parameters.dataStartTime =DateTime.Now.AddDays(-10);
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
                    else await Task.Delay(20000);
                }

                return filePath;

            });

        }

    }
}
