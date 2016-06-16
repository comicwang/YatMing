using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;

namespace DoConvert
{
    class Program
    {
        private static string _pdfFolder = ConfigurationManager.AppSettings["pdfFolder"];
        private static string _swfFolder = ConfigurationManager.AppSettings["swfFolder"];

        static void Main(string[] args)
        {
            if (args == null || args.Length == 0)
                return;
            string filePath = args[0];
           // string filePath = @"C:\Users\Administrator\Desktop\新建文件夹 (2)\微分销.ppt";
            string pdfPath = Path.Combine(_pdfFolder, Path.GetFileNameWithoutExtension(filePath) + ".pdf");
            string swfPath = Path.Combine(_swfFolder, Path.GetFileNameWithoutExtension(filePath) + ".swf");
            if (filePath.ToLower().EndsWith(".doc") || filePath.ToLower().EndsWith(".docx"))
            {
                Console.WriteLine("开始转换DOC...");
                bool pdfSuccess = OfficeParser.ConvertDocToPdF(filePath, pdfPath);
                if (pdfSuccess)
                {
                    Console.WriteLine("开始转换SWF...");
                    bool swfSuccess = OfficeParser.PDFConvertToSwf(pdfPath, swfPath);
                    if (swfSuccess)
                    {
                        Console.WriteLine("转换完成！");
                    }
                    else
                    {
                        Console.WriteLine(string.Format("转换{0}为SWF失败", Path.GetFileName(filePath)));
                    }
                }
                else
                {
                    Console.WriteLine(string.Format("转换{0}为PDF失败", Path.GetFileName(filePath)));
                }
            }
            else if (filePath.ToLower().EndsWith(".ppt") || filePath.ToLower().EndsWith(".pptx"))
            {
                Console.WriteLine("开始转换PPT...");
                bool pdfSuccess = OfficeParser.ConvertPowerPointToPdf(filePath, pdfPath);
                if (pdfSuccess)
                {
                    Console.WriteLine("开始转换SWF...");
                    bool swfSuccess = OfficeParser.PDFConvertToSwf(pdfPath, swfPath);
                    if (swfSuccess)
                    {
                        Console.WriteLine("转换完成！");
                    }
                    else
                    {
                        Console.WriteLine(string.Format("转换{0}为SWF失败", Path.GetFileName(filePath)));
                    }
                }
                else
                {
                    Console.WriteLine(string.Format("转换{0}为PDF失败", Path.GetFileName(filePath)));
                }
            }
            else if (filePath.ToLower().EndsWith(".xls"))
            {
                Console.WriteLine("开始转换XLS...");
                bool pdfSuccess = OfficeParser.ConvertExcelToPdf(filePath, pdfPath);
                if (pdfSuccess)
                {
                    Console.WriteLine("开始转换SWF...");
                    bool swfSuccess = OfficeParser.PDFConvertToSwf(pdfPath, swfPath);
                    if (swfSuccess)
                    {
                        Console.WriteLine("转换完成！");
                    }
                    else
                    {
                        Console.WriteLine(string.Format("转换{0}为SWF失败", Path.GetFileName(filePath)));
                    }
                }
                else
                {
                    Console.WriteLine(string.Format("转换{0}为PDF失败", Path.GetFileName(filePath)));
                }
            }
            else
            {
                Console.WriteLine("文件格式不支持！");
            }
           // Console.ReadKey();
        }
    }
}
