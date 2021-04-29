using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServerMonitor.Tool.MainInterface
{
    public partial class SiteControl : UserControl
    {
        public SiteControl()
        {
            InitializeComponent();
            InitView();
        }

        private void InitView()
        {
            listBox1.Items.AddRange(Tool.LocalView.AddListItems());
        }

        private void button1_Click(object sender, EventArgs e)
        {
          S  listBox1.Items.Count;
        }
    }
}
