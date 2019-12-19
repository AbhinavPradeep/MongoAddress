using MongoDB.Driver;
using System;

namespace MongoAddress
{
    class Program
    {
        private static IMongoCollection<Person> InitializeDatabase()
        {
            var client = new MongoClient("mongodb+srv://lol:lol@clusterone-5rfg7.mongodb.net/CustomersDB?retryWrites=true&w=majority");
            var database = client.GetDatabase("CustomersDB");
            var collection = database.GetCollection<Person>("Customers");
            return collection;
        }

        static void Main(string[] args)
        {
            IMongoCollection<Person> collection = InitializeDatabase();

            if (args[0] == "Add")
            {
                AddCustomer(collection);
            }
            else if (args[0] == "List")
            {
                string customerid = args[1];
                Int32.TryParse(customerid, out int id);
                FindCustomer(collection, id);
            }
            else if (args[0] == "Delete")
            {
                string customerid = args[1];
                Int32.TryParse(customerid, out int id);
                DeleteCustomer(collection, id);
            }
            else if (args[0] == "Update")
            {
                string customerid = args[1];
                Int32.TryParse(customerid, out int id);
                string field = args[2];
                string renamed = args[3];
                UpdateRename(collection,id,field,renamed);
            } 
        }

        private static void DeleteCustomer(IMongoCollection<Person> collection, int id)
        {
            var result = collection.DeleteOne<Person>(x => x._id == id);
            if (result.DeletedCount > 0)
                Console.WriteLine("deleted");
        }
        private static void UpdateRename(IMongoCollection<Person> collection, int id,string field, string renamed)
        {
           var update = Builders<Person>.Update.Set(field,renamed);
           collection.UpdateOne(x => x._id == id,update);
        }


        private static void FindCustomer(IMongoCollection<Person> collection, int id)
        {   
            var persons = collection.Find<Person>(person => person._id == id).ToList();

            foreach (var person in persons)
            {
                PrintPerson(person);
            }
        }
        private static void PrintPerson(Person person)
        {
            Console.WriteLine($"Person ID  is {person._id}");
            Console.WriteLine($"Person first Name is {person.FirstName}");
            Console.WriteLine($"Person Last Name is {person.LastName}");
            Console.WriteLine($"Person HouseNum is {person.Address.HouseNum}");
            Console.WriteLine($"Person Street is {person.Address.Street}");
            Console.WriteLine($"Person Area is {person.Address.Area}");
            Console.WriteLine($"Person state is {person.Address.State}");
            Console.WriteLine($"Person country is {person.Address.Country}");
            
        }

        private static void AddCustomer(IMongoCollection<Person> collection)
        {
            
            bool repeat = true;

            PersonFactory factory = new PersonFactory();
            Person person = new Person();

            while (repeat)
            {
                person = factory.CreatePerson();

                collection.InsertOne(person);

                Console.WriteLine("Go again? Y/N: ");
                string go = Console.ReadLine();
                if (go.ToUpper() != "Y")
                {
                    repeat = false;
                }

            }
        }        
    }
}