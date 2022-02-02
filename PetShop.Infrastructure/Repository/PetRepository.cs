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
    public class PetRepository : DataHelper, IPetRepository
    {
        private readonly IConfiguration configuration;

        public PetRepository(IConfiguration configuration) : base(configuration)
        {
            this.configuration = configuration;
        }


        public async Task<int> AddAsync(Pet entity)
        {
            entity.CreateDt = System.DateTime.Now;
            var query = "Insert into Pets (PetName, PetType, CreateDt) VALUES (@PetName, @PetType, @CreateDt)";
            
            var parameters = new DynamicParameters();
            parameters.Add("PetName", entity.PetName, System.Data.DbType.String);
            parameters.Add("PetType", entity.PetType, System.Data.DbType.String);
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
            var query = "DELETE FROM Pets where Id = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("Id", id, System.Data.DbType.Int32);

            using(var connection = CreateConnection())
            {
                return (await connection.ExecuteAsync(query, parameters));
            }
        }

        public async Task<IReadOnlyList<Pet>> GetAllAsync()
        {
            var query = "Select * from Pets";
                using(var connection = CreateConnection())
                {
                    return (await connection.QueryAsync<Pet>(query)).ToList();
                }
        }



        public async Task<Pet> GetByIdAsync(int id)
        {
             var query = "Select * from Pets where Id = @Id";

                var parameters = new DynamicParameters();
                parameters.Add("Id", id, System.Data.DbType.Int32);


                using(var connection = CreateConnection())
                {
                    return (await connection.QueryFirstOrDefaultAsync<Pet>(query, parameters));
                }
        }

        public async Task<int> UpdateAsync(Pet entity)
        {
            var query = "Update Pets Set PetName = @PetName, PetType = @PetType WHERE Id = @Id";

                var parameters = new DynamicParameters();
                parameters.Add("PetName", entity.PetName, System.Data.DbType.String);
                parameters.Add("PetType", entity.PetType, System.Data.DbType.String);
                
                parameters.Add("Id", entity.Id, System.Data.DbType.Int32);


                using(var connection = CreateConnection())
                {
                    return (await connection.ExecuteAsync(query, parameters));
                }
        }
    }
}