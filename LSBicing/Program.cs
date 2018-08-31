using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json.Linq;

namespace LSBicing
{
    class Program
    {
        
        static void Main(string[] args)
        {
            //string foo = "Esto es una prueba"; 
            //StringFormatter fooFormat = new StringFormatter(foo);
            //Console.WriteLine("Non formatted string: " + fooFormat.GetString());
            //fooFormat.ReplaceBlanks();
            //Console.WriteLine("Formatted string: "+ fooFormat.GetString());
            //Console.WriteLine("Insert Address: ");
            //string address = Console.ReadLine();
            //Geocoding testing = new Geocoding(address);
            //Console.WriteLine("Loading Google Maps...");
            //Process.Start("/Applications/Google Chrome.app/Contents/MacOS/Google Chrome", testing.GetGeocodingUrl());
            //using (var client = new WebClient()){
            //    string result = client.DownloadString(@"https://maps.googleapis.com/maps/api/geocode/json?address=1600+Amphitheatre+Parkway,+Mountain+View,+CA&key=AIzaSyAm5Sagiy095tGRNnoM710E0MUafqhj1k0");
            //    Console.WriteLine(result);
            //}

            //var openUpMenu = new Menu();
            //var selector = openUpMenu.GetChoice();
            //Console.Clear();

            //if (selector == 1)
            //{
            //    Console.WriteLine("Insert your address: ");
            //    var myAddress = Console.ReadLine();
            //    var geocode = new Geocoding(myAddress);
            //    geocode.GetJsonString();
            //    geocode.ParseJson();
            //    Console.WriteLine(geocode.GetFormattedAddress());
            //    geocode.GetLocationFromJson();

            //    if (geocode.isGoodRequest){
            //        Console.WriteLine("Latitude " + geocode.Location["Lat"]);
            //        Console.WriteLine("Longitude " + geocode.Location["Lon"]);
            //        geocode.OpenMap();
            //    }

            //}

            Bicing bicing = new Bicing("ronda de sant pau 72");
            bicing.GetDistanceMatrix();
            Console.WriteLine(bicing.distanceMatrix);

        }
    }
}
