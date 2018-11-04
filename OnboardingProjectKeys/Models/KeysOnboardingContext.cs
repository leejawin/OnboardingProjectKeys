using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OnboardingProjectKeys.Models
{
    public class KeysOnboardingContext : DbContext
    {
        public KeysOnboardingContext() : base("KeysOnboardingContext")
        {
            //Database.SetInitializer<KeysOnboardingContext>(new CreateDatabaseIfNotExists<KeysOnboardingContext>());

            Database.SetInitializer<KeysOnboardingContext>(new DropCreateDatabaseIfModelChanges<KeysOnboardingContext>());
            //Database.SetInitializer<KeysOnboardingContext>(new DropCreateDatabaseAlways<KeysOnboardingContext>());
            //Database.SetInitializer<KeysOnboardingContext>(new DBInitializer());
        }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Store> Store { get; set; }
        public DbSet<ProductSold> ProductSold { get; set; }

    }
}