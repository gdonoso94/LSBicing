using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace LSBicing
{
    class Geocoding
    {
        public string baseUrl = @"https://maps.googleapis.com/maps/api/geocode/json?";
        public string apiKey = ;
        public string result;
        public JObject jsonResult;
        public string address;
        public Dictionary<string, string> Location { get; private set; }

        public Geocoding(string str)
        {
            SetAddress(str);
        }

        //getters and setters
        public void SetKey(string newKey)
        {
            this.apiKey = newKey;
        }
        public string GetKey()
        {
            return this.apiKey;
        }

        public void SetAddress(string str)
        {
            this.address = str.Replace(" ", "+");
        }

        public string GetAddress()
        {
            return this.address;
        }

        public JObject GetJsonResult()
        {
            return this.jsonResult;
        }

        public void SetJsonResult(JObject newJson)
        {
            this.jsonResult = newJson;
        }

        //public void SetQuery(string str){
        //    this.query = str;
        //}
        public void SetResult(string str)
        {
            this.result = str;
        }
        public string GetResult()
        {
            return this.result;
        }

        //methods
        public string GetJsonString()
        {
            using (var client = new WebClient())
            {
                string result_ = client.DownloadString(string.Format("{0}address={1}&key={2}", this.baseUrl, GetAddress(), GetKey()));
                //string result = client.DownloadString(@"https://maps.googleapis.com/maps/api/geocode/json?address=1600+Amphitheatre+Parkway,+Mountain+View,+CA&key=");
                SetResult(result_);
                return GetResult();
            }
        }

        public JObject ParseJson()
        {
            return this.jsonResult = JObject.Parse(GetResult());
        }

        public string GetFormattedAddress()
        {
            if ((string)GetJsonResult()["status"] == "OK")
            {
                if (!GetJsonResult()["results"][0].isEmpty())
                {
                    return (string)GetJsonResult()["results"][0]["formatted_address"];
                }
                else
                {
                    return "No results for that address."; 
                }
            }
            else
            {
                return "Bad Request";
            }
        }

        public void GetLocationFromJson()
        {  //Returns dictionary with location for the address.

            var Location_ = new Dictionary<string, string>();

            if ((string)GetJsonResult()["status"] == "OK")
            {
                Location_.Add("Lon", (string)GetJsonResult()["results"][0]["geometry"]["location"]["lng"]);
                Location_.Add("Lat", (string)GetJsonResult()["results"][0]["geometry"]["location"]["lat"]);
                this.Location = Location_;
            }
            else
            {
                throw new HttpListenerException(1, "There is a problem with your request. Review API key.");
            }
        }

        public void OpenMap(){
            Process.Start("/Applications/Google Chrome.app/Contents/MacOS/Google Chrome", string.Format("https://www.google.com/maps/search/{0},{1}",
                                                                                                        this.Location["Lat"], this.Location["Lon"]));
            // https://www.google.com/maps/search/40.3820398,+-3.1984832?sa=X&ved=2ahUKEwjC6o6V15LdAhUhzlkKHVaeCmUQ8gEwAHoECAQQAQ

        }

    }

    //public string GetQuery(){
    //    return this.query;
    //}

    //public string GetGeocodingUrl(){
    //    StringFormatter queryFormatted = new StringFormatter(this.query);
    //    queryFormatted.ReplaceBlanks();
    //    return this.baseUrl + queryFormatted.GetString();
    //}
}
