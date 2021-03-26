using PFSS.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PFSS.Models.ViewModels
{
    public class DirectoryViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public string ParentDirectoryId { get; set; }
        public List<DirectoryViewModel> ChildDirectories { get; set; }
        public List<string> ChildFileIds { get; set; }
    }
}
