using Newtonsoft.Json;
using ServerMonitor.Helper;
using ServerMonitor.Helper.Currency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerMonitor.Tool.Mail
{
    class MailHelper
    {
 /// <summary>
 /// 保存邮箱信息 
 /// </summary>
 /// <param name="SendUserName"></param>
 /// <param name="SendUserPass"></param>
 /// <param name="SendStmp"></param>
 /// <param name="SendToMail"></param>

        internal static void SaveMailInfo(string SendUserName, string SendUserPass, string SendStmp,string SendToMail)
        {
            try
            {
                SendCatMailInfo product = new SendCatMailInfo()
                {
                    UserName = SendUserName,
                    UserPass = SendUserPass,
                    Stmp = SendStmp
                    ,
                    ToMail = SendToMail
                };

                string json = JsonConvert.SerializeObject(product);
                FileHelper.WriteUTF8Text(StaticValue.BinPath + "Mail.json", json);
            }
            catch (Exception ex) {

                PrintLog.Log(ex);
            }


        }
        public class SendCatMailInfo
        {
            private  string userName;
            private  string userPass;
            private  string stmp;
            private string toMail;
            public string UserName { get => userName; set => userName = value; }
           
            public string Stmp { get => stmp; set => stmp = value; }
            public string UserPass { get => userPass; set => userPass = value; }
            /// <summary>
            /// 到那个邮箱
            /// </summary>
            public string ToMail { get => toMail; set => toMail = value; }
        }
      
        /// <summary>
        ///  发送测试邮件
        /// </summary>
        /// <param name="SendUserName"></param>
        /// <param name="SendUserPass"></param>
        /// <param name="SendStmp"></param>
        /// <param name="Tomail"></param>
        public static void SendTsetMail(string SendUserName, string SendUserPass, string SendStmp,string Tomail) {


                SendMail(CreteClient(SendUserName, SendUserPass, SendStmp),CreateMail(SendUserName,Tomail,"test","This is test mail"));
        }

        /// <summary>
        ///  创建client
        /// </summary>
        /// <param name="SendUserName"></param>
        /// <param name="SendUserPass"></param>
        /// <param name="SendStmp"></param>
        /// <returns></returns>
        public static System.Net.Mail.SmtpClient CreteClient(string SendUserName, string SendUserPass, string SendStmp) {



            //生成一个   使用SMTP发送邮件的客户端对象 
            System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient(SendStmp);

            //表示以当前登录用户的默认凭据进行身份验证 
            client.UseDefaultCredentials = true;

            //包含用户名和密码 
            client.Credentials = new System.Net.NetworkCredential(SendUserName, SendUserPass);

            //指定如何发送电子邮件。 
            //Network                                          电子邮件通过网络发送到   SMTP   服务器。       
            //PickupDirectoryFromIis        将电子邮件复制到挑选目录，然后通过本地   Internet   信息服务   (IIS)   传送。       
            //SpecifiedPickupDirectory    将电子邮件复制到   SmtpClient.PickupDirectoryLocation   属性指定的目录，然后由外部应用程序传送。       

            client.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;

            return client;
        }
        /// <summary>
        /// 最后一步发布
        /// </summary>
        /// <param name="client"></param>
        /// <param name="message"></param>
        private static   void SendMail(System.Net.Mail.SmtpClient client, System.Net.Mail.MailMessage message)
        {
         

            try
            {
                //异步发送 
                //client.SendAsync(message, "");
                client.Send(message);  //<strong><span style="color:#ff0000;">此处引发异常</span></strong>
                                       //  return true; //发送成功
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        /// <summary>
        /// 创建一封邮件
        /// 
        /// </summary>
        /// <param name="FormMail"></param>
        /// <param name="ToMail"></param>
        /// <param name="Title"></param>
        /// <param name="Content"></param>
        /// <returns></returns>
        private static System.Net.Mail.MailMessage CreateMail(string FormMail,string ToMail,string Title,string Content)
        {

            //建立邮件对象    
            System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage(FormMail,ToMail,Title,Content);

            //定义邮件正文，主题的编码方式 
            message.BodyEncoding = System.Text.Encoding.UTF8;
            message.SubjectEncoding = System.Text.Encoding.UTF8;

            //获取或设置一个值，该值指示电子邮件正文是否为   HTML。    
            message.IsBodyHtml = true;

            //指定邮件优先级 

            message.Priority = System.Net.Mail.MailPriority.High;
            return message;
        }
    }
}
