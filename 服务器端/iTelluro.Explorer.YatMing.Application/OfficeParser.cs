using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aspose.Cells;
using Aspose.Words;
using Aspose.Slides;
using System.Text.RegularExpressions;
using System.IO;

namespace iTelluro.Explorer.YatMing.Application
{
    /// <summary>
    /// 第三方组件ASPOSE Office/WPS文件转换
    /// Writer:Helen Joe
    /// Date:2014-09-24
    /// </summary>
    public class AsposeUtils
    {
        /// <summary>
        /// PFD转换器位置
        /// </summary>
        private static string _EXEFILENAME = @"E:\Program Files (x86)\SWFTools\pdf2swf.exe";

        #region 1.01 Wrod文档转换为PDF文件 +ConvertDocToPdF(string sourceFileName, string targetFileName)
        /// <summary>
        /// Wrod文档转换为PDF文件
        /// </summary>
        /// <param name="sourceFileName">需要转换的Word全路径</param>
        /// <param name="targetFileName">目标文件全路径</param>
        /// <returns>转换是否成功</returns>
        public static bool ConvertDocToPdF(string sourceFileName, string targetFileName)
        {
           // Souxuexiao.API.Logger.error(string.Format("Wrod文档转换为PDF文件:sourceFileName={0},targetFileName={1}", sourceFileName, targetFileName));
            try
            {
                using (System.IO.Stream stream = new System.IO.FileStream(sourceFileName, System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.ReadWrite))
                {
                    Document doc = new Document(sourceFileName);
                    doc.Save(targetFileName, Aspose.Words.SaveFormat.Pdf);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return System.IO.File.Exists(targetFileName);
        }
        #endregion

        #region 1.02 Excel文件转换为HTML文件 +(string sourceFileName, string targetFileName, string guid)
        /// <summary>
        /// Excel文件转换为HTML文件 
        /// </summary>
        /// <param name="sourceFileName">Excel文件路径</param>
        /// <param name="targetFileName">目标路径</param>
        /// <returns>转换是否成功</returns>
        public static bool ConvertExcelToHtml(string sourceFileName, string targetFileName)
        {
          //  Souxuexiao.API.Logger.info(string.Format("准备执行Excel文件转换为HTML文件,sourceFileName={0},targetFileName={1}", sourceFileName, targetFileName));
            try
            {
                using (System.IO.Stream stream = new System.IO.FileStream(sourceFileName, System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.ReadWrite))
                {
                    Aspose.Cells.Workbook workbook = new Workbook(stream);
                    workbook.Save(targetFileName, Aspose.Cells.SaveFormat.Html);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return System.IO.File.Exists(targetFileName);
        }
        #endregion

        #region 1.03 将PowerPoint文件转换为PDF +ConvertPowerPointToPdf(string sourceFileName, string targetFileName)
        /// <summary>
        /// 将PowerPoint文件转换为PDF
        /// </summary>
        /// <param name="sourceFileName">PPT/PPTX文件路径</param>
        /// <param name="targetFileName">目标文件路径</param>
        /// <returns>转换是否成功</returns>
        public static bool ConvertPowerPointToPdf(string sourceFileName, string targetFileName)
        {
           // Souxuexiao.API.Logger.info(string.Format("准备执行PowerPoint转换PDF,sourceFileName={0},targetFileName={1}", sourceFileName, targetFileName));
            try
            {
                using (System.IO.Stream stream = new System.IO.FileStream(sourceFileName, System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.ReadWrite))
                {
                    Aspose.Slides.Presentation pptx = new Aspose.Slides.Presentation(stream);
                    pptx.Save(targetFileName, Aspose.Slides.Export.SaveFormat.Pdf);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return System.IO.File.Exists(targetFileName);
        }
        #endregion

        #region 2.01 读取pdf文件的总页数 +GetPageCount(string pdf_filename)
        /// <summary>
        /// 读取pdf文件的总页数
        /// </summary>
        /// <param name="pdf_filename">pdf文件</param>
        /// <returns></returns>
        public static int GetPageCountByPDF(string pdf_filename)
        {
            int pageCount = 0;
            if (System.IO.File.Exists(pdf_filename))
            {
                try
                {
                    byte[] buffer = System.IO.File.ReadAllBytes(pdf_filename);
                    if (buffer != null && buffer.Length > 0)
                    {
                        pageCount = -1;
                        string pdfText = Encoding.Default.GetString(buffer);
                        Regex regex = new Regex(@"/Type\s*/Page[^s]");
                        MatchCollection conllection = regex.Matches(pdfText);
                        pageCount = conllection.Count;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return pageCount;
        }
        #endregion

        #region 2.02 转换PDF文件为SWF格式 +PDFConvertToSwf(string pdfPath, string swfPath, int page)
        /// <summary>
        /// 转换PDF文件为SWF格式
        /// </summary>
        /// <param name="pdfPath">PDF文件路径</param>
        /// <param name="swfPath">SWF生成目标文件路径</param>
        /// <param name="page">PDF页数</param>
        /// <returns>生成是否成功</returns>
        public static bool PDFConvertToSwf(string pdfPath, string swfPath, int page)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" \"" + pdfPath + "\"");
            sb.Append(" -o \"" + swfPath + "\"");
            sb.Append(" -z");
            //flash version
            sb.Append(" -s flashversion=9");
            //禁止PDF里面的链接
            sb.Append(" -s disablelinks");
            //PDF页数
            sb.Append(" -p " + "\"1" + "-" + page + "\"");
            //SWF中的图片质量
            sb.Append(" -j 100");
            string command = sb.ToString();
            System.Diagnostics.Process p = null;
            try
            {
                using (p = new System.Diagnostics.Process())
                {
                    p.StartInfo.FileName = _EXEFILENAME;
                    p.StartInfo.Arguments = command;
                    p.StartInfo.WorkingDirectory = System.IO.Path.GetDirectoryName(_EXEFILENAME);
                    //不使用操作系统外壳程序 启动 线程
                    p.StartInfo.UseShellExecute = false;
                    //p.StartInfo.RedirectStandardInput = true;
                    //p.StartInfo.RedirectStandardOutput = true;

                    //把外部程序错误输出写到StandardError流中(pdf2swf.exe的所有输出信息,都为错误输出流,用 StandardOutput是捕获不到任何消息的...
                    p.StartInfo.RedirectStandardError = true;
                    //不创建进程窗口
                    p.StartInfo.CreateNoWindow = false;
                    //启动进程
                    p.Start();
                    //开始异步读取
                    p.BeginErrorReadLine();
                    //等待完成
                    p.WaitForExit();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (p != null)
                {
                    //关闭进程
                    p.Close();
                    //释放资源
                    p.Dispose();
                }
            }
            return File.Exists(swfPath);
        }
        #endregion
    }
}
