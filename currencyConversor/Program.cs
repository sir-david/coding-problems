using System;

namespace currencyConversor
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine(new Converter.Converter("https://free.currconv.com/api/v7/", "282abf33cfb4a9a08aa5").Convert(20, currencyConversor.Converter.CurrencyType.EUR, currencyConversor.Converter.CurrencyType.USD) );
            
        }
    }
}
