using currencyConversor.Model;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace currencyConversor.Converter.Local
{
    public class ConversionHelper
    {
        LiteDBRateRepository rateRepository;
         
        public ConversionHelper(string path)
        {
            this.rateRepository = new LiteDBRateRepository( path);
        }
        public ExchangeRate GetExchangeRate(CurrencyType from, CurrencyType to)=>rateRepository.GetExchangeRate(from, to);

        public List<ExchangeRate> GetAllExchangeRate()=>rateRepository.GetAllExchangeRate();
        public string AddNewExchangeRate(ExchangeRate rate) => this.rateRepository.InsertExchangeRate(rate);
        public string AddBulkExchangeRate(List<ExchangeRate> rates) => this.rateRepository.InsertBulkExchangeRate(rates);
    }
}
