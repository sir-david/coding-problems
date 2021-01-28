using System;
using System.Collections.Generic;
using System.Text;

namespace currencyConversor.Model
{
    public class ExchangeRate
    {
        public string change { get; set; }
        public double factor { get; set; }
        public long epochCreatedAt{ get; set; }
        public DateTime CreatedAt => Utils.Utils.UnixTimeToDateTime(this.epochCreatedAt);
    }
}
