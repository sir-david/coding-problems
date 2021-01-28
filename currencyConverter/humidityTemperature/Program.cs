using currencyConversor.Converter.Local;
using currencyConversor.Utils;
using Newtonsoft.Json.Linq;
using System;

namespace humidityTemperature
{
    class Program
    {
        const string URL_SOURCE = "https://dweet.io/get/latest/dweet/for/thecore";
        const string PATH_DB = @"D:\sir-david\code\coding-problems\currencyConverter\currencyConversor\bin\Debug\netcoreapp3.1\exchangeRateDB";
        const string URL_WEB_HOOK = "https://webhook.site/14693700-0cce-4ef4-9961-e927cf90c008";

        HttpHit hh = new HttpHit();
        LiteDBDataRepository repo = new LiteDBDataRepository(PATH_DB);
        static void Main(string[] args)
        {



        }
        public void EveryMinute()
        {
            string humidityTemperatureRawData = hh.ExecuteAndGetResponse(URL_SOURCE);

            var data = new Data
            {
                Temperature = JObject.Parse(humidityTemperatureRawData)["with"].First["content"].Value<double>("temperature"),
                Humidity = JObject.Parse(humidityTemperatureRawData)["with"].First["content"].Value<double>("temperature")
            };
            repo.InsertData(data);

        }
        public void After15Minutes()
        {
            var data = repo.GetAllData();
            hh.hitUrlAsync(URL_WEB_HOOK, Newtonsoft.Json.JsonConvert.SerializeObject(data)).Wait();
        }

    }
}
