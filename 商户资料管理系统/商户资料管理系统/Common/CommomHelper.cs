using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Forms;
using 商户资料管理系统.Properties;
using 商户资料管理系统.YatServer;

namespace 商户资料管理系统.Common
{
    public class CommomHelper
    {
        private static YatMingServiceClient _client = ServiceProvider.Clent;

        public static string GuidGetter(object obj)
        {
            return obj == null ? Guid.NewGuid().ToString() : obj.ToString();
        }

        public static string NullGetter(object obj)
        {
            return obj == null ? null : obj.ToString();
        }

        public static int IntGetter(string obj)
        {
            int result = 0;
            bool success = int.TryParse(obj, out result);
            return result;
        }

        public static float ParseFloat(double flo)
        {
            return (float)flo;
        }

        public static object ParseDateTime(DateTime? dt)
        {
            if (dt == null)
                return string.Empty;
            return dt.Value;
        }

        public static DateTime ParseDateTime(object obj)
        {
            DateTime result = DateTime.MinValue;
            if (obj != null)
            {
                bool success = DateTime.TryParse(obj.ToString(), out result);
            }
            return result;
        }

        public static double ParseMB(string b)
        {
            double result = 0;
            bool success = double.TryParse(b, out result);
            if (success)
                result = Math.Round(result / 1024 / 1024, 2);
            return result;
        }

        public static T Clone<T>(T item)
            where T : class
        {
            T result = default(T);
            if (null != item)
            {
                MemoryStream ms = new MemoryStream();
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(ms, item);
                ms.Seek(0, SeekOrigin.Begin);
            }
            return result;
        }

        /// <summary>
        /// 获取图片指定部分
        /// </summary>
        /// <param name="pPath">图片路径</param>
        /// <param name="pPartStartPointX">目标图片开始绘制处的坐标X值(通常为0)</param>
        /// <param name="pPartStartPointY">目标图片开始绘制处的坐标Y值(通常为0)</param>
        /// <param name="pPartWidth">目标图片的宽度</param>
        /// <param name="pPartHeight">目标图片的高度</param>
        /// <param name="pOrigStartPointX">原始图片开始截取处的坐标X值</param>
        /// <param name="pOrigStartPointY">原始图片开始截取处的坐标Y值</param>
        public static Bitmap GetImgPart(Image originalImg, int pPartStartPointX, int pPartStartPointY, int pPartWidth, int pPartHeight, int pOrigStartPointX, int pOrigStartPointY)
        {
            //System.Drawing.Image originalImg = System.Drawing.Image.FromFile(pPath);

            System.Drawing.Bitmap partImg = new System.Drawing.Bitmap(pPartWidth, pPartHeight);
            System.Drawing.Graphics graphics = System.Drawing.Graphics.FromImage(partImg);
            System.Drawing.Rectangle destRect = new System.Drawing.Rectangle(new System.Drawing.Point(pPartStartPointX, pPartStartPointY), new System.Drawing.Size(pPartWidth, pPartHeight));//目标位置
            System.Drawing.Rectangle origRect = new System.Drawing.Rectangle(new System.Drawing.Point(pOrigStartPointX, pOrigStartPointY), new System.Drawing.Size(pPartWidth, pPartHeight));//原图位置（默认从原图中截取的图片大小等于目标图片的大小）

            graphics.DrawImage(originalImg, destRect, origRect, System.Drawing.GraphicsUnit.Pixel);

            return partImg;
        }

        private static bool ThumbnailCallback()
        {
            return false;
        }

        private static Image GetReducedImage(Image ResourceImage, int Width, int Height)
        {
            try
            {
                Image ReducedImage;

                Image.GetThumbnailImageAbort callb = new Image.GetThumbnailImageAbort(ThumbnailCallback);

                ReducedImage = ResourceImage.GetThumbnailImage(Width, Height, callb, IntPtr.Zero);
                ResourceImage.Dispose();
                return ReducedImage;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static int GetImageIndex(TDataInfoDTO dto, ImageList lstImg)
        {
            string fileExtention = Path.GetExtension(dto.DataName);
            string keyword = fileExtention;            
            try
            {
                if (!lstImg.Images.Keys.Contains(fileExtention))
                {
                    //图片文件，寻找图片缩略图
                    if (fileExtention.ToLower().EndsWith(".png") || fileExtention.ToLower().EndsWith(".bmp") || fileExtention.ToLower().EndsWith(".jpeg") || fileExtention.ToLower().EndsWith(".jpg"))
                    {
                        keyword = dto.MetaDataId;
                        Image targetImg = null;
                        string tempDir = Path.Combine(System.Environment.GetEnvironmentVariable("TEMP"), "64");
                        if (!Directory.Exists(tempDir))
                        {
                            Directory.CreateDirectory(tempDir);
                        }
                        string tempPath = Path.Combine(tempDir, dto.MetaDataId + ".jpeg");
                        if (!File.Exists(tempPath))
                        {
                            //下载缩略图
                            string temp = Path.Combine(System.Environment.GetEnvironmentVariable("TEMP"), dto.MetaDataId + fileExtention);
                            long total = 0;
                            byte[] buffer = null;
                            bool success = true;
                            while (success)
                            {
                                using (FileStream stream = new FileStream(temp, FileMode.Append))
                                {
                                    success = _client.TDataInfoDownloadFile(out buffer, total, dto.MetaDataId);
                                    if (success == false)
                                    {
                                        break;
                                    }
                                    total += buffer.Length;
                                    stream.Write(buffer, 0, buffer.Length);
                                }
                            }
                            Image sourceImg = Image.FromFile(temp);
                            int width = sourceImg.Width * 64 / sourceImg.Height;
                            targetImg = GetReducedImage(sourceImg, width, 64);
                            targetImg.Save(tempPath, ImageFormat.Jpeg);
                           // File.Delete(temp);
                        }
                        else
                        {
                            targetImg = Image.FromFile(tempPath);
                        }
                        lstImg.Images.Add(keyword, targetImg);
                    }
                    else
                    {
                        keyword = fileExtention;
                        lstImg.Images.Add(keyword, IconsExtention.IconFromExtension(fileExtention, IconsExtention.SystemIconSize.Large));
                    }
                }

            }
            catch (Exception)
            {
                if (fileExtention.EndsWith(".exe"))
                {
                    keyword = fileExtention;
                    lstImg.Images.Add(keyword, Resources.exe);
                }
            }
            return lstImg.Images.IndexOfKey(keyword);
        }

        public static int GetImageIndex(string filePath,string id ,ImageList lstImg)
        {
            string fileExtention = Path.GetExtension(filePath);
            string keyword = fileExtention;
            try
            {
                if (!lstImg.Images.Keys.Contains(fileExtention))
                {
                    //图片文件，寻找图片缩略图
                    if (fileExtention.ToLower().EndsWith(".png") || fileExtention.ToLower().EndsWith(".bmp") || fileExtention.ToLower().EndsWith(".jpeg") || fileExtention.ToLower().EndsWith(".jpg"))
                    {
                        keyword = id;
                        Image targetImg = null;
                        string tempDir = Path.Combine(System.Environment.GetEnvironmentVariable("TEMP"), "64");
                        if (!Directory.Exists(tempDir))
                        {
                            Directory.CreateDirectory(tempDir);
                        }
                        string tempPath = Path.Combine(tempDir, id + ".jpeg");
                        Image sourceImg = Image.FromFile(filePath);
                        targetImg = GetReducedImage(sourceImg, 64, 64);
                        targetImg.Save(tempPath, ImageFormat.Jpeg);
                        lstImg.Images.Add(keyword, targetImg);
                    }
                    else
                    {
                        keyword = fileExtention;
                        lstImg.Images.Add(keyword, IconsExtention.IconFromExtension(fileExtention, IconsExtention.SystemIconSize.Large));
                    }
                }

            }
            catch (Exception)
            {
                if (fileExtention.EndsWith(".exe"))
                {
                    keyword = fileExtention;
                    lstImg.Images.Add(keyword, Resources.exe);
                }
            }
            return lstImg.Images.IndexOfKey(keyword);
        }
    }
}
