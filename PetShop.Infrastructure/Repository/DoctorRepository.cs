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
    public class DoctorRepository : DataHelper, IDoctorRepository
    {
        private readonly IConfiguration configuration;

        public DoctorRepository(IConfiguration configuration) : base(configuration)
        {
            this.configuration = configuration;
        }


        public async Task<int> AddAsync(Doctor entity)
        {
            entity.CreateDt = System.DateTime.Now;
            var query = "Insert into Doctors (DoctorName, CreateDt) VALUES (@DoctorName, @CreateDt)";
            
            var parameters = new DynamicParameters();
            parameters.Add("DoctorName", entity.DoctorName, System.Data.DbType.String);
            parameters.Add("CreateDt", entity.CreateDt, System.Data.DbType.DateTime);
            
            using (var connection = CreateConnection())
            {
                connection.Open();
                var result = await connection.ExecuteAsync(query, entity);
                return result;
            }
        }

        public async Task<int> DeleteAsync(int id)
        {
            var query = "DELETE FROM Doctors where Id = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("Id", id, System.Data.DbType.Int32);

            using(var connection = CreateConnection())
            {
                return (await connection.ExecuteAsync(query, parameters));
            }
        }

        public async Task<IReadOnlyList<Doctor>> GetAllAsync()
        {
            var query = "Select * from Doctors";
                using(var connection = CreateConnection())
                {
                    return (await connection.QueryAsync<Doctor>(query)).ToList();
                }
        }

        public async Task<Doctor> GetByIdAsync(int id)
        {
             var query = "Select * from Doctors where Id = @Id";

                var parameters = new DynamicParameters();
                parameters.Add("Id", id, System.Data.DbType.Int32);


                using(var connection = CreateConnection())
                {
                    return (await connection.QueryFirstOrDefaultAsync<Doctor>(query, parameters));
                }
        }

        public async Task<int> UpdateAsync(Doctor entity)
        {
            var query = "Update Doctors Set DoctorName = @DoctorName WHERE Id = @Id";

                var parameters = new DynamicParameters();
                parameters.Add("DoctorName", entity.DoctorName, System.Data.DbType.String);
                
                parameters.Add("Id", entity.Id, System.Data.DbType.Int32);


                using(var connection = CreateConnection())
                {
                    return (await connection.ExecuteAsync(query, parameters));
                }
        }
    }
}