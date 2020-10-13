using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Net;
using System.Linq;
namespace SunAPI
{
    class Program
    {
        private static string url = "https://api.sunrise-sunset.org/json?lat=59.4370&lng=24.7536&date=2020-10-13";
        static void Main(string[] args)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            WebResponse webResponse = request.GetResponse();
            Stream webStream = webResponse.GetResponseStream();
            using (StreamReader responseReader = new StreamReader(webStream))
            {
                string response = responseReader.ReadToEnd();
                Sun sun = JsonConvert.DeserializeObject<Sun>(response);
                if (sun.Status.Trim().ToLower()=="ok")
                {
                    Console.WriteLine($"Sunrise time: {sun.Results.Sunrise}");
                    Console.WriteLine($"Sunset time: {sun.Results.SunSet}");
                    Console.WriteLine($"Solar noon time: {sun.Results.Solar_Noon}");
                    string day = sun.Results.Day_Length;
                    Console.WriteLine($"Day length: {day.Substring(0,2)} hours {day.Substring(3,2)} minutes {day.Substring(6,2)} seconds");
                    Console.WriteLine($"Civil twilight begins at: {sun.Results.Civil_Twilight_Begin}");
                    Console.WriteLine($"Civil twilight ends at: {sun.Results.Civil_Twilight_End}");
                    Console.WriteLine($"Nautical twilight begins at: {sun.Results.Nautical_Twilight_Begin}");
                    Console.WriteLine($"Nautical twilight ends at: {sun.Results.Nautical_Twilight_End}");
                    Console.WriteLine($"Astronomical twilight begins at: {sun.Results.Astronomical_Twilight_Begin}");
                    Console.WriteLine($"Astronomical twilight ends at: {sun.Results.Astronomical_Twilight_End}");
                }
                else
                {
                    Console.WriteLine("Something goes wrong");
                }

                /* JObject o = JObject.Parse(response);
                 string sunrise = (string)o["results"]["sunrise"];
                 string sunset = (string)o["results"]["sunset"];
                 Console.WriteLine($"Sunrise time: {sunrise}");
                 Console.WriteLine($"Sunset time: {sunset}");*/
            };

        }
    }
}
