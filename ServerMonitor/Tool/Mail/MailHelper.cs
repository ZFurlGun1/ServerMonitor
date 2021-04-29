using Newtonsoft.Json;
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
 

        internal static void SaveMailInfo(string SendUserName, string SendUserPass, string SendStmp)
        {
            try
            {
                SendCatMailInfo product = new SendCatMailInfo()
                {
                    UserName = SendUserName,
                    UserPass = SendUserPass,
                    Stmp = SendStmp
                };

                string json = JsonConvert.SerializeObject(product);
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

            public string UserName { get => userName; set => userName = value; }
           
            public string Stmp { get => stmp; set => stmp = value; }
            public string UserPass { get => userPass; set => userPass = value; }
        }
        public class UserData
        {
            string WebLink;
            string Xpath;
            string FileName;

            public string WebLink1 { get => WebLink; set => WebLink = value; }
            public string Xpath1 { get => Xpath; set => Xpath = value; }
            public string FileName1 { get => FileName; set => FileName = value; }
        }

        private void SendMail()
        {




            //生成一个   使用SMTP发送邮件的客户端对象 
            System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient("smtp.exmail.qq.com");

            //表示以当前登录用户的默认凭据进行身份验证 
            client.UseDefaultCredentials = true;

            //包含用户名和密码 
            client.Credentials = new System.Net.NetworkCredential("pixiv@acg12.cn", "utyJCQ3NPPkLJOuF");

            //指定如何发送电子邮件。 
            //Network                                          电子邮件通过网络发送到   SMTP   服务器。       
            //PickupDirectoryFromIis        将电子邮件复制到挑选目录，然后通过本地   Internet   信息服务   (IIS)   传送。       
            //SpecifiedPickupDirectory    将电子邮件复制到   SmtpClient.PickupDirectoryLocation   属性指定的目录，然后由外部应用程序传送。       

            client.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;

            //建立邮件对象    
            System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage("pixiv@acg12.cn", "1428245421@qq.com", "test", "It is a test");

            //定义邮件正文，主题的编码方式 
            message.BodyEncoding = System.Text.Encoding.UTF8;
            message.SubjectEncoding = System.Text.Encoding.UTF8;

            //获取或设置一个值，该值指示电子邮件正文是否为   HTML。    
            message.IsBodyHtml = true;

            //指定邮件优先级 

            message.Priority = System.Net.Mail.MailPriority.High;


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
    }
}
