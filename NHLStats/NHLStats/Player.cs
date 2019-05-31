using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace NHLStats
{
    
    public class Player
    {
        public int playerID { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int primaryNumber { get; set; }
        public string birthDate { get; set; }
        public int currentAge { get; set; }
        public string birthCity { get; set; }
        public string birthStateProvince { get; set; }
        public string birthCountry { get; set; }
        public string nationality { get; set; }
        public int height { get; set; }
        public int weight { get; set; }
        public string active { get; set; }
        public string alternateCaptain { get; set; }
        public string captain { get; set; }
        public string rookie { get; set; }
        public string shootsCatches { get; set; }
        public string rosterStatus { get; set; }
        public int currentTeamID { get; set; }
        public string primaryPositionCode { get; set; }
        public string primaryPositionName { get; set; }
        public string primaryPositionType { get; set; }
        public string primaryPositionAbbr { get; set; }
        public JObject playerJson { get; set; } // Populate the raw JSON to a property

        public Player()
        {

        }

        public Player(int thePlayerID)
        {
            playerID = thePlayerID;

            // Create API call URL by appending the Player ID to the URL
            string playerLink = NHLAPIServiceURLs.specificplayer + thePlayerID.ToString();

            var json = DataAccessLayer.ExecuteAPICall(playerLink);
            JObject playerData = JObject.Parse(json.SelectToken("people")[0].ToString());

            // Populate the raw JSON to a property
            playerJson = playerData;


            if (playerData.ContainsKey("firstName") == true)
            {
                firstName = json.SelectToken("people[0].firstName").ToString();
            }
            else
            {
                firstName = "UNKNOWN";
            }

            if (playerData.ContainsKey("lastName") == true)
            {
                lastName = json.SelectToken("people[0].lastName").ToString();
            }
            else
            {
                lastName = "PLAYER";
            }

            if (playerData.ContainsKey("primaryNumber") == true)
            {
                primaryNumber = Convert.ToInt32(json.SelectToken("people[0].primaryNumber"));
            }

            if (playerData.ContainsKey("birthDate") == true)
            {
                birthDate = json.SelectToken("people[0].birthDate").ToString();
            }
            else
            {
                birthDate = "1800-01-01";
            }

            if (playerData.ContainsKey("currentAge") == true)
            {
                currentAge = Convert.ToInt32(json.SelectToken("people[0].currentAge"));
            }

            if (playerData.ContainsKey("birthCity") == true)
            {
                birthCity = json.SelectToken("people[0].birthCity").ToString();
            }

            if (playerData.ContainsKey("birthStateProvince")==true)
            {
                birthStateProvince = json.SelectToken("people[0].birthStateProvince").ToString();
            }

            if (playerData.ContainsKey("birthCountry") == true)
            {
                birthCountry = json.SelectToken("people[0].birthCountry").ToString();
            }

            if (playerData.ContainsKey("nationality") == true)
            {
                nationality = json.SelectToken("people[0].nationality").ToString();
            }

            if (playerData.ContainsKey("height") == true)
            {
                height = Convert.ToInt32(json.SelectToken("people[0].height").ToString().Split(new char[] { '\'' })[0]) * 12 + Convert.ToInt32(json.SelectToken("people[0].height").ToString().Split(new char[] { '\'' })[1].Split(new char[] { '\"' })[0]);
            }

            if (playerData.ContainsKey("weight") == true)
            {
                weight = Convert.ToInt32(json.SelectToken("people[0].weight"));
            }

            if (playerData.ContainsKey("active") == true)
            {
                active = json.SelectToken("people[0].active").ToString();
            }
            else
            {
                active = "False";
            }

            if (playerData.ContainsKey("alternateCaptain") == true)
            {
                alternateCaptain = json.SelectToken("people[0].alternateCaptain").ToString();
            }
            else
            {
                alternateCaptain = "False"
            }

            if (playerData.ContainsKey("captain") == true)
            {
                captain = json.SelectToken("people[0].captain").ToString();
            }
            else
            {
                captain = "False";
            }

            if (playerData.ContainsKey("rookie") == true)
            {
                rookie = json.SelectToken("people[0].rookie").ToString();
            }
            else
            {
                rookie = "UNKOWN";
            }

            if (playerData.ContainsKey("shootsCatches") == true)
            {
                shootsCatches = json.SelectToken("people[0].shootsCatches").ToString();
            }
            else
            {
                shootsCatches = "UNKNOWN";
            }

            if (playerData.ContainsKey("rosterStatus") == true)
            {
                rosterStatus = json.SelectToken("people[0].rosterStatus").ToString();
            }
            else
            {
                rosterStatus = "UNKNOWN";
            }

            if (playerData.ContainsKey("currentTeam") == true)
            {
                currentTeamID = Convert.ToInt32(json.SelectToken("people[0].currentTeam.id"));
            }

            if (playerData.ContainsKey("primaryPostion") == true)
            {
                primaryPositionCode = json.SelectToken("people[0].primaryPosition.code").ToString();
                primaryPositionName = json.SelectToken("people[0].primaryPosition.name").ToString();
                primaryPositionType = json.SelectToken("people[0].primaryPosition.type").ToString();
                primaryPositionAbbr = json.SelectToken("people[0].primaryPosition.abbreviation").ToString();
            }



        }
    }
}

