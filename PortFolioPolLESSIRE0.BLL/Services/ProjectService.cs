using Dapper;
using Microsoft.AspNetCore.SignalR.Client;
using PortFolioPolLESSIRE0.BLL.Interfaces;
using PortFolioPolLESSIRE0.BLL;
using PortFolioPolLESSIRE0.DAL.Repositories;
using PortFolioPolLESSIRE0.DAL.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Client;
using Microsoft.AspNetCore.Components;
using PortFolioPolLESSIRE0.DAL.Entities;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace PortFolioPolLESSIRE0.BLL.Services
{
    public class ProjectService : IProjectService
    {
    #nullable disable
        private readonly IProjectRepository _projectRepository;

        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public Task<bool> AddProjectAsync(Project project)
        {
            try
            {
                return _projectRepository.AddProjectAsync(project);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error add project: {ex.ToString}");
                return null;
            }
        }

        public void AddProject(Project project)
        {
            try
            {
                _projectRepository.AddProject(project);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error Create Project: {ex.ToString}");
            }
        }

        public async Task<IEnumerable<Project?>> GetAllProjectsAsync()
        {
            try
            {
                return await _projectRepository.GetAllProjectAsync();
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error return Projects : {ex.Message}");
                return null;
            }
        }

        public async Task<Project?> GetByIdProjectAsync(int id)
        {
            try
            {
                if (id <= 0)
                {
                    throw new System.ArgumentException("Id must be greater than 0", nameof(id));
                }
                return await _projectRepository.GetByIdProjectAsync(id);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error geting Project: {ex.ToString}");
                return null;
            }
        }

        public Project UpdateProject(int id, string name, string description, string url, DateTime startDate, DateTime endDate)
        {
            try
            {
                var UpdateProject = _projectRepository.UpdateProject(id, name, description, url, startDate, endDate);
                return UpdateProject;
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
