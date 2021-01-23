using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PFSS.API.RequestModels.Directory
{
    public class CreateDirectoryRequestModel
    {
        public string ParentDirectoryId { get; set; }
        public string Name { get; set; }
    }
}
