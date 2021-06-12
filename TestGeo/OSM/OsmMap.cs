using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TestGeo.Entity;

namespace TestGeo.OSM
{
    public class OsmMap : IMapService
    {
        public void WriteCoordinateToFile(string filePath, string info, int pass)
        {
            var jsonArr = JArray.Parse(info);
            int sityCount = 1;
            foreach (var json in jsonArr)
            {
                int cordCount = json["geojson"]["coordinates"][0].Count();
                using (StreamWriter sw = new StreamWriter(filePath + $"(Result{sityCount}).txt", true))
                {
                    for (int index = 0; index < cordCount; index++)
                    {
                        if (index % pass == 0)
                        {
                            string text = json["geojson"]["coordinates"][0][index].ToString();
                            sw.WriteLine(text);
                        }
                    }
                    sw.Flush();
                    sw.Close();
                }
                sityCount++;
            }
        }

        public string GetInfo(string findSity)
        {
            string url = File.ReadAllText(@".\OSM\Url.txt") + findSity + "&format=json&polygon_geojson=1";

            WebClient webClient = new WebClient();
            webClient.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:45.0) Gecko/20100101 Firefox/45.0");
            webClient.Headers.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8");
            webClient.Headers.Add("Accept-Language", "ru-RU,ru;q=0.8,en-US;q=0.5,en;q=0.3");

            return webClient.DownloadString(url);
        }
    }
}
