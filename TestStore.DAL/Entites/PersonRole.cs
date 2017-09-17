using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStore.Core.Entites;
using TestStore.DAL.Entites.EntityBase;

namespace TestStore.DAL.Entites
{
    public class PersonRole: BaseEntity
    {
        public int PersonId { get; set; }
        public int RolesId { get; set; }
        public Person Person { get; set; }
        public Role Role { get; set; }
    }
}
