using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Neo4j.Driver;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

class Program
{
    static async Task Main()
    {
        using (var driver = GraphDatabase.Driver("neo4j+s://414bb2b8.databases.neo4j.io", AuthTokens.Basic("neo4j", "A5bChRkS99PpB1uHxVvFfxG5zqBrSw2MehQ9F69p42Q")))
        {
             using (var session = driver.AsyncSession())
            {
                var cypherQuery = "MATCH (n:new_Property) RETURN n";
                var result = await session.RunAsync(cypherQuery);

                // Extract properties from the result
                var nodesList = new List<Dictionary<string, object>>();

                await result.ForEachAsync(record =>
                {
                    var node = record["n"];
                    string nodeId = node.As<INode>().Id.ToString();
                    var properties = node.As<INode>().Properties;
                    var jsonResult = JsonConvert.SerializeObject(properties, Formatting.Indented);
                    var json = JObject.Parse(jsonResult);
                    json.Add("id", JObject.FromObject((object)nodeId));
                    // Add ID and properties to the dictionary
                    var nodeData = new Dictionary<string, object>
                    {
                        {"id", nodeId},
                        {"properties", properties}
                    };

                    nodesList.Add(nodeData);
                });

                // Convert the list of properties to JSON
                //var jsonResult = JsonConvert.SerializeObject(nodesList, Formatting.Indented);
               // var results = JObject.Parse(data1)["properties"].ToString(Formatting.None);

                }
                // Print or use the JSON result
               // Console.WriteLine(jsonResult);
            
        }
    }
}
