using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;

namespace NHLStats
{
    public class Division
    {
        public int divisionId { get; set; }  // ID of the division
        public string divisionName { get; set; }  // Name of the division
        public string shortName { get; set; }  // Short name of the division
        public string abbreviation { get; set; }  // Abbreviation of the division
        public Conference conference { get; set; }  // Conference the division is in
        public string active { get; set; } // Whether the division is active or historical
        public JObject divisionJson { get; set; } // Populate the raw JSON feed to a property

        public Division()
        {

        }

        public Division(int theDivisionId)
        {
            if (theDivisionId == 0)
            {
                divisionId = theDivisionId;
                divisionName = "No Division";
                shortName = "NoDiv";
                abbreviation = "ND";
                active = "N/A";
                conference = new Conference(0);
            }
            else
            {
                divisionId = theDivisionId;

                string divisionLink = NHLAPIServiceURLs.divisions + divisionId.ToString();

                var json = DataAccessLayer.ExecuteAPICall(divisionLink);

                // Populate the raw JSON to a property
                divisionJson = json;
                var keyCheckJson = json.SelectToken("divisions[0]").ToObject<JObject>(); ;

                divisionName = json.SelectToken("divisions[0].name").ToString();
                //------------------
                if(keyCheckJson.ContainsKey("nameShort"))
                {
                    shortName = json.SelectToken("divisions[0].nameShort").ToString();
                }
                
                if (keyCheckJson.ContainsKey("abbreviation"))
                {
                    abbreviation = json.SelectToken("divisions[0].abbreviation").ToString();
                }
                
                if (keyCheckJson.ContainsKey("conference"))
                {
                    Conference theConference = new Conference(Convert.ToInt32(json.SelectToken("divisions[0].conference.id")));
                    conference = theConference;
                }
                
                if (keyCheckJson.ContainsKey("active"))
                {
                    active = json.SelectToken("divisions[0].active").ToString();
                }
                
            }
        }

        public static List<Division> GetAllDivisions()
        {
            var json = DataAccessLayer.ExecuteAPICall(NHLAPIServiceURLs.divisions);
            var divisionArray = JArray.Parse(json.SelectToken("divisions").ToString());

            List<Division> listOfDivisions = new List<Division>();
            Division tempDivision;

            foreach (var aDivision in divisionArray)
            {
                tempDivision = new Division(Convert.ToInt32(aDivision.SelectToken("id")));
                listOfDivisions.Add(tempDivision);
            }

            return listOfDivisions;
        }

    }
}
