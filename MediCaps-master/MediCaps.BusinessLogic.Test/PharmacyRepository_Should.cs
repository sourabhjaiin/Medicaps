using MediCaps.DataAccess.Entities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediCaps.BusinessLogic.Test
{
    [TestFixture]
    public class PharmacyRepository_Should
    {
        private PharmacyRepository pharmacy;
        [OneTimeSetUp]
        public void Init()
        {
            pharmacy = new PharmacyRepository();
        }
        [OneTimeTearDown]
        public void Cleanup()
        {
            pharmacy.Dispose();
        }
        [Test]
        public void ReturnAllPharmacy()
        {
            var phar = pharmacy.GetPharamcy();
            CollectionAssert.IsNotEmpty(phar);
        }
        //[Test]
        //public void AddPharmacy()
        //{
        //    var phar = new Pharmacy();
        //    phar.PsID = 101;
        //    phar.PsName = "BlackBuck Pharmacy";
        //    phar.Location = "Salman Nagar";
        //    phar.Pincode = 455001;
        //    var result = pharmacy.Add(phar);
        //    Assert.AreEqual(true, result);
        //}
        //[Test]
        //public void DeleteThePharmacy()
        //{
        //    int id = 101;
        //    var result = pharmacy.PharDelete(id);
        //    Assert.AreEqual(true,result);
        //}
    }
}