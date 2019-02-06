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

        public Conference()
        {

        }

        public Conference(int theConferenceID)
        {
            string conferenceLink = NHLAPIServiceURLs.conferences + theConferenceID.ToString();

            var json = DataAccessLayer.ExecuteAPICall(conferenceLink);

            conferenceID = theConferenceID;
            conferenceName = json.SelectToken("conferences[0].name").ToString();
            conferenceAbbreviation = json.SelectToken("conferences[0].abbreviation").ToString();
            shortName = json.SelectToken("conferences[0].shortName").ToString();
            active = json.SelectToken("conferences[0].active").ToString();
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
