namespace MediCaps.DataAccess.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using MediCaps.DataAccess.Entities; 
    

    internal sealed class Configuration : DbMigrationsConfiguration<MediCaps.DataAccess.MedicapsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MediCaps.DataAccess.MedicapsContext context)
        {
            var l1 = new Login() { UserName = "sourabh", Password = "srb123" };
            var l2 = new Login() { UserName = "pawan", Password = "pawan123" };
            var l3 = new Login() { UserName = "abhishek", Password = "abhi123" };
            var l4 = new Login() { UserName = "rajanvathi", Password = "rajan123" };
            var l5 = new Login() { UserName = "piyush", Password = "piyush123" };
            context.Logins.AddOrUpdate(m => m.UserName, l1, l2, l3, l4, l5);


            var p1 = new Pharmacy() { PsID = 101, PsName = "BlackBuck Pharmacy", Location = "Salman Nagar" };
            var p2 = new Pharmacy() { PsID = 102, PsName = "Ranvir Pharmacy", Location = "Katrina Nagar" };
            var p3 = new Pharmacy() { PsID = 103, PsName = "Jetha Pharmacy", Location = "Babita Nagar" };
            var p4 = new Pharmacy() { PsID = 104, PsName = "Thalaiva Pharmacy", Location = "Rajnikant Nagar" };
            var p5 = new Pharmacy() { PsID = 101, PsName = "Bablu Pharmacy", Location = "Mirzapur" };
            context.Pharmacies.AddOrUpdate(p => p.PsName, p1, p2, p3, p4, p5);

            var m1 = new Medicine() { MedicineId = 1001, MedicineName = "Remd3sivir", MedicinePrice =2800, Composition = "Tocilizumab", IsDelivable =false};
            var m2 = new Medicine() { MedicineId = 1002, MedicineName = "Paracetamol", MedicinePrice =50, Composition = "Aspirin", IsDelivable =true};
            var m3 = new Medicine() { MedicineId = 1003, MedicineName = "Ibuprofen", MedicinePrice =100, Composition = "Bromelain", IsDelivable =true};
            var m4 = new Medicine() { MedicineId = 1004, MedicineName = "Amphotericin-B", MedicinePrice =6800, Composition = "Fungisome", IsDelivable =false};
            var m5 = new Medicine() { MedicineId = 1005, MedicineName = "Sudafed", MedicinePrice =250, Composition = "Mucinex", IsDelivable =true};
            context.Medicines.AddOrUpdate(m => m.MedicineId, m1, m2, m3, m4, m5);

        }
    }
}
