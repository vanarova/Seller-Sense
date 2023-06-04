using Emgu.CV;
using Emgu.CV.Features2D;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using HtmlAgilityPack;
using System.Net;

namespace ImgCompare
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            //Image<Gray, Byte> sourceImage = new Image<Gray, Byte>(@"Images/1.bmp");
            //Image<Gray, Byte> templateImage = new Image<Gray, Byte>(@"Images/2.bmp");
            //Image<Gray, float> resultImage = sourceImage.MatchTemplate(templateImage, Emgu.CV.CvEnum.TemplateMatchingType.Ccoeff);
            //byte[] imgr = resultImage.ToJpegData(95);

            //using (var msr = new MemoryStream(imgr))
            //{
            //    pictureBox1.Invalidate();
            //    Image i_img = Image.FromStream(msr);
            //    i_img.Save("result.jpg");
            //    pictureBox1.Image = i_img;
            //}
            progressBar1.Visible = true;
            //lstbox_Comp.Items.Clear();
            DirectoryInfo dinfo = new DirectoryInfo("Images");
            List<string> FoundImages = new List<string>();
            FileInfo[] finfo = dinfo.GetFiles();
            for (int i = 0; i < finfo.Count(); i++)
            {
                if (await MatchImgsAsync(imageList1.Images[listView1.SelectedItems[0].Index], finfo[i].FullName) == "match")
                {
                    FoundImages.Add(finfo[i].FullName);
                    imageList2.Images.Add(Image.FromFile(finfo[i].FullName));
                }
            }

            for (int i = 0; i < imageList2.Images.Count; i++)
            {
                listView2.Items.Add(new ListViewItem(FoundImages[i], i));
            }
            progressBar1.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            imageList1.ImageSize = new Size(160,160);
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            listView1.LargeImageList = imageList1;

            imageList2.ImageSize = new Size(160, 160);
            imageList2.ColorDepth = ColorDepth.Depth32Bit;
            listView2.LargeImageList = imageList2;
            //listView1.SmallImageList = this.imageList1;
            //Image<Gray, Byte> sourceImage = new Image<Gray, Byte>(@"Images/1.jpg");
            //byte[] img = sourceImage.ToJpegData(95);
            //using (var ms = new MemoryStream(img))
            //{

            //    pictureBox1.Image = Image.FromStream(ms);
            //}
        }


        private Task<string> MatchImgsAsync(string img1, string img2)
        {
            string PathToImage1 = img1;
            string PathToImage2 = img2;
            
            Mat Image1 = CvInvoke.Imread(PathToImage1);

            /* Emgu.CV.Mat is a class which can store the pixel values.
             * Emgu.CV.CvInvoke is the library to invoke OpenCV functions. 
             * Imread loads an image from the specified path. 
             * Image1 now have the details of first image */

            Mat Image2 = CvInvoke.Imread(PathToImage2); // Image2 now have the details of second image 

            return Task.Run(() => {
               return MatchFeatures(Image1, Image2);
            });

        }

        private Task<string> MatchImgsAsync(Image img1, string img2)
        {
            Mat Image2 = CvInvoke.Imread(img2);
            return Task.Run(() => {
                return MatchFeatures(GetMatFromSDImage(img1), Image2);
            });

        }

        private Task<string> MatchImgsAsync(Image img1, Image img2)
        {
            return Task.Run(() => {
                return MatchFeatures(GetMatFromSDImage(img1), GetMatFromSDImage(img2));
            });

        }

        private Mat GetMatFromSDImage(System.Drawing.Image image)
        {
            int stride = 0;
            Bitmap bmp = new Bitmap(image);

            System.Drawing.Rectangle rect = new System.Drawing.Rectangle(0, 0, bmp.Width, bmp.Height);
            System.Drawing.Imaging.BitmapData bmpData = bmp.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, bmp.PixelFormat);

            System.Drawing.Imaging.PixelFormat pf = bmp.PixelFormat;
            if (pf == System.Drawing.Imaging.PixelFormat.Format32bppArgb)
            {
                stride = bmp.Width * 4;
            }
            else
            {
                stride = bmp.Width * 3;
            }

            Image<Bgra, byte> cvImage = new Image<Bgra, byte>(bmp.Width, bmp.Height, stride, (IntPtr)bmpData.Scan0);

            bmp.UnlockBits(bmpData);

            return cvImage.Mat;
        }


        private byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, imageIn.RawFormat);
                return ms.ToArray();
            }
        }

        private string MatchFeatures(Mat Image1, Mat Image2)
        {
            //TODO : Make a validation check that, image names in company workspace directory, should match with product codes, throw error if someone altered image names.

            string result = "no-match";
            Emgu.CV.Features2D.ORB ORB = new Emgu.CV.Features2D.ORB(); // Emgu.CV.Features2D.ORBDetector class. Now, ORB is an instance of the class.

            VectorOfKeyPoint KeyPoints1 = new VectorOfKeyPoint(); // KeyPoints1 - for storing the keypoints of Image1

            VectorOfKeyPoint KeyPoints2 = new VectorOfKeyPoint(); // KeyPoints2 - for storing the keypoints of Image2

            Mat Descriptors1 = new Mat(); // Descriptors1 - for storing the descriptors of Image1

            Mat Descriptors2 = new Mat(); // Descriptors2 - for storing the descriptors of Image2


            //Feature Extraction from Image1
            ORB.DetectAndCompute(Image1, null, KeyPoints1, Descriptors1, false);

            /* Detects Keypoints in Image1 and then computes descriptors on the image from the keypoints. 
             * Keypoints will be stored into - KeyPoints1 and Descriptors will be stored into - Descriptors1*/


            //Feature Extraction from Image2
            ORB.DetectAndCompute(Image2, null, KeyPoints2, Descriptors2, false);

            int k = 2;
            /*  Count of best matches found per each descriptor 
            or less if a descriptor has less than k possible matches in total. */

            BFMatcher matcher = new BFMatcher(DistanceType.Hamming); // BruteForceMatcher to perform descriptor matching.

            matcher.Add(Descriptors1); // Descriptors of Image1 is added.

            VectorOfVectorOfDMatch matches = new VectorOfVectorOfDMatch(); // For storing the output of matching operation.

            matcher.KnnMatch(Descriptors2, matches, k, null); // matches will now have the result of matching operation.


            /* After the matching operation, we will get a 2D array (as k = 2). 
             * For checking whether two Images are similar or not, 
             * we need the distance parameter from this array.
             * (matches[0][0].Distance, matches[0][0].Distance, matches[1][0].Distance, ...)
             * If Image1 and Image2 are same, all  distance values will be 0.
             * If they're similar the distance values will be lesser. 
             * Otherwise, distance values will be greater*/


            /* That is, for two images to be similar, the distance values present in the matches array,
             * should be lesser */


            List<float> matchList = new List<float>();


            /* The matching operation, in some situation, may result in false-positive results. 
             * For filtering out the false-positive results, David Lowe proposed a test 
             * https://www.cs.ubc.ca/~lowe/papers/ijcv04.pdf#page=20
             * This test rejects poor matches by computing the ratio between the best and second-best match. 
             * If the ratio is below some threshold, the match is discarded as being low-quality. */

            for (int b = 0; b < matches.Size; ++b)
            {
                const double ratio = 0.8; // As in Lowe's paper; can be tuned accordingly.
                if (matches[b][0].Distance < ratio * matches[b][1].Distance)
                {
                    matchList.Add(matches[b][0].Distance);
                }
            }


            matchList.Sort();
            matchList = matchList.Take(40).ToList();

            /* matchList will now contain first 40 matches.
             * Based on my research, I had found that for qualifying as a similar image,
             * there should be atleast 10 distance values, 
             * with distance value less than or equal to 45 
             * 
                            - In this case. Tune this to your particular situation. */


            int distanceThreshold = 45;
            int FilterThreshold = 30;
            int FilterCount = 0;
            

            for (int j = 0; j < matchList.Count; j++)
            {
                if ((matchList[j]) <= (distanceThreshold))
                {
                    FilterCount++;
                }
            }


            if (FilterCount >= FilterThreshold)
            {
                // Images are similar, perform the operation you want. 
                FilterCount = 0;
                result = "match" ;
                //MessageBox.Show("matched..");
            }
            else
            {
                FilterCount = 0;
                result = "no-match";
                //MessageBox.Show("Not - matched..");
            }
            return result;
        }

        private void btn_scrap_Click(object sender, EventArgs e)
        {
            progressBar1.Visible = true;
            Scrap(textBox1.Text);
            progressBar1.Visible = false;
        }

        private Image LoadImage(string url)
        {
            if (string.IsNullOrEmpty(url))
                return null;
            var request = WebRequest.Create(url);
            Image result = null;
            using (var response = request.GetResponse())
            using (var stream = response.GetResponseStream())
            {
                result = Bitmap.FromStream(stream);
            }
            return result;
        }

        private void FillGridWithDoanloadedImages()
        {
            listView1.Columns.Add("Image found");
            //ListView l = new ListView();
            //listView1.LargeImageList = imageList1;
            for (int i = 0; i < imageList1.Images.Count; i++)
            {
                listView1.Items.Add(new ListViewItem((i+1).ToString(), i));
            }
            //taGridView1.s = imageList;
        }

        //List<Image> imgs = new List<Image>();
        private void Scrap(string url)
        {
           
            int count = 0; string CampUrl= string.Empty;
            //List<row> rows = new List<row>();
            HtmlWeb web = new HtmlWeb();
            if (!string.IsNullOrWhiteSpace(url))
                CampUrl = url;
            //for (int i = 1; i <= Convert.ToInt32(textBoxPages.Text); i++)
            //{


                HtmlAgilityPack.HtmlDocument campaign = web.Load(CampUrl);
                HtmlNodeCollection nodes = campaign.DocumentNode.SelectNodes("//img[@loading]");
            foreach (var item in nodes)
            {
                Image ig = null;
                if (item.Attributes["src"] != null)
                    ig = LoadImage(item.Attributes["src"].Value);
                if(ig!= null)
                imageList1.Images.Add(ig);//listView1.Items.Add(CampUrl"",)
            }
            //nodes[0].Attributes["src"]
            FillGridWithDoanloadedImages();
            return;
                //foreach (HtmlNode item in nodes)
                //{
                //    HtmlWeb prod = new HtmlWeb();
                //    HtmlAgilityPack.HtmlDocument productpage = web.Load(
                //        System.Net.WebUtility.HtmlDecode(item.ChildNodes[1].ChildNodes[0].Attributes[0].Value));
                //    HtmlNodeCollection pnodes = productpage.DocumentNode.SelectNodes("//ul[contains(@class, 'thumbnails')]");

                //    var trow = new row()
                //    {
                //        name = item.ChildNodes[1].InnerText,
                //        url = item.ChildNodes[1].ChildNodes[0].Attributes[0].Value,
                //        price = item.ChildNodes[5].InnerText,
                //        img1 = pnodes[0].ChildNodes[1].ChildNodes["a"].Attributes["href"].Value
                //    };

                //    try
                //    {
                //        //trow.img2 = pnodes[0].ChildNodes[3].ChildNodes["a"].Attributes["href"].Value;
                //        //trow.img3 = pnodes[0].ChildNodes[5].ChildNodes["a"].Attributes["href"].Value;
                //    }
                //    catch (Exception)
                //    {
                //        //empty images
                //    }
                //    //rows.Add(trow);
                //    count++;
                //    //backgroundWorker1.ReportProgress(count);
                //}

            //CreateHtml(); int counter = 0;
            //foreach (var item in rows)
            //{

            //    WriteRow(item, counter);
            //    counter++;
            //}
            //EndHtml();
        }

        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
           // e.ItemIndex
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listView2.SelectedItems.Count>0)
            {
                pictureBox1.Image = imageList2.Images[listView2.SelectedItems[0].Index];
                label4.Text = Path.GetFileName(listView2.SelectedItems[0].Text);
                button2.Enabled = true;
            }
            else
            {
                button2.Enabled = false;
            }
        }
    }
}