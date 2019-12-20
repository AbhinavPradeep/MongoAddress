using System;

namespace MongoAddress
{
    class PersonFactory
    {
        public Person CreatePerson()
        {
            Person person = new Person();
            System.Console.WriteLine("Enter The _id of the document");
            string personidstr = System.Console.ReadLine();
            Int32.TryParse( personidstr, out int personid);
            person._id = personid;
            System.Console.WriteLine("Enter the customers first name");
            person.FirstName = System.Console.ReadLine();
            System.Console.WriteLine("Enter the customers last name");
            person.LastName = System.Console.ReadLine();

            Address address = new Address();
            System.Console.WriteLine("Enter the customers country");
            address.Country = System.Console.ReadLine();
            System.Console.WriteLine("Enter the customers state");
            address.State = System.Console.ReadLine();
            System.Console.WriteLine("Enter the customers area");
            address.Area = System.Console.ReadLine();
            System.Console.WriteLine("Enter the customers street");
            address.Street = System.Console.ReadLine();
            System.Console.WriteLine("Enter the customes house number");
           Int32.TryParse( System.Console.ReadLine(), out int inthouse);
            address.HouseNum = inthouse;

            person.Address = address;

            return person;
        }
        
        
    }
}