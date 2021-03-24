using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFSS.RequestModels.Directory
{
    public class CreateDirectoryRequestModel
    {
        public string ParentDirectoryId { get; set; }
        public string Name { get; set; }
    }
}
