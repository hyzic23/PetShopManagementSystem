using System;

namespace PetShop.Core.Models
{
    public class BookVetAppointment
    {

        public int Id { get; set; }
        public int DogId { get; set; }
        public int DoctorId { get; set; }
        public string AppointmentDt { get; set; }
        public string EmailAddress { get; set; }
        public string phoneNumber { get; set; }
        public string PetsOwnerName { get; set; }
        public DateTime CreateDt { get; set; }
    
    }
}