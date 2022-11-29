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
            CreateMap<DescriptionModel, Table>().ReverseMap();
            CreateMap<TableViewModel, Table>();
            CreateMap<TableUpdateModel, Table>().ReverseMap();
            CreateMap<Table, TableViewModel>()
                .ForMember(f => f.Floor, map => map.MapFrom(f => f.Floor));

            //Item
            CreateMap<ItemAddModel, Item>()
                .ForMember(f => f.Id, map => map.Ignore())
                .ForMember(f => f.DateCreated, map => map.Ignore());

            CreateMap<Item, ItemViewModel>().ForMember(f => f.Images, map => map.Ignore());

            CreateMap<Item, ItemStatisticModel>()
                .ForMember(f => f.Selled, map => map.Ignore())
                .ForMember(f => f.Total, map => map.Ignore())
                .ForMember(f => f.Images, map => map.Ignore());

            //Pair
            CreateMap<SystemSetting, PairModel>()
                .ForMember(f => f.Key, map => map.MapFrom(f => f.Key))
                .ForMember(f => f.Value, map => map.MapFrom(f => f.Value))
                .ReverseMap();

            //Oders
            CreateMap<Order, OrderViewModel>()
                .ReverseMap();

            CreateMap<OrderDetail, OrderDetailViewModel>()
                .ReverseMap();

            //Coupon
            CreateMap<Coupon, CouponAddModel>()
                .ReverseMap();

            CreateMap<Coupon, CouponViewModel>()
                .ReverseMap();

            CreateMap<Coupon, CouponUseableModel>()
                .ReverseMap();

            //Statistic
            CreateMap<Bill, BillStatisticModel>()
                .ForMember(f => f.Casher, map => map.MapFrom(m => m.Casher))
                .ForMember(f => f.Customer, map => map.MapFrom(m => m.Customer))
               .ReverseMap();

            CreateMap<Order, OrderStatisticModel>()
                .ForMember(f => f.Table, map => map.MapFrom(m => m.Table))
                .ForMember(f => f.Employee, map => map.MapFrom(m => m.Employee))
                .ForMember(f => f.Bartender, map => map.MapFrom(m => m.Bartender))
                .ForMember(f => f.UserRejected, map => map.MapFrom(m => m.UserRejected))
                .ForMember(f => f.OrderDetails, map => map.MapFrom(m => m.OrderDetails))
               .ReverseMap();

            CreateMap<OrderDetail, OrderDetailStatisticModel>()
                .ForMember(f => f.Item, map => map.MapFrom(m => m.Item))
               .ReverseMap();

            CreateMap<User, BaseStringModel>()
            .ForMember(f => f.Description, map => map.MapFrom(m => m.Fullname))
            .ReverseMap();

            CreateMap<Table, DescriptionViewModel>().ReverseMap();
            CreateMap<Item, DescriptionViewModel>()
                .ForMember(f => f.Description, map => map.MapFrom(m => m.Name))
                .ReverseMap();
        }
    }
}
