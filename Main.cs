using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace GetMeal
{
    public class MealSites
    {
        public string GeneralLocation { get; set; }
        public string ProgramName { get; set; }
        public string Location { get; set; }
        public string PhoneNumber { get; set; }
        public string Website { get; set; }
        public string MealInformation { get; set; }
    }

    public class Main
    {
        private string address;

        public Main(string address)
        {
            this.address = address;
        }

        public List<string> Execute()

        {

            

            try
            {
                //Expose as Azure function so it can be called from anywhere and easy integration with any apps
                //We stored data in Cosmo DB for high reliability stoarge and acessibility of data
                var dbResult = QueryAllDocument("https://dubhack2019.documents.azure.com:443/",
                              "RhJ7nANxSQLMEKts2w2NT4kSO4fZ84uwLq5XaeAvQ8fJ11xDBqfLTJozaM7PMokHd12lPlAfj1njiYLuqAT2eA==",
                              "dubhack2019Db",
                              "dubhack2019Container");

                string key = "AsVv6EZaO3eVZEFxjBX5U3yag0-QBFErIUzcrCFlFOAsu99ICksFfgv69NlX-1PT";
                string query = "1 Microsoft Way, Redmond, WA";
                Uri geocodeRequest = new Uri(string.Format("http://dev.virtualearth.net/REST/v1/Locations?q={0}&key={1}", query, key));

                var bingLocation = new GetAddress();
                var geoCode;
                bingLocation.GetResponse(geocodeRequest, (x) =>
                {
                    Console.WriteLine(x.ResourceSets[0].Resources.Length + " result(s) found.");
                    Console.ReadLine();
                    geoCode = bingLocation.Coordinates;
                });

                var result = new List<locationPlace>();
                var storeDist = new List<locationPlace>();
                foreach (var location in dbResult)
                {
                    string query = location.Location;
                    Uri geocodeRequest = new Uri(string.Format("http://dev.virtualearth.net/REST/v1/Locations?q={0}&key={1}", query, key));

                    var bingLocationDest = new GetAddress();
                    var geoCodeDest;
                    bingLocationDest.GetResponse(geocodeRequest, (x) =>
                    {
                        Console.WriteLine(x.ResourceSets[0].Resources.Length + " result(s) found.");
                        Console.ReadLine();
                        geoCodeDest = bingLocationDest.Coordinates;
                    });


                    string origin = geoCodeDest;
                    string dest = geoCode;
                    Uri distanceRequest = new Uri(string.Format("http://dev.virtualearth.net/REST/v1/Locations?q={0}&key={1}", query, key));
                    var bingLocationDist = new GetAddress();
                    var geoCodeDist;
                    bingLocationDist.GetResponse(distanceRequest, (x) =>
                    {
                        Console.WriteLine(x.ResourceSets[0].Resources.Length + " result(s) found.");
                        Console.ReadLine();
                        geoCodeDist = bingLocationDist.Distance;
                    });
                    storeDist.addAddress(location.address);
                    storeDist.addLocation(location.Location);
                    storeDist.addDist(geoCodeDist);
                }
                var i = 0;
                foreach(var location in storeDist)
                {
                    if (location.dist <= 10)
                    {
                        result.Add(location);
                    }
                }
                return result;
            }



               
            
            catch(Exception e)
            {
                throw;
            }
        }

        public static List<MealSites> QueryAllDocument(string Uri, string Key, string DatabaseName, string CollectionName)
        {
            DocumentClient client = new DocumentClient(new Uri(Uri), Key, new ConnectionPolicy { EnableEndpointDiscovery = false });

            var rawList = client.CreateDocumentQuery<MealSites>(UriFactory.CreateDocumentCollectionUri(DatabaseName, CollectionName).ToString(), new SqlQuerySpec("SELECT * FROM c"), new FeedOptions { MaxItemCount = -1, EnableCrossPartitionQuery = true });
            List<MealSites> list = rawList.ToList<MealSites>();
            return list;
        }
    }
}
