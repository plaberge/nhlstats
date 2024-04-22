using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHLStats
{
    public class TVBroadcast
    {

        public string id { get; set; }
        public string market { get; set; }
        public string countryCode { get; set; }
        public string network { get; set; }
        public JToken json { get; set; }
       
       // Empty default constructor
        public TVBroadcast()
        {

        }

        public TVBroadcast(JToken tvBroadcast) 
        {
            id = tvBroadcast["id"].ToString();
            market = tvBroadcast["market"].ToString();
            countryCode = tvBroadcast["countryCode"].ToString();
            network = tvBroadcast["network"].ToString();
            json = tvBroadcast;
            
        }
    }
}
