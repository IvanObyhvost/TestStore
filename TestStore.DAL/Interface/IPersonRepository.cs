using System.Collections.Generic;
using TestStore.BLL.DTO;
using TestStore.Core.DTO;

namespace TestStore.DAL.Interface
{
    public interface IPersonRepository
    {
        IEnumerable<PersonDTO> GetAllPerson();
        PersonDTO GetPersonById(int id);
    }
}