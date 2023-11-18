using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;

namespace NHLStats
{
    public class Venue
    {
        public string venueID { get; set; }
        public string venueName { get; set; }
        public JToken venueJson { get; set; } // Populate the raw JSON to a property

        public Venue()
        {

        }

        public Venue(JObject json)
        {
            venueID = " ";
            //venueName = json.Value<string>("default").ToString();

            //JObject jsonObject = json.ToObject<JObject>();
            //venueName = jsonObject["default"].ToString();
            venueName = json["default"].ToString();
            venueJson = json;
        }


        //public Venue(string theVenueID)
        //{
        //    // Populate the venueID property
        //    venueID = theVenueID;

        //    // Get the URL for the API call to a specific Venue
        //    string venueLink = NHLAPIServiceURLs.venues + theVenueID;

        //    // Execute the API call
        //    var json = DataAccessLayer.ExecuteAPICall(venueLink);

        //    // Populate the raw JSON to a property
        //    venueJson = json;

        //    // Populate the rest of the Venue class properties
        //    venueName = json.SelectToken("venues[0].name").ToString();



        //}

    }
}
