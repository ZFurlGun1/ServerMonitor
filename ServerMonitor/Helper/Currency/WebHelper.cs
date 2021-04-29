using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ServerMonitor.Helper.Currency
{
    class WebHelper
    {


        /// <summary>
        /// 获取JSON，使用手机UA
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static String HttpGetJsonForMobile(String url)
        {

            String HtmlCode = "";
            Console.WriteLine(url);
            using (WebClient webClient = new WebClient())
            {
                webClient.Headers.Add("Host", new Uri(url).Host);
                webClient.Headers.Add("User-Agent", StaticValue.MoblieUserAgent);
                webClient.Headers.Add("Accept-Language", "zh-TW,zh;q=0.8,en-US;q=0.5,en;q=0.3");
                webClient.Headers.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8");
                webClient.Headers.Add("Accept-Language", "zh-TW,zh;q=0.8,en-US;q=0.5,en;q=0.3");
                webClient.Headers.Add("Pragma", "no-cache");
                webClient.Headers.Add("Cache-Control", "no-cache");

                try
                {
                    HtmlCode = new StreamReader(webClient.OpenRead(url)).ReadToEnd();
                }
                catch (Exception ex)
                {

                    PrintLog.Log(ex);
                }
            }
            return HtmlCode;

        }
        /// <summary>
        /// 同步获取html代码
        /// </summary>
        /// <param name="Url"></param>
        /// <returns></returns>
        public static string HttpGet(String Url)
        {
          

            String HtmlCode = "";

            using (WebClient webClient = new WebClient())
            {

                try
                {
                    webClient.Headers.Add("User-Agent", StaticValue.UserAgent);
                    webClient.Headers.Add("Accept-Language", "zh-CN,zh;q=0.9");
                    HtmlCode = new StreamReader(webClient.OpenRead(Url)).ReadToEnd();
                }
                catch (Exception ex)
                {

                    PrintLog.Log(ex);
                }
            }
            return HtmlCode;
        }

        public static string PostDataForAjax(String Url, string PostData)
        {
            using (WebClient PostWebClient = new WebClient())
            {

                String Host = GetHost(Url);
                if (Host != "")
                    PostWebClient.Headers.Add("Host", Host);

                PostWebClient.Headers.Add("User-Agent", StaticValue.UserAgent);

                PostWebClient.Headers.Add("Accept", "*/*");
                PostWebClient.Headers.Add("Accept-Language", "zh-TW,zh;q=0.8,en-US;q=0.5,en;q=0.3");

                PostWebClient.Headers.Add("Content-Type", "application/x-www-form-urlencoded; charset=UTF-8");
                PostWebClient.Headers.Add("X-Requested-With", "XMLHttpRequest");

                try
                {
                    byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(PostData);


                    byte[] responseArray = PostWebClient.UploadData(Url, byteArray);


                    return Encoding.Default.GetString(responseArray);


                }
                catch (Exception ex)
                {
                    PrintLog.Log(ex);
                }

            }
            return "";
        }
        public static string GetHost(String Url)
        {
            try
            {
                return new Uri(Url).Host;
            }
            catch (Exception ex)
            {
                PrintLog.Log(ex);
            }
            return "";
        }
        /// <summary>
        /// 获取301转移状态码，侦测资源是否发生了转移 转移返回true
        /// </summary>
        /// <param name="Link"></param>
        /// <returns></returns>
        public static bool GetStatusCode301OR404(String Link)
        {

            HttpWebRequest httpReq = (HttpWebRequest)WebRequest.Create(Link);
            httpReq.UserAgent = StaticValue.UserAgent;
            httpReq.AllowAutoRedirect = false;//禁止自动重定向
            try
            {
              
                using (HttpWebResponse httpRes = (HttpWebResponse)httpReq.GetResponse())
                {

                    if (httpRes.StatusCode == HttpStatusCode.Moved)
                    {
                        // Code for moved resources goes here.
                        return true;
                    }

                }
            }
            catch (Exception ex)
            {
                string link = ex.Message;
                if (link.IndexOf("404") > 0)
                    return true;
                Console.WriteLine(ex.Message);

            }
            return false;
        }
        /// <summary>
        /// 文件下载 文件名默认自动生成
        /// </summary>
        /// <param name="FileUrl"></param>
        /// <param name="DefaultName"></param>
        /// <returns></returns>
        public static String FileDownload(String FileUrl, WebHeaderCollection headers, String DefaultFileName = "")
        {
            Console.WriteLine(FileUrl);
            String Filename = "";
            if (DefaultFileName != "")
                Filename = DefaultFileName;
            else
            {
                Filename= FileDownNameHelper(StaticValue.ImgTemp1, FileUrl);
             
            }

            using (WebClient DownloadWebClient = new WebClient())
            {
                DownloadWebClient.Headers = headers;
                try
                {
                  
                    DownloadWebClient.DownloadFile(new Uri(FileUrl), Filename);
                }
                catch (Exception ex)
                {
                    PrintLog.Log(ex);
                    Filename = "";
                }



            }
            return Filename;

        }
        /// <summary>
        /// 下载图片的方法 
        /// </summary>
        /// <param name="FloderPath"></param>
        /// <param name="FileUrl"></param>
        /// <param name="headers"></param>
        /// <param name="DownStringCompletedCallBack"></param>
        /// <param name="ProgressCountCallBack"></param>
        /// <param name="FilstFlag"></param>
        public static void ImgDownload(String FloderPath, String FileUrl, WebHeaderCollection headers, AsyncCompletedEventHandler DownStringCompletedCallBack = null,
            DownloadProgressChangedEventHandler ProgressCountCallBack = null,bool FilstFlag=true)
        {
         
        

            using (WebClient webClient = new WebClient())
            {
                webClient.Headers = headers;


                String SavePath = FileDownNameHelper(FloderPath, FileUrl);
                Console.WriteLine(SavePath);
                if (SavePath == "")
                    return;
                if (DownStringCompletedCallBack != null)
                    webClient.DownloadFileCompleted += DownStringCompletedCallBack;
                if (ProgressCountCallBack != null)
                    webClient.DownloadProgressChanged += ProgressCountCallBack;

                try
                {
                    webClient.DownloadFileAsync(new Uri(FileUrl), SavePath);

                }
                catch (Exception ex)
                {
                    PrintLog.Log(ex);
                    PrintLog.Log("下载出错的链接：" + FileUrl);

                   
                }

            }

        }
        /// <summary>
        /// 下载帮助，快速创建文件夹初始化路径
        /// </summary>
        /// <param name="FloderPath"></param>
        /// <param name="FileUrl"></param>
        /// <returns></returns>
        public static string FileDownNameHelper(string FloderPath, string FileUrl)
        {
            if (!FloderHelper.FloderExits(FloderPath, true))
                return "";
            FileUrl= FloderPath + Path.GetFileName(FileUrl);
            if (FileUrl.Length > 200)//文件名过长的情况进行溢出截断
                FileUrl = FloderPath + DateTime.Now.ToFileTime().ToString() + Path.GetExtension(FileUrl);
            return FileUrl;
        }

    


        /// <summary>
        /// 获取http响应状态码的类，需要连接
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static bool GetStatusCode(String url)
        {
            HttpWebRequest httpReq = (HttpWebRequest)WebRequest.Create(url);
            httpReq.Referer = "https://www.pixiv.net/member_illust.php?mode=medium&illust_id=" + Path.GetFileNameWithoutExtension(url);
            httpReq.Host = new Uri(url).Host;
            httpReq.AllowAutoRedirect = true;//这里很重要，如果你跟随和不跟随重定向得到的结果不同，由于我项目需要跟随重定向，故已经跟随。如果不需要请改为false
            httpReq.UserAgent = StaticValue.UserAgent;

            try
            {
                using (HttpWebResponse httpRes = (HttpWebResponse)httpReq.GetResponse())
                {
                    Console.WriteLine("响应码为：" + httpRes.StatusCode);
                    if (httpRes.StatusCode == HttpStatusCode.OK)
                    {
                        Console.WriteLine(httpRes.StatusCode);

                        return true;
                    }

                    Console.WriteLine("StatusCode" + httpRes.StatusCode);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ///404 403之类的错误会在这里出现
            }
            return false;
        }
    }
}
