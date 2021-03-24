using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace PFSS.Models
{ 

    public class User: Shared
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserType UserType { get; set; }
        public string Token { get; set; }
        public List<string> AuthorizedDirectories { get; set; }
    }

    public enum UserType:byte { 
        Admin=0,
        Guest=1,
        Standard=2
    }
}