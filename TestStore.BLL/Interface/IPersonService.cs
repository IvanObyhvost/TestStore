using System.Collections.Generic;
using TestStore.BLL.DTO;
using TestStore.Core.DTO;

namespace TestStore.BLL.Interface
{
    public interface IPersonService
    {
        IEnumerable<PersonDTO> GetAllPerson();
        PersonDTO GetPersonById(int id); 
    }
}