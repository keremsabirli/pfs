using System;
using System.Collections.Generic;
using System.Text;

namespace PFSS.Models
{
    public class UserGroup
    {
        public string Name { get; set; }
        public User Creator { get; set; }
        public List<User> Members { get; set; }
    }
}
