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
                    InlineKeyboardButton.WithCallbackData(text: "Новосибирск", callbackData: "11"),
                    InlineKeyboardButton.WithCallbackData(text: "Талдыкорган", callbackData: "12"),
                },
                // second row
                new []
                {
                    InlineKeyboardButton.WithCallbackData(text: "Алмата", callbackData: "21"),
                    InlineKeyboardButton.WithCallbackData(text: "Москва", callbackData: "22"),
                },
            });
            return inlineKeyboard;
        }
    }
}
