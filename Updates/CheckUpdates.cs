using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Updates
{
    public class CheckUpdates
    {

        private string url = "https://raw.githubusercontent.com/vanarova/Seller-Sense/main/latest_release.txt";
        private static string downloadURL = $"https://github.com/vanarova/Seller-Sense/releases/download/[version]/SS.msi";
        string currentVersion;
        bool IsUpdateNeeded = false;
        public CheckUpdates(string currentVersion)
        {
            this.currentVersion = currentVersion;
            CheckForUpdates();
        }

        private async void CheckForUpdates()
        {
            string version = await ReadTextFileFromUrl(url);
            if (!string.IsNullOrEmpty(version))
            {
                IsUpdateNeeded = IsVersionABigger(version, currentVersion);
                if (IsUpdateNeeded)
                {
                    Updates upd = new Updates(version);
                    upd.ShowDialog();
                    //Application.Exit();
                }
            }
        }

        private static bool IsVersionABigger(string versionA, string versionB)
        {
            string[] versionAComponents = versionA.Split('.');
            string[] versionBComponents = versionB.Split('.');
            int VERSION_LEN = 3; // 4 digit version

            // Compare each component numerically
            for (int i = 0; i < VERSION_LEN; i++)
            {
                int componentA = int.Parse(versionAComponents[i]);
                int componentB = int.Parse(versionBComponents[i]);
                // Last component, compare numerically
                if (componentA > componentB)
                    return true;
                else if (componentA < componentB)
                    return false;

            }

            // If all components are equal, return false
            return false;
        }

        public static async Task<Exception> DownloadSetup(string version, string destinationPath)
        {
            Exception exp = null;
            downloadURL = downloadURL.Replace("[version]", version);
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(downloadURL);
                    response.EnsureSuccessStatusCode(); // Ensure success status code

                    using (Stream contentStream = await response.Content.ReadAsStreamAsync())
                    {
                        using (FileStream fileStream = File.Create(destinationPath))
                        {
                            await contentStream.CopyToAsync(fileStream);
                        }
                    }

                    Console.WriteLine($"File downloaded successfully to: {destinationPath}");
                }
                catch (HttpRequestException e)
                {
                    exp = e;
                }
                catch (Exception ex)
                {
                    exp = ex;
                }
            }
            return exp ;
        }

        public static void RunSetUp(string SetUpURL)
        {
            Process p = new Process
            {
                StartInfo = new ProcessStartInfo(SetUpURL)
            };
            p.Start();
            
            Application.Exit();
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
