using System;
using System.Net;
using MongoDB;
using MongoDB.Driver;
using Newtonsoft.Json;
using Newtonsoft.Json.Bson;



namespace MongoAddress
{
    class Program
    {
        static void Main(string[] args)
        {
            PersonFactory factory = new PersonFactory();
            Person person = new Person();
            person = factory.CreatePerson();
            
            var client = new MongoClient("mongodb+srv://appuser:apppassword@clusterone-5rfg7.mongodb.net/CustomersDB?retryWrites=true&w=majority");
            var database = client.GetDatabase("CustomersDB");
            var collection = database.GetCollection<Person>("Customers");
            collection.InsertOne(person);
        }
    }
}
