using System;
using MongoDB;
using MongoDB.Driver;
using Newtonsoft.Json;

namespace MongoAddress
{
    class PersonFactory
    {
        public Person CreatePerson()
        {
            Person Abhinav = new Person();
            System.Console.WriteLine("Enter The _id of the document");
            string personidstr = System.Console.ReadLine();
            Int32.TryParse( personidstr, out int personid);
            Abhinav._id = personid;
            System.Console.WriteLine("Enter the customers first name");
            Abhinav.FirstName = System.Console.ReadLine();
            System.Console.WriteLine("Enter the customers last name");
            Abhinav.LastName = System.Console.ReadLine();

            Address AbhinavAddress = new Address();
            System.Console.WriteLine("Enter the customers country");
            AbhinavAddress.Country = System.Console.ReadLine();
            System.Console.WriteLine("Enter the customers state");
            AbhinavAddress.State = System.Console.ReadLine();
            System.Console.WriteLine("Enter the customers area");
            AbhinavAddress.Area = System.Console.ReadLine();
            System.Console.WriteLine("Enter the customers street");
            AbhinavAddress.Street = System.Console.ReadLine();
            System.Console.WriteLine("Enter the customes house number");
           Int32.TryParse( System.Console.ReadLine(), out int inthouse);
            AbhinavAddress.HouseNum = inthouse;

            Abhinav.Address = AbhinavAddress;

            return Abhinav;
        }
        
        
    }
}