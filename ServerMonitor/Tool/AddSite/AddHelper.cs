using Newtonsoft.Json;
using ServerMonitor.Helper;
using ServerMonitor.Helper.Currency;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ServerMonitor.Tool.AddSite
{
    internal class AddHelper
    {
        internal static void TextWebInfo(string WebLink, string Xpath, RichTextBox richTextBox1, RichTextBox richTextBox2)
        {
            string Shtml = WebHelper.HttpGet(WebLink);
            richTextBox1.Text = Shtml;
            List<string> TempLink = HtmlHelper.GetLinkVlaueList(Shtml, Xpath);
            richTextBox2.Lines = TempLink.ToArray();
        }
       public class UserData {
            string WebLink;
            string Xpath;
            string FileName;

            public string WebLink1 { get => WebLink; set => WebLink = value; }
            public string Xpath1 { get => Xpath; set => Xpath = value; }
            public string FileName1 { get => FileName; set => FileName = value; }
        }
        internal static void SaveWebSiteJson(string WebUrl, string Xpath, string Filename)
        {
            String SavePath = StaticValue.UserInfoPath + TextHelper.ReplaceBadChar(Filename) + ".json";
            
            string json = JsonConvert.SerializeObject(new UserData() {WebLink1=WebUrl,Xpath1=Xpath,FileName1= TextHelper.ReplaceBadChar(Filename) });
            FileHelper.WriteUTF8Text(SavePath,json);
        }
    }
}