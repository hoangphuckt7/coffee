using AutoMapper;
using Data.Entities;
using Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.MapperProfiles
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Floor, DescriptionViewModel>().ReverseMap();
            CreateMap<Category, DescriptionViewModel>().ReverseMap();
            CreateMap<Table, TableViewModel>()
                .ForMember(f => f.Floor, map => map.MapFrom(f => f.Floor));

            //Item
            CreateMap<ItemAddModel, Item>()
                .ForMember(f => f.Id, map => map.Ignore())
                .ForMember(f => f.DateCreated, map => map.Ignore());

            CreateMap<Item, ItemViewModel>().ForMember(f => f.Images, map => map.Ignore());

            //Pair
            CreateMap<SystemSetting, PairModel>()
                .ForMember(f => f.Key, map => map.MapFrom(f => f.Key))
                .ForMember(f => f.Value, map => map.MapFrom(f => f.Value))
                .ReverseMap();

            CreateMap<OrderCreateModel, OrderViewModel>()
                .ForMember(f => f.Id, map => map.Ignore())
                .ReverseMap();
        }
    }
}
