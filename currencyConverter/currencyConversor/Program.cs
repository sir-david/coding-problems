using currencyConversor.Converter;
using System;

namespace currencyConversor
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var isOnlineMode = true;

            IConverter onlineConverter = new Converter.OnlineConverter("https://free.currconv.com/api/v7/", "282abf33cfb4a9a08aa5");
            IConverter localConverter = new Converter.LocalConverter("exchangeRateDB");
            Console.WriteLine(onlineConverter.Convert(20, currencyConversor.Converter.CurrencyType.EUR, currencyConversor.Converter.CurrencyType.USD));
            ((LocalConverter)localConverter).AddExchangeRate(onlineConverter.GetExchangeRateConversion(currencyConversor.Converter.CurrencyType.EUR, currencyConversor.Converter.CurrencyType.USD));
            Console.WriteLine(localConverter.Convert(20, currencyConversor.Converter.CurrencyType.EUR, currencyConversor.Converter.CurrencyType.USD));


            Console.WriteLine("Consultado info de EUR TO USD");
            var eur2usd = ((OnlineConverter)onlineConverter).GetHistoryExchangeRate(CurrencyType.EUR, CurrencyType.USD, new DateTime(2021, 1, 25), new DateTime(2021, 1, 28));
            ((LocalConverter)localConverter).BulkExchangeRate(eur2usd);
            
            Console.WriteLine("Consultado info de CLP TO USD");
            var clp2usd = ((OnlineConverter)onlineConverter).GetHistoryExchangeRate(CurrencyType.CLP, CurrencyType.USD, new DateTime(2021, 1, 25), new DateTime(2021, 1, 28));
            ((LocalConverter)localConverter).BulkExchangeRate(clp2usd);

            Console.WriteLine("Consultado info de PEN TO USD");
            var pen2usd = ((OnlineConverter)onlineConverter).GetHistoryExchangeRate(CurrencyType.PEN, CurrencyType.USD, new DateTime(2021, 1, 25), new DateTime(2021, 1, 28));
            ((LocalConverter)localConverter).BulkExchangeRate(pen2usd);


        }
    }
}
