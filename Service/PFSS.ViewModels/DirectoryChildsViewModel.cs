using System;
using System.Collections.Generic;
using System.Text;

namespace PFSS.ViewModels
{
    public class DirectoryChildsViewModel
    {
        public List<FileViewModel> Files { get; set; }
        public List<DirectoryViewModel> ChildDirectories { get; set; }
    }
}
