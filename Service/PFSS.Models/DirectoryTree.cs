using System;
using System.Collections.Generic;
using System.Text;

namespace PFSS.Models
{
    public class DirectoryTree
    {
        public string DirectoryId { get; set; }
        public string Name { get; set; }
        public List<DirectoryTree> Childs { get; set; }
    }
}
