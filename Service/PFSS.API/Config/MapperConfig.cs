using AutoMapper;
using PFSS.API.RequestModels.Container;
using PFSS.API.RequestModels.Directory;
using PFSS.API.RequestModels.User;
using PFSS.Models;
using PFSS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PFSS.API.Config
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateViewModelMaps();
            CreateRequestModelMaps();
        }
        public void CreateViewModelMaps()
        {
            CreateMap<Container, ContainerViewModel>().ReverseMap();

            CreateMap<Directory, DirectoryViewModel>().ReverseMap();

            CreateMap<File, FileViewModel>().ReverseMap();

            CreateMap<User, LoginViewModel>().ReverseMap();
        }
        public void CreateRequestModelMaps()
        {
            CreateMap<Container, CreateContainerRequestModel>();

            CreateMap<Directory, CreateDirectoryRequestModel>();
            CreateMap<Directory, GetDirectoryChildsRequestModel>();

            CreateMap<User, CreateUserRequestModel>();
        }
    }
}
