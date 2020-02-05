using BLL;
using Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace WebUI
{
    /// <summary>
    /// register 的摘要说明
    /// </summary>
    public class register : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            switch (context.Request["action"].ToString())
            {
                case "GetEmail":
                    GetEmail(context);
                    break;

                case "HasUser":
                    HasUser(context);
                    break;
            }
        }

        /// <summary>
        /// 判断用户是否抢注
        /// </summary>
        /// <param name="context"></param>
        private void HasUser(HttpContext context)
        {
            List<UsersInfoModel> ls = new LoginBLL().HasUser();

            //判断是否有重复名
            foreach (UsersInfoModel item in ls)
            {
                if (item.UserAccount == context.Request["UserAccount"].Trim())
                {
                    context.Response.Write(true);
                    return;
                }
            }

            context.Response.Write(false);
        }

        /// <summary>
        /// 邮箱验证码
        /// </summary>
        /// <param name="context"></param>
        public void GetEmail(HttpContext context)
        {
            //发送邮件
            //实例化一个发送邮件类。
            MailMessage mailMessage = new MailMessage();
            //发件人邮箱地址，方法重载不同，可以根据需求自行选择。
            mailMessage.From = new MailAddress("1812613402@qq.com");
            //收件人邮箱地址。

            string num = context.Request["Email"].ToString();
            mailMessage.To.Add(new MailAddress("1812613402@qq.com"));
            //邮件标题。
            mailMessage.Subject = "发送邮件测试";
            //邮件内容。
            Random random = new Random();
            int x = random.Next(1000, 9999);
            mailMessage.Body = "您的验证码为" + x.ToString();

            //实例化一个SmtpClient类。
            SmtpClient client = new SmtpClient();

            //在这里我使用的是qq邮箱，所以是smtp.qq.com，如果你使用的是126邮箱，那么就是smtp.126.com。
            client.Host = "smtp.qq.com";

            //使用安全加密连接。
            client.EnableSsl = true;

            //不和请求一块发送。
            client.UseDefaultCredentials = false;

            //验证发件人身份(发件人的邮箱，邮箱里的生成授权码);
            client.Credentials = new NetworkCredential("1812613402@qq.com", "dduudtjypszgbceh");

            //发送
            client.Send(mailMessage);

            context.Response.Write(x);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}