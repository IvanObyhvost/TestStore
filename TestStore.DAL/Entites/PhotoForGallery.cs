using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStore.Core.Entites;
using TestStore.DAL.Entites.EntityBase;

namespace TestStore.DAL.Entites
{
    public class PhotoForGallery: BaseEntity
    {
        public int RealEstateId { get; set; }
        public string UrlImage { get; set; }
        public RealEstate RealEstates { get; set; } 
    }
}
