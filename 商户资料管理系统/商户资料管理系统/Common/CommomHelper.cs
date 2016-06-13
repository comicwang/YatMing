using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Forms;
using 商户资料管理系统.Properties;

namespace 商户资料管理系统.Common
{
    public class CommomHelper
    {
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
            int result=0;
            bool success= int.TryParse(obj, out result);
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
             DateTime result=DateTime.MinValue;
             if (obj != null)
             {
                 bool success = DateTime.TryParse(obj.ToString(), out result);
             }
             return result;
        }

        public static double ParseMB(string b)
        {
            double result=0;
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

        public static void AddImageIndex(string fileExtention,ImageList lstImg)
        {
            try
            {
                if (!lstImg.Images.Keys.Contains(fileExtention))
                    lstImg.Images.Add(fileExtention, IconsExtention.IconFromExtension(fileExtention, IconsExtention.SystemIconSize.Large));
            }
            catch (Exception)
            {
                if (fileExtention.EndsWith(".exe"))
                {
                    lstImg.Images.Add(".exe", Resources.exe);
                }
            }
        }
    }
}
