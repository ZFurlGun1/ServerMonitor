using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServerMonitor.Helper.ViewHelper
{
    class MessageHelper
    {
        /// <summary>
        /// 判断并且警告用户内容为空  为空返回false
        /// </summary>
        /// <param name="Text"></param>
        public static bool AlertNull(String Text) {
            if (Currency.TextHelper.JudgeNull(Text))
            {
                MessageBox.Show("内容不能为空");
                return false;
            }
            return true;
        }
        public static void Alert(String Tip) {
            MessageBox.Show(Tip);
        }
        /// <summary>
        /// 确定取消 按钮，返回结果
        /// </summary>
        /// <param name="Tip"></param>
        /// <returns></returns>
        public static bool DialogResultAlert(String Tip) {
            DialogResult DialogShow = MessageBox.Show(Tip, "提示", MessageBoxButtons.OKCancel);
            if (DialogShow == DialogResult.OK)
            {
                return true;
            }
            else if (DialogShow == DialogResult.Cancel)
            {
                return false;
            }
            return false;
        }
    }
}
