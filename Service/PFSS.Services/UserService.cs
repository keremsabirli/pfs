using PFSS.Models;
using PrivateFileStorageService;
using System;
using System.Collections.Generic;
using System.Text;

namespace PFSS.Services
{
    public class UserService : BaseService<User>
    {
        public UserService(IDatabaseSettings settings) : base(settings)
        {
        }
    }
}
