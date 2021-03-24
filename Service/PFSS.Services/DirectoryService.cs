using PFSS.Models;
using PrivateFileStorageService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFSS.Services
{
    public class DirectoryService : BaseService<Models.Directory>
    {
        public DirectoryService(IDatabaseSettings settings): base(settings)
        {

        }
        public async Task<List<Directory>> GetRootDirectories(User user)
        {
            var directories = (await GetByCondition(x => user.AuthorizedDirectories.Contains(x.Id) && x.ParentDirectoryId == null)).ToList();
            return directories;
        }
        public async Task<List<Directory>> GetChilds(string parentDirectoryId)
        {
            var directoryChilds = (await GetByCondition(x => x.Id == parentDirectoryId)).ToList();
            return directoryChilds;
        }
    }
}
