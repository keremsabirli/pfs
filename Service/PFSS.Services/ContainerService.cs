using PFSS.Models;
using PrivateFileStorageService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFSS.Services
{
    public class ContainerService : BaseService<Container>
    {
        public ContainerService(IDatabaseSettings settings) : base(settings)
        {
        }
        public async Task<List<Container>> GetUserContainers(string id)
        {
            var containers = (await GetByCondition(x => x.CreatorId == id)).ToList();
            return containers;
        }
    }
}
