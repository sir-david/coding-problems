using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using currencyConversor.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace rest_api.Controllers
{
    public class ExchangeRate : Controller
    {
        private const string WORD_FOR_LOCAL_ENVIROMENT = "local";
        private const string WEB_HOOK = @"https://webhook.site/14693700-0cce-4ef4-9961-e927cf90c008";
        static currencyConversor.Converter.IConverter localConverter = new currencyConversor.Converter.LocalConverter(@"D:\sir-david\code\coding-problems\currencyConversor\bin\Debug\netcoreapp3.1\exchangeRateDB");
        static currencyConversor.Converter.IConverter onlineConverter = new currencyConversor.Converter.OnlineConverter("https://free.currconv.com/api/v7/", "282abf33cfb4a9a08aa5");


        [Route("api/[controller]/{env}/{from}/{to}")]
        public ActionResult GetAllLocal(string env, string from, string to)


        {
            HttpHit hit = new HttpHit();

            from = from.ToUpper();
            to = to.ToUpper();
            currencyConversor.Converter.CurrencyType fromSymbol;
            Enum.TryParse<currencyConversor.Converter.CurrencyType>(from, out fromSymbol);
            if (fromSymbol == currencyConversor.Converter.CurrencyType.NONE) return NotFound(new { message = $"{from} Symbol not found" });

            currencyConversor.Converter.CurrencyType toSymbol;
            Enum.TryParse<currencyConversor.Converter.CurrencyType>(to, out toSymbol);
            if (toSymbol == currencyConversor.Converter.CurrencyType.NONE) return NotFound(new { message = $"{to} Symbol not found" });


            currencyConversor.Model.ExchangeRate rate = (env == WORD_FOR_LOCAL_ENVIROMENT ? localConverter : onlineConverter).GetExchangeRateConversion(fromSymbol, toSymbol);
            hit.hitUrlAsync(WEB_HOOK, Newtonsoft.Json.JsonConvert.SerializeObject(rate)).Wait();

            if (rate is null)
                return NotFound(rate);
            else return Ok(rate);
        }


    }
}
