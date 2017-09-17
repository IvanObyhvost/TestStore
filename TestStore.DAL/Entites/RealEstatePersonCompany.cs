using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStore.DAL.Entites.EntityBase;

namespace TestStore.Core.Entites
{
    public class RealEstatePersonCompany: BaseEntity
    {
        
        public int RealEstateId { get; set; }
        public RealEstate RealEstate { get; set; } 
        public int PersonId { get; set; }
        public Person Persons { get; set; } 
        public int CompanyId { get; set; }
        public Company Company { get; set; }


    }
}
