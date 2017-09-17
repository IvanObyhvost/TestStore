using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStore.BLL.Interface;
using TestStore.Core.DTO;
using TestStore.DAL.Interface;

namespace TestStore.BLL.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        IAuthenticationRepository _authenticationRepository;

        public AuthenticationService(IAuthenticationRepository repository)
        {
            _authenticationRepository = repository;
        }
        public PersonDTO GetPersonById(int id)
        {
            return _authenticationRepository.GetPersonById(id);
        }

        public void AddPerson(PersonDTO item)
        {
            _authenticationRepository.AddPerson(item);
            Save();
        }

        public void Save()
        {
            _authenticationRepository.Save();
        }


        public bool ValidateUser(string email, string password)
        {
            bool isValid = false;
            try
            {
                var personEmail = _authenticationRepository.GetPersonByEmail(email);
                if (personEmail != null && personEmail.Password == password)
                {
                    isValid = true;
                }
            }
            catch
            {
                isValid = false;
            }
            return isValid;
        }
        public PersonDTO GetPersonByEmail(string email)
        {
            return _authenticationRepository.GetPersonByEmail(email);
        }
        
        public void CreateRole(string roleName)
        {
            _authenticationRepository.CreateRole(roleName);
        }

        public bool IsUserInRole(string email, string roleName)
        {
            bool result = false;
            try
            {
                PersonDTO person = _authenticationRepository.GetPersonByEmail(email);
                if (person != null)
                {
                    var PersonRole = _authenticationRepository.GetRoleById(person.Id);
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
        
        public string[] GetRolesForUser(string email)
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
}
}
