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


            firstName = json.SelectToken("people[0].firstName").ToString();
            lastName = json.SelectToken("people[0].lastName").ToString();
            primaryNumber = Convert.ToInt32(json.SelectToken("people[0].primaryNumber"));
            birthDate = json.SelectToken("people[0].birthDate").ToString();
            currentAge = Convert.ToInt32(json.SelectToken("people[0].currentAge"));
            birthCity = json.SelectToken("people[0].birthCity").ToString();

            // TODO:  This if block always seems to return false, so I need to figure out how to 
            //        find a way to determine if the "birthStateProvince" field exists for the current
            //        record
            if (playerData.ContainsKey("birthStateProvince")==true)
            {
                birthStateProvince = json.SelectToken("people[0].birthStateProvince").ToString();
            }
            birthCountry = json.SelectToken("people[0].birthCountry").ToString();
            nationality = json.SelectToken("people[0].nationality").ToString();
            height = Convert.ToInt32(json.SelectToken("people[0].height").ToString().Split(new char[] { '\'' })[0]) * 12 + Convert.ToInt32(json.SelectToken("people[0].height").ToString().Split(new char[] { '\'' })[1].Split(new char[] { '\"' })[0]);
            weight = Convert.ToInt32(json.SelectToken("people[0].weight"));
            active = json.SelectToken("people[0].active").ToString();
            alternateCaptain = json.SelectToken("people[0].alternateCaptain").ToString();
            captain = json.SelectToken("people[0].captain").ToString();
            rookie = json.SelectToken("people[0].rookie").ToString();
            shootsCatches = json.SelectToken("people[0].shootsCatches").ToString();
            rosterStatus = json.SelectToken("people[0].rosterStatus").ToString();
            currentTeamID = Convert.ToInt32(json.SelectToken("people[0].currentTeam.id"));
            primaryPositionCode = json.SelectToken("people[0].primaryPosition.code").ToString();
            primaryPositionName = json.SelectToken("people[0].primaryPosition.name").ToString();
            primaryPositionType = json.SelectToken("people[0].primaryPosition.type").ToString();
            primaryPositionAbbr = json.SelectToken("people[0].primaryPosition.abbreviation").ToString();



        }
    }
}

