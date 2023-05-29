using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Compression;

namespace SellerSense.Helper
{
    internal static class ProjIO
    {
        private static Dictionary<string, string> UserSettings = new Dictionary<string, string>();
        private static string localappdata_sellersense;
         static ProjIO()
        {
            UserSettings = new Dictionary<string, string>();
            //localappdata_sellersense = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.), "Seller-Sense");
            localappdata_sellersense = Path.Combine(Path.GetTempPath(), "Seller-Sense");

        }
        //internal static void SaveEmailSettings(string senderEmail, string )
        //{


        //}


        internal static string CleanAndPrepareLocalAppData()
        {
            if(Directory.Exists(localappdata_sellersense))
                Directory.Delete(localappdata_sellersense, true);
            Directory.CreateDirectory(localappdata_sellersense);
            return localappdata_sellersense;
        }

        //call after CleanLocalAppData()
        internal static (string,string, string, string,string) RenameAppendCompanyCodeAndCopyFilesToTempDir(
            string filePath, string filePath2="", string filePath3 = "",
            string filePath4 = "", string filePath5 = "")
        {
            string targetFilePath1 = Path.Combine(localappdata_sellersense,GetUserSetting(Constants.Company1Code)+".json");
            string targetFilePath2 = Path.Combine(localappdata_sellersense,GetUserSetting(Constants.Company2Code)+".json");
            string targetFilePath3 = Path.Combine(localappdata_sellersense,GetUserSetting(Constants.Company3Code)+".json");
            string targetFilePath4 = Path.Combine(localappdata_sellersense,GetUserSetting(Constants.Company4Code)+".json");
            string targetFilePath5 = Path.Combine(localappdata_sellersense,GetUserSetting(Constants.Company5Code)+ ".json");
            File.Copy(filePath, targetFilePath1);
            if(!string.IsNullOrEmpty(filePath2))
                File.Copy(filePath2, targetFilePath2);
            if (!string.IsNullOrEmpty(filePath3))
                File.Copy(filePath3, targetFilePath3);
            if (!string.IsNullOrEmpty(filePath4))
                File.Copy(filePath4, targetFilePath4);
            if (!string.IsNullOrEmpty(filePath5))
                File.Copy(filePath5, targetFilePath5);

            return (targetFilePath1, targetFilePath2, targetFilePath3, targetFilePath4, targetFilePath5);
        }

        internal static string GetCompany1MapFilePathAndCheckFileExists()
        {
            if(string.IsNullOrEmpty(GetUserSetting(Constants.Company1Code)))
                return string.Empty;
            if (!File.Exists(Path.Combine(GetUserSetting(Constants.WorkspaceDir), GetUserSetting(Constants.Company1Code),
               Constants.MapFileName)))
                return string.Empty;
            return Path.Combine(GetUserSetting(Constants.WorkspaceDir), GetUserSetting(Constants.Company1Code),
                Constants.MapFileName);
        }


        internal static string GetCompany2MapFilePathAndCheckFileExists()
        {
            if (string.IsNullOrEmpty(GetUserSetting(Constants.Company2Code)) )
                return string.Empty;
            if(!File.Exists(Path.Combine(GetUserSetting(Constants.WorkspaceDir), GetUserSetting(Constants.Company2Code),
                Constants.MapFileName)))
                return string.Empty;
            return Path.Combine(GetUserSetting(Constants.WorkspaceDir), GetUserSetting(Constants.Company2Code),
                Constants.MapFileName);
        }

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

        internal static bool IsCompany1DirExist()
        {
           return Directory.Exists(Path.Combine(GetUserSetting(Constants.WorkspaceDir), GetUserSetting(Constants.Company1Code)));
        }
        internal static bool IsCompany2DirExist()
        {
            return Directory.Exists(Path.Combine(GetUserSetting(Constants.WorkspaceDir), GetUserSetting(Constants.Company2Code)));
        }
        internal static bool IsCompany3DirExist()
        {
            return Directory.Exists(Path.Combine(GetUserSetting(Constants.WorkspaceDir), GetUserSetting(Constants.Company3Code)));
        }
        internal static bool IsCompany4DirExist()
        {
            return Directory.Exists(Path.Combine(GetUserSetting(Constants.WorkspaceDir), GetUserSetting(Constants.Company4Code)));
        }
        internal static bool IsCompany5DirExist()
        {
            return Directory.Exists(Path.Combine(GetUserSetting(Constants.WorkspaceDir), GetUserSetting(Constants.Company5Code)));
        }

        //internal static void ImportMap1FileToLastSavedLocation(string fileName, string companyCode)
        //{
        //    string mapFileLocation = Path.Combine(GetUserSetting(Constants.WorkspaceDir),
        //        companyCode,Constants.MapFileName);
        //    File.Copy(fileName, mapFileLocation);
        //}

        internal static void ImportMap(string fileName, string companyCode, Action MapExists
            ,Action FileIOError)
        {
            string mapFileLocation = Path.Combine(GetUserSetting(Constants.WorkspaceDir),
                companyCode, Constants.MapFileName);
            File.Copy(fileName, mapFileLocation);
        }

        internal static void ExportMap(string companyCode)
        {
            string tempDirPath =  ProjIO.CleanAndPrepareLocalAppData();
            string targetDir = Path.Combine(tempDirPath, companyCode);
            Directory.CreateDirectory(targetDir);
            string mapFileLocation = Path.Combine(GetUserSetting(Constants.WorkspaceDir),
               companyCode, Constants.MapFileName);
            File.Copy(mapFileLocation, Path.Combine(targetDir,Constants.MapFileName)); // [temp]/company_code

            ZipFile.CreateFromDirectory(targetDir,Path.Combine(tempDirPath, companyCode+".zip") );
        }
    }
}
