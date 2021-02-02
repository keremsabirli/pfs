using System;
namespace PFSS.Models.Auth
{
    public class RegisterModel
    {
        public string name { get; set; }
        public string surname { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public UserType userType { get; set; }
    }
}
