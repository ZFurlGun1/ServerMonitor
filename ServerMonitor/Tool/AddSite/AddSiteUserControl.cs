using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServerMonitor.Tool.AddSite
{
    public partial class AddSiteUserControl : UserControl
    {
        public AddSiteUserControl()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
         AddSite.AddHelper.   TextWebInfo(textBox1.Text, textBox2.Text, richTextBox1, richTextBox2);
        }
    }
}
