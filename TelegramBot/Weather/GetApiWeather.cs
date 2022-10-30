using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Weather
{
    public static class GetApiWeather
    {
        private static string city = "London";
        private static string url = "";
        private static HttpWebRequest webRequest;
        private static HttpWebResponse webResponse;

        public static string HttpRequestWeatherByCity(string _city)
        {
            city = _city;
            url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&units=metric&appid=0814fff08b0e9ad373b5261321abdf48";
            webRequest = (HttpWebRequest)WebRequest.Create(url);

            webResponse = (HttpWebResponse)webRequest.GetResponse();

            string response;

            using(StreamReader streamReader = new StreamReader(webResponse.GetResponseStream()))
            {
                return streamReader.ReadToEnd();
            }
        }
    }
}
