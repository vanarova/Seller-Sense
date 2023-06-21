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
        internal static Task<List<string>> SearchDirForImages(string searchPath, Image queryImage)
        {
           return Task<List<string>>.Run(() =>
            {
                List<string> filePaths = new List<string>();
                List<string> fileNames = new List<string>();
                foreach (var item in Directory.GetFiles(searchPath))
                {
                    (Point x, Point y) = FindImage(queryImage, item);
                    if (x != null && y != null)
                        filePaths.Add(item);
                }
                foreach (var item in filePaths)
                {
                    fileNames.Add(Path.GetFileName(item));
                }
                return fileNames;
            });
        }

        internal static (Point, Point) FindImage(Image queryImage, string targetImagePath)
        {
            Bitmap bitmap = new Bitmap(queryImage);
            // Create a new Mat object
            Mat mat = new Mat();
            Mat grayMat = new Mat();
            // Convert the Bitmap to a Mat
            BitmapConverter.ToMat(bitmap, mat);
            Cv2.CvtColor(mat, grayMat, ColorConversionCodes.BGR2GRAY);
            //using (var queryImage = new Mat(queryImagePath, ImreadModes.Grayscale))
                using (var targetImage = new Mat(targetImagePath, ImreadModes.Grayscale))
                using(var result = new Mat())
            {
                Cv2.MatchTemplate(targetImage, grayMat, result, TemplateMatchModes.CCoeffNormed);
                Cv2.MinMaxLoc(result, out _, out double maxVal, out Point minLoc, out Point maxLoc);
                CropImage(targetImagePath, maxLoc.X, maxLoc.Y, targetImage.Width - maxLoc.X, targetImage.Height - maxLoc.Y);
                double threshold = 0.8;
                if(maxVal >= threshold)
                { return (minLoc, maxLoc); }
                else
                {
                    return (default(Point), default(Point));
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
