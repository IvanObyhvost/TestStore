using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestStore.Core.DTO;

namespace TestStore.Models
{
    public class EditDescriptionViewModel
    {
        public int Id { get; set; }
        public int RealEstateId { get; set; }
        public string ShortDescription { get; set; }

       [UIHint("tinymce_jquery_full"), AllowHtml]
        public string LongDescription { get; set; }

       public IList<PhotoForGalleryDTO> PhotosDto { get; set; }
    }
}