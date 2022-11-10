using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using Telegram.Bot;
using System.Threading;
using Telegram.Bot.Types.Enums;
using System.IO;
using Telegram.Bot.Types.InputFiles;
using TelegramBot.Weather.WeatherModels;
using TelegramBot.Weather;

namespace TelegramBot.Commands
{
    public static class CmdHandler
    {
        private const string authorInfo = "author    - Sedakov Ilya Vasilevich\r\ntelegram  - @damn_green_elephant\t\r\nvk \t  - https://vk.com/sand_man629\t\r\ngit\t  - https://github.com/LopPlop\r\nsteam\t  - https://steamcommunity.com/id/sand_man894/\r\ndiscord\t  - damn green elephant#0187\r\nsummary:";
        public static void CmdHandle(ITelegramBotClient botClient, Update update)
        {
            CmdGetHandler(botClient, update);
            CmdWriteHandler(botClient, update);
            // CmdWriteGekchaHandler(botClient, update);
            CmdStartHandler(botClient, update);
            CmdWeatherHandler(botClient, update);
        }

        // Обрабатывает команду /get info
        private async static void CmdGetHandler(ITelegramBotClient botClient, Update update)
        {
            string str = update.Message.Text;

            if (string.IsNullOrEmpty(str))
            {
                return;
            }

            if (str.ToLower().Contains("/get info"))
            {
                await SendMessage.BotSendFileAsync(botClient, update, @"C:\Users\Bruh\Desktop\учеба\C# .NET 6\Summary.docx", "Author's summary", "Summary.docx");
                await botClient.SendTextMessageAsync(update.Message.Chat.Id, authorInfo);
                return;
            }
        }
        // Обрабатывает команду /start
        private async static void CmdStartHandler(ITelegramBotClient botClient, Update update)
        {
            string str = update.Message.Text;

            if (string.IsNullOrEmpty(str))
            {
                return;
            }
            if (str.ToLower().Contains("/start"))
            {
                await botClient.SendTextMessageAsync(update.Message.Chat.Id, $"{TextComands.startCommands}");
                return;
            }
        }


        // Обрабатывает команду /write {message}
        private static async void CmdWriteHandler(ITelegramBotClient botClient, Update update)
        {
            string str = update.Message.Text;

            if (str.ToLower().Contains("/write "))
            {
                string tmp = SimpleMethods.GetMessageAfterSpace(str);
                await botClient.SendTextMessageAsync(update.Message.Chat.Id, "Сообщение отправлено, автор обязательно свяжется с вами!");
                await botClient.SendTextMessageAsync(1885288357, $"{update.Message.Chat.Username} написал тебе: {tmp}");
                return;
            }
        }

        // Скрытый функционал
        private static async void CmdWriteGekchaHandler(ITelegramBotClient botClient, Update update)
        {
            string str = update.Message.Text;

            if (str.ToLower().Contains("/gekcha "))
            {
                string tmp = SimpleMethods.GetMessageAfterSpace(str);
                await botClient.SendTextMessageAsync(update.Message.Chat.Id, "Вы отправили сообщение польхователю Gekcha");
                await botClient.SendTextMessageAsync(2046105074, $"{update.Message.Chat.Username} написал тебе: {tmp}");
                return;
            }
        }

        // Обработка команды /tempreture {город}
        private static async void CmdWeatherHandler(ITelegramBotClient botClient, Update update)
        {
            string str = update.Message.Text;

            if (str.ToLower().Contains("/tempreture "))
            {
                string city = SimpleMethods.GetMessageAfterSpace(str);
                GetApiWeather getApiWeather = new GetApiWeather();
                WeatherModel weather = getApiWeather.HttpRequestResponceByStr(city);
                await botClient.SendTextMessageAsync(update.Message.Chat.Id, $"В городе {weather.Name} сейчас {weather.Main.Temp} °C");
                return;
            }
        }
    }
}
