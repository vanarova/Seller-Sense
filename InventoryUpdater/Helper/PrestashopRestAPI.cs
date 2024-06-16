using MS.WindowsAPICodePack.Internal;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Xml;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace SellerSense.Helper
{
    internal class PrestashopRestAPI
    {

        public static async Task<XmlDocument> Prestashop_Get_xml(string url, string method, string accessKey)
        {
            var restResponse = await Get(url,method,accessKey);
            XmlDocument xmlDoc = new XmlDocument();
            if (restResponse != null)
                xmlDoc.LoadXml(restResponse.Content);
            else
                return default;
            return xmlDoc;
        }


        public static async Task<System.Drawing.Image> Prestashop_Get_image(string url, string method, string accessKey)
        {
            try
            {
                var options = new RestClientOptions()
                {
                    Authenticator = new HttpBasicAuthenticator(accessKey, string.Empty),
                    Timeout = new TimeSpan(0, 0, 5)// 5 secs
                };
                var client = new RestClient(options);
                //client.auth
                var request = new RestRequest(url + method);
                var cancellationTokenSource = new CancellationTokenSource();
                request.AddParameter("webservice_key", accessKey, ParameterType.HttpHeader);
                request.AddParameter("webservice_url", url, ParameterType.HttpHeader);
                var response = await client.DownloadDataAsync(request, cancellationTokenSource.Token);
                using (MemoryStream ms = new MemoryStream(response))
                {
                    var img = System.Drawing.Image.FromStream(ms);
                    //converting again to stream, as it was giving error.
                    using (Bitmap bmp = new Bitmap(img))
                    {
                        MemoryStream mem = new MemoryStream();
                        bmp.Save(mem, img.RawFormat);
                        return System.Drawing.Image.FromStream(mem);
                    }
                }
            }catch  (Exception ex) { return default; }
        }


        //public static async Task<System.Drawing.Image> Prestashop_Get_image(string url, string method, string accessKey)
        //{
        //    var options = new RestClientOptions()
        //    {
        //        Authenticator = new HttpBasicAuthenticator(accessKey, string.Empty),
        //        Timeout = new TimeSpan(0, 0, 5)// 5 secs
        //    };
        //    var client = new RestClient(options);
        //    //client.auth
        //    var request = new RestRequest(url + method);
        //    var cancellationTokenSource = new CancellationTokenSource();
        //    request.AddParameter("webservice_key", accessKey, ParameterType.HttpHeader);
        //    request.AddParameter("webservice_url", url, ParameterType.HttpHeader);
        //    var response = await client.DownloadDataAsync(request, cancellationTokenSource.Token);
        //    //File.WriteAllBytes("222222.jpg",response);
        //    using (MemoryStream ms = new MemoryStream(response))
        //    {
        //        //var img = System.Drawing.Image.FromStream(ms);
        //        //using (Bitmap bmp = new Bitmap(img))
        //        //{
        //        //    MemoryStream mem = new MemoryStream();
        //        //    bmp.Save(mem, img.RawFormat);
        //        //    imgs = Image.FromStream(mem);
        //        //}
        //        return System.Drawing.Image.FromStream(ms);
        //        //i.Save("s2312.jpg");
        //        //return new Bitmap(ms);
        //    }
        //    //return default;
        //}

        private static Bitmap stringToImage(string inputString)
        {
            byte[] imageBytes = Encoding.Unicode.GetBytes(inputString);
            using (MemoryStream ms = new MemoryStream(imageBytes))
            {
                return new Bitmap(ms);
            }
        }

        private static async Task<RestResponse> Get(string url, string method, string accessKey)
        {
            var options = new RestClientOptions()
            {
                Authenticator = new HttpBasicAuthenticator(accessKey, string.Empty),
                Timeout = new TimeSpan(0, 0, 5)// 5 secs
            };
            var client = new RestClient(options);
            //client.auth
            var request = new RestRequest(url + method);
            var cancellationTokenSource = new CancellationTokenSource();
            //request.Authenticator= 
            request.AddParameter("webservice_key", accessKey, ParameterType.HttpHeader);
            request.AddParameter("webservice_url", url, ParameterType.HttpHeader);
            //request.AddParameter
            var restResponse = await client.ExecuteAsync(request, cancellationTokenSource.Token);
            if (string.IsNullOrWhiteSpace(restResponse.Content))
                return default;
            return restResponse;
        }

        //public static async Task<XmlDocument> Get(string url, string method, string accessKey)
        //{

        //}
    }
}
