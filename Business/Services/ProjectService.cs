using Business.Models;
using Data.Entities;
using Data.Repositories;

namespace Business.Services;

public class ProjectService(ProjectRepository repository) : IProjectService
{
    private readonly ProjectRepository _repository = repository;

    
    public async Task<bool> CreateProjectAsync(ProjectFormRegistration form)
    {
        
    }
    public async Task<bool> GetProjectsAsync()
    {
        var projects = await _repository.GetAllAsync();

        if (projects.Any())
        {
            
        }
    }

    public async Task<bool> UpdateProjectAsync(int id)
    {
        var project = await _repository.GetAsync(x => x.Id == id);

        if (project != null)
        {
            
        }
    }

    public async Task<bool> DeleteProjectAsync(ProjectEntity entity)
    {
       var result = await _repository.DeleteAsync(entity);

       return result; 
    }
}