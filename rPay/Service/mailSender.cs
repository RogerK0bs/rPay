using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace rPay.Service
{
    public class mailSender
    {
        string FIO = "";
        public void mailForward(string mail, string text, string pacient)
        {
            SmtpClient smtp = new SmtpClient();
            //string host = "192.168.100.27";
            string host = "192.168.112.72";
            int port = 25;
            MailAddress from = new MailAddress("medica.nsk-sbp@gm.clinic", "ООО Медика НСК");
            MailAddress to = new MailAddress(mail);
            MailMessage m = new MailMessage(from, to);
            DateTime dateTime = DateTime.Now;
            m.Subject = $"Ссылка на оплату пациента № - {pacient}";
            m.Body = $"<h1>Ссылка для оплаты услуг клиники</h1><br><h3>Пройдите по ссылке ниже<h3><br><br><br>{text}<br><br><br><br><br>Спасибо, что выбрали нас!!!";
            m.IsBodyHtml = true;
            SmtpClient medica = new SmtpClient(host, port);
            medica.Credentials = new NetworkCredential("medica.nsk-sbp", "qwerty51!");
            medica.EnableSsl = false;
            medica.Send(m);
        }
        public string aFIO (string name)
        {
            return FIO = name;
        }
    }
}
