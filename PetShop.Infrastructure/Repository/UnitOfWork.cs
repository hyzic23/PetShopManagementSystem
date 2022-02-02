using PetShop.Core.Interfaces;

namespace PetShop.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {

        public UnitOfWork(IPetRepository petRepository, 
                          IDoctorRepository doctorRepository,
                          IAppointmentRepository appointmentRepository)
        {
            Pets = petRepository;
            Doctors = doctorRepository;
            Appointments = appointmentRepository;
        }


        public IPetRepository Pets { get; }

        public IDoctorRepository Doctors { get; }
        public IAppointmentRepository Appointments { get; }

       
    }
}