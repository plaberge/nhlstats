using System;
using System.Collections.Generic;
using System.Text;

namespace NHLStats
{
    class Schedule
    {
        public string totalItems { get; set; }
        public string totalEvents { get; set; }
        public string totalGames { get; set; }
        public string totalMatches { get; set; }
        public string wait { get; set; }
        public List<Game> games { get; set; }

        // Important URLs:  https://statsapi.web.nhl.com/api/v1/schedule?date=2018-11-21

        // Default constructor
        public Schedule()
        {
            var client = new System.Net.Http.HttpClient();

            // Get Current League Standings from NHL API
            var response = client.GetAsync(NHLAPIServiceURLs.todaysGames).Result;
            var retResp = new HttpResponseMessage();
            var stringResult = response.Content.ReadAsStringAsync().Result;
            var json = JObject.Parse(stringResult);

        }
    }
}
