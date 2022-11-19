using AutoMapper;
using Model;
using Model.DTOs;
using Model.Identity;
using Service.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Api.Config
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Client, ClientDto>();
            CreateMap<DataCollection<Client>, DataCollection<ClientDto>>();

            CreateMap<Product, ProductDto>();
            CreateMap<DataCollection<Product>, DataCollection<ProductDto>>();

            CreateMap<Order, OrderDto>();
            CreateMap<OrderDetail, OrderDetailDto>();
            CreateMap<DataCollection<Order>, DataCollection<OrderDto>>();

            CreateMap<Order, OrderCreateDto>();
            CreateMap<OrderDetail, OrderDetailCreateDto>();

            CreateMap<AplicationUser, AplicationUserDto>()
                .ForMember(
                    to => to.Roles,
                    from => from.MapFrom(
                            source => source.UserRoles.Select(x => x.Role.Name).ToList()
                        )
                );
            CreateMap<DataCollection<AplicationUser>, DataCollection<AplicationUserDto>>();
        }
    }
}
