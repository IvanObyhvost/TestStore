using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStore.Core.DTO;
using TestStore.Core.Entites;
using TestStore.DAL.Entites;
using TestStore.DAL.Entites.EntityBase;
using TestStore.DAL.Interface;

namespace TestStore.DAL.Repository
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private TestStoreContext _testStoreContext;
        public AuthenticationRepository(TestStoreContext testStore)
        {
            _testStoreContext = testStore;
        }

        public PersonDTO GetPersonById(int id)
        {
            var person = _testStoreContext.Persons.Find(id);
            PersonDTO personDto = new PersonDTO()
            {
                Email = person.Email,
                Password = person.Password,
                FistName = person.FistName,
                LastName = person.LastName,
                CreationDate = person.CreationDate
            };
            return personDto;
        }

        public void AddPerson(PersonDTO item)
        {
            Person person = new Person()
            {
                Email = item.Email,
                Password = item.Password,
                FistName = item.FistName,
                LastName = item.LastName,
                CreationDate = DateTime.Now
            };

            var role = _testStoreContext.Roles.Find(2);
            PersonRole personRole = new PersonRole()
            {
                PersonId = person.Id,
                RolesId = role.Id
            };

            _testStoreContext.Persons.Add(person);
            _testStoreContext.PersonsRoles.Add(personRole);
        }
        public void Save()
        {
            try
            { _testStoreContext.SaveChanges(); }
            catch
            {

            }
            
        }

        public PersonDTO GetPersonByEmail(string email)
        {
            var person = (from u in _testStoreContext.Persons
                          where u.Email == email
                          select u).FirstOrDefault();
            if (person != null)
            {
                PersonDTO personDto = new PersonDTO()
                {
                    Id = person.Id,
                    Email = person.Email,
                    Password = person.Password,
                    FistName = person.FistName,
                    LastName = person.LastName,
                    CreationDate = person.CreationDate
                };

                return personDto;
            }
            else
                return null;
        }

        public void CreateRole(string roleName)
        {
            Role role = new Role()
            {
                Name = roleName
            };
            _testStoreContext.Roles.Add(role);
        }


        public RoleDTO GetRoleById(int id)
        {
            try
            {
                var roleId =(from u in _testStoreContext.PersonsRoles
                            where u.PersonId == id
                            select u).FirstOrDefault();
                if(roleId != null)
                {
                    var role = _testStoreContext.Roles.Find(roleId.RolesId);
                    RoleDTO roleDto = new RoleDTO()
                    {
                        Name = role.Name
                    };
                    return roleDto;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
            
        }
    }
}