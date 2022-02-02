using System;
using System.ComponentModel.DataAnnotations;

namespace PetShop.Core.Models
{
    public class Doctor
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Pet Name is required")]
        public string DoctorName { get; set; }

        public DateTime CreateDt { get; set; }
    }
}