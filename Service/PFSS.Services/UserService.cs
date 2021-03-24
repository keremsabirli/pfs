using PFSS.Models;
using PrivateFileStorageService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFSS.Services
{
    public class UserService : BaseService<User>
    {
        public UserService(IDatabaseSettings settings) : base(settings)
        {
        }
        public async Task<User> GetByToken(string token)
        {
            return (await GetByCondition(x => x.Token == token)).FirstOrDefault();
        }
        public async Task<bool> AddDirectoryAuthorization(string userId, string directoryId)
        {
            var user = await GetById(userId);
            if(user.AuthorizedDirectories == null)
            {
                user.AuthorizedDirectories = new List<string>{ directoryId };
            }
            else
            {
                user.AuthorizedDirectories.Add(directoryId);
            }
            await Update(user);
            return true;
        }
    }
}
