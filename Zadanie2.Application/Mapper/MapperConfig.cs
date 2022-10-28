using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadanie2.Core;

namespace Zadanie2.Application.Mapper
{
    public class MapperConfig:Profile
    {
        public MapperConfig()
        {
            CreateMap<Recipient, AddRecipientDTO>().ReverseMap(); 
            CreateMap<Recipient, EditRecipientDTO>().ReverseMap(); 
            CreateMap<Recipient, GetRecipientDTO>().ReverseMap(); 
            CreateMap<Package, GetListPackageDTO>().ReverseMap(); 
            CreateMap<Package, DetailsPackageDTO>().ReverseMap(); 
            CreateMap<Package, AddPackageDTO>().ReverseMap(); 
            CreateMap<Package, EditPackageDTO>().ReverseMap(); 
        }
    }
}
