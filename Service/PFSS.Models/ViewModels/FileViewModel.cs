using System;
using System.Collections.Generic;
using System.Text;

namespace PFSS.Models.ViewModels
{
    public class FileViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public string Extension { get; set; }
        public byte[] Bytes { get; set; }
    }
}
