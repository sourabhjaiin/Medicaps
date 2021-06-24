using MediCaps.BusinessLogic.Repos;
using MediCaps.BusinessLogic.Services;
using MediCaps.DataAccess;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediCaps.BusinessLogic.Test
{
    [TestFixture]
    public class LoginService_Should : LoginService
    {
        private LoginRepo loginRepo;
        private LoginService service;
        [OneTimeSetUp]
        public void Init()
        {
            loginRepo = new LoginRepo();
            service = new LoginService();
        }
        [OneTimeTearDown]
        public void Cleanup()
        {
            service.Dispose();
            loginRepo.Dispose();
        }
        [Test]
        public void ReturnAllUsers()
        {
            var user = loginRepo.GetAll();
            CollectionAssert.IsNotEmpty(user);
        }
        [Test]
        public void ValidateTheAdmin()
        {
            var log = new Login();
            log.UserName = "sourabh";
            log.Password = "srb123";
            log.Email = "srb@gmail.com";
            log.Phone = "9617415145";
            log.Confirmed = true;
            log.UserType = UserType.Admin;
            var result = loginRepo.ValidatedAdmin(log);
            Assert.AreEqual(true, result);
        }
        [Test]
        public void AddTheUser()
        {
            var log = new Login();
            log.UserName = "rajaaa";
            log.Password = "raja123";
            log.Email = "raja@gmail.com";
            log.Phone = "9617416473";
            log.Confirmed = true;
            log.UserType = UserType.User;
            var result = loginRepo.AddUser(log);
            Assert.AreEqual(true, result);
        }
        //[Test]
        //public void CheckUser()
        //{
        //    User x = service. ("sourabh", "srb123");
        //    User y = service.CheckUser("sourabh", "");
        //    Assert.AreEqual("", x);
        //    Assert.AreEqual("", y);
        //}
        //[Test]
        //public void Return_All_Users()
        //{
        //    var user = service.getUser();
        //    CollectionAssert.IsNotEmpty();

        //}
    }
}