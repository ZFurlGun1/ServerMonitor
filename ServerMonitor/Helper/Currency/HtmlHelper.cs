using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerMonitor.Helper.Currency
{
    class HtmlHelper
    {/// <summary>
     /// 加载HTML
     /// </summary>
     /// <param name="Htmlnode"></param>
     /// <returns></returns>
        public static HtmlDocument LoadHtml(String Htmlnode)
        {

            HtmlDocument doc = new HtmlDocument();
            try
            {
                doc.LoadHtml(Htmlnode);
            }
            catch (Exception ex)
            {
                PrintLog.Log(ex);
                PrintLog.Log("加载HTML错误 ");
            }
            return doc;
        }
        /// <summary>
        /// 选择并且返回HtmlNodeCollection
        /// </summary>
        /// <param name="Htmlnode"></param>
        /// <param name="Xpath"></param>
        /// <returns></returns>
        public static HtmlNodeCollection SelectNodes(String Htmlnode, String Xpath)
        {

            HtmlNodeCollection NodeCollectionvalue = null;
            try
            {
                NodeCollectionvalue = LoadHtml(Htmlnode).DocumentNode.SelectNodes(Xpath);
            }
            catch (Exception ex)
            {
                PrintLog.Log(ex);
                PrintLog.Log("选择器错误");
            }
            return NodeCollectionvalue;
        }/// <summary>
         /// 获取htmlNodeCollection里的inntext值
         /// </summary>
         /// <param name="Htmlnode"></param>
         /// <param name="Xpath"></param>
         /// <returns></returns>
        public static List<String> GetTextValueList(String Htmlnode, String Xpath)
        {
            List<string> ValueList = new List<string>();
            HtmlNodeCollection htmlNodeCollection = SelectNodes(Htmlnode, Xpath);
            if (htmlNodeCollection != null)

                foreach (HtmlNode SingleNode in htmlNodeCollection)
                {
                    ValueList.Add(SingleNode.InnerText);
                }
            return ValueList;
        }/// <summary>
         /// 获取A标签里的href属性值
         /// </summary>
         /// <param name="Htmlnode"></param>
         /// <param name="Xpath"></param>
         /// <returns></returns>

        public static List<String> GetLinkVlaueList(String Htmlnode, String Xpath)
        {
            List<string> ValueList = new List<string>();
            HtmlNodeCollection htmlNodeCollection = SelectNodes(Htmlnode, Xpath);
            if (htmlNodeCollection != null)
                foreach (HtmlNode SingleNode in htmlNodeCollection)
                {
                    try
                    {

                        ValueList.Add(SingleNode.Attributes["href"].Value);
                    }
                    catch (Exception ex)
                    {
                        PrintLog.Log(ex);
                        PrintLog.Log("获取超链接错误");
                    }
                }
            return ValueList;
        }/// <summary>
         /// 获取图片src的辅助方法
         /// </summary>
         /// <param name="Htmlnode"></param>
         /// <param name="Xpath"></param>
         /// <returns></returns>

        public static List<String> GetImgSrcVlaueList(String Htmlnode, String Xpath)
        {
            List<string> ValueList = new List<string>();
            HtmlNodeCollection htmlNodeCollection = SelectNodes(Htmlnode, Xpath);
            if (htmlNodeCollection != null)
                foreach (HtmlNode SingleNode in htmlNodeCollection)
                {
                    try
                    {

                        ValueList.Add(SingleNode.Attributes["src"].Value);
                    }
                    catch (Exception ex)
                    {
                        PrintLog.Log(ex);
                        PrintLog.Log("获取超链接错误");
                    }
                }
            return ValueList;
        }


        /// <summary>
        /// 获取图片src的辅助方法
        /// </summary>
        /// <param name="Htmlnode"></param>
        /// <param name="Xpath"></param>
        /// <returns></returns>

        public static List<String> GetAttributesVlaueList(String Htmlnode, String Attributes, String Xpath)
        {
            List<string> ValueList = new List<string>();
            HtmlNodeCollection htmlNodeCollection = SelectNodes(Htmlnode, Xpath);



            if (htmlNodeCollection != null)
                foreach (HtmlNode SingleNode in htmlNodeCollection)
                {
                    try
                    {
                     
                        ValueList.Add(SingleNode.Attributes[Attributes].Value);
                    }
                    catch (Exception ex)
                    {
                        PrintLog.Log(ex);
                        PrintLog.Log("获取GetAttributesVlaueList错误");
                    }
                }
            else
                Console.WriteLine("null");
            return ValueList;
        }
        /// <summary>
        /// 获取第一个值，因为htmlnode会崩溃所以要单独抽出来做
        /// </summary>
        /// <param name="list">需要liststing</param>
        /// <returns></returns>
        public static String FirstValue(List<String> list)
        {
            String value = "";
            foreach (string line in list)
            {
                value = line;
                break;
            }
            return value;
        }
    }
}
