using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Weather.WeatherModels;

namespace TelegramBot.Data.Intefaces
{
    public interface IReguestResposeApi<T> where T : IApiModel
    {
        T HttpRequestResponceByStr(string _obj);
        T JsonDeserialization(string request);
    }
}
