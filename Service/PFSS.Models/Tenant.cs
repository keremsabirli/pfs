using System;
using System.Collections.Generic;
using System.Text;

namespace PFSS.Models
{
    public class Tenant : Shared
    {
        public string Name { get; set; }
        public List<User> Users { get; set; }
    }
}
