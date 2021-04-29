using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServerMonitor.Helper.Currency
{
    class FloderHelper
    {
        /// <summary>
        /// 打开文件夹
        /// </summary>
        /// <param name="FloderPath"></param>
        public static void OpenFloder(string FloderPath) {

            if (!ViewHelper.MessageHelper.AlertNull(FloderPath))
                return;
            System.Diagnostics.Process.Start(FloderPath);
        }


        /// <summary>
        /// 获取文件夹路径
        /// </summary>
        /// <param name="FilePath"></param>
        /// <returns></returns>
        public static string GetFloderPath(String FilePath) {
            string Floderpath = "";
            try { Floderpath = Path.GetDirectoryName(FilePath)+"\\"; } catch (Exception ex) {

                PrintLog.Log(ex);
            }
            return Floderpath;
        }
        /// <summary>
        /// 每次启动程序清理缓存
        /// </summary>
        /// <param name="FloderPath"></param>
        public static void DeleteAllChildrenFile(String FloderPath)
        {

            foreach (string line in FloderHelper.GetFullFileNameList(FloderPath))
            {

            FileHelper.    FileDelete(line);
            }
        }
        /// <summary>
        /// 判断文件夹是否存在
        /// </summary>
        /// <param name="FloderPath"></param>
        /// <param name="CreatFlag"></param>
        /// <returns></returns>
        public static bool FloderExits(String FloderPath, bool CreatFlag)
        {
            if (!CreatFlag)
            {
                return false;
            }
            if (!Directory.Exists(FloderPath))
            {


                Console.WriteLine("已创建" + FloderPath);
                try { Directory.CreateDirectory(FloderPath); }
                catch (Exception ex)
                {
                    PrintLog.Log(ex);
                    PrintLog.Log("异常文件夹名字" + FloderPath);
                    return false;
                }

            }
            return true;
        }
        /// <summary>
        /// 删除文件夹  包括里面的文件
        /// </summary>
        /// <param name="FloderPath"></param>
        public static void FolderDelete(String FloderPath) {

            try {
                Directory.Delete(FloderPath,true);
            }catch(Exception ex) {

                PrintLog.Log(ex);
            }
        }
        /// <summary>
        /// 删除文件夹
        /// </summary>
        /// <param name="FloderPath"></param>
        public static void FolderCreate(String FloderPath)
        {

            try
            {
                Directory.CreateDirectory(FloderPath);
            }
            catch (Exception ex)
            {

                PrintLog.Log(ex);
            }
        }
        /// <summary>
        /// 获取目录下文件列表，带路径
        /// </summary>
        /// <param name="FloderPath"></param>
        /// <param name="Pattern"></param>
        /// <returns></returns>
        public static List<String> GetFullFileNameList(String FloderPath, String Pattern = "*.*")
        {

            List<String> FileList = new List<String>();
            try
            {
                FileList = Directory.GetFiles(FloderPath, Pattern).ToList<String>();
            }
            catch (Exception ex)
            {
                PrintLog.Log("当前是没有任何文件需要下载的情况，文件夹没有创建。");
                PrintLog.Log(ex);
            }
            return FileList;
        }
        /// <summary>
        /// 获取文件夹列表
        /// </summary>
        /// <param name="FloderPath"></param>
        /// <returns></returns>
        public static List<string> GetFloderNameList(string FloderPath) {
            List<string> FloderList = new List<string>();
            if (!FloderExits(FloderPath, true))
            {
                Console.WriteLine("创建新文件夹失败");
                return FloderList;

            }
            try
            {
                FloderList = Directory.GetDirectories(FloderPath).ToList<string>();
            }
            catch (Exception ex) {

                PrintLog.Log(ex);
            }
            return FloderList;
        }

        /// <summary>
        /// 移动文件夹文件到新文件夹
        /// </summary>
        /// <param name="OldFloder"></param>
        /// <param name="NewFloder"></param>
        public static void FloderFileMove(string OldFloder, string NewFloder) {

            if (!FloderExits(NewFloder,true))
            {
                Console.WriteLine("创建新文件夹失败");
                return;

            }
            foreach (string line in FloderHelper.GetFullFileNameList(OldFloder))
            {

                FileHelper.FileMove(line,Path.GetFullPath(NewFloder)+"\\" +Path.GetFileName(line));
            }
         
        }
        /// <summary>
        /// 选择一个文件夹
        /// </summary>
        /// <returns></returns>
        public static string SelectFloder() {

            using (FolderBrowserDialog SelectFileFolder = new FolderBrowserDialog())
            {
                if (SelectFileFolder.ShowDialog() == DialogResult.OK)
                {
                    return SelectFileFolder.SelectedPath;
                }
                else
                    return "";



                   

            }
        }
    }
}
