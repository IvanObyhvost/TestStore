using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStore.Core.Entites;
using TestStore.DAL.Entites;
using TestStore.DAL.Entites.EntityBase;

namespace TestStore.DAL
{
    public class TestStoreContext : DbContext
    {
        public TestStoreContext() : base("DBConnection")
        {
        }

        public DbSet<RealEstate> RealEstates { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Description> Descriptions { get; set; }
        public DbSet<RealEstatePersonCompany> RealEstatePersonCompanies { get; set; }
        public DbSet<PersonRole> PersonsRoles { get; set; }
        public DbSet<PhotoForGallery> PhotoForGalleries { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RealEstate>()
                .HasMany(p => p.RealEstatePersonCompanies)
                .WithRequired(b => b.RealEstate)
                .HasForeignKey(k => k.RealEstateId);

            modelBuilder.Entity<Person>()
                .HasMany(p => p.RealEstatesPersonCompanies)
                .WithRequired(b => b.Persons)
                .HasForeignKey(k => k.PersonId);

            modelBuilder.Entity<Company>()
                .HasMany(p => p.RealEstatePersonCompanies)
                .WithRequired(b => b.Company)
                .HasForeignKey(k => k.CompanyId);

            modelBuilder.Entity<Description>()
                .HasRequired(p => p.RealEstate)
                .WithOptional(p => p.Description);

            modelBuilder.Entity<Person>()
                .HasMany(p => p.PersonRole)
                .WithRequired(p => p.Person)
                .HasForeignKey(p => p.PersonId);

            modelBuilder.Entity<Role>()
                .HasMany(p => p.PersonRole)
                .WithRequired(p => p.Role)
                .HasForeignKey(p => p.RolesId);

            modelBuilder.Entity<PhotoForGallery>()
                .HasRequired(p => p.RealEstates)
                .WithMany(p => p.PhotoForGalleries)
                .HasForeignKey(p => p.RealEstateId);
        }
    }
}
