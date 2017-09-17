using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TestStore.BLL.DTO;
using TestStore.Core.DTO;
using TestStore.Core.Entites;
using TestStore.Core.Repository;
using TestStore.DAL.Interface;

namespace TestStore.DAL.Repository
{
    public class PersonRepository : IPersonRepository
    {
        private TestStoreContext _testStoreContext;

        public PersonRepository(TestStoreContext testStoreContext)
        {
            _testStoreContext = testStoreContext;
        }

        public IEnumerable<PersonDTO> GetAllPerson()
        {
            var allPerson = _testStoreContext.Persons.ToList();
            List<PersonDTO> personDtos = new List<PersonDTO>();
            foreach (var item in allPerson)
            {
                personDtos.Add(new PersonDTO()
                {
                    Id = item.Id,
                    FistName = item.FistName,
                    LastName = item.LastName
                });
            }
            return personDtos;
        }

        public PersonDTO GetPersonById(int id)
        {
            var person = _testStoreContext.Persons.Find(id);
            PersonDTO personDto = new PersonDTO()
            {
                Id = person.Id,
                FistName = person.FistName,
                LastName = person.LastName
           };

            return personDto;
        }


        //public IEnumerable<Person> Find(Func<Person, bool> predicate)
        //{
        //    return _testStoreContext.Persons.Where(predicate).ToList();
        //}

        //public void Add(Person item)
        //{
        //    _testStoreContext.Persons.Add(item);
        //}

        //public void Update(Person item)
        //{
        //    _testStoreContext.Entry(item).State = EntityState.Modified;
        //}

        //public void Delete(int id)
        //{
        //    Person person = _testStoreContext.Persons.Find(id);
        //    if (person != null)
        //        _testStoreContext.Persons.Remove(person);
        //}
    }
}
