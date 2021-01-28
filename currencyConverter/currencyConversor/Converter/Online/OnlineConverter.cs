using currencyConversor.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace currencyConversor.Converter
{
    public class OnlineConverter : IConverter
    {
        ConversionHelper helper;

        public OnlineConverter(string url, string apiKey)
        {
            this.helper = new ConversionHelper(new ConnectionSetting { key = apiKey, endPoint = url });
        }
        public double Convert(double amount, CurrencyType from, CurrencyType to)
        {
            return helper.GetExchangeRate(from, to) * amount;
        } 
        public ExchangeRate GetExchangeRateConversion(CurrencyType from, CurrencyType to)
        {
            return new ExchangeRate { change = $"{from.ToString()}_{to.ToString()}", factor = helper.GetExchangeRate(from, to), epochCreatedAt = Utils.Utils.DateTimeToUnix(DateTime.Now) };
        }

        public List<ExchangeRate> GetHistoryExchangeRate(CurrencyType from, CurrencyType to, DateTime init, DateTime end) {
            return helper.GetHistoryRange(from, to, init.ToString("yyyy-MM-dd"), end.ToString("yyyy-MM-dd"));
        }
    }
}
