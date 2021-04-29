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
            richTextBox2.Lines=  TempLink.ToArray();
        }
    }
}