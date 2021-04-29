﻿using ServerMonitor.Helper;
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
            List<string> ReadAllLine = FileHelper.ReadAllLine(StaticValue.UserInfoPath);
            listBox1.Items.AddRange(ReadAllLine.ToArray());
           
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
