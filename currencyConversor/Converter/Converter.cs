using System;
using System.Collections.Generic;
using System.Text;

namespace currencyConversor.Converter
{
    public class Converter
    {
        ConversionHelper helper;

        public Converter(string url, string apiKey) {
            this.helper = new ConversionHelper(new ConnectionSetting {key=apiKey, endPoint = url  });
        }
        public double Convert(double amount, CurrencyType from, CurrencyType to)
        {
            return helper.GetExchangeRate(from, to) * amount;
        }
    }
}
