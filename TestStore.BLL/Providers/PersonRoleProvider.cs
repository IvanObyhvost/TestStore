using System;
using System.Web.Security;
using TestStore.BLL.Interface;
using TestStore.Core.DTO;
using TestStore.DAL;
using TestStore.DAL.Entites;
using TestStore.DAL.Repository;

namespace TestStore.BLL.Providers
{
    public class PersonRoleProvider : RoleProvider
    {
        private AuthenticationRepository _authenticationRepository;
        private TestStoreContext _testStoreContext = new TestStoreContext();

        public PersonRoleProvider()
        {
            _authenticationRepository = new AuthenticationRepository(_testStoreContext);
        }
        public override string[] GetRolesForUser(string email)
        {
           string[] role = new string[] {};
            try
            {
                PersonDTO person = _authenticationRepository.GetPersonByEmail(email);
                if(person != null)
                {
                    var personRole = _authenticationRepository.GetRoleById(person.Id);
                    if(personRole != null)
                    {
                        role = new string[] {personRole.Name};
                    }
                }
            }
            catch
            {
                role = new string[] { };
            }
            return role;
        }
        public override void CreateRole(string roleName)
        {
            _authenticationRepository.CreateRole(roleName);
        }
        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }
        public override bool IsUserInRole(string email, string roleName)
        {
            bool result = false;
            try
            {
                PersonDTO person = _authenticationRepository.GetPersonByEmail(email);
                if (person != null)
                {
                    RoleDTO PersonRole = _authenticationRepository.GetRoleById(person.Id);
                    if (PersonRole != null && PersonRole.Name == roleName)
                    {
                        result = true;
                    }
                }
            }
            catch
            {
                result = false;
            }

            return result;
        }

        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }



        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}