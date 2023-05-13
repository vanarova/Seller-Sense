using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryUpdater.Helper
{
    internal static class ProjIO
    {
        private static Dictionary<string, string> UserSettings = new Dictionary<string, string>();

        internal static void SaveUserSetting(string key, string value)
        {
            string appdata = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData, Environment.SpecialFolderOption.Create);
            string inSettingPath = Path.Combine(appdata, "Seller-Sense");
            if (!Directory.Exists(inSettingPath))
                Directory.CreateDirectory(inSettingPath);
            if (UserSettings == null)
                UserSettings = new Dictionary<string, string>();
            UserSettings[key] = value;
            string json = JsonConvert.SerializeObject(UserSettings, Formatting.Indented);
            File.WriteAllText(inSettingPath+ @"\inv.json", json); 
        }

        internal static void LoadUserSettings()
        {
            string json = string.Empty;
            string appdata = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData, Environment.SpecialFolderOption.Create);
            string inSettingPath = Path.Combine(appdata, "Seller-Sense");
            if (!Directory.Exists(inSettingPath))
                Directory.CreateDirectory(inSettingPath);
            if(File.Exists(inSettingPath + @"\inv.json"))
             json = File.ReadAllText(inSettingPath + @"\inv.json");
            UserSettings = JsonConvert.DeserializeObject<Dictionary<string,string>>(json);
        }


        

        internal static string GetUserSetting(string key)
        {
            string value = "";
            if (UserSettings == null)
                UserSettings = new Dictionary<string, string>();
            if (UserSettings.Count==0 )
                LoadUserSettings();
            if (UserSettings != null && UserSettings.Count > 0)
            {
                UserSettings.TryGetValue(key, out value);
            }
            return value; 
        }


        internal static string DefaultWorkspaceLocation()
        {
           return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments, Environment.SpecialFolderOption.Create),
                Constants.WorkspaceDefaultDirName);
        }

        internal static void CreateCompanyDir(string code)
        { 
            string wdir = GetUserSetting(Constants.WorkspaceDir);
            if (!Directory.Exists(Path.Combine(wdir, code)))
                Directory.CreateDirectory(Path.Combine(wdir, code));
        }

        internal static bool DoesWorkspaceAndProjectsExists()
        {
            bool result =  Directory.Exists(GetUserSetting(Constants.WorkspaceDir));
            //TODO: check for any project exists
            return result;
        }

            internal static string CreateWorkspace(string customeWorkspaceDir="")
        {
            string toSavePath;
            if (string.IsNullOrEmpty(customeWorkspaceDir))
                toSavePath = DefaultWorkspaceLocation();
            else
                toSavePath = Path.Combine(customeWorkspaceDir, Constants.WorkspaceDefaultDirName);
            if (!Directory.Exists(toSavePath))
                Directory.CreateDirectory(toSavePath);
            if (UserSettings == null)
                UserSettings = new Dictionary<string, string>();
            if (string.Equals(GetUserSetting(Constants.WorkspaceDir), toSavePath))
                return toSavePath;
            SaveUserSetting(Constants.WorkspaceDir, toSavePath);
            //UserSettings[Constants.WorkspaceDir] = toSavePath;
            //string json = JsonConvert.SerializeObject(UserSettings, Formatting.Indented);
            //File.WriteAllText(toSavePath + @"\inv.json", json);
            return toSavePath;
        }


    }
}
