
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using humidityTemperature;

namespace currencyConversor.Converter.Local
{
    public class LiteDBDataRepository

    {
        ConnectionManager dbManager;
        public LiteDBDataRepository(string path) {
            this.dbManager = new ConnectionManager(path);
        } 
        public List<Data> GetAllData( )
        {
            var collection = this.dbManager.GetDatabase().GetCollection<Data>("data"); 
            var exchangeRate = collection.FindAll(); 
            return exchangeRate.ToList();

        } 
        public string InsertBulkData(List<Data> rates)
        {
            var collection = this.dbManager.GetDatabase().GetCollection<Data>("data");
          
            var id = collection.InsertBulk(rates);
            return id.ToString();
        }
        public string InsertData(Data rates)
        {
            var collection = this.dbManager.GetDatabase().GetCollection<Data>("data");

            var id = collection. Insert(rates);
            return id.ToString();
        }

    }
}
 