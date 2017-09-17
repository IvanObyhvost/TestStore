using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace TestStore.Core.DTO
{
    public class DescriptionDTO
    {
        public int Id { get; set;}
        public int RealEstateId { get; set; }
        public string ShortDescription { get; set; }

        [UIHint("tinymce_jquery_full"), AllowHtml]
        public string LongDescription { get; set; }
    }
}
