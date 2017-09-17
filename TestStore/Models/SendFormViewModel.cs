using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace TestStore.Models
{
    public class SendFormViewModel
    {
        [Required(ErrorMessage = "Please enter a title")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Please enter a Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter a phone number")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Please enter a message")]
        [DataType(DataType.MultilineText)]
        public string Message { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string Email { get; set; }
        public TimeToContactVieModel TimeToContactVieModel { get; set; }
    }
}