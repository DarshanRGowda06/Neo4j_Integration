using Neo4j.Driver;
using neo4joperation;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neo4j_Project
{
    internal class Program
    {
        [Obsolete]
        static async Task Main(string[] args)
        {
            // NEO$J AURA CREDENTIALS
            //string neo4jUri = "neo4j+s://414bb2b8.databases.neo4j.io";
            //string neo4jUser = "neo4j";
            //string neo4jPassword = "A5bChRkS99PpB1uHxVvFfxG5zqBrSw2MehQ9F69p42Q";

            //NEO4J LOCAL DB CREDENTIALS
            string neo4jUri = "bolt://localhost:7687";
            string neo4jUser = "darshan";
            string neo4jPassword = "Password";


            var neo4jCRUD = new Neo4jCRUD(neo4jUri, neo4jUser, neo4jPassword);

            //CREATE DATABASE ------------------------------------------
            //string dbname = "hello1db";
            //if (!neo4jUri.Contains("databses.neo4j.io"))
            //{
            //    await neo4jCRUD.CreateDatabase(dbname);
            //    Console.WriteLine("DataBase Created");
            //}


            //LIST DATABASE NAME-----------------

            //List<string> listDataBase = new List<string>();
            //listDataBase = await neo4jCRUD.listdatabase();
            //foreach (var item in listDataBase)
            //{
            //    Console.WriteLine(item);
            //}



            //CREATE Node RETURN ID-----------------------

            //long CreateNodeResponse = await neo4jCRUD.CreateNode("demodb", "student", new { name = "darshanr", age = 24 });
            //Console.WriteLine(CreateNodeResponse);






            //UPDATE NODE LABEL, PROPERTIES AND RETURN <NODE ID, NODE PROPERTIES, NODE ELEMENTID, NODE LABEL----------------

            //List<string> list = new List<string>() { "171"};
            //var propertiesToUpdate = new Dictionary<string, string>
            //{

            //    { "year", "2000" }
            //};
            //int i = 1;
            //ListNodeData result = await neo4jCRUD.UpdateNodes("neo4j", "Family", "student", list, propertiesToUpdate);
            //foreach (var items in result.nodeData)
            //{
            //    Console.WriteLine("Node " + i.ToString());
            //    Console.WriteLine();
            //    Console.WriteLine("Node ID :" + items.Id);
            //    Console.WriteLine("Node ELEMENT ID :" + items.ElementId);
            //    foreach (var item in items.Label)
            //    {
            //        Console.WriteLine("Node Label :" + item);
            //    }
            //    Console.WriteLine();
            //    Console.WriteLine("NODE PROPERTIES :");
            //    foreach (var item in items.Property)
            //    {
            //        Console.WriteLine(item.Key + " :" + item.Value);
            //    }
            //    Console.WriteLine();
            //    Console.WriteLine();
            //    i += 1;
            //}






            //DELETE NODE OR NODES---------------

            //List<int> nodeId = new List<int>() { 2000 }; ;
            //string databasename = "neo4j";
            //string DeleteNodeResponse = await neo4jCRUD.DeleteNode(nodeId, databasename);
            //Console.WriteLine(DeleteNodeResponse);






            //READ NODE RETURN NODE PROPERTIES AND LABEL-------------

            List<int> nodeId = new List<int>() { 171 };
            string databasename = "neo4j";
            int i = 1;
            (ListNodeData,List<string> PropertyLabel)  record = await neo4jCRUD.ReadNode(nodeId, databasename);
            if (record.Item1 != null)
            {
                foreach(string propertylabel in record.PropertyLabel) 
                {
                    Console.WriteLine(propertylabel); 
                }
                foreach (var items in record.Item1.nodeData)
                {
                    Console.WriteLine("Node " + i.ToString());
                    Console.WriteLine();
                    Console.WriteLine("Node ID :" + items.Id);
                    Console.WriteLine("Node ELEMENT ID :" + items.ElementId);
                    foreach (var item in items.Label)
                    {
                        Console.WriteLine("Node Label :" + item);
                    }
                    Console.WriteLine();
                    Console.WriteLine("NODE PROPERTIES :");
                    foreach (var item in items.Property)
                    {
                        Console.WriteLine(item.Key + " :" + item.Value);
                    }
                    Console.WriteLine();
                    Console.WriteLine();
                    i += 1;
                }
            }
            else Console.WriteLine("No data found");

        }
    }
}
