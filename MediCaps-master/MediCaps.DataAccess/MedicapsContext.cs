using System;
using System.Data.Entity;
using System.Linq;
using MediCaps.DataAccess.Entities;

namespace MediCaps.DataAccess
{
    public class MedicapsContext : DbContext
    {

        public MedicapsContext()
            : base("name=MedicapsContext")
        {
        }

        public virtual DbSet<Login> Logins { get; set; }

        public virtual DbSet<Registration> Registrations { get; set; }



        public virtual DbSet<Medicine> Medicines { get; set; }

        public virtual DbSet<Pharmacy> Pharmacies { get; set; }

        public virtual DbSet<Cart> Carts { get; set; }

        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderItem>OrderItems {get; set;}

    }

   
}