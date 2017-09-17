using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStore.Core.DTO;

namespace TestStore.DAL.Interface
{
    public interface IAuthenticationRepository
    {
        PersonDTO GetPersonById(int id);
        void AddPerson(PersonDTO item);
        PersonDTO GetPersonByEmail(string email);
        void CreateRole(string roleName);
        RoleDTO GetRoleById(int id);
        void Save();
    }
}
