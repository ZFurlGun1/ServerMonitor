using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;

namespace ServerMonitor.Tool.Mail
{
    public partial class MailUserControl : UserControl
    {
        public MailUserControl()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MailHelper.SaveMailInfo("","","");
            SendMail();
        }

      
    }
}
