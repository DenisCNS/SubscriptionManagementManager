using Telegram.Bot;
using Telegram.Bot.Types.ReplyMarkups;

namespace SubscriptionManagementManager.Services
{
    public class TelegramBotService
    {
        public async Task OnStartReceiving(ITelegramBotClient botClient, long chatId) 
        {
            var replyKeyboard = new ReplyKeyboardMarkup(new[]
                    {
                        new KeyboardButton[] { "Сервисы" },
                        new KeyboardButton[] { "Личный кабинет" }
                    });
            replyKeyboard.ResizeKeyboard = true;

            await botClient.SendTextMessageAsync(
                chatId: chatId,
                text: "Главное меню :",
                replyMarkup: replyKeyboard
            );
        }

        public async Task OnUnknownMessageReceiving(ITelegramBotClient botClient, long chatId) 
        {
            var replyKeyboard = new ReplyKeyboardMarkup(new[]
        {
                        new KeyboardButton[] { "Сервисы" },
                        new KeyboardButton[] { "Личный кабинет" }
                    });
            replyKeyboard.ResizeKeyboard = true;

            await botClient.SendTextMessageAsync(
                chatId: chatId,
                text: "Главное меню :",
                replyMarkup: replyKeyboard
            );
        }
    }
}
