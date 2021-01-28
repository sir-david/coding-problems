using currencyConversor.Model;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace currencyConversor.Converter
{
    public class ConversionHelper
    {
        ConnectionSetting settings;

        public ConversionHelper(ConnectionSetting settings)
        {
            this.settings = settings;
        }
        public ConversionHelper(string endpointtUrl, string apiKey)
        {
            this.settings = new ConnectionSetting { endPoint = endpointtUrl, key = apiKey };
        }
        public double GetExchangeRate(CurrencyType from, CurrencyType to)
        {
            string url;
            url = settings.endPoint + "convert?q=" + from + "_" + to + "&compact=y&apiKey=" + settings.key;

            var jsonString = ExecuteAndGetResponse(url);
            return JObject.Parse(jsonString).First.First["val"].ToObject<double>();
        }
        private static string ExecuteAndGetResponse(string url)
        {
            string jsonString;

            var request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;

            using (var response = (HttpWebResponse)request.GetResponse())
            using (var stream = response.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                jsonString = reader.ReadToEnd();
            }

            return jsonString;
        }
        public List<ExchangeRate> GetHistoryRange(CurrencyType from, CurrencyType to, string startDate, string endDate)
        {
            string url = this.settings.endPoint + "convert?q=" + from + "_" + to + "&compact=ultra&date=" + startDate + "&endDate=" + endDate + "&apiKey=" + this.settings.key;

            var jsonString = ExecuteAndGetResponse(url);
            var data = JObject.Parse(jsonString).First.ToArray();
            return (from item in data
                    let obj = (JObject)item
                    from prop in obj.Properties()
                    select new ExchangeRate
                    {
                        epochCreatedAt = Utils.Utils.DateTimeToUnix( Convert.ToDateTime( prop.Name)),
                         change = $"{from.ToString()}_{to.ToString()}" ,
                         factor= item[prop.Name].ToObject<double>()
                    }).ToList();
         }
    }
}
