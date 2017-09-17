using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestStore.Core.DTO;

namespace TestStore.Models
{
    public class DescriptionViewModel
    {
       public int Id { get; set; }
       public int Price { get; set; }
       public string Location { get; set; }
       public string Tenure { get; set; }
       public int RealEstateId { get; set; }
       public string ShortDescription { get; set; }
       public string LongDescription { get; set; }

       public List<PhotoForGalleryDTO> PhotoForGalleryDto { get; set; }

    }
}