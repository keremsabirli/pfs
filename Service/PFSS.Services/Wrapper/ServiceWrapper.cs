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
            container = new Lazy<ContainerService>(() => new ContainerService(settings));
        }
        private Lazy<FileService> file;
        private Lazy<DirectoryService> directory;
        private Lazy<UserService> user;
        private Lazy<ContainerService> container;

        public FileService File => file.Value;
        public DirectoryService Directory => directory.Value;
        public UserService User => user.Value;
        public ContainerService Container => container.Value;
    }
}
