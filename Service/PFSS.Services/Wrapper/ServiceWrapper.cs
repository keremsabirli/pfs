using PrivateFileStorageService;
using System;
using System.Collections.Generic;
using System.Text;

namespace PFSS.Services.Wrapper
{
    public class ServiceWrapper
    {
        public ServiceWrapper(IDatabaseSettings settings,IJwtSettings jwtSettings)
        {
            file = new Lazy<FileService>(() => new FileService(settings));
            directory = new Lazy<DirectoryService>(() => new DirectoryService(settings));
            user = new Lazy<UserService>(() => new UserService(settings));
            loginService = new Lazy<LoginService>(() => new LoginService(settings,jwtSettings));
        }
        private Lazy<FileService> file;
        private Lazy<DirectoryService> directory;
        private Lazy<UserService> user;
        private Lazy<LoginService> loginService;

        public FileService File => file.Value;
        public DirectoryService Directory => directory.Value;
        public UserService User => user.Value;
        public LoginService LoginService => loginService.Value;
    }
}
