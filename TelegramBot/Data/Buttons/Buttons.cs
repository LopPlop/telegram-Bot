using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types.ReplyMarkups;
using TelegramBot.Weather;

namespace TelegramBot.Buttons
{
    public static class Buttons
    {
        public static IReplyMarkup GetButtons()
        {
            InlineKeyboardMarkup inlineKeyboard = new InlineKeyboardMarkup(new[]
            {
                // first row
                new []
                {
                    InlineKeyboardButton.WithCallbackData(text: "Novosibirsk", callbackData: "Novosibirsk"),
                    InlineKeyboardButton.WithCallbackData(text: "Taldykorgan", callbackData: "Taldykorgan"),
                },
                // second row
                new []
                {
                    InlineKeyboardButton.WithCallbackData(text: "Almaty", callbackData: "Almaty"),
                    InlineKeyboardButton.WithCallbackData(text: "Moscow", callbackData: "Moscow"),
                },
            });
            return inlineKeyboard;
        }
    }
}
