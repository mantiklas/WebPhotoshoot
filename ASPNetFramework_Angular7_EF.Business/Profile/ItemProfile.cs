using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASPNetFramework_Angular7_EF.Business.Dtos;
using ASPNetFramework_Angular7_EF.Domain.Entities;


namespace ASPNetFramework_Angular7_EF.Business.Profile
{
   public  class ItemProfile : AutoMapper.Profile
    {
        public ItemProfile()
        {
            CreateMap<Item, ItemDto>()
               .ForMember(dto => dto.Id, from => from.MapFrom(src => src.Id))
               .ForMember(dto => dto.Name, from => from.MapFrom(src => src.Name));
              
        }
    }
}
