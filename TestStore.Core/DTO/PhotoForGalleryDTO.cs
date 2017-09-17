using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestStore.Core.DTO
{
    public class PhotoForGalleryDTO
    {
        public int Id { get; set; }
        public int RealEstateId { get; set; }
        public string UrlImage { get; set; }
    }
}
