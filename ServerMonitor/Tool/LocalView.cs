using ServerMonitor.Helper;
using ServerMonitor.Helper.Currency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServerMonitor.Tool
{
    class LocalView
    {
        internal static string[] AddListItems()
        {

            List<string> TempList = new List<string>();
            foreach (string line in FloderHelper.GetFullFileNameList(StaticValue.UserInfoPath)) {
                string Temptext = FileHelper.GetFileNameWithoutExtension(line);
                if (Temptext != "")
                    TempList.Add(FileHelper.GetFileNameWithoutExtension(line));
            }

                return TempList.ToArray();
        }
    }
}
