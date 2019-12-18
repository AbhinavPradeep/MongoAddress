using System;
using MongoDB;
using MongoDB.Driver;

namespace MongoAddress
{
    public class Person
    {
        public int _id {get;set;}
        public string FirstName {get; set;}        
        public string LastName {get;set;}       
        public Address Address{get;set;}        
        
    }
}