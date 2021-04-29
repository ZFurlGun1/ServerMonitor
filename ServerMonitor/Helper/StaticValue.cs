using ServerMonitor.Helper.Currency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ServerMonitor.Helper
{
    class StaticValue
    {
        /*
         ViewHelper
         */
        public static bool ComboxShowFlag = false;
        private static bool printFlag = true;
        private static string tempPath = ".\\TempPath\\";
        private static string downloadPath =TempPath+ "Download\\";
  
        private static string binPath = ".\\Bin\\";
        private static string userInfoPath = BinPath + "UserInfo\\";
        private static string oldLogPath=tempPath+"OldLog\\";
        private static string printLogPath = TempPath + "Runlog.txt";
        //下载文件的辅助
        private static string ImgTemp = TempPath + "DownloadImg\\";
        private static string userAgent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/62.0.3202.94 Safari/537.36";
        private static string moblieUserAgent = "Mozilla/5.0 (Linux; Android 7.0; PLUS Build/NRD90M) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/61.0.3163.98 Mobile Safari/537.36";

        /// 控制日志写入的flag
        /// </summary>
        public static bool PrintFlag { get => printFlag; set => printFlag = value; }
        /// <summary>
        /// 缓存路径
        /// </summary>
        public static string TempPath { get => tempPath; set => tempPath = value; }
   
        public static string BinPath { get => binPath; set => binPath = value; }
        public static string UserInfoPath { get => userInfoPath; set => userInfoPath = value; }
        public static string PrintLogPath { get => printLogPath; set => printLogPath = value; }
        public static string ImgTemp1 { get => ImgTemp; set => ImgTemp = value; }
        public static string UserAgent { get => userAgent; set => userAgent = value; }
        public static string MoblieUserAgent { get => moblieUserAgent; set => moblieUserAgent = value; }
        /// <summary>
        /// 下载文件夹
        /// </summary>
        public static string DownloadPath { get => downloadPath; set => downloadPath = value; }
        /// <summary>
        /// 放置旧的LOG
        /// </summary>
        public static string OldLogPath { get => oldLogPath; set => oldLogPath = value; }
    
        /// <summary>
        /// 基础header
        /// </summary>
        /// <param name="FileUrl"></param>
        /// <returns></returns>
        public static WebHeaderCollection CurrencyWebHeader()
        {
            WebHeaderCollection webHeaderCollection = new WebHeaderCollection();
        
            webHeaderCollection.Add("User-Agent", UserAgent);
            webHeaderCollection.Add("Accept-Language", "zh-TW,zh;q=0.8,en-US;q=0.5,en;q=0.3");
            return webHeaderCollection;
        }
    }
}
