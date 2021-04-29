using ServerMonitor.Helper;
using ServerMonitor.Helper.Currency;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServerMonitor
{
    public partial class SystemMain : Form
    {
        public SystemMain()
        {
            InitializeComponent();
            InitView();
        }

        private void InitView()
        {
            FloderHelper.FloderExits(StaticValue.UserInfoPath,true);
            FloderHelper.FloderExits(StaticValue.OldLogPath, true);
            FloderHelper.FloderExits(StaticValue.SiteLogFloderPath, true);
            Helper.ViewHelper.GroupBoxHelper.Replace(groupBox1, new Tool.MainInterface.SiteControl());
            //   listBox1.Items.AddRange(Tool.LocalView.AddListItems());

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Helper.ViewHelper.GroupBoxHelper.Replace(groupBox1, new Tool.AddSite.AddSiteUserControl());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FloderHelper.OpenFloder(".\\");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Helper.ViewHelper.GroupBoxHelper.Replace(groupBox1, new Tool.MainInterface.SiteControl());
        }
    }
}
