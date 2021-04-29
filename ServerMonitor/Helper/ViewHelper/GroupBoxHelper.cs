using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ServerMonitor.Helper.ViewHelper
{
    class GroupBoxHelper
    {/// <summary>
    /// GroupBox替换操作
    /// </summary>
    /// <param name="groupBox1"></param>
    /// <param name="Control"></param>
        internal static void Replace(GroupBox groupBox1, UserControl Control)
        {
            groupBox1.Controls.Clear();
            groupBox1.Controls.Add(Control);
        }
    }
}
