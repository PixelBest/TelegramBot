using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timer = System.Timers.Timer;
using System.IO;
using System.Net.Mail;
using System.Net;

namespace TelegramBot
{
    internal class SendEmail
    {
        static string path = Directory.GetCurrentDirectory();
        static bool check = true;
        public static void Time()
        {
            while (check)
            {
                Timer timer = new Timer(60 * 60 * 1000);
                timer.Start();
                timer.Elapsed += Timer_Elapsed;
                { check = false; }
            }
        }
         private static void Timer_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
         {
            if(File.Exists($@"{path}\dataBase.xlsx"))
            {
                MailMessage message = new MailMessage();
                SmtpClient client =
                new SmtpClient("smtp.yandex.ru", 587) // сервер,порт
                {
                    Credentials = new NetworkCredential("nick.poroschin@yandex.ru", "ojqjuyzfxquixxpl"),
                    EnableSsl = true // обязательно!
                };
                message.From = new MailAddress("nick.poroschin@yandex.ru");
                message.To.Add(new MailAddress("nick.poroschin@yandex.ru"));
                message.Subject = "Заказы";
                message.SubjectEncoding = Encoding.UTF8;
                /*message.Body = "Текст в форме сообщения";*/
                message.BodyEncoding = Encoding.UTF8; // кодировка 
                Attachment item = new Attachment($@"{path}\dataBase.xlsx");
                message.Attachments.Add(item);// добавляем файл к сообщению
                client.Send(message); // отправка сообщения
                item.Dispose();
                File.Delete($@"{path}\dataBase.xlsx");
                Console.WriteLine("Файл отправлен");
            }
            else
            {
                Console.WriteLine("Заказов не было");
            }
         }
    }
}
