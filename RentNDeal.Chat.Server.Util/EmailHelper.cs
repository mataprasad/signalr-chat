namespace RentNDeal.Chat.Server.Util
{
    using System.Net;
    using System.Net.Mail;

    public static class EmailHelper
    {
        public static void SendEmail(EmailRequest emailRequest)
        {
            using (MailMessage mm = new MailMessage(WebConfigHelper.BulkSenderEmailId, emailRequest.To))
            {
                mm.Subject = emailRequest.Subject;
                mm.Body = emailRequest.Body;
                mm.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = WebConfigHelper.SMTPHost;
                //smtp.EnableSsl = true;
                NetworkCredential NetworkCred = new NetworkCredential(WebConfigHelper.BulkSenderEmailId, WebConfigHelper.BulkSenderEmailPassword);
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                smtp.Port = WebConfigHelper.SMTPPort;
                smtp.Send(mm);//send email
            }
        }
    }

    public class EmailRequest
    {
        public string SenderUserName { get; set; }
        public string ReceiverUserName { get; set; }
        public string To { get; set; }
        public string Cc { get; set; }
        public string Bcc { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }

}
