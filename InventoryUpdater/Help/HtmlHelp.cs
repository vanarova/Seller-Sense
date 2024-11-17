using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SellerSense.help
{
    internal class HtmlHelp
    {

        public static void OpenHelpPage(string id)
        {
            try
            {
                var p = System.IO.Path.GetFullPath(Assembly.GetExecutingAssembly().Location);
                var finfo = new System.IO.FileInfo(p);
                string installation_dir = finfo.DirectoryName;
                string helpHtml = System.IO.Path.Combine(installation_dir, "SellerSenseHelp.html");
                if (System.IO.File.Exists(helpHtml))
                {
                    Process.Start(GetDefaultBrowserPath(GetDefaultBrowserId()).FullName, GenerateFileUri(ConvertFilesystemStringToBrowserString(helpHtml), id));

                    //Process.Start("Chrome.exe", Uri.EscapeDataString(helpHtml + id));
                    //System.Diagnostics.Process process = new System.Diagnostics.Process();
                    ////process.StartInfo.UseShellExecute = true;
                    //process.StartInfo.FileName = "Chrome.exe";
                    //process.StartInfo.Arguments = helpHtml + id;
                    //process.Start();

                }
                else
                    throw new InvalidOperationException();
            }
            catch { MessageBox.Show("Error opening help page in browser. " +
                "Please check your installation directory and open for help : SellerSenseHelp.html ", "Error", 
                MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private static string GenerateFileUri(string uri, string elementId)
        {
            string localUri = $"file:///{uri}?#{elementId}";
            return localUri;
        }

        private static string ConvertFilesystemStringToBrowserString(string filePath)
        {

            filePath = filePath.Replace("\\", "/");
            filePath = Uri.EscapeUriString(filePath);
            //filePath = filePath.Replace(" ", "%20");

            return filePath;
        }

        private static string GetDefaultBrowserId()
        {
            const string userChoice = @"Software\Microsoft\Windows\Shell\Associations\UrlAssociations\http\UserChoice";
            string progId;
            //BrowserApplication browser;
            using (RegistryKey userChoiceKey = Registry.CurrentUser.OpenSubKey(userChoice))
            {
                if (userChoiceKey == null)
                {
                    throw new NotSupportedException("No standard browser id found in registry");
                    //break;
                }
                object progIdValue = userChoiceKey.GetValue("Progid");
                if (progIdValue == null)
                {
                    throw new NotSupportedException("No standard browser id found in registry");
                    //break;
                }
                progId = progIdValue.ToString();
                return progId;
            }
        }

        private static FileInfo GetDefaultBrowserPath(string defaultBrwoserId)
        {
            const string exeSuffix = ".exe";
            string path = defaultBrwoserId + @"\shell\open\command";
            FileInfo browserPath = null;
            using (RegistryKey pathKey = Registry.ClassesRoot.OpenSubKey(path))
            {
                if (pathKey == null)
                {
                    throw new NotSupportedException("Standard browser not properly registred in registry!");
                    //return;
                }

                // Trim parameters.
                try
                {
                    path = pathKey.GetValue(null).ToString().ToLower().Replace("\"", "");
                    if (!path.EndsWith(exeSuffix))
                    {
                        path = path.Substring(0, path.LastIndexOf(exeSuffix, StringComparison.Ordinal) + exeSuffix.Length);
                        browserPath = new FileInfo(path);
                    }
                }
                catch
                {
                    // Assume the registry value is set incorrectly, or some funky browser is used which currently is unknown.
                    throw new NotSupportedException("Standard browser not properly registred in registry!");
                }
            }

            return browserPath;

        }

    }
}
