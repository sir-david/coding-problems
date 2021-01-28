using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;

namespace currencyConversor.Utils
{
    public class HttpHit
    {
        private static readonly HttpClient client = new HttpClient();

        public async System.Threading.Tasks.Task<string> hitUrlAsync(string url, string body)
        {
            var values = new Dictionary<string, string>
{
    { "content", body }
};

            var content = new FormUrlEncodedContent(values);
            var response = await client.PostAsync(url, content);
            var responseString = await response.Content.ReadAsStringAsync();
            return responseString;
        }
    }
}
