using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;

namespace NHLStats
{
    public class Conference
    {
        public int conferenceID { get; set; } // ID for the conference
        public string conferenceName { get; set; } // Name of the Conference
        public string conferenceAbbreviation { get; set; } // Abbreviation for the conference
        public string shortName { get; set; } // Short Name for the Conference
        public string active { get; set; } // Whether conference is active or not
        public JObject conferenceJson { get; set; } // storing the raw JSON feed

        public Conference()
        {

        }

        public Conference(int theConferenceID)
        {
            if (theConferenceID == 0)
            {
                conferenceID = theConferenceID;
                conferenceName = "No Conference";
                conferenceAbbreviation = "NC";
                shortName = "NoConf";
                active = "N/A";
            }
            else
            {
                string conferenceLink = NHLAPIServiceURLs.conferences + theConferenceID.ToString();

                var json = DataAccessLayer.ExecuteAPICall(conferenceLink);

                // Populate the JSON feed into a property
                conferenceJson = json;

                conferenceID = theConferenceID;
                JObject detailsJson = new JObject();
                detailsJson = json.SelectToken("conferences[0]").ToObject<JObject>();

                if (detailsJson.ContainsKey("name") == true)
                {
                    conferenceName = json.SelectToken("conferences[0].name").ToString();
                }

                if (detailsJson.ContainsKey("abbreviation") == true)
                {
                    conferenceAbbreviation = json.SelectToken("conferences[0].abbreviation").ToString();
                }

                if (detailsJson.ContainsKey("shortName") == true)
                {
                    shortName = json.SelectToken("conferences[0].shortName").ToString();
                }

                if (detailsJson.ContainsKey("active") == true)
                {
                    active = json.SelectToken("conferences[0].active").ToString();
                }
            }
        }

        public static List<Conference> GetAllConferences()
        {
            var json = DataAccessLayer.ExecuteAPICall(NHLAPIServiceURLs.conferences);

            var conferenceArray = JArray.Parse(json.SelectToken("conferences").ToString());

            List<Conference> listOfConferences = new List<Conference>();
            Conference tempConference;

            foreach (var aConference in conferenceArray)
            {
                tempConference = new Conference(Convert.ToInt32(aConference.SelectToken("id")));
                listOfConferences.Add(tempConference);
            }
            return listOfConferences;
        }

    }
}
