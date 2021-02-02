using System;
using System.Collections.Generic;
using System.Text;

namespace PFSS.ViewModels
{
    public class ContainerViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public string CreatorId { get; set; }
        public List<DirectoryViewModel> Directories { get; set; }
    }
}
