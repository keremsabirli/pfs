using PrivateFileStorageService;
using System;
using System.Collections.Generic;
using System.Text;

namespace PFSS.Services
{
    public class DirectoryService : BaseService<Models.Directory>
    {
        public DirectoryService(IDatabaseSettings settings): base(settings)
        {

        }
    }
}
