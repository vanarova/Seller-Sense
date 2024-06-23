using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RestSharp;


namespace SellerSense.Helper
{

    //internal class FlipkartAPI
    //{
    //    static string clientId = "__CLIENT_ID__";           // Replace with your application id or client id
    //    static string clientSecret = "__CLIENT_SECRET__";   // Replace with your application secret or client secret
    //    static string credentials = Base64Encode(clientId + ":" + clientSecret);

    //    void GetAccessToken()
    //    {

    //        var client = new RestClient("https://sandbox-api.flipkart.net/oauth-service/oauth/token?grant_type=client_credentials&scope=Seller_Api");
    //        var request = new RestRequest(string.Empty,Method.Get);
    //        request.AddHeader("Authorization", "Basic " + credentials);
    //        IRestResponse response = client.Execute(request);

    //        var _snakeSettings = new JsonSerializerSettings()
    //        {
    //            ContractResolver = new UnderscorePropertyNamesContractResolver()
    //        };

    //        var accessTokenResponse = JsonConvert.DeserializeObject<AccessTokenResponse>(response.Content, _snakeSettings);
    //        Console.WriteLine("Your access token is : " + accessTokenResponse.accessToken);
    //    }

    //    public class UnderscorePropertyNamesContractResolver : DefaultContractResolver
    //    {
    //        public UnderscorePropertyNamesContractResolver()
    //        {
    //            NamingStrategy = new SnakeCaseNamingStrategy();
    //        }
    //    }

    //    private static string Base64Encode(string plainText)
    //    {
    //        var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
    //        return System.Convert.ToBase64String(plainTextBytes);
    //    }

    //    public class AccessTokenResponse
    //    {
    //        public string accessToken { get; set; }
    //    }
    //}

}




