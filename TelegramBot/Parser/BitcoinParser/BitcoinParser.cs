using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace TelegramBot.Parser.BitcoinParser
{
    public class BitcoinParser
    {
        public static string GetBitcoinPrice()
        {
            WebClient client = new WebClient();
            string response = client.DownloadString("https://ru.investing.com/crypto/bitcoin/btc-usd");

            string price = System.Text.RegularExpressions.Regex.Match(response, @"<span class=""text-2xl bg-negative-light"" data-test=""instrument-price-last"">+([0-9]+\.[0-9]+)").Groups[1].Value;

            string changes = System.Text.RegularExpressions.Regex.Match(response, @"<span class=""instrument-price_change-value__h13Qh ml-2.5 text-positive-main"" data-test=""instrument-price-change"">([0-9]+\,[0-9]+)</span>").Groups[1].ToString();

            string percent = System.Text.RegularExpressions.Regex.Match(response, @"<span class=""instrument-price_change-percent__bT4yt ml-2.5 text-positive-main"" data-test=""instrument-price-change-percent"">([0-2]+\,[0-2]+%)</span>").Groups[1].ToString();

            return price + " +" + changes + " +" + percent + "%";
        }
    }
}
