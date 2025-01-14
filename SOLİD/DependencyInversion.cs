
using System;

namespace NotificationSystem
{
    // Yüksek seviyeli modül: Bildirim servisi
    public class NotificationService
    {
        private readonly INotifier _notifier;

        public NotificationService(INotifier notifier)
        {
            _notifier = notifier;
        }

        public void Notify(string message)
        {
            _notifier.Send(message);
        }
    }

    // Soyutlama: Bildirim arayüzü
    public interface INotifier
    {
        void Send(string message);
    }

    // Düşük seviyeli modül: E-posta bildirimi
    public class EmailNotifier : INotifier
    {
        public void Send(string message)
        {
            Console.WriteLine($"E-posta gönderildi: {message}");
        }
    }

    // Düşük seviyeli modül: SMS bildirimi
    public class SmsNotifier : INotifier
    {
        public void Send(string message)
        {
            Console.WriteLine($"SMS gönderildi: {message}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // E-posta bildirimi için servisi oluştur
            INotifier emailNotifier = new EmailNotifier();
            NotificationService emailService = new NotificationService(emailNotifier);
            emailService.Notify("E-posta mesajı!");

            // SMS bildirimi için servisi oluştur
            INotifier smsNotifier = new SmsNotifier();
            NotificationService smsService = new NotificationService(smsNotifier);
            smsService.Notify("SMS mesajı!");
        }
    }
}

