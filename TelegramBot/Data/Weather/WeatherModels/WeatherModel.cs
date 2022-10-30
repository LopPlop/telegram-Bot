using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Data.Intefaces;

namespace TelegramBot.Weather.WeatherModels
{
    public class WeatherModel : IApiModel
    {
        public TempretureInfoModel Main { get; set; }
        public string Name { get; set; }
    }
}
