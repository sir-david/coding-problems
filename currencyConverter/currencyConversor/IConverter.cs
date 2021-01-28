using currencyConversor.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace currencyConversor.Converter
{
    public interface IConverter 
    {
        double Convert(double amount, CurrencyType from, CurrencyType to);
        ExchangeRate GetExchangeRateConversion(CurrencyType from, CurrencyType to);


    }
}
