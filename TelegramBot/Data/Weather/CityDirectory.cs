using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Weather
{
    public class CityDirectory
    {
        public enum City
        {
            Novosibirsk = 0,
            Taldykorgan = 1,
            Barnaul = 2,
            Moscow = 3,
        }

        public static string GetCoordByCityEnum(City city)
        {
            switch (((int)city))
            {
                case 0:
                    {
                        return "Novosibirsk";
                    }
                case 1:
                    {
                        return "Taldykorgan";
                    }
                case 2:
                    {
                        return "Barnaul";
                    }
                case 3:
                    {
                        return "Moscow";
                    }
            }
            return "London";
        }
    }
}
