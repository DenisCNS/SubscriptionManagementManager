using SubscriptionManagementManager.Services;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace SubscriptionManagementManager
{
    class Program
    {
        static ITelegramBotClient bot = new TelegramBotClient("7131447486:AAFLeESKxyKPUvchxW-oy127CCHBIGOIqlo");
        static TelegramBotService _telegramBotService = new TelegramBotService();
        public static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {            
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(update));
            if (update.Type == Telegram.Bot.Types.Enums.UpdateType.Message)
            {
                var message = update.Message;
                var botTask = message.Text.ToLower() switch
                {
                    "/start" => _telegramBotService.OnStartReceiving(botClient, message.Chat.Id),
                    _ => _telegramBotService.OnUnknownMessageReceiving(botClient, message.Chat.Id),
                };

                await botTask;
            }
        }

        public static async Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {            
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(exception));
        }


        static void Main(string[] args)
        {
            Console.WriteLine("Запущен бот " + bot.GetMeAsync().Result.FirstName);

            var cts = new CancellationTokenSource();
            var cancellationToken = cts.Token;
            var receiverOptions = new ReceiverOptions
            {
                AllowedUpdates = { }, 
            };
            bot.StartReceiving(
                HandleUpdateAsync,
                HandleErrorAsync,
                receiverOptions,
                cancellationToken
            );

            Console.ReadLine();
        }
    }
}