using System;
using System.Collections.Generic;
using System.Text;

namespace PFSS.Models
{
    public class User : Shared
    {
        public string Name { get; set; }
        public List<UserGroup> UserGroups { get; set; }
        public Tenant Tenant { get; set; }
    }
}
