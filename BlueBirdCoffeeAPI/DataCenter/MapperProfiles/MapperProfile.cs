using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace DataCenter.MapperProfiles
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Collections.Bill, Data.Entities.Bill>()
                .ForMember(f => f.Id, map => map.MapFrom(m => m.Id))
                .ForMember(f => f.DateCreated, map => map.MapFrom(m => DateTime.SpecifyKind(m.DateCreated, DateTimeKind.Unspecified)))
                .ForMember(f => f.DateUpdated, map => map.MapFrom(m => DateTime.SpecifyKind(m.DateUpdated, DateTimeKind.Unspecified)))
                .ReverseMap();
            CreateMap<Data.Entities.BillOrder, Collections.BillOrder>()
                .ReverseMap();
            CreateMap<Collections.Category, Data.Entities.Category>()
                .ForMember(f => f.DateCreated, map => map.MapFrom(m => DateTime.SpecifyKind(m.DateCreated, DateTimeKind.Unspecified)))
                .ForMember(f => f.DateUpdated, map => map.MapFrom(m => DateTime.SpecifyKind(m.DateUpdated, DateTimeKind.Unspecified)))
                .ReverseMap();
            CreateMap<Collections.Coupon, Data.Entities.Coupon>()
                .ReverseMap();
            CreateMap<Collections.Floor, Data.Entities.Floor>()
                .ForMember(f => f.DateCreated, map => map.MapFrom(m => DateTime.SpecifyKind(m.DateCreated, DateTimeKind.Unspecified)))
                .ForMember(f => f.DateUpdated, map => map.MapFrom(m => DateTime.SpecifyKind(m.DateUpdated, DateTimeKind.Unspecified)))
                .ReverseMap();
            CreateMap<Collections.Item, Data.Entities.Item>()
                .ForMember(f => f.DateCreated, map => map.MapFrom(m => DateTime.SpecifyKind(m.DateCreated, DateTimeKind.Unspecified)))
                .ForMember(f => f.DateUpdated, map => map.MapFrom(m => DateTime.SpecifyKind(m.DateUpdated, DateTimeKind.Unspecified)))
                .ReverseMap();
            CreateMap<Collections.ItemImage, Data.Entities.ItemImage>()
                .ForMember(f => f.DateCreated, map => map.MapFrom(m => DateTime.SpecifyKind(m.DateCreated, DateTimeKind.Unspecified)))
                .ForMember(f => f.DateUpdated, map => map.MapFrom(m => DateTime.SpecifyKind(m.DateUpdated, DateTimeKind.Unspecified)))
                .ReverseMap();
            CreateMap<Collections.Order, Data.Entities.Order>()
                .ForMember(f => f.DateCreated, map => map.MapFrom(m => DateTime.SpecifyKind(m.DateCreated, DateTimeKind.Unspecified)))
                .ForMember(f => f.DateUpdated, map => map.MapFrom(m => DateTime.SpecifyKind(m.DateUpdated, DateTimeKind.Unspecified)))
                .ReverseMap();
            CreateMap<Collections.OrderDetail, Data.Entities.OrderDetail>()
                .ForMember(f => f.DateUpdated, map => map.MapFrom(m => DateTime.SpecifyKind(m.DateUpdated, DateTimeKind.Unspecified)))
                .ReverseMap();
            CreateMap<Data.Entities.SystemSetting, Collections.SystemSetting>().ReverseMap();
            CreateMap<Collections.Table, Data.Entities.Table>()
                .ForMember(f => f.DateCreated, map => map.MapFrom(m => DateTime.SpecifyKind(m.DateCreated, DateTimeKind.Unspecified)))
                .ForMember(f => f.DateUpdated, map => map.MapFrom(m => DateTime.SpecifyKind(m.DateUpdated, DateTimeKind.Unspecified)))
                .ReverseMap();
            CreateMap<Collections.User, Data.Entities.User>()
                .ForMember(f => f.DateCreated, map => map.MapFrom(m => DateTime.SpecifyKind(m.DateCreated, DateTimeKind.Unspecified)))
                .ForMember(f => f.DateUpdated, map => map.MapFrom(m => DateTime.SpecifyKind(m.DateUpdated, DateTimeKind.Unspecified)))
                .ReverseMap();
            CreateMap<IdentityRole, Collections.Role>().ReverseMap();
            CreateMap<IdentityUserRole<string>, Collections.UserRole>().ReverseMap();
        }
    }
}
