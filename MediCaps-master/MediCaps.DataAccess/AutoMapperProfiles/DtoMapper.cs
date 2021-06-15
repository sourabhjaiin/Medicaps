using AutoMapper;
using MediCaps.DataAccess.DTOs;
using MediCaps.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediCaps.DataAccess.AutoMapperProfiles
{
    public class DtoMapper : Profile
    {
        public DtoMapper()
        {
            CreateMap<Login, LoginDto>().ReverseMap();
        }
    }
}
