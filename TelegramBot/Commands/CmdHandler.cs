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

namespace TelegramBot.Commands
{
    public static class CmdHandler
    {
        public static void CmdHandle(ITelegramBotClient botClient, Update update)
        {
            CmdGetHandler(botClient, update);
            CmdWriteHandler(botClient, update);
            CmdWriteGekchaHandler(botClient, update);
        }

        // Обрабатывает все команды начинающиеся с /get
        private async static void CmdGetHandler(ITelegramBotClient botClient, Update update)
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
            if (str.ToLower().Contains("/get author"))
            {
                await botClient.SendTextMessageAsync(update.Message.Chat.Id, "Седаков Илья Васильевич");
                return;
            }
            if (str.ToLower().Contains("/get telegram"))
            {
                await botClient.SendTextMessageAsync(update.Message.Chat.Id, "@damn_green_elephant");
                return;
            }
            if (str.ToLower().Contains("/get vk"))
            {
                await botClient.SendTextMessageAsync(update.Message.Chat.Id, "https://vk.com/sand_man629");
                return;
            }
            if (str.ToLower().Contains("/get summary"))
            {
                await SendMessage.BotSendFileAsync(botClient, update, @"C:\Users\Bruh\Desktop\учеба\C# .NET 6\Summary.docx", "Резюме автора", "Summary.docx");
                return;
            }
            if (str.ToLower().Contains("/get steam"))
            {
                await botClient.SendTextMessageAsync(update.Message.Chat.Id, "https://steamcommunity.com/id/sand_man894/");
                return;
            }
            if (str.ToLower().Contains("/get discord"))
            {
                await botClient.SendTextMessageAsync(update.Message.Chat.Id, "damn green elephant#0187");
                return;
            }
            if (str.ToLower().Contains("/get git"))
            {
                await botClient.SendTextMessageAsync(update.Message.Chat.Id, "https://github.com/LopPlop");
                return;
            }
        }


        // Обрабатывает команду /write
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
    }
}
