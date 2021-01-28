using currencyConversor.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace currencyConversor.Converter
{
    public class LocalConverter : IConverter
    {
        Local.ConversionHelper helper;

        public LocalConverter(string url) {
            this.helper = new Local.ConversionHelper(url);
        }
        public double Convert(double amount, CurrencyType from, CurrencyType to)=> helper.GetExchangeRate(from, to).factor * amount; 

        public ExchangeRate GetExchangeRateConversion(CurrencyType from, CurrencyType to)=> helper.GetExchangeRate(from, to); 
        public List<ExchangeRate> GetAllExchangeRateConversion()=> helper.GetAllExchangeRate();

        public string AddExchangeRate(ExchangeRate newRate )=> this.helper.AddNewExchangeRate(newRate); 
        public string BulkExchangeRate(List<ExchangeRate> newRates )=> this.helper.AddBulkExchangeRate(newRates);
    }
}
