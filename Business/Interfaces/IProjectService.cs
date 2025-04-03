using Business.Models;
using Data.Entities;

namespace Business.Interfaces;

public interface IProjectService
{
    Task<bool> CreateProjectAsync(ProjectFormRegistration form);
    Task<IEnumerable<Project>?> GetProjectsAsync();
    Task<Project?> GetProjectAsync(int id);
    Task<bool> UpdateProjectAsync(ProjectEntity entity);
    Task<bool> DeleteProjectAsync(int id);
}