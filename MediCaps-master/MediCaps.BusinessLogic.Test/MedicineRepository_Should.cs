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
    public class MedicineRepository_Should
    {
        private MedicineRepository medicine;
        [OneTimeSetUp]
        public void Init()
        {
            medicine = new MedicineRepository();
        }
        [OneTimeTearDown]
        public void Cleanup()
        {
            medicine.Dispose();
        }
        [Test]
        public void ReturnMedicines()
        {
            var med = medicine.GetMed();
            CollectionAssert.IsNotEmpty(med);
        }
        [Test]
        public void AddMedicine()
        {
            var med = new Medicine();
            med.MedicineName = "Remdesivir";
            med.MedicinePrice = 2800;
            med.Composition = "Tocilizumab";
            med.IsDelivable = false;
            var result = medicine.Add(med);
            Assert.AreEqual(false, result);
        }
        [Test]
        public void DeleteTheMedicine()
        {
            int id = 2;
            var result = medicine.MedDelete(id);
            Assert.AreEqual(true, result);
        }
    }
}