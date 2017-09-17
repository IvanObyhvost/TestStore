using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestStore.Core.DTO;

namespace TestStore.Models
{
    public class RealEstateListViewModel
    {
        public List<RealEstateDTO> RealEstates{ get; set; }

        public PagingInfo PagingInfo { get; set; }
    }
}