using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Net;

namespace NHLStats
{
    public static class DataAccessLayer
    {
        static System.Net.Http.HttpClient client = new HttpClient();

        public static JObject ExecuteAPICall(string apiUrl)
        {
            
            System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
            //stopwatch.Start();
            // Get Current League Standings from NHL API
            var response = client.GetAsync(apiUrl).Result;
            bool responseSuccessful = response.IsSuccessStatusCode;

            while ((!responseSuccessful) && (response.StatusCode != HttpStatusCode.NotFound))
            {
                response = client.GetAsync(apiUrl).Result;
                responseSuccessful = response.IsSuccessStatusCode;
            }
            //stopwatch.Stop();
            //System.Diagnostics.Debug.WriteLine(stopwatch.ElapsedMilliseconds + "  ->   " + apiUrl);
            
            var stringResult = response.Content.ReadAsStringAsync().Result;
            var json = JObject.Parse(stringResult);

            return json;
        }
    }
}
