using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Compression;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using Common;

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

        internal static Image ResizeImage(int newWidth, int newHeight, string stPhotoPath)
        {
            Image imgPhoto = Image.FromFile(stPhotoPath);

            int sourceWidth = imgPhoto.Width;
            int sourceHeight = imgPhoto.Height;

            //Consider vertical pics
            if (sourceWidth < sourceHeight)
            {
                int buff = newWidth;

                newWidth = newHeight;
                newHeight = buff;
            }

            int sourceX = 0, sourceY = 0, destX = 0, destY = 0;
            float nPercent = 0, nPercentW = 0, nPercentH = 0;

            nPercentW = ((float)newWidth / (float)sourceWidth);
            nPercentH = ((float)newHeight / (float)sourceHeight);
            if (nPercentH < nPercentW)
            {
                nPercent = nPercentH;
                destX = System.Convert.ToInt16((newWidth -
                          (sourceWidth * nPercent)) / 2);
            }
            else
            {
                nPercent = nPercentW;
                destY = System.Convert.ToInt16((newHeight -
                          (sourceHeight * nPercent)) / 2);
            }

            int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);


            Bitmap bmPhoto = new Bitmap(newWidth, newHeight,
                          PixelFormat.Format24bppRgb);

            bmPhoto.SetResolution(imgPhoto.HorizontalResolution,
                         imgPhoto.VerticalResolution);

            Graphics grPhoto = Graphics.FromImage(bmPhoto);
            grPhoto.Clear(Color.Black);
            grPhoto.InterpolationMode =
                System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

            grPhoto.DrawImage(imgPhoto,
                new Rectangle(destX, destY, destWidth, destHeight),
                new Rectangle(sourceX, sourceY, sourceWidth, sourceHeight),
                GraphicsUnit.Pixel);

            grPhoto.Dispose();
            imgPhoto.Dispose();
            return bmPhoto;
        }


        internal static string CleanAndPrepareLocalAppData()
        {
            if (Directory.Exists(localappdata_sellersense))
                Directory.Delete(localappdata_sellersense, true);
            Directory.CreateDirectory(localappdata_sellersense);
            return localappdata_sellersense;
        }

        //call after CleanLocalAppData()
        internal static (string, string, string, string, string) RenameAppendCompanyCodeAndCopyFilesToTempDir(
            string filePath, string filePath2 = "", string filePath3 = "",
            string filePath4 = "", string filePath5 = "")
        {
            string targetFilePath1 = Path.Combine(localappdata_sellersense, GetUserSetting(Constants.Company1Code) + ".json");
            string targetFilePath2 = Path.Combine(localappdata_sellersense, GetUserSetting(Constants.Company2Code) + ".json");
            string targetFilePath3 = Path.Combine(localappdata_sellersense, GetUserSetting(Constants.Company3Code) + ".json");
            string targetFilePath4 = Path.Combine(localappdata_sellersense, GetUserSetting(Constants.Company4Code) + ".json");
            string targetFilePath5 = Path.Combine(localappdata_sellersense, GetUserSetting(Constants.Company5Code) + ".json");
            File.Copy(filePath, targetFilePath1);
            if (!string.IsNullOrEmpty(filePath2))
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
            if (string.IsNullOrEmpty(GetUserSetting(Constants.Company1Code)))
                return string.Empty;
            if (!File.Exists(Path.Combine(GetUserSetting(Constants.WorkspaceDir), GetUserSetting(Constants.Company1Code),
               Constants.MapFileName)))
                return string.Empty;
            return Path.Combine(GetUserSetting(Constants.WorkspaceDir), GetUserSetting(Constants.Company1Code),
                Constants.MapFileName);
        }


        internal static string GetCompany2MapFilePathAndCheckFileExists()
        {
            if (string.IsNullOrEmpty(GetUserSetting(Constants.Company2Code)))
                return string.Empty;
            if (!File.Exists(Path.Combine(GetUserSetting(Constants.WorkspaceDir), GetUserSetting(Constants.Company2Code),
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
            File.WriteAllText(inSettingPath + @"\inv.json", json);
        }

        internal static void LoadUserSettings()
        {
            string json = string.Empty;
            string appdata = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData, Environment.SpecialFolderOption.Create);
            string inSettingPath = Path.Combine(appdata, "Seller-Sense");
            if (!Directory.Exists(inSettingPath))
                Directory.CreateDirectory(inSettingPath);
            if (File.Exists(inSettingPath + @"\inv.json"))
                json = File.ReadAllText(inSettingPath + @"\inv.json");
            UserSettings = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
        }

        internal static (string, Image) LoadImageAndDownSize75x75(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
                return (null, null);
            using (var bmpTemp = new Bitmap(filePath))
            {
                return (filePath, new Bitmap(bmpTemp, new Size(75, 75)));
            }
        }


        internal static (string, Image) LoadImageUsingFileNameAndDownSize75x75(string fileName, string companyCode)
        {
            if (string.IsNullOrEmpty(fileName))
                return (null, null);
            (bool exist, string dir) = GetCompanyMapDirIfExist(companyCode);
            if (!exist)
                return (null,null);
            string imgPath = Path.Combine(dir,Constants.Imgs,fileName);
            if (!File.Exists(imgPath))
                return (null, null);
            using (var bmpTemp = new Bitmap(imgPath))
            {
                return (imgPath, new Bitmap(bmpTemp, new Size(75, 75)));
            }
        }

        internal static (string, Image) LoadImageWithoutLocking(string filePath)
        {
            if(string.IsNullOrEmpty(filePath))
                return (null, null);
            using (var bmpTemp = new Bitmap(filePath))
            {
                return (filePath, new Bitmap(bmpTemp));
            }
        }

        internal static Dictionary<string,Image> LoadAllImagesAndDownSize75x75(string dirPath)
        {
            Dictionary<string, Image> imgs = new Dictionary<string, Image>();
            foreach (var item in Directory.GetFiles(dirPath))
            {
                using (var bmpTemp = new Bitmap(item))
                {
                    imgs.Add(item, new Bitmap(bmpTemp, new Size(75,75)));
                }
            }
            return imgs;
        }

        internal static Task<Dictionary<string,Image>> LoadAllImagesAndDownSize75x75Async(string dirPath)
        {
           return Task<Dictionary<string, Image>>.Run(() =>
            {
                Dictionary<string, Image> imgs = new Dictionary<string, Image>();
                foreach (var item in Directory.GetFiles(dirPath))
                {
                    using (var bmpTemp = new Bitmap(item))
                    {
                        imgs.Add(Path.GetFileNameWithoutExtension(item), new Bitmap(bmpTemp, new Size(75, 75)));
                    }
                }
                return imgs;
            });
        }


        internal static string GetUserSetting(string key)
        {
            string value = "";
            if (UserSettings == null)
                UserSettings = new Dictionary<string, string>();
            if (UserSettings.Count == 0)
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
            bool result = Directory.Exists(GetUserSetting(Constants.WorkspaceDir));
            //TODO: check for any project exists
            return result;
        }

        internal static string CreateWorkspace(string customeWorkspaceDir = "")
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

       

        internal static (bool,string) GetCompany1DirIfExist()
        {
           return (Directory.Exists(Path.Combine(GetUserSetting(Constants.WorkspaceDir), GetUserSetting(Constants.Company1Code))),
                Path.Combine(GetUserSetting(Constants.WorkspaceDir), GetUserSetting(Constants.Company1Code))
                );
        }
        internal static (bool, string) GetCompany2DirIfExist()
        {
            return (Directory.Exists(Path.Combine(GetUserSetting(Constants.WorkspaceDir), GetUserSetting(Constants.Company2Code))),
                Path.Combine(GetUserSetting(Constants.WorkspaceDir), GetUserSetting(Constants.Company2Code))
                );
        }
        internal static (bool, string) GetCompany3DirIfExist()
        {
            return (Directory.Exists(Path.Combine(GetUserSetting(Constants.WorkspaceDir), GetUserSetting(Constants.Company3Code))), 
                Path.Combine(GetUserSetting(Constants.WorkspaceDir), GetUserSetting(Constants.Company3Code)));
        }
        internal static (bool, string) GetCompany4DirIfExist()
        {
            return (Directory.Exists(Path.Combine(GetUserSetting(Constants.WorkspaceDir), GetUserSetting(Constants.Company4Code))), 
                Path.Combine(GetUserSetting(Constants.WorkspaceDir), GetUserSetting(Constants.Company4Code)));
        }
        internal static (bool, string) GetCompany5DirIfExist()
        {
            return (Directory.Exists(Path.Combine(GetUserSetting(Constants.WorkspaceDir), GetUserSetting(Constants.Company5Code))), 
                Path.Combine(GetUserSetting(Constants.WorkspaceDir), GetUserSetting(Constants.Company5Code)));
        }

        internal static bool DoesCompanyCodeExist(string code)
        {
            (bool c1Dir, _) = ProjIO.GetCompany1DirIfExist();
            (bool c2Dir, _) = ProjIO.GetCompany2DirIfExist();
            (bool c3Dir, _) = ProjIO.GetCompany3DirIfExist();
            (bool c4Dir, _) = ProjIO.GetCompany4DirIfExist();
            (bool c5Dir, _) = ProjIO.GetCompany5DirIfExist();
            if (string.Equals(ProjIO.GetUserSetting(Constants.Company1Code), code) && c1Dir)
                return true;
            if (string.Equals(ProjIO.GetUserSetting(Constants.Company2Code), code) && c2Dir)
                return true;
            if (string.Equals(ProjIO.GetUserSetting(Constants.Company3Code), code) && c3Dir)
                return true;
            if (string.Equals(ProjIO.GetUserSetting(Constants.Company4Code), code) && c4Dir)
                return true;
            if (string.Equals(ProjIO.GetUserSetting(Constants.Company5Code), code) && c5Dir)
                return true;

            return false;
        }

        internal static (bool, string) GetCompanyMapDirIfExist(string code)
        {
            (bool c1Exist, string c1DirPath) = ProjIO.GetCompany1DirIfExist();
            if (string.Equals(ProjIO.GetUserSetting(Constants.Company1Code), code) && c1Exist)
                return (c1Exist, c1DirPath);

            (bool c2Exist, string c2DirPath) = ProjIO.GetCompany2DirIfExist();
            if (string.Equals(ProjIO.GetUserSetting(Constants.Company2Code), code) && c2Exist)
                return (c2Exist, c2DirPath);

            (bool c3Exist, string c3DirPath) = ProjIO.GetCompany3DirIfExist();
            if (string.Equals(ProjIO.GetUserSetting(Constants.Company3Code), code) && c3Exist)
                return (c3Exist, c3DirPath);

            (bool c4Exist, string c4DirPath) = ProjIO.GetCompany4DirIfExist();
            if (string.Equals(ProjIO.GetUserSetting(Constants.Company4Code), code) && c4Exist)
                return (c4Exist, c4DirPath);

            (bool c5Exist, string c5DirPath) = ProjIO.GetCompany5DirIfExist();
            if (string.Equals(ProjIO.GetUserSetting(Constants.Company5Code), code) && c5Exist)
                return (c5Exist, c5DirPath);

            return (false, string.Empty);
        }

        internal static (bool, string) GetCompanyImageDirIfExist(string code)
        {
            (bool doExist, string mapDir) = GetCompanyMapDirIfExist(code);
            if (doExist)
                return (doExist, Path.Combine(mapDir, Constants.Imgs));
            else
                return (false, string.Empty);
        }

        internal static (string filePath, string fileName) GetImageFilePath(string companyCode, string productCode)
        {
            string imgsLocation = Path.Combine(GetUserSetting(Constants.WorkspaceDir),
                   companyCode, Constants.Imgs);
            string filePath = string.Empty;
            if (Directory.Exists(imgsLocation))
            {
                filePath =Path.Combine(imgsLocation, productCode);
                if (File.Exists(filePath + Constants.JPG) )
                    return (filePath + Constants.JPG, productCode+ Constants.JPG); 
                if( File.Exists(filePath + Constants.PNG))
                    return (filePath + Constants.PNG, productCode + Constants.PNG);

            }
            return ("", "");
        }

            //internal static void ImportMap1FileToLastSavedLocation(string fileName, string companyCode)
            //{
            //    string mapFileLocation = Path.Combine(GetUserSetting(Constants.WorkspaceDir),
            //        companyCode,Constants.MapFileName);
            //    File.Copy(fileName, mapFileLocation);
            //}

            internal static bool ImportMap(string fileName, string companyCode,Action SuggestUserUnSafeOperation, Func<string,bool> MapExists
            ,Action<string> Result)
        {
            bool returnCode = false;
            SuggestUserUnSafeOperation();//potential unsafe operation, close existing 
            bool overwrite = true;
            string mapFileLocation = Path.Combine(GetUserSetting(Constants.WorkspaceDir),
                companyCode, Constants.MapFileName);
            if (File.Exists(mapFileLocation))
                overwrite = MapExists("File already exists, Continue?");
            
            if (overwrite)
            {
                if (File.Exists(mapFileLocation))
                {
                    File.Copy(mapFileLocation, mapFileLocation + "arv");
                    File.Delete(mapFileLocation);
                }
                try
                {
                    File.Copy(fileName, mapFileLocation);
                    Result("Map file imported successfully.");
                    returnCode = true;
                }
                catch { File.Copy(mapFileLocation + "arv", mapFileLocation); Result("Import map failed."); returnCode = false; } // if copy fails, revert to original map file.
                finally { 
                    if(File.Exists(mapFileLocation + "arv"))
                        File.Delete(mapFileLocation + "arv"); 
                    
                    } //delete backup file

            }
            return returnCode;
        }



        internal static void ImportMapAndImages(string zipFilePath, string companyCode, Action SuggestUserUnSafeOperation, Func<string, bool> MapExists
       , Action<string> Result)
        {
            // go to temp location
            // unzip file
            try
            {
                string tempDir = UnzipInTempDirectory(zipFilePath);
                string mapfilePath = Path.Combine(tempDir, Constants.MapFileName);
                string tempImgDirPath = Path.Combine(tempDir, Constants.Imgs);
                string imgDirLocation = Path.Combine(GetUserSetting(Constants.WorkspaceDir), companyCode, Constants.Imgs);
                bool mapCopied = false;

                string tempSnapshotsDirPath = Path.Combine(tempDir, Constants.Snapshots);
                string snapshotsDirLocation = Path.Combine(GetUserSetting(Constants.WorkspaceDir), companyCode, Constants.Snapshots);

                if (tempDir != default(string) && File.Exists(mapfilePath))
                    mapCopied = ImportMap(mapfilePath, companyCode, SuggestUserUnSafeOperation, MapExists, Result);

                if (mapCopied)
                {
                    CopyDirectory(tempImgDirPath, imgDirLocation, recursive: true, overwrite: true);
                    Result("Images imported successfully.");
                }

                if (mapCopied)
                {
                    CopyDirectory(tempSnapshotsDirPath, snapshotsDirLocation, recursive: true, overwrite: true);
                    Result("Snapshots imported successfully.");
                }
            }catch (Exception ex)
            {
                Result("Error copying all files.. Please copy files manually at.." + GetUserSetting(Constants.WorkspaceDir));
                throw (ex);
            }
            // copy snapshots

        }


        static string UnzipInTempDirectory(string zipFilePath)
        {
            try
            {
                // Create a temporary directory
                string tempDirectory = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
                Directory.CreateDirectory(tempDirectory);

                // Extract the contents of the zip file to the temporary directory
                ZipFile.ExtractToDirectory(zipFilePath, tempDirectory);

                // Copy the contents of the temporary directory to the destination directory
                //CopyDirectory(tempDirectory, destinationDirectory, true);

                //Console.WriteLine("Unzip and copy completed successfully.");
                return tempDirectory;
            }
            catch (Exception ex)
            {
                Logger.Log($"Error: {ex.Message}",Logger.LogLevel.error,true);
                return default(string);
            }
        }


        internal static Task<string> ExportAllLogs(string selectedPath)
        {
            string companyCode1 = GetUserSetting(Constants.Company1Code);
            string companyCode2 = GetUserSetting(Constants.Company2Code);
            string companyCode3 = GetUserSetting(Constants.Company3Code);
            string companyCode4 = GetUserSetting(Constants.Company4Code);
            string workSpace = GetUserSetting(Constants.WorkspaceDir);
            Guid uniqId = Guid.NewGuid();
            string exportAllPath = Path.Combine(selectedPath, uniqId.ToString());
            Directory.CreateDirectory(exportAllPath);

            string tempDirPath = ProjIO.CleanAndPrepareLocalAppData();

            return Task<string>.Run(() => {


                //copy log files
                if (!string.IsNullOrWhiteSpace(companyCode1))
                {
                    string localLogFileLocation = Path.Combine(workSpace, companyCode1, Constants.logFileName);
                    string zipSrcDir = Path.Combine(tempDirPath, companyCode1); Directory.CreateDirectory(zipSrcDir);
                    if (File.Exists(localLogFileLocation))
                        File.Copy(localLogFileLocation, Path.Combine(zipSrcDir, Constants.logFileName));
                }

                if (!string.IsNullOrWhiteSpace(companyCode2))
                {
                    string localLogFileLocation = Path.Combine(workSpace, companyCode2, Constants.logFileName);
                    string zipSrcDir = Path.Combine(tempDirPath, companyCode2); Directory.CreateDirectory(zipSrcDir);
                    if (File.Exists(localLogFileLocation))
                        File.Copy(localLogFileLocation, Path.Combine(zipSrcDir, Constants.logFileName));
                }

                if (!string.IsNullOrWhiteSpace(companyCode3))
                {
                    string localLogFileLocation = Path.Combine(workSpace, companyCode3, Constants.logFileName);
                    string zipSrcDir = Path.Combine(tempDirPath, companyCode3); Directory.CreateDirectory(zipSrcDir);
                    if (File.Exists(localLogFileLocation))
                        File.Copy(localLogFileLocation, Path.Combine(zipSrcDir, Constants.logFileName));
                }

                if (!string.IsNullOrWhiteSpace(companyCode4))
                {
                    string localLogFileLocation = Path.Combine(workSpace, companyCode4, Constants.logFileName);
                    string zipSrcDir = Path.Combine(tempDirPath, companyCode4); Directory.CreateDirectory(zipSrcDir);
                    if (File.Exists(localLogFileLocation))
                        File.Copy(localLogFileLocation, Path.Combine(zipSrcDir, Constants.logFileName));
                }

                
                string globalLogFileLocation = Path.Combine(workSpace, Constants.logFileName);
                if (File.Exists(globalLogFileLocation))
                    File.Copy(globalLogFileLocation, Path.Combine(tempDirPath, "global" + Constants.logFileName));
               

                ZipFile.CreateFromDirectory(tempDirPath, Path.Combine(exportAllPath, "logs.zip"));
                //File.Copy(Path.Combine(tempDirPath, "logs.zip"), Path.Combine(exportAllPath, "logs.zip"));
                //FileExported();
                
                return Path.Combine(exportAllPath, "logs.zip");
            });

        }


        internal static Task ExportMap(string companyCode,string zipFileDir, 
            bool exportLog, bool exportImgs, bool exportSnapshots, Action sameNameFileExistsinTargetDir, Action FileExported)
        {
            if (string.IsNullOrEmpty(companyCode))
                return Task.FromResult(false);
            string tempDirPath =  ProjIO.CleanAndPrepareLocalAppData();
            if (File.Exists(Path.Combine(zipFileDir, companyCode + ".zip")))
            {

                sameNameFileExistsinTargetDir();
                return Task.FromResult(false);
            }
           return Task.Run(() => { 
            string zipSrcDir = Path.Combine(tempDirPath, companyCode);
            Directory.CreateDirectory(zipSrcDir);
            //copy map file
            string mapFileLocation = Path.Combine(GetUserSetting(Constants.WorkspaceDir),
               companyCode, Constants.MapFileName);
            File.Copy(mapFileLocation, Path.Combine(zipSrcDir,Constants.MapFileName)); // [temp]/company_code

            //copy log files
            if (exportLog)
            {
                string localLogFileLocation = Path.Combine(GetUserSetting(Constants.WorkspaceDir),
                   companyCode, Constants.logFileName);
                if (File.Exists(localLogFileLocation))
                    File.Copy(localLogFileLocation, Path.Combine(zipSrcDir, Constants.logFileName));
                string globalLogFileLocation = Path.Combine(GetUserSetting(Constants.WorkspaceDir),
                    Constants.logFileName);
                if (File.Exists(globalLogFileLocation))
                    File.Copy(globalLogFileLocation, Path.Combine(zipSrcDir, "global"+Constants.logFileName));
            }

            //copy images
            if (exportImgs)
            {
                string imgsLocation = Path.Combine(GetUserSetting(Constants.WorkspaceDir),
                   companyCode, Constants.Imgs);
                if (Directory.Exists(imgsLocation))
                    CopyDirectory(imgsLocation, Path.Combine(zipSrcDir, Constants.Imgs), true);
            }

            //copy snapshots
            if (exportSnapshots)
            {
                string snapShotsLocation = Path.Combine(GetUserSetting(Constants.WorkspaceDir),
                   companyCode, Constants.Snapshots);
                if (Directory.Exists(snapShotsLocation))
                    CopyDirectory(snapShotsLocation, Path.Combine(zipSrcDir, Constants.Snapshots), true);
            }

            ZipFile.CreateFromDirectory(zipSrcDir,Path.Combine(tempDirPath, companyCode+".zip") );
            if (!File.Exists(Path.Combine(zipFileDir, companyCode + ".zip")))
                File.Copy(Path.Combine(tempDirPath, companyCode + ".zip"), Path.Combine(zipFileDir, companyCode + ".zip"));
            FileExported();
            
            });

        }

        //internal async static void ExportAllLogs(string mapCode1, string mapCode2, string mapCode3, string mapCode4, string mapCode5,
        //   string selectedPath, bool exportLog, bool exportImgs, bool exportSnapshots, Action<string> FileExported)
        //{
        //    Guid uniqId = Guid.NewGuid();
        //    string exportAllPath = Path.Combine(selectedPath, uniqId.ToString());
        //    Directory.CreateDirectory(exportAllPath);
        //    await ExportMap(mapCode1, exportAllPath,
        //      exportLog, exportImgs, exportSnapshots, () => { }, () => { });
        //    await ExportMap(mapCode2, exportAllPath,
        //      exportLog, exportImgs, exportSnapshots, () => { }, () => { });
        //    await ExportMap(mapCode3, exportAllPath,
        //      exportLog, exportImgs, exportSnapshots, () => { }, () => { });
        //    await ExportMap(mapCode4, exportAllPath,
        //      exportLog, exportImgs, exportSnapshots, () => { }, () => { });
        //    await ExportMap(mapCode5, exportAllPath,
        //      exportLog, exportImgs, exportSnapshots, () => { }, () => { });

        //    FileExported(exportAllPath);
        //}

        internal async static void ExportAllMaps(string mapCode1, string mapCode2, string mapCode3, string mapCode4, string mapCode5,
           string selectedPath, bool exportLog, bool exportImgs, bool exportSnapshots, bool exportViaTelegram, Action<string> FileExported)
        {
            Guid uniqId = Guid.NewGuid();
            string exportAllPath = Path.Combine(selectedPath, uniqId.ToString());
            Directory.CreateDirectory(exportAllPath);
           await ExportMap(mapCode1, exportAllPath,
             exportLog, exportImgs, exportSnapshots, () => { }, () => { });
           await ExportMap(mapCode2, exportAllPath,
             exportLog, exportImgs, exportSnapshots, () => { }, () => { });
           await ExportMap(mapCode3, exportAllPath,
             exportLog, exportImgs, exportSnapshots, () => { }, () => { });
           await ExportMap(mapCode4, exportAllPath,
             exportLog, exportImgs, exportSnapshots, () => { }, () => {  });
           await ExportMap(mapCode5, exportAllPath,
             exportLog, exportImgs, exportSnapshots, () => { }, () => { });
           await ExportToTelegram(exportAllPath);
            FileExported(exportAllPath);
        }

        private async static Task ExportToTelegram(string zipFile)
        {
            foreach (var item in Directory.GetFiles(zipFile))
            {
                var fileName = Path.GetFileName(item);
               await Logger.TelegramDocument(zipFile, fileName, Logger.LogLevel.info);
            }
        }

        //taken from msdn
        private static void CopyDirectory(string sourceDir, string destinationDir, bool recursive, bool overwrite = false)
        {
            // Get information about the source directory
            var dir = new DirectoryInfo(sourceDir);

            // Check if the source directory exists
            if (!dir.Exists)
                throw new DirectoryNotFoundException($"Source directory not found: {dir.FullName}");

            // Cache directories before we start copying
            DirectoryInfo[] dirs = dir.GetDirectories();

            // Create the destination directory
            Directory.CreateDirectory(destinationDir);

            // Get the files in the source directory and copy to the destination directory
            foreach (FileInfo file in dir.GetFiles())
            {
                string targetFilePath = Path.Combine(destinationDir, file.Name);
                file.CopyTo(targetFilePath, overwrite);
            }

            // If recursive and copying subdirectories, recursively call this method
            if (recursive)
            {
                foreach (DirectoryInfo subDir in dirs)
                {
                    string newDestinationDir = Path.Combine(destinationDir, subDir.Name);
                    CopyDirectory(subDir.FullName, newDestinationDir, true, overwrite);
                }
            }
        }
    }
}