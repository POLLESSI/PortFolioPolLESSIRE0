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
    public class SkillRepository : ISkillRepository
    {
    #nullable disable
        private readonly SqlConnection _connection;

        public SkillRepository(SqlConnection connection)
        {
            _connection = connection ?? throw new ArgumentNullException(nameof(connection));
        }

        public async Task<bool> AddSkillAsync(Skill skill)
        {
            try
            {
                string sql = "INSERT INTO Skill (Name, Level, Description) VALUES " +
                     "(@Name, @Level, @Description)";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Name", skill.Name);
                parameters.Add("@Level", skill.Level);
                parameters.Add("@Description", skill.Description);
               
                int rowsAffected = await _connection.ExecuteAsync(sql, parameters);
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding skill: {ex.ToString()}");
                return false;
            }
        }

        public void AddSkill(Skill skill)
        {
            try
            {
                string sql = @"INSERT INTO Skill (Name, Level, Description)" +
                    "VALUES (@name, @level, @description)";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@name", skill.Name);
                parameters.Add("@level", skill.Level);
                parameters.Add("@description", skill.Description);
                
                _connection.Execute(sql, parameters);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating skill: {ex.ToString}");
            }
        }

        public async Task<IEnumerable<Skill?>> GetAllSkillAsync(bool includeInactive = false)
        {
            try
            {
                string sql = includeInactive ? "SELECT * FROM Skill" : "SELECT * FROM Skill WHERE Active = 1";

                var skills = await _connection.QueryAsync<Skill?>(sql);

                return skills ?? Enumerable.Empty<Skill>();
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error retrieving skills: {ex.Message}");
                return Enumerable.Empty<Skill>();
            }
        }

        public async Task<Skill?> GetByIdSkillAsync(int id)
        {
            try
            {
                string sql = "SELECT * FROM Skill WHERE Id = @id AND Active = 1";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@id", id, DbType.Int64);

                var skill = await _connection.QueryFirstOrDefaultAsync<Skill?>(sql, parameters);

                return skill;
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error geting Skill : {ex.ToString}");

                return null;
            }
        }

        public Skill UpdateSkill(int id, string name, string level, string description)
        {
            try
            {
                string sql = "UPDATE Skill SET Name = @name, Level = @level, Description = @description WHERE Activity_Id = @activity_Id";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@name", name);
                parameters.Add("@level", level);
                parameters.Add("@description", description);
                return _connection.QueryFirst<Skill?>(sql, parameters);
            }
            catch (System.ComponentModel.DataAnnotations.ValidationException ex)
            {

                Console.WriteLine($"Validation error : {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating skill : {ex}");
            }
            return new Skill();
        }
    }
}






















//Copyrite https://github.com/POLLESSI
