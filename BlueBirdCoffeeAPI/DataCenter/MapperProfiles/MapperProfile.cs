using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace DataCenter.MapperProfiles
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Collections.Bill, Data.Entities.Bill>().ForMember(f => f.Id, map => map.MapFrom(m => m.Id)).ReverseMap();
            CreateMap<Data.Entities.BillOrder, Collections.BillOrder>().ReverseMap();
            CreateMap<Data.Entities.Category, Collections.Category>().ReverseMap();
            CreateMap<Data.Entities.Coupon, Collections.Coupon>().ReverseMap();
            CreateMap<Data.Entities.Floor, Collections.Floor>().ReverseMap();
            CreateMap<Data.Entities.Item, Collections.Item>().ReverseMap();
            CreateMap<Data.Entities.ItemImage, Collections.ItemImage>().ReverseMap();
            CreateMap<Data.Entities.Order, Collections.Order>().ReverseMap();
            CreateMap<Data.Entities.OrderDetail, Collections.OrderDetail>().ReverseMap();
            CreateMap<Data.Entities.SystemSetting, Collections.SystemSetting>().ReverseMap();
            CreateMap<Data.Entities.Table, Collections.Table>().ReverseMap();
            CreateMap<Data.Entities.User, Collections.User>().ReverseMap();
            CreateMap<IdentityRole, Collections.Role>().ReverseMap();
            CreateMap<IdentityUserRole<string>, Collections.UserRole>().ReverseMap();
        }
    }
}
