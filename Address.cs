using System;
using MongoDB;
using MongoDB.Driver;

namespace MongoAddress
{
    public class Address
    {
        public string Country;
        public string State;
        public string Area;
        public string Street;
        public int HouseNum;
    }
}