using System;
using System.Collections.Generic;
using System.Text;

namespace PFSS.Models
{
    public class Directory : Shared
    {
        public string Name { get; set; }
        public List<File> ChildFiles { get; set; }
        public List<Directory> ChildDirectories { get; set; }
        public Directory ParentDirectory { get; set; }
        public List<User> UserGroups { get; set; }
    }
}
