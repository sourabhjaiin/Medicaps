using AutoMapper;
using MediCaps.DataAccess.DTOs;
using MediCaps.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediCaps.DataAccess.AutoMapperProfiles
{
    public class DtoMapper 
    {
        public static void  Map()
        {
            Mapper.Initialize(config => {
                config.CreateMap<LoginDto, Login>().ReverseMap();
                config.CreateMap<Medicine, ProductRequest>().ReverseMap();
                config.CreateMap<Medicine, ProductResponse>().ReverseMap();
                config.CreateMap<Pharmacy, PharmacyRequest>().ReverseMap();
                config.CreateMap<Pharmacy, PharmacyResponse>().ReverseMap();
                config.CreateMap<Login, LoginResponse>().ReverseMap();
            });
            
        }
    }
}
