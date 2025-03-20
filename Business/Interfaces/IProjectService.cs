using Business.Models;
using Data.Entities;

namespace Business.Services;

public interface IProjectService
{
    Task<bool> CreateProjectAsync(ProjectFormRegistration form);
    Task<bool> GetProjectsAsync();
    Task<bool> UpdateProjectAsync(int id);
    Task<bool> DeleteProjectAsync(ProjectEntity entity);
}