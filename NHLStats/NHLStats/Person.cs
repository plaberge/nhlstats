using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;

namespace NHLStats
{
    // Person class is meant for miscellaneous people associated to a game
    // Like coaches and referees
    public class Person
    {
        public string personId { get; set; } // ID of the person
        public string fullName { get; set; } // Full name of the person
        public string role { get; set; } // Role of the person (e.g.:  coach, official, etc.)
        public string subRole { get; set; } // Specific role of the person (e.g.:  referee, linesman, etc.)
        public JObject personJson { get; set; } // Populate the raw JSON to a property

        public Person(JObject json)
        {
            personJson = json; // Populate the raw JSON to a property
            // Populating the person object if the type is official
            if (json.ContainsKey("official"))
            {
                if (json.ContainsKey("official.id"))
                {
                    personId = json.SelectToken("official.id").ToString();
                }
                else
                    personId = Guid.NewGuid().ToString();
                
                fullName = json.SelectToken("official.fullName").ToString();
                role = "Official";
                subRole = json.SelectToken("officialType").ToString();
            }
            else if (json.ContainsKey("position"))
            {
                // Create a dummy ID for a coach as they do not have IDs
                personId = Guid.NewGuid().ToString();
                fullName = json.SelectToken("person.fullName").ToString();
                role = json.SelectToken("position.type").ToString();
            }
            else
            {
                personId = Guid.NewGuid().ToString();
                fullName = "EMPTY EMPTY";
                role = "Head Coach";
            }
        }

        public Person(JObject json, string personType)
        {
            if (personType == "referee")
            {
                personId = " ";
                fullName = json["default"].ToString();
                role = "Official";
                subRole = "Referee";
                personJson = json;
            }
            else if (personType == "linesman")
            {
                personId = " ";
                fullName = json["default"].ToString();
                role = "Official";
                subRole = "Linesman";
                personJson = json;
            }
            else if (personType == "coach")
            {
                personId = " ";
                fullName = json["default"].ToString();
                role = "Head Coach";
                personJson = json;
            }
            else
            {
                personId = " ";
                fullName = "EMPTY EMPTY";
                role = "Other";
                personJson = json;
            }
        }

    }
}
