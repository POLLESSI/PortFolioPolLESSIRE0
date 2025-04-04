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
    public class EducationRepository : IEducationRepository
    {
    #nullable disable
        private readonly SqlConnection _connection;

        public EducationRepository(SqlConnection connection)
        {
            _connection = connection ?? throw new ArgumentNullException(nameof(connection));
        }

        public async Task<bool> AddEducationAsync(Education education)
        {
            try
            {
                string sql = "INSERT INTO Education (School, Degree, FieldOfStudy, StartDate, EndDate, Description) VALUES " + "(@School, @Degree, @FieldOfStudy, @StartDate, @EndDate, @Description)";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@School", education.School);
                parameters.Add("@Degree", education.Degree);
                parameters.Add("@FieldOfStudy", education.FieldOfStudy);
                parameters.Add("@StartDate", education.StartDate);
                parameters.Add("@EndDate", education.EndDate);
                parameters.Add("@Description", education.Description);

                int rowsAffected = await _connection.ExecuteAsync(sql, parameters);
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding education: {ex.ToString()}");
                return false;
            }
        }

        public void AddEducation(Education education)
        {
            try
            {
                string sql = @"INSERT INTO Education (School, Degree, FieldOfStudy, StartDate, EndDate, Description)" +
                    "VALUES (@school, @degree, @fieldOfStudy, @startDate, @endDate, @description)";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@school", education.School);
                parameters.Add("@degree", education.Degree);
                parameters.Add("@fielOfStudy", education.FieldOfStudy);
                parameters.Add("@startDate", education.StartDate);
                parameters.Add("@endDate", education.EndDate);
                parameters.Add("@description", education.Description);

                _connection.Execute(sql, parameters);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating education: {ex.ToString}");
            }
        }

        public async Task<IEnumerable<Education?>> GetAllEducationsAsync(bool includeInactive = false)
        {
            try
            {
                string sql = includeInactive ? "SELECT * FROM Education" : "SELECT * FROM Education WHERE Active = 1";

                var educations = await _connection.QueryAsync<Education?>(sql);

                return educations ?? Enumerable.Empty<Education>();
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error retrieving educations: {ex.Message}");
                return Enumerable.Empty<Education>();
            }
        }

        public async Task<Education?> GetByIdEducationAsync(int id)
        {
            try
            {
                string sql = "SELECT * FROM Education WHERE Id = @id AND Active = 1";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@id", id, DbType.Int64);

                var education = await _connection.QueryFirstOrDefaultAsync<Education?>(sql, parameters);

                return education;
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error geting Education : {ex.ToString}");

                return null;
            }
        }
    }
}
