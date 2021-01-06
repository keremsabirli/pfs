using System;
using System.Collections.Generic;
using System.Text;

namespace PFSS.ViewModels
{
    public class LiteFileViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public string Extension { get; set; }
    }
    public class FileViewModel : LiteFileViewModel
    {
        
    }
    public class DetailedViewModel : FileViewModel
    {

    }
}
