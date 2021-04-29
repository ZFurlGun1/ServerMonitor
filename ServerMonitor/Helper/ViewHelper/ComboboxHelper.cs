using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServerMonitor.Helper.ViewHelper
{
    class ComboboxHelper
    {
        internal static void ChangeItems(ComboBox comboBox1, List<string> ItemList)
        {
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(ItemList.ToArray());
            comboBox1.DroppedDown = Helper.StaticValue.ComboxShowFlag;
        }
    }
}
