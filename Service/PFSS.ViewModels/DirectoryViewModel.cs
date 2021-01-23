using System;
using System.Collections.Generic;

namespace PFSS.ViewModels
{
    public class DirectoryViewModel : BaseViewModel
    {
        public List<FileViewModel> Files { get; set; }
        public List<DirectoryViewModel> ChildDirectories { get; set; }
    }
}
