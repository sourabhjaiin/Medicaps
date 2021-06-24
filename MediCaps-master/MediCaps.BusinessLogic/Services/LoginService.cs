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
  
        readonly LoginRepo repository;

        public LoginService()
        {
            this.repository = new LoginRepo();
        }

      

        public bool AddUser(LoginDto dto)
        {
            var Obj = Mapper.Map<Login>(dto);
            return repository.AddUser(Obj);
        }

        public LoginDto getUser(int Id)
        {
            var Obj = repository.getUser(Id);
            var Dto = Mapper.Map<LoginDto>(Obj);
            return Dto;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
