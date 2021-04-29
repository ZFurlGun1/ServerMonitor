using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServerMonitor.Helper.Currency
{
    class SelectHelper
    {
        public static string SelectFile(string InitialDirectory="", string Filter= "所有文件(*.*)|*.*")
        {
            string path = "";
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Multiselect = true;//该值确定是否可以选择多个文件
                dialog.Title = "请选择文件夹";
                if(InitialDirectory!="")
                dialog.InitialDirectory = InitialDirectory;
                if (Filter!="")
                dialog.Filter = Filter;
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    path = dialog.FileName;
                }
                Console.WriteLine(dialog.InitialDirectory);
            }
            return path;
        }
    }
}
