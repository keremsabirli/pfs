using PFSS.Models.RequestModels.Directory;
using PFSS.Services.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFSS.Managers
{
    public class DirectoryManager : BaseManager
    {
        public DirectoryManager(ServiceWrapper serviceWrapper) : base(serviceWrapper)
        {
        }
        public bool CreateDirectory(CreateDirectoryRequestModel model)
        {
            return true;
        }
    }
}
