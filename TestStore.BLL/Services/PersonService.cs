using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStore.BLL.DTO;
using TestStore.BLL.Interface;
using TestStore.Core.DTO;
using TestStore.DAL.Interface;

namespace TestStore.BLL.Services
{
    public class PersonService: IPersonService
    {
        IPersonRepository _personRepository;

        public PersonService(IPersonRepository repository)
        {
            _personRepository = repository;
        }
        public IEnumerable<PersonDTO> GetAllPerson()
        {
            return _personRepository.GetAllPerson();
        }

        public PersonDTO GetPersonById(int id)
        {
            return _personRepository.GetPersonById(id);
        }
    }
}
