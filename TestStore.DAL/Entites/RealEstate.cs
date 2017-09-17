using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using TestStore.Core.Enums;
using TestStore.DAL.Entites;
using TestStore.DAL.Entites.EntityBase;

namespace TestStore.Core.Entites
{
    public class RealEstate: BaseEntity
    {
        public int RealEstateID { get; set; }
        public int Price { get; set; }
        public string Postcode { get; set; }
        public string Location { get; set; }
        public string Area { get; set; }
        public bool SSTC { get; set; }
        public byte Bedrooms { get; set; }
        public byte LivingRooms { get; set; }
        public byte Bathrooms { get; set; }
        public byte Shower { get; set; }
        public bool Garden { get; set; }
        public bool Parking { get; set; }
        public string ImageMimeType { get; set; }
        public string ImagePath { get; set; }
        public string SalesCorner { get; set; }
        public string Tenure { get; set; }
        public string PropertyStatus { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public virtual ICollection<RealEstatePersonCompany> RealEstatePersonCompanies { get; set; }
        public Description Description { get; set; }

        public virtual ICollection<PhotoForGallery> PhotoForGalleries { get; set; }

    }
}
