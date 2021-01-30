using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace PFSS.Models
{ 

    public class User: Shared
    {
        public int UserId { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public UserType userType { get; set; }
        public string token { get; set; }
    }

    public enum UserType:byte { 
        Admin=0,
        Guest=1,
        Standard=2
    }
}