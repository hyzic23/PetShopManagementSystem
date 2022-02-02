using System;
using System.ComponentModel.DataAnnotations;

namespace PetShop.Core.Models
{
    public class Pet
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Pet Name is required")]
        public string PetName { get; set; }

        [Required(ErrorMessage ="Pet Type is required")]
        public string PetType { get; set; }
        public DateTime CreateDt { get; set; }
    }
}