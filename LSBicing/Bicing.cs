using System;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json.Linq;

namespace LSBicing
{
    public class Bicing
    {
        public JObject bicingInfo { get; set;}
        public JObject distanceData { get; set; }
        private string apiKey = File.ReadAllText("../apikey.txt").ToString();
        public string originAddress { get; set; }
        public JObject distanceMatrix { get; set; }

        //getter
        public string GetApiKey(){
            return this.apiKey;
        }

        public Bicing(string str)
        {
            this.originAddress = str;
            using (var client = new WebClient())
            {
                this.bicingInfo = JObject.Parse(client.DownloadString(@"http://wservice.viabicing.cat/v2/stations"));
            }
            //{"stations":[{"id":"1","type":"BIKE","latitude":"41.397952","longitude
            //":"2.180042","streetName":"Gran Via Corts Catalanes","streetNumber":"760","altitude":"21","slots":"2","bikes":"26","nearbyStations":"24, 369, 387, 426","status":"OPN"},
        }

        public void GetDistanceMatrix(){
            StringBuilder sb = new StringBuilder();

            foreach (var dict in this.bicingInfo["stations"])
            {
                if((string)dict["type"] == "BIKE")
                {
                    sb.Append(dict["streetName"] + " " + dict["streetNumber"] + "|");
                }
            }

            string urlDM = string.Format("https://maps.googleapis.com/maps/api/" +
                                         "distancematrix/json?units=imperial&origins={0}&destinations={1}&key={2}",
                                         this.originAddress, sb.ToString().Replace(" ", "+").Remove(sb.ToString().Length - 1), GetApiKey());

            var client = new WebClient();
            Console.WriteLine(urlDM);
            this.distanceMatrix = JObject.Parse(client.DownloadString(urlDM));
        }







        //http://wservice.viabicing.cat/v2/stations

    }
}
