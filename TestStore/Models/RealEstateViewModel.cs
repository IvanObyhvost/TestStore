using System.Collections.Generic;
using System.Web.Mvc;
using TestStore.BLL.DTO;
using TestStore.Core.DTO;

namespace TestStore.Models
{
    public class RealEstateViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
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
        //public byte[] ImageData { get; set; }

        //[HiddenInput(DisplayValue = false)]
        //public string ImageMimeType { get; set; }
        //public Tenure Tenure { get; set; }
        //public PropertyStatus PropertyStatus { get; set; }
    }
}