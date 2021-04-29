using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerMonitor.Helper.Currency
{
    class PrintLog
    {
        /// <summary>
        /// string format  支持三个参数拼接。
        /// </summary>
        /// <param name="format"></param>
        /// <param name="arg0"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        public static void Log(string format, object arg0, object arg1, object arg2)
        {
            String text = string.Format(format, arg0, arg1, arg2);
            Console.WriteLine(text);
            WriteLog(text);
        }
        /// <summary>
        /// 帮助你写入一个
        /// </summary>
        /// <param name="Content"></param>
        public static void RandomLog(string Content,string Label="随机日志") {

            Helper.Currency.FileHelper.AppendUTF8Text(StaticValue.TempPath+ Label + DateTime.Now.ToFileTime()+".txt",Content);
        }

       


        /// <summary>
        /// string format  支持两个个参数拼接。
        /// </summary>
        /// <param name="format"></param>
        /// <param name="arg0"></param>
        /// <param name="arg1"></param>

        public static void Log(string format, object arg0, object arg1)
        {
            String text = string.Format(format, arg0, arg1);
            Console.WriteLine(text);
            WriteLog(text);
        }
        /// <summary>
        ///  string format  支持一个参数拼接。
        /// </summary>
        /// <param name="format"></param>
        /// <param name="arg0"></param>
        public static void Log(string format, object arg0)
        {
            String text = string.Format(format, arg0);
            Console.WriteLine(text);
            WriteLog(text);
        }
        public static void Log(String Log)
        {
            Console.WriteLine(Log);
            WriteLog(Log);
        }

        private static void WriteLog(string Log)
        {
            String GetFloder = Path.GetDirectoryName(StaticValue.PrintLogPath);
            if (!Directory.Exists(GetFloder))
                Directory.CreateDirectory(GetFloder);//由于printLog要复制多个项目，故专门实现一次
            try { File.AppendAllText(StaticValue.PrintLogPath, "\r\n" + Log, Encoding.UTF8); } catch (Exception ex) {
           
                Console.WriteLine(ex);
            
            }
               
        }

        public static void Log(System.Exception Log)
        {
            String text = Log.ToString();
            Console.WriteLine(text);
            WriteLog(text);
        }


        public static void Log(List<String> Log)
        {

            foreach (String line in Log)
            {
                Console.WriteLine(line);
                WriteLog(line);
            }
        }
    }
}
