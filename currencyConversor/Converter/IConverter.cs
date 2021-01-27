using System;
using System.Collections.Generic;
using System.Text;

namespace currencyConversor.Converter
{
    public interface IConverter 
    {
        Convert(double amount, CurrencyType from, CurrencyType to);

    }
}
