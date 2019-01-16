using System;
using System.Collections.Generic;
using System.Text;

namespace NHLStats
{
    public class Venue
    {
        public string venueID { get; set; }
        public string venueName { get; set; }

        public Venue()
        {

        }

        public Venue(string theVenueID)
        {
            // Populate the venueID property
            venueID = theVenueID;

            // Get the URL for the API call to a specific Venue
            string venueLink = NHLAPIServiceURLs.venues + theVenueID;

            // Execute the API call
            var json = DataAccessLayer.ExecuteAPICall(venueLink);

            // Populate the rest of the Venue class properties
            venueName = json.SelectToken("venues[0].name").ToString();



        }

    }
}
