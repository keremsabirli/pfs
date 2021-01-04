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
        }
        private Lazy<FileService> file;

        public FileService File => file.Value;
    }
}
