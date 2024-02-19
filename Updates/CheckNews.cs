using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Updates
{
    public  class CheckNews
    {
        private string url = "https://raw.githubusercontent.com/vanarova/Seller-Sense/main/News.txt";

        public CheckNews()
        {
            IsNewsAvailable();
        }

        public async void IsNewsAvailable()
        {
            string news = await ReadTextFileFromUrl(url);
            if (!string.IsNullOrEmpty(news))
            {
                news = news.Replace("\n", Environment.NewLine);
                News n = new News(news);
                n.ShowDialog();
            }
        }


        private static async Task<string> ReadTextFileFromUrl(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode(); // Ensure success status code

                    // Read content asynchronously
                    string content = await response.Content.ReadAsStringAsync();
                    content = content.Trim();
                    return content;
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine($"Error accessing the URL: {e.Message}");
                    return null;
                }
            }
        }
    }
}
