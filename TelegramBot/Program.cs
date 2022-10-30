using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using TelegramBot.Commands;
using TelegramBot.Weather;
using TelegramBot.Weather.WeatherModels;
using TelegramBot.Buttons;

namespace TelegramBot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var botClient = new TelegramBotClient("5394331505:AAGqYz8oWrLQKr9MN0f073mhnGnKupUVkco") { Timeout = TimeSpan.FromSeconds(10) };

            botClient.StartReceiving(Update, Error);

            Console.WriteLine("@tgmNet_bot");
            Console.ReadLine();
        }

        async static Task Error(ITelegramBotClient botClient, Exception ex, CancellationToken token)
        {

        }

        async static Task Update(ITelegramBotClient botClient, Update update, CancellationToken token)
        {
            var message = update.Message;

            if (message.Text != null)
            {
                Console.WriteLine($"{message.Chat.Username ?? "Unknown"}\t\t|\t\t{message.Text}\t\t|\t\t{message.Chat.Id}");
                if (message.Text.ToLower().Contains("здорова"))
                {
                    await botClient.SendTextMessageAsync(message.Chat.Id, $"{message.Chat.Id}");
                    return;
                }
                if (message.Text.ToLower().Contains("/tempreture"))
                {
                    /*await botClient.SendTextMessageAsync(message.Chat.Id, "Выберите город:", replyMarkup: Buttons.Buttons.GetButtons());*/

                    WeatherModel weather = JsonConverter.JsonDeserialization(GetApiWeather.HttpRequestWeatherByCity("Novosibirsk"));
                    await botClient.SendTextMessageAsync(message.Chat.Id, $"В городе {weather.Name} сейчас {weather.Main.Temp} °C");
                    return;
                }
                CmdHandler.CmdHandle(botClient, update);
            }
            

            if (message.Photo != null)
            {
                await botClient.SendTextMessageAsync(message.Chat.Id, "Прекрасно!");
                return;
            }
        }

        
    }
}
