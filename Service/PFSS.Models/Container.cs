using System;
using System.Collections.Generic;
using System.Text;

namespace PFSS.Models
{
    public class Container : Shared
    {
        public string Name { get; set; }
        public string CreatorId { get; set; }
        public List<Directory> Directories { get; set; }
    }
}
