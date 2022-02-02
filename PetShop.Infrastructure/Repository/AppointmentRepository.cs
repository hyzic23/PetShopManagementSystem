using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using PetShop.Core.Interfaces;
using PetShop.Core.Models;
using PetShop.Infrastructure.DataAccess;

namespace PetShop.Infrastructure.Repository
{
    public class AppointmentRepository : DataHelper, IAppointmentRepository
    {

        private readonly IConfiguration configuration;

        public AppointmentRepository(IConfiguration configuration) : base(configuration)
        {
            this.configuration = configuration;
        }


        public async Task<int> BookAppointment(BookVetAppointment request)
        {
            request.CreateDt = System.DateTime.Now;
            var query = "Insert into BookAppointment (DogId, DoctorId, AppointmentDt, EmailAddress, phoneNumber, PetsOwnerName, CreateDt) ";
              query += " VALUES (@DogId, @DoctorId,@AppointmentDt, @EmailAddress, @phoneNumber, @PetsOwnerName, @CreateDt)";
            
            var parameters = new DynamicParameters();
            parameters.Add("DogId", request.DogId, System.Data.DbType.Int16);
            parameters.Add("DoctorId", request.DoctorId, System.Data.DbType.Int16);
            parameters.Add("AppointmentDt", request.AppointmentDt, System.Data.DbType.String);

            parameters.Add("EmailAddress", request.EmailAddress, System.Data.DbType.String);
            parameters.Add("phoneNumber", request.phoneNumber, System.Data.DbType.String);
            parameters.Add("PetsOwnerName", request.PetsOwnerName, System.Data.DbType.String);
            parameters.Add("CreateDt", request.CreateDt, System.Data.DbType.DateTime);
            
            using (var connection = CreateConnection())
            {
                connection.Open();
                var result = await connection.ExecuteAsync(query, request);
                return result;
            }
        }

        public async Task<IEnumerable<BookVetAppointment>> GetAllAppointments()
        {
                var query = "Select * from BookAppointment";
                using(var connection = CreateConnection())
                {
                    return (await connection.QueryAsync<BookVetAppointment>(query)).ToList();
                }
        }
    }
}