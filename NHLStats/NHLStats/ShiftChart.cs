using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHLStats
{
    public class ShiftChart
    {
        public string shiftId { get; set; }
        public string detailCode { get; set; }
        public string duration { get; set; }
        public string startTime { get; set; }
        public string endTime { get; set; }
        public string eventDescription { get; set; }
        public string eventDetails { get; set; }
        public string eventNumber { get; set; }
        public string playerId { get; set; }
        public string playerFirstName { get; set; }
        public string playerLastName { get; set; }
        public string teamAbbrev { get; set; }
        public string teamId { get; set; }
        public string teamName { get; set; }
        public string gameId { get; set; }
        public string hexValue { get; set; }
        public string period { get; set; }
        public string shiftNumber { get; set; }
        public string typeCode { get; set; }
        public JToken shiftChartJson { get; set; }
        public ShiftChart()
        {

        }   

        public ShiftChart(string gameId, JToken shift)
        {
           
                shiftId = shift.SelectToken("id").ToString();
                detailCode = shift.SelectToken("detailCode").ToString();
                duration = shift.SelectToken("duration").ToString();
                startTime = shift.SelectToken("startTime").ToString();
                endTime = shift.SelectToken("endTime").ToString();
                eventDescription = shift.SelectToken("eventDescription").ToString();
                eventDetails = shift.SelectToken("eventDetails").ToString();
                eventNumber = shift.SelectToken("eventNumber").ToString();
                playerId = shift.SelectToken("playerId").ToString();
                playerFirstName = shift.SelectToken("firstName").ToString();
                playerLastName = shift.SelectToken("lastName").ToString();
                teamAbbrev = shift.SelectToken("teamAbbrev").ToString();
                teamId = shift.SelectToken("teamId").ToString();
                teamName = shift.SelectToken("teamName").ToString();
                this.gameId = gameId;
                hexValue = shift.SelectToken("hexValue").ToString();
                period = shift.SelectToken("period").ToString();
                shiftNumber = shift.SelectToken("shiftNumber").ToString();
                typeCode = shift.SelectToken("typeCode").ToString();
                this.shiftChartJson = shift;
            
        }
    }
}
