using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Requests;
using Telegram.Bot.Types;
using Telegram.Bot.Types.InputFiles;

namespace TelegramBot.Commands
{
    public static class SendMessage
    {
        // Метод, отвечающий за отправку документов
        public static async Task BotSendFileAsync(ITelegramBotClient botClient, Update update, string path, string caption = "", string filename = "file.docx")
        {
            Stream stream = System.IO.File.OpenRead($"{path}");
            Message message = await botClient.SendDocumentAsync(
                chatId: update.Message.Chat.Id,
                document: new InputOnlineFile(content: stream, fileName: filename), caption: caption);
            stream.Close();
        }
    }
}
