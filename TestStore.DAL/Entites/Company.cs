using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStore.DAL.Entites.EntityBase;

namespace TestStore.Core.Entites
{
    public class Company: BaseEntity
    {
        public string NameCompany { get; set; }

        public virtual ICollection<RealEstatePersonCompany> RealEstatePersonCompanies { get; set; }

    }
}
