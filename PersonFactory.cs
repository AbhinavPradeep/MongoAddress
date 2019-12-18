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
            Abhinav._id = 2;
            Abhinav.FirstName = "Abhinav";
            Abhinav.LastName = "Pradeep";

            Address AbhinavAddress = new Address();
            AbhinavAddress.Country = "Australia";
            AbhinavAddress.State = "QLD";
            AbhinavAddress.Area = "Buderim";
            AbhinavAddress.Street = "Nyes Crescent";
            AbhinavAddress.HouseNum = 42;

            Abhinav.Address = AbhinavAddress;

            return Abhinav;
        }
        
        
    }
}