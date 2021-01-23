using PFSS.API.RequestModels.Directory;
using PFSS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PFSS.API.Config
{
    public class MapperConfig : AutoMapper.Profile
    {
        public MapperConfig()
        {
            MapRequestModels();
            MapViewModels();
        }
        public void MapRequestModels()
        {
            CreateMap<CreateDirectoryRequestModel, Models.Directory>();
        }
        public void MapViewModels()
        {
            CreateMap<Models.Directory, DirectoryViewModel>();
        }
    }
}
