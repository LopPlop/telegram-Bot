using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Weather.WeatherModels
{
    public class WeatherModel
    {
        public TempretureInfoModel Main { get; set; }
        public string Name { get; set; }
    }
}
