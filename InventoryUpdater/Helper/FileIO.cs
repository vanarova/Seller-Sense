using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryUpdater.Helper
{
    internal class FileIO
    {
        private static Dictionary<string, string> UserSettings = new Dictionary<string, string>();

        internal static void SaveUserSetting(string key, string value)
        {
            string appdata = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData, Environment.SpecialFolderOption.Create);
            string inSettingPath = Path.Combine(appdata, "InventoryUpdater");
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
            string inSettingPath = Path.Combine(appdata, "InventoryUpdater");
            if (!Directory.Exists(inSettingPath))
                Directory.CreateDirectory(inSettingPath);
            if(File.Exists(inSettingPath + @"\inv.json"))
             json = File.ReadAllText(inSettingPath + @"\inv.json");
            UserSettings = JsonConvert.DeserializeObject<Dictionary<string,string>>(json);
        }


        

        internal static string GetUserSetting(string key)
        {
            if (UserSettings != null && UserSettings.Count > 0)
                return UserSettings[key];
            else 
                return default;
        }
    }
}
