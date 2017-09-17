using System;
using TestStore.Core.Entites;
using TestStore.Core.Repository;

namespace TestStore.DAL.Repository
{
    public class EFUnitOfWork//: IUnitOfWork
    {
        //private TestStoreContext _testStoreContext;
        //private RealEstateRepository realEstateRepository;
        //private PersonRepository personRepository;
        //private CompanyRepository companyRepository;

        //public EFUnitOfWork(TestStoreContext connectionString)
        //{
        //    _testStoreContext = connectionString;
        //}

        //public IRepository<RealEstate> RealEstates
        //{
        //    get
        //    {
        //        if(realEstateRepository == null)
        //        {
        //            realEstateRepository = new RealEstateRepository(_testStoreContext);
        //        }
        //        return realEstateRepository;
        //    }
        //}

        //public IRepository<Person> Persons
        //{
        //    get
        //    {
        //        if (personRepository == null)
        //        {
        //            personRepository = new PersonRepository(_testStoreContext);
        //        }
        //        return personRepository;
        //    }
        //}

        //public IRepository<Company> Companies
        //{
        //    get
        //    {
        //        if (companyRepository == null)
        //        {
        //            companyRepository = new CompanyRepository(_testStoreContext);
        //        }
        //        return companyRepository;
        //    }
        //}

        //public void Save()
        //{
        //    _testStoreContext.SaveChanges();
        //}
    }
}
