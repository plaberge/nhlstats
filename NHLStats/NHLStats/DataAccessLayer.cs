using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace NHLStats
{
    static class DataAccessLayer
    {

        public static JObject ExecuteAPICall(string apiUrl)
        {
            var client = new System.Net.Http.HttpClient();

            // Get Current League Standings from NHL API
            var response = client.GetAsync(NHLAPIServiceURLs.leagueStandings).Result;
            var retResp = new HttpResponseMessage();
            var stringResult = response.Content.ReadAsStringAsync().Result;
            var json = JObject.Parse(stringResult);

            return json;
        }
    }
}
