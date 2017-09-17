using System;
using TestStore.Core.Entites;

namespace TestStore.Core.Repository
{
    public interface IUnitOfWork
    {
        IRepository<RealEstate> RealEstates { get; }
        IRepository<Person> Persons { get; }
        IRepository<Company> Companies { get; } 
        void Save();
    }
}