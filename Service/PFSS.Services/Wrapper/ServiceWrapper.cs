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
        }
        private Lazy<FileService> file;
        private Lazy<DirectoryService> directory;

        public FileService File => file.Value;
        public DirectoryService Directory => directory.Value;
    }
}
