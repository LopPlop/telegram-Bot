using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Weather.WeatherModels;

namespace TelegramBot.Weather
{
    public static class JsonConverter
    {
        public static WeatherModel JsonDeserialization(string request)
        {
            WeatherModel weather = JsonConvert.DeserializeObject<WeatherModel>(request);

            Console.WriteLine($"В городе {weather.Name} сейчас {weather.Main.Temp} °C");

            return weather;
        }
    }
}
