using AutoMapper;
using MediCaps.DataAccess;
using MediCaps.DataAccess.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediCaps.BusinessLogic.Repos;

namespace MediCaps.BusinessLogic.Services
{
    public class LoginService
    {
        readonly IMapper mapper;
        readonly LoginRepo repository;

        public LoginService()
        {
        }

        public LoginService(IMapper mapper)
        {
            this.repository = new LoginRepo();
            this.mapper = mapper;
        }

        public bool AddUser(LoginDto dto)
        {
            var Obj = mapper.Map<Login>(dto);
            return repository.AddUser(Obj);
        }

        public LoginDto getUser(int Id)
        {
            var Obj = repository.getUser(Id);
            var Dto = mapper.Map<LoginDto>(Obj);
            return Dto;
        }
    }
}
