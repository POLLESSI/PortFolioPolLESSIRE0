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
    public class LanguageRepository : ILanguageRepository
    {
#nullable disable
        private readonly SqlConnection _connection;

        public LanguageRepository(SqlConnection connection)
        {
            _connection = connection ?? throw new ArgumentNullException(nameof(connection));
        }

        public async Task<bool> AddLanguageAsync(Language language)
        {
            try
            {
                string sql = "INSERT INTO Language (Name, Level) VALUES" +
                     "(@Name, @Level)";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Name", language.Name);
                parameters.Add("@Level", language.Level);

                int rowsAffected = await _connection.ExecuteAsync(sql, parameters);
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding language: {ex.ToString()}");
                return false;
            }
        }

        public void AddLanguage(Language language)
        {
            try
            {
                string sql = "INSERT INTO Language (Name, Level)" +
                    "VALUES (@name, @level)";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@name", language.Name);
                parameters.Add("@level", language.Level);
                
                _connection.Execute(sql, parameters);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating language: {ex.ToString}");
            }
        }

        public async Task<IEnumerable<Language?>> GetAllLanguagesAsync(bool includeInactive = false)
        {
            try
            {
                string sql = includeInactive ? "SELECT * FROM Language" : "SELECT * FROM Language WHERE Active = 1";

                var languages = await _connection.QueryAsync<Language?>(sql);

                return languages ?? Enumerable.Empty<Language>();
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error retrieving languages: {ex.Message}");
                return Enumerable.Empty<Language>();
            }
        }

        public async Task<Language?> GetByIdLanguageAsync(int id)
        {
            try
            {
                string sql = "SELECT * FROM Language WHERE Id = @id AND Active = 1";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@id", id, DbType.Int64);

                var language = await _connection.QueryFirstOrDefaultAsync<Language?>(sql, parameters);

                return language;
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error geting Language : {ex.ToString}");

                return null;
            }
        }
    }
}
