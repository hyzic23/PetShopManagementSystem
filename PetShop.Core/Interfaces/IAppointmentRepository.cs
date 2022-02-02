using System.Collections.Generic;
using System.Threading.Tasks;
using PetShop.Core.Models;

namespace PetShop.Core.Interfaces
{
    public interface IAppointmentRepository
    {
         Task<int> BookAppointment(BookVetAppointment request);
         Task<IEnumerable<BookVetAppointment>> GetAllAppointments();
    }
}