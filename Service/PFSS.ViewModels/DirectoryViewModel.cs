using System;

namespace PFSS.ViewModels
{
    public class LiteDirectoryViewModel : BaseViewModel
    {
        public string Name { get; set; }
    }
    public class DirectoryViewModel : LiteDirectoryViewModel
    {
    }
    public class DetailedDirectoryViewModel : DirectoryViewModel
    {

    }
}
