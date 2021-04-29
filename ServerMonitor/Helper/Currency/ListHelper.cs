using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerMonitor.Helper.Currency
{
    class ListHelper
    {
        /// <summary>
        /// List去重复
        /// </summary>
        /// <param name="OldList"></param>
        /// <returns></returns>
        public static List<string> ListRepeat(List<string> OldList)
        {
            List<string> ToRepeat =new List<string>();
          
            foreach (string line in OldList)
            {
                if (!TextHelper.JudgeNull(line) && !ToRepeat.Contains(line))
                    ToRepeat.Add(line);
                else {
                    Console.WriteLine("去除关键词{0}",line);
                }
              
            }
            return ToRepeat;
        }
        /// <summary>
        ///  List判断在一个子集里  如果存在返回true，不存在返回false
        /// </summary>
        /// <param name="Sublist">子集 </param>
        /// <param name="ParentList">父集</param>
        /// <returns></returns>
        public static bool JudgeRepetition(List<string> Sublist,List<string> ParentList)
        {
            Sublist = ListRepeat(Sublist);
            ParentList = ListRepeat(ParentList);
        
            foreach (string line in Sublist)
            {
                if (ParentList.Contains(line)) {
                    Console.WriteLine("屏蔽词：" + line);
                       return true;
                }
               

            }
                return false;
          
        }

    }
}
