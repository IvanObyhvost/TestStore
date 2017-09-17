using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStore.Core.Entites;
using TestStore.DAL.Entites.EntityBase;

namespace TestStore.DAL.Entites
{
    public class Description: BaseEntity
    {
        public int RealEstateId { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public RealEstate RealEstate { get; set; }
    }
}
