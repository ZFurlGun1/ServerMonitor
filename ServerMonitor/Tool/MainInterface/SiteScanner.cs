using Newtonsoft.Json;
using ServerMonitor.Helper;
using ServerMonitor.Helper.Currency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServerMonitor.Tool.MainInterface
{
    class SiteScanner
    {
        internal static void Start(ListBox listBox1)
        {
            foreach (string Line in listBox1.Items) {
              
                InitScanner(Line);
            }
            foreach (string Line in listBox1.Items)
            {

                CreateLog(Line);
            }
        }
        /// <summary>
        /// 根据上个方法，获取每个方法的数据
        /// </summary>
        /// <param name="line"></param>
        private static void CreateLog(string UserDataName)
        {
            string ReadLinfo = StaticValue.SiteLogFloderPath + UserDataName + DateTime.Now.ToString("yyyyMMdd");
            List<string> TempList = FileHelper.ReadAllLine(ReadLinfo);
            Console.WriteLine("{0}发布了{1}个资源。",UserDataName,TempList.Count);

        }

        /// <summary>
        /// 初始化扫描
        /// </summary>
        /// <param name="UserDataJson"></param>
        private static void InitScanner(string UserDataJson)
        {
            try
            {
                string ReadJson = FileHelper.ReadContextUtf8(StaticValue.UserInfoPath + UserDataJson + ".json");
                Tool.AddSite.AddHelper.UserData ALLJson = JsonConvert.DeserializeObject<Tool.AddSite.AddHelper.UserData>(ReadJson);
                string Shtml = WebHelper.HttpGet(ALLJson.WebLink1);
                List<string> TempList = HtmlHelper.GetLinkVlaueList(Shtml, ALLJson.Xpath1);
                foreach (string Line in TempList) {
                    string Temptext = Line + DateTime.Now.ToString("yyyyMMdd");
                    if (!StaticValue.LogList.Contains(Temptext))
                    {
                        Console.WriteLine("加入{0}",Line);
                        PrintLog.ReflushLog(StaticValue.UrlLogFile, StaticValue.LogList, Temptext);
                        FileHelper.AppendUTF8Text(StaticValue.SiteLogFloderPath + UserDataJson + DateTime.Now.ToString("yyyyMMdd"), Temptext);
                    }
               
                }

            }
            catch (Exception ex) {
                PrintLog.Log(ex);
            }

        }
    }
}
