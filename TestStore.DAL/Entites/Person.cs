using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStore.DAL.Entites;
using TestStore.DAL.Entites.EntityBase;

namespace TestStore.Core.Entites
{
    public class Person: BaseEntity
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FistName { get; set; }
        public string LastName { get; set; }
        public DateTime CreationDate { get; set; }
        public virtual ICollection<PersonRole> PersonRole { get; set; }
        public virtual ICollection<RealEstatePersonCompany> RealEstatesPersonCompanies { get; set; } 

    }
}
