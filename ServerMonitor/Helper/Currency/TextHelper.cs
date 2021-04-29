using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServerMonitor.Helper.Currency
{
    class TextHelper
    {
   
        /// <summary>
        /// URL编码
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        internal static string EncodingToUtf8(string tag)
        {
        return    System.Web.HttpUtility.UrlEncode(tag, Encoding.UTF8);
        }

        /// <summary>
        /// 判断字符串是否为空，如果为空则返回true，否则返回false
        /// </summary>
        /// <param name="Text"></param>
        /// <returns></returns>
        internal static bool JudgeNull(string Text)
        {
            if (Text == "" ||
                 Text == null ||
                 Text == string.Empty)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 正则匹配的辅助方法
        /// </summary>
        /// <param name="RegText"></param>
        /// <param name="pattern"></param>
        /// <returns></returns>
        public static string RegexText(String RegText, String pattern)
        {

            RegText = Regex.Match(RegText, pattern).Value;

            if (RegText != "")
                return RegText;
            else
                return "";
        }
        public static List<string> RegexTextList(String RegText, String pattern)
        {
            List<String> RegList = new List<string>();

            foreach (Match SingleMatch in Regex.Matches(RegText, pattern))
            {
                RegList.Add(SingleMatch.Value);
            }
            return RegList;
        }

        internal static string ByteTOUtf8String(byte[] responseData)
        {
            string Text = "";

            try {

                Text= Encoding.GetEncoding(65001).GetString(responseData);
            } catch (Exception ex) {
                PrintLog.Log(ex);

            }
            return Text;
        }

        /// <summary>
        /// 正则替换的文档
        /// </summary>
        /// <param name="RegText"></param>
        /// <param name="pattern"></param>
        /// <returns></returns>
        public static string ReplaceText(String RegText, String pattern, String NewText)
        {

            RegText = Regex.Replace(RegText, pattern, NewText);

            return RegText;
        }

        /// <summary>
        /// 替换文件名中非法字符 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ReplaceBadChar(string str)
        {
            if (string.IsNullOrEmpty(str))
                return "";

            StringBuilder rBuilder = new StringBuilder(str);

            foreach (char rInvalidChar in Path.GetInvalidFileNameChars())
                rBuilder.Replace(rInvalidChar.ToString(), string.Empty);

            str = rBuilder.ToString();
            return str;
        }
        /// <summary>
        /// 获取数组的首行元素并返回，
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static string GetFirstVlaue(List<String> list)
        {
            String text = "";
            foreach (String line in list)
            {


                text = line;
                break;

            }
            return text;
        }
        /// <summary>
        /// 读取文件所有行
        /// </summary>
        /// <param name="FilePath"></param>
        /// <returns></returns>
        public static List<String> ReadAllLine(String FilePath)
        {
           
            List<String> FileLine = new List<string>();
            try
            {
              
                FloderHelper.FloderExits(Path.GetDirectoryName(FilePath), true);
                if (!File.Exists(FilePath))
                    File.AppendAllText(FilePath, "");
                FileLine = new List<string>(File.ReadAllLines(FilePath));
            
                Console.WriteLine("读取：" + FilePath + FileLine.Count);
            }
            catch (Exception ex)
            {

                PrintLog.Log(ex);
            }
            return FileLine;
        }

        /// <summary>
        /// 利用强制转型崩溃来测试是否是纯数字  是则返回true
        /// </summary>
        /// <param name="NumberStr"></param>
        /// <returns></returns>
        public static bool PureDigits(string NumberStr)
        {
            try
            {
                Convert.ToInt32(NumberStr);
                return true;
            }
            catch
            {
                Console.WriteLine("非纯数字");
            }
            return false;
        }

        public static byte[] StringTOUtf8Byte(string Text)
        {
            /*
             https://msdn.microsoft.com/zh-cn/library/system.text.encodinginfo.getencoding(v=vs.110).aspx
             对应的字符编码集 
             */
            try
            {
                return Encoding.GetEncoding(65001).GetBytes(Text);
            }
            catch (Exception ex)
            {
                PrintLog.Log(ex);
                return new byte[0];
            }

        }
        /// <summary>
        /// 强制转型到int
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public static int StringToInt(String count)
        {
            int Number = 0;
            if (PureDigits(count))
                Number = Convert.ToInt32(count);
            return Number;
        }
    }
}
