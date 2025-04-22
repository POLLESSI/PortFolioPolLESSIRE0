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
    public class ProjectRepository : IProjectRepository
    {
    #nullable disable
        private readonly SqlConnection _connection;

        public ProjectRepository(SqlConnection connection)
        {
            _connection = connection ?? throw new ArgumentNullException(nameof(connection));
        }

        public async Task<bool> AddProjectAsync(Project project)
        {
            try
            {
                string sql = "INSERT INTO Project (Name, Description, Url, StartDate, EndDate) VALUES " +
                     "(@Name, @Description, @Url, @StartDate, @EndDate)";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Name", project.Name);
                parameters.Add("@Description", project.Description);
                parameters.Add("@Url", project.Url);
                parameters.Add("@StartDate", project.StartDate);
                parameters.Add("@EndDate", project.EndDate);

                int rowsAffected = await _connection.ExecuteAsync(sql, parameters);
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding project: {ex.ToString()}");
                return false;
            }
        }

        public void AddProject(Project project)
        {
            try
            {
                string sql = @"INSERT INTO Project (Name, Description, Url, StartDate, EndDate)" +
                    "VALUES (@name, @description, @url, @startDate, @endDate)";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@name", project.Name);
                parameters.Add("@description", project.Description);
                parameters.Add("@uRL", project.Url);
                parameters.Add("@startDate", project.StartDate);
                parameters.Add("@endDate", project.EndDate);

                _connection.Execute(sql, parameters);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating project: {ex.ToString}");
            }
        }

        public async Task<IEnumerable<Project?>> GetAllProjectAsync(bool includeInactive = false)
        {
            try
            {
                string sql = includeInactive ? "SELECT * FROM Project" : "SELECT * FROM Project WHERE Active = 1";

                var projects = await _connection.QueryAsync<Project?>(sql);

                return projects ?? Enumerable.Empty<Project>();
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error retrieving projects: {ex.Message}");
                return Enumerable.Empty<Project>();
            }
        }

        public async Task<Project?> GetByIdProjectAsync(int id)
        {
            try
            {
                string sql = "SELECT * FROM Project WHERE Id = @id AND Active = 1";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@id", id, DbType.Int64);

                var project = await _connection.QueryFirstOrDefaultAsync<Project?>(sql, parameters);

                return project;
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error geting Project : {ex.ToString}");

                return null;
            }
        }

        public Project UpdateProject(int id, string name, string description, string url, DateTime startDate, DateTime endDate)
        {
            try
            {
                string sql = "UPDATE Project SET Name = @name, Description = @description, Url = @url, StartDate = @startDate, EndDate = @endDate WHERE Id = @id";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@name", name);
                parameters.Add("@description", description);
                parameters.Add("@url", url);
                parameters.Add("@startDate", startDate);
                parameters.Add("@endDate", endDate);
                return _connection.QueryFirst<Project?>(sql, parameters);
            }
            catch (System.ComponentModel.DataAnnotations.ValidationException ex)
            {

                Console.WriteLine($"Validation error : {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating project : {ex}");
            }
            return new Project();
        }
    }
}

















//Copyrite https://github.com/POLLESSI
