using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace TestStore.Core.DTO
{
    public class RealEstateDTO
    {
        public int Id { get; set; }
        public int RealEstateID { get; set; }
        [Description("Price £")]
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

        [DataType(DataType.MultilineText)]
        public string SalesCorner { get; set; }
        [HiddenInput(DisplayValue = false)]
        public string ImageMimeType { get; set; }
        [HiddenInput(DisplayValue = false)]
        public string ImagePath { get; set; }

        //[UIHint("Enum")]
        //public Tenure Tenure { get; set; }
        public string Tenure { get; set; }
        public string PropertyStatus { get; set; }
        //[UIHint("Enum")]
        //public PropertyStatus PropertyStatus { get; set; }
        public string ShortDescription { get; set; }

        [UIHint("tinymce_jquery_full"), AllowHtml]
        public string LongDescription { get; set; }

    }
}
