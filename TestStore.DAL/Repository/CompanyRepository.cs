using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStore.Core.Entites;
using TestStore.Core.Repository;

namespace TestStore.DAL.Repository
{
    public class CompanyRepository: IRepository<Company>
    {
        private TestStoreContext _testStoreContext;

        public CompanyRepository(TestStoreContext testStoreContext)
        {
            _testStoreContext = testStoreContext;
        }

        public IEnumerable<Company> GetAll()
        {
            return _testStoreContext.Companies;
        }

        public Company Get(int id)
        {
            return _testStoreContext.Companies.Find(id);
        }

        public IEnumerable<Company> Find(Func<Company, bool> predicate)
        {
            return _testStoreContext.Companies.Where(predicate).ToList();
        }

        public void Add(Company item)
        {
            _testStoreContext.Companies.Add(item);
        }

        public void Update(Company item)
        {
            _testStoreContext.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Company company = _testStoreContext.Companies.Find(id);
            if (company != null)
                _testStoreContext.Companies.Remove(company);
        }
    }
}
