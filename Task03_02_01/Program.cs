using Microsoft.Extensions.DependencyInjection;

namespace Task03_02_01
{
    public interface INotificationSender
    {
        void Send(string recipient, string message);
    }
    public class EmailSender : INotificationSender
    {
        public void Send(string recipient, string message)
        {
            // Симуляция отправки email
            Console.WriteLine($"Email для {recipient}: {message}");
        }
    }

    public class SmsSender : INotificationSender
    {
        public void Send(string recipient, string message)
        {
            // Симуляция отправки SMS
            Console.WriteLine($"SMS для {recipient}: {message}");
        }
    }

    public interface ILoggerService
    {
        void Log(string message);
    }

    public class FileLogger : ILoggerService
    {
        private const string FileName = "log.txt";

        public void Log(string message)
        {
            File.AppendAllText(FileName, $"{message}{Environment.NewLine}");
        }
    }

    public class NotificationService
    {
        private readonly INotificationSender _sender;
        private readonly ILoggerService _logger;

        public NotificationService(INotificationSender sender, ILoggerService logger)
        {
            _sender = sender ?? throw new ArgumentNullException(nameof(sender));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public void SendNotification(string message, string recipient)
        {
            string formattedMessage = $"Уведомление: {message}";
            _sender.Send(recipient, formattedMessage);
            _logger.Log($"Отправлено уведомление для {recipient}");
        }
    }

    class Program
    {
        static void Main()
        {
            var services = new ServiceCollection();

            // Регистрация сервисов
            services.AddSingleton<ILoggerService, FileLogger>();
            services.AddTransient<EmailSender>();
            services.AddTransient<SmsSender>();

            var provider = services.BuildServiceProvider();

            Console.Write("Выберите тип рассылки (email/sms): ");
            var typeInput = (Console.ReadLine() ?? "").Trim().ToLowerInvariant();

            INotificationSender chosenSender = null;
            switch (typeInput)
            {
                case "email":
                case "e":
                    chosenSender = provider.GetRequiredService<EmailSender>();
                    break;
                case "sms":
                case "s":
                    chosenSender = provider.GetRequiredService<SmsSender>();
                    break;
                default:
                    Console.WriteLine("Неправильный тип рассылки. Используйте 'email' или 'sms'.");
                    return;
            }

            Console.Write("Введите адрес получателя (email или номер): ");
            var recipient = Console.ReadLine() ?? "";

            Console.Write("Введите текст уведомления: ");
            var message = Console.ReadLine() ?? "";

            var logger = provider.GetRequiredService<ILoggerService>();
            var notificationService = new NotificationService(chosenSender, logger);
            notificationService.SendNotification(message, recipient);
        }
    }
}
