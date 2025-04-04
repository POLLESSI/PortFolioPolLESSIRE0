using System;
using Dapper;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using PortFolioPolLESSIRE0.DAL.Interfaces;
using PortFolioPolLESSIRE0.DAL.Entities;
using System.Data;

namespace PortFolioPolLESSIRE0.DAL.Repositories
{
    public class ExperienceRepository : IExperienceRepository
    {
    #nullable disable
        private readonly SqlConnection _connection;

        public ExperienceRepository(SqlConnection connection)
        {
            _connection = connection ?? throw new ArgumentNullException(nameof(connection));
        }

        public async Task<bool> AddExperienceAsync(Experience experience)
        {
            try
            {
                string sql = "INSERT INTO Experience (Company, Position, Description, StartDate, EndDate) VALUES" +
                     "(@Company, @Position, @Description, @StartDate, @EndDate)";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Company", experience.Company);
                parameters.Add("@Position", experience.Position);
                parameters.Add("@Description", experience.Description);
                parameters.Add("@StartDate", experience.StartDate);
                parameters.Add("@EndDate", experience.EndDate);

                int rowsAffected = await _connection.ExecuteAsync(sql, parameters);
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding experience: {ex.ToString()}");
                return false;
            }
        }

        public void AddExperience(Experience experience)
        {
            try
            {
                string sql = "INSERT INTO Experience (Company, Position, Description, StartDate, EndDate)" +
                    "VALUES (@company, @position, @description, @startDate, @endDate)";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@company", experience.Company);
                parameters.Add("@position", experience.Position);
                parameters.Add("@description", experience.Description);
                parameters.Add("@startDate", experience.StartDate);
                parameters.Add("@endDate", experience.EndDate);

                _connection.Execute(sql, parameters);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating experience: {ex.ToString}");
            }
        }

        public async Task<IEnumerable<Experience?>> GetAllExperiencesAsync(bool includeInactive = false)
        {
            try
            {
                string sql = includeInactive ? "SELECT * FROM Experience" : "SELECT * FROM Experience WHERE Active = 1";

                var experiences = await _connection.QueryAsync<Experience?>(sql);

                return experiences ?? Enumerable.Empty<Experience>();
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error retrieving experiences: {ex.Message}");
                return Enumerable.Empty<Experience>();
            }
        }

        public async Task<Experience?> GetByIdExperienceAsync(int id)
        {
            try
            {
                string sql = "SELECT * FROM Experience WHERE Id = @id AND Active = 1";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@id", id, DbType.Int64);

                var experience = await _connection.QueryFirstOrDefaultAsync<Experience?>(sql, parameters);

                return experience;
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error geting Experience : {ex.ToString}");

                return null;
            }
        }
    }
}
