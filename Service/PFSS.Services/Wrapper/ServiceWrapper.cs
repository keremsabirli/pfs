using PrivateFileStorageService;
using System;
using System.Collections.Generic;
using System.Text;

namespace PFSS.Services.Wrapper
{
    public class ServiceWrapper
    {
        public ServiceWrapper(IDatabaseSettings settings)
        {
            file = new Lazy<FileService>(() => new FileService(settings));
            directory = new Lazy<DirectoryService>(() => new DirectoryService(settings));
            user = new Lazy<UserService>(() => new UserService(settings));
        }
        private Lazy<FileService> file;
        private Lazy<DirectoryService> directory;
        private Lazy<UserService> user;

        public FileService File => file.Value;
        public DirectoryService Directory => directory.Value;
        public UserService User => user.Value;
    }
}
