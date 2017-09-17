using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestStore.Core.DTO;

namespace TestStore.Models
{
    public class PersonModel
    {
        //public int Id { get; set; }
        //public string FistName { get; set; }
        //public string LastName { get; set; }
        public List<RealEstateDTO> realList { get; set; }
    }
}