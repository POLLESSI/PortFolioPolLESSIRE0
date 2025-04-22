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
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace PortFolioPolLESSIRE0.DAL.Repositories
{
    public class InterestRepository : IInterestRepository
    {
    #nullable disable
        private readonly SqlConnection _connection;

        public InterestRepository(SqlConnection connection)
        {
            _connection = connection ?? throw new ArgumentNullException(nameof(connection));
        }

        public async Task<bool> AddInterestAsync(Interest interest)
        {
            try
            {
                string sql = "INSERT INTO Interest (Name, Description) VALUES " +
                     "(@Name, @Description)";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Name", interest.Name);
                parameters.Add("@Description", interest.Description);
                
                int rowsAffected = await _connection.ExecuteAsync(sql, parameters); 
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding interest: {ex.ToString()}");
                return false;
            }
        }

        public void AddInterest(Interest interest)
        {
            try
            {
                string sql = "INSERT INTO Interest (Name, Description)" +
                    "VALUES (@name, @description)";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@name", interest.Name);
                parameters.Add("@description", interest.Description);
                
                _connection.Execute(sql, parameters);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating interest: {ex.ToString}");
            }
        }

        public async Task<IEnumerable<Interest?>> GetAllInterestsAsync(bool includeInactive = false)
        {
            try
            {
                string sql = includeInactive ? "SELECT * FROM Interest" : "SELECT * FROM Interest WHERE Active = 1";

                var interests = await _connection.QueryAsync<Interest?>(sql);

                return interests ?? Enumerable.Empty<Interest>();
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error retrieving interests: {ex.Message}");
                return Enumerable.Empty<Interest>();
            }
        }

        public async Task<Interest?> GetByIdInterestAsync(int id)
        {
            try
            {
                string sql = "SELECT * FROM Interest WHERE Id = @id AND Active = 1";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@id", id, DbType.Int64);

                var interest = await _connection.QueryFirstOrDefaultAsync<Interest?>(sql, parameters);

                return interest;
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error geting Interest : {ex.ToString}");

                return null;
            }
        }

        public Interest UpdateInterest(int id, string name, string description)
        {
            try
            {
                string sql = "UPDATE Interest SET Name = @name, Description = @description WHERE Id = @id";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@name", name);
                parameters.Add("@description", description);
                return _connection.QueryFirst<Interest?>(sql, parameters);
            }
            catch (System.ComponentModel.DataAnnotations.ValidationException ex)
            {

                Console.WriteLine($"Validation error : {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating interest : {ex}");
            }
            return new Interest();
        }
    }
}

















//Copyrite https://github.com/POLLESSI
