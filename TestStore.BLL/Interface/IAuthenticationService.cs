using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStore.Core.DTO;

namespace TestStore.BLL.Interface
{
    public interface IAuthenticationService
    {
        PersonDTO GetPersonById(int id);
        void AddPerson(PersonDTO item);
        bool ValidateUser(string email, string password);
        PersonDTO GetPersonByEmail(string email);
        void CreateRole(string roleName);
        bool IsUserInRole(string email, string roleName);
        string[] GetRolesForUser(string email);
        void Save();
    }
}
