using OpenCvSharp;
using OpenCvSharp.Extensions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Point = OpenCvSharp.Point; //TODO this this statement, use usings to shorten collections all over project.

namespace ImageSearch
{
    public class ImageSearchByImage
    {
        //internal static string CleanAndPrepareLocalAppData()
        //{
        //    string localappdata_sellersense = Path.Combine(Path.GetTempPath(), "Seller-Sense");
        //    if (Directory.Exists(localappdata_sellersense))
        //        Directory.Delete(localappdata_sellersense, true);
        //    Directory.CreateDirectory(localappdata_sellersense);
        //    return localappdata_sellersense;
        //}
        private static object _locker = new object();
        public class progressiveMatchList
        {
            public progressiveMatchList(string fileName, string error)
            {
                this.fileName = fileName;
                this.Error = error;
            }
            public string fileName { get; set; }
            public string Error { get; set; }
        }


        internal static Task SearchDirForImages(string searchPath, 
            Bitmap queryImage, decimal thresholdV, IProgress<progressiveMatchList> progress)
        {
            return Task.Run(() =>
             {
                 //queryImage.MakeTransparent();
                 string imagePath = Path.GetTempFileName();
            queryImage.Save(imagePath);
                 // List<string> filePaths = new List<string>();
                 // List<string> fileNames = new List<string>();
                 lock (_locker)
                 {
                     foreach (var item in Directory.GetFiles(searchPath))
                     {
                         try
                         {
                             (bool found, Point x, Point y) = FindImage(imagePath, item, thresholdV);
                             if (found)
                             { //filePaths.Add(item); }
                                 progress.Report(new progressiveMatchList(item, string.Empty));
                             }
                         }
                         catch (Exception ex)
                         {
                             progress.Report(new progressiveMatchList(string.Empty, ex.Message));
                         }

                     }
                 }
                //foreach (var item in filePaths)
                //{
                //    fileNames.Add(Path.GetFileName(item));
                //}
                 try
                 {
                     File.Delete(imagePath);
                 }
                 catch (Exception ex) { progress.Report(new progressiveMatchList(string.Empty, ex.Message)); }
                //return fileNames;
           });
        }


        //internal static Task<List<string>> SearchDirForImages(string searchPath, Image queryImage)
        //{
        //    return Task<List<string>>.Run(() =>
        //    {
        //        List<string> filePaths = new List<string>();
        //        List<string> fileNames = new List<string>();
        //        foreach (var item in Directory.GetFiles(searchPath))
        //        {
        //            (Point x, Point y) = FindImage(queryImage, item);
        //            if (x != null && y != null)
        //                filePaths.Add(item);
        //        }
        //        foreach (var item in filePaths)
        //        {
        //            fileNames.Add(Path.GetFileName(item));
        //        }
        //        return fileNames;
        //    });
        //}

        internal static (bool, Point, Point) FindImage(string queryImagePath, string targetImagePath, decimal thresholdV)
        {
            //Bitmap bitmap = new Bitmap(queryImage);
            // Create a new Mat object
            //OpenCvSharp.Size s = new OpenCvSharp.Size(queryImage.Width, queryImage.Height);   
            //Mat mat = new Mat();
            //Mat grayMat = new Mat();
           
            Mat grayMat = Cv2.ImRead(queryImagePath, ImreadModes.Grayscale);
            //Bitmap bmp = new Bitmap(imagePath);
            // Convert the Bitmap to a Mat
            //BitmapConverter.ToMat(bmp, mat);
            //Cv2.CvtColor(mat, grayMat, ColorConversionCodes.BGR2GRAY);
            //using (var queryImage = new Mat(queryImagePath, ImreadModes.Grayscale))
                using (var targetImage = new Mat(targetImagePath, ImreadModes.Grayscale))
                using(var result = new Mat())
            {
                Cv2.MatchTemplate(targetImage, grayMat, result, TemplateMatchModes.CCoeffNormed);
                Cv2.MinMaxLoc(result, out _, out double maxVal, out Point minLoc, out Point maxLoc);
                //CropImage(targetImagePath, maxLoc.X, maxLoc.Y, targetImage.Width - maxLoc.X, targetImage.Height - maxLoc.Y);
                //decimal threshold = thresholdV;
                if(maxVal >= Convert.ToDouble(thresholdV))
                { return (true, minLoc, maxLoc); }
                else
                {
                    return (false, default(Point), default(Point));
                }

            }
        }

        private static void SaveAsJpeg(Mat image, string outputPath)
        {
            Cv2.ImWrite(outputPath, image, new ImageEncodingParam(ImwriteFlags.JpegQuality, 90));
        }

        private static  void CropImage(string imagePath, int startX, int startY, int width, int height)
        {
            using (Mat image = new Mat(imagePath, ImreadModes.Color))
            {
                Rect roi = new Rect(startX, startY, width, height);
                using (Mat croppedImage = new Mat(image, roi))
                {
                    SaveAsJpeg(croppedImage, "result.jpg");
                }

            }

        }

    }
}
