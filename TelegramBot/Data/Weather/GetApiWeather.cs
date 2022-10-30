using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Weather.WeatherModels;
using TelegramBot.Data.Intefaces;

namespace TelegramBot.Weather
{
    public class GetApiWeather : IReguestResposeApi<WeatherModel>
    {
        private static string city = "London";
        private static string url = "";
        private static HttpWebRequest webRequest;
        private static HttpWebResponse webResponse;

        public WeatherModel HttpRequestResponceByStr(string _city)
        {
            city = _city;
            url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&units=metric&appid=0814fff08b0e9ad373b5261321abdf48";
            webRequest = (HttpWebRequest)WebRequest.Create(url);

            webResponse = (HttpWebResponse)webRequest.GetResponse();

            using(StreamReader streamReader = new StreamReader(webResponse.GetResponseStream()))
            {
                return JsonDeserialization(streamReader.ReadToEnd());
            }
        }

        public WeatherModel JsonDeserialization(string request)
        {
            WeatherModel weather = JsonConvert.DeserializeObject<WeatherModel>(request);

            Console.WriteLine($"В городе {weather.Name} сейчас {weather.Main.Temp} °C");

            return weather;
        }
    }
}
