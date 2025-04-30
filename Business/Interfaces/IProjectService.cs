using System.Linq.Expressions;
using Business.Models;
using Data.Entities;

namespace Business.Interfaces;

public interface IProjectService
{
    Task<bool> CreateProjectAsync(ProjectFormRegistration form);
    Task<IEnumerable<Project>?> GetProjectsAsync();
    Task<IEnumerable<Project>?> GetFilteredProjectsAsync(Expression<Func<ProjectEntity, bool>> expression);
    Task<Project?> GetProjectAsync(int id);
    Task<bool> UpdateProjectAsync(ProjectEntity entity);
    Task<bool> DeleteProjectAsync(int id);
}