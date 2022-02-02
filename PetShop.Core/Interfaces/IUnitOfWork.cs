using System.Threading.Tasks;

namespace PetShop.Core.Interfaces
{
    public interface IUnitOfWork
    {
        IPetRepository Pets { get;}
        IDoctorRepository Doctors { get;}
        IAppointmentRepository Appointments { get; }
        //Task<bool> SaveAsync();
    }
}