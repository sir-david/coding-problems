using currencyConversor.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace currencyConversor.Converter.Local
{
    public class LiteDBRateRepository

    {
        ConnectionManager dbManager;
        public LiteDBRateRepository(string path) {
            this.dbManager = new ConnectionManager(path);
        }

        public ExchangeRate GetExchangeRate(CurrencyType from, CurrencyType to) {
            var collection = this.dbManager.GetDatabase().GetCollection<ExchangeRate>("rate");
            collection.EnsureIndex(x=> x.change);
            var exchangeRate = collection.Find(LiteDB.Query.EQ("change", $"{from.ToString()}_{to.ToString()}"));
            if (exchangeRate is null) throw new Exception("EXCHANGE_RATE_NOT_FOUND");
            return exchangeRate.FirstOrDefault();

        } 
        public List<ExchangeRate> GetAllExchangeRate( )
        {
            var collection = this.dbManager.GetDatabase().GetCollection<ExchangeRate>("rate");
            collection.EnsureIndex(x => x.change);
            var exchangeRate = collection.FindAll(); 
            return exchangeRate.ToList();

        }
        public string InsertExchangeRate(ExchangeRate rate)
        {
            var collection = this.dbManager.GetDatabase().GetCollection<ExchangeRate>("rate");
          
            var id = collection.Insert(rate);
            return id.RawValue.ToString();
        }
        public string InsertBulkExchangeRate(List<ExchangeRate> rates)
        {
            var collection = this.dbManager.GetDatabase().GetCollection<ExchangeRate>("rate");
          
            var id = collection.InsertBulk(rates);
            return id.ToString();
        }

    }
}
 