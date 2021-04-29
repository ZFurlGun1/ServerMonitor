using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ServerMonitor.Helper.Currency.CookiesWebclient
{
    class CWebclient:WebClient
    {
        private CookieContainer TempcookieContainer;
        public CWebclient() {

            this.TempcookieContainer = new CookieContainer();
        }
        public CWebclient(CookieContainer cookie) {
            this.TempcookieContainer = cookie;
        }

        public CookieContainer TempcookieContainer1 { get => TempcookieContainer; set => TempcookieContainer = value; }
        /// <summary>
        /// 重新赋值cookies
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        protected override WebRequest GetWebRequest(Uri address)
        {
            WebRequest request = base.GetWebRequest(address);
            if (request is HttpWebRequest) {
                HttpWebRequest httpWebRequest = request as HttpWebRequest;
                httpWebRequest.CookieContainer = TempcookieContainer;
            }
            return request;
        }
        /// <summary>
        /// 获取源码
        /// </summary>
        /// <param name="Link"></param>
        /// <param name="webHeaderCollection"></param>
        /// <returns></returns>
        public string GetHtml(string Link, WebHeaderCollection webHeaderCollection) {
            string ReqText = "";
            this.Headers = webHeaderCollection;
            /*
            this.Headers.Add("User-Agent", StaticValue.UserAgent);
            this.Headers.Add("Accept-Language", "zh-TW,zh;q=0.8,en-US;q=0.5,en;q=0.3");*/
         //   this.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
            try
            {
                byte[] responseData = this.DownloadData(Link);
                ReqText = TextHelper.ByteTOUtf8String(responseData);
            }
            catch (Exception ex)
            {

                PrintLog.Log(ex);
            }
            return ReqText;
        }
        /// <summary>
        /// 发送post
        /// </summary>
        /// <param name="PostUrl"></param>
        /// <param name="PostData"></param>
        /// <param name="webHeaderCollection"></param>
        /// <returns></returns>
        public  string  SendPost(string PostUrl, string PostData,WebHeaderCollection webHeaderCollection) {
           
            byte[] PostDataByte = TextHelper.StringTOUtf8Byte(PostData);
            this.Headers = webHeaderCollection;
            /*
            this.Headers.Add("User-Agent", StaticValue. UserAgent);
            this.Headers.Add("Accept-Language", "zh-TW,zh;q=0.8,en-US;q=0.5,en;q=0.3");*/
            this.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
            String ReqText = "";
            try
            {
                byte[] responseData = this.UploadData(PostUrl, "POST", PostDataByte);
             ReqText = TextHelper.ByteTOUtf8String(responseData);
            } catch (Exception ex) {

                PrintLog.Log(ex);
            }
          
            return ReqText;
        }
    }
}
