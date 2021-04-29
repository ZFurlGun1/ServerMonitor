using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerMonitor.Helper.Currency
{
    class FileHelper
    {
        /// <summary>
        /// 文件是否存在，是否需要创建
        /// </summary>
        /// <param name="FilePath"></param>
        /// <param name="CreateFlag"></param>
        /// <returns></returns>
        public static bool FileExits(String FilePath, bool CreateFlag = false)
        {

            if (File.Exists(FilePath))
            {

                return true;
            }

            else {
                if (CreateFlag)
                {
                    try
                    {
                        File.AppendAllText(FilePath, "");
                        return true;
                    }
                    catch (Exception ex) {
                        PrintLog.Log(ex);
                    }


                }
            }
                return false;
        }
        /// <summary>
        /// 用utf8读取文件
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string ReadContextUtf8(string path)
        {
            FileExits(path, true);
            try
            {
                using (FileStream fs = new FileStream(path, FileMode.Open))
                {
                    using (StreamReader sr = new StreamReader(fs, System.Text.Encoding.UTF8))
                    {
                        return sr.ReadToEnd();

                    }
                }
            }
            catch (Exception ex) {
                PrintLog.Log(ex);
            }
            return "";
        }

 
        /// <summary>
        /// 获取文件名 不带路径
        /// </summary>
        /// <param name="FilePath"></param>
        /// <param name="Pattern"></param>
        /// <returns></returns>
        public static string GetFileName(String FilePath)
        {

            String FileName = "";
            try
            {
                FileName=Path.GetFileName(FilePath);

            }
            catch (Exception ex)
            {
                PrintLog.Log("当前是没有任何文件需要下载的情况，文件夹没有创建。");
                PrintLog.Log(ex);
            }
            return FileName;
        }



        /// <summary>
        /// 获取文件名列表，包含完整路径
        /// </summary>
        /// <param name="FloderPath"></param>
        /// <param name="Pattern"></param>
        /// <returns></returns>
        public static List<string> GetFullFileNameList(String FloderPath, String Pattern = "*.*")
        {

            List<String> FileList = new List<String>();
            try
            {
                foreach (string line in Directory.GetFiles(FloderPath, Pattern))
                    FileList.Add(line);

            }
            catch (Exception ex)
            {
                PrintLog.Log("当前是没有任何文件需要下载的情况，文件夹没有创建。");
                PrintLog.Log(ex);
            }
            return FileList;
        }

        /// <summary>
        /// 统一写入utf8的方法
        /// </summary>
        /// <param name="FilePath"></param>
        /// <param name="Content"></param>
        public static void AppendUTF8Text(String FilePath, String Content)
        {
            File.AppendAllText(FilePath, "\r\n" + Content, Encoding.UTF8);

        }
        /// <summary>
        /// 统一写入utf8的方法
        /// </summary>
        /// <param name="FilePath"></param>
        /// <param name="Content"></param>
        public static void AppendUTF8List(String FilePath, List<String> Content)
        {
            FilePath = JudgePath(FilePath);
            File.AppendAllText(FilePath, "\r\n", Encoding.UTF8);
            File.AppendAllLines(FilePath, Content, Encoding.UTF8);

        }

        private static string JudgePath(string filePath)
        {
            if (filePath.Length < 240)
                return filePath;
            else
            {
                String FloderPath = Path.GetDirectoryName(filePath)+"\\";
                string FileName = Path.GetFileNameWithoutExtension(filePath);
                FloderPath = FloderPath + FileName.Substring(0, 150);

                return FloderPath+Path.GetExtension(filePath);
            }
        }

        /// <summary>
        /// 覆盖源文件，写入list
        /// </summary>
        /// <param name="FilePath"></param>
        /// <param name="Content"></param>
        public static void WriteUTF8List(String FilePath, List<String> Content)
        {
            try
            {
                FloderHelper.FloderExits(FloderHelper.GetFloderPath(FilePath), true);
                File.WriteAllLines(FilePath, Content, Encoding.UTF8);
            }
            catch (Exception ex)
            {
                PrintLog.Log(ex);
            }
        }
        /// <summary>
        /// 覆盖源文件，写入text
        /// </summary>
        /// <param name="FilePath"></param>
        /// <param name="Content"></param>
        public static void WriteUTF8Text(String FilePath, string Content)
        {
        
            try
            {
                FloderHelper.FloderExits(FloderHelper.GetFloderPath(FilePath), true);
                File.WriteAllText(FilePath, Content, Encoding.UTF8);
            }
            catch (Exception ex)
            {
                PrintLog.Log(ex);
            }
        }
        /// <summary>
        /// 读取所有行 不存在则创建
        /// </summary>
        /// <param name="FilePath"></param>
        /// <param name="CreateFlag"></param>
        /// <returns></returns>
        public static List<string> ReadAllLine(String FilePath,bool CreateFlag= true)
        {
            List<String> ReadAllLine = new List<string>();
            try
            {
                if (FileExits(FilePath))
                    ReadAllLine = File.ReadAllLines(FilePath).ToList<string>();
                else {
                    if (CreateFlag)
                        File.AppendAllText(FilePath, "",Encoding.UTF8);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return ReadAllLine;
        }
        /// <summary>
        /// 去重复行和空行，然后重新覆盖这个文件
        /// </summary>
        public static void ToRepartLine(String FilePath)
        {
            List<String> AllLine = ReadAllLine(FilePath);

            File.Copy(FilePath, FilePath + ".bak", true);
            foreach (String line in File.ReadAllLines(FilePath))
            {

                if (line != "" && (!AllLine.Contains(line)))
                {
                    AllLine.Add(line.Trim());
                    Console.WriteLine("已读取" + line);
                }
            }
            File.WriteAllLines(FilePath, AllLine);
        }
        /// <summary>
        /// 移动文件
        /// </summary>
        /// <param name="FilePath"></param>
        /// <param name="NewFilePath"></param>
        public static void FileMove(String FilePath, String NewFilePath)
        {
            try
            {
              FloderHelper.  FloderExits(Path.GetDirectoryName(NewFilePath), true);
                if (File.Exists(NewFilePath))
                    NewFilePath = FloderHelper.GetFloderPath(NewFilePath) + DateTime.Now.ToFileTime() + GetFileName(NewFilePath);
                File.Move(FilePath, NewFilePath);
            }
            catch (Exception ex)
            {
                PrintLog.Log(ex);
            }
        }

        /// <summary>
        /// 删除文件的方法，会告诉你删除是否成功
        /// </summary>
        /// <param name="Filename"></param>
        /// <returns></returns>
        public static bool FileDelete(String Filename)
        {
            try
            {
                File.Delete(Filename);
                return true;
            }
            catch (Exception ex)
            {
                PrintLog.Log(ex);
                return false;
            }
        }

        /// <summary>
        /// 判断文件大小是否超过了界限，超过返回false
        /// </summary>
        /// <param name="FileName"></param>
        /// <param name="FileSize">文件大小 KB</param>
        /// <returns></returns>
        public static bool JudgementOfSize(String FileName, int FileSize)
        {

            FileInfo fi = new FileInfo(FileName);
            if (fi.Length > 1024 * FileSize)
            {

                return false;
            }
            return true;
        }

        
        /// <summary>
        /// 修改文件md5
        /// </summary>
        /// <param name="Filename"></param>
        public static void ModifyMD5(String Filename)
        {

            if (!File.Exists(Filename))
            {
                Console.WriteLine("文件不存在");
                return;
            }
            else
            {
                //转化byte[]到list 
                List<byte> ByteList = File.ReadAllBytes(Filename).ToList<byte>();
                ///添加一个二进制随机数
                ByteList.AddRange(Encoding.Default.GetBytes(Convert.ToString(new Random().Next(), 2)).ToList<byte>());
                try
                {
                    File.WriteAllBytes(Filename, ByteList.ToArray());
                }
                catch (Exception ex)
                {

                    PrintLog.Log(ex);
                };

            }


        }

        /// <summary>
        /// 获取文件大小 返回的是byte
        /// </summary>
        /// <param name="sFullName"></param>
        /// <returns></returns>
        public static long GetFileSizeForByte(string sFullName)
        {
            long lSize = 0;
           
            if (File.Exists(sFullName))
                lSize = new FileInfo(sFullName).Length;
            return lSize;
        }
        /// <summary>
        /// 获取文件大小 返回的是KB
        /// </summary>
        /// <param name="sFullName"></param>
        /// <returns></returns>
        public static double GetFileSizeForKB(string sFullName)
        {
            long FactSize = GetFileSizeForByte(sFullName);
            Console.WriteLine(FactSize);
            return (FactSize / 1024.00);
        }
    }
}
