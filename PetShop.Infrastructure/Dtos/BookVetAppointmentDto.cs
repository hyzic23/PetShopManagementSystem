

namespace PetShop.Infrastructure.Dtos
{
    public class BookVetAppointmentDto 
    {
        
        public int DogId { get; set; }
        public int DoctorId { get; set; }
        public string AppointmentDt { get; set; }
        public string EmailAddress { get; set; }
        public string phoneNumber { get; set; }
        public string PetsOwnerName { get; set; }
        
    }
}