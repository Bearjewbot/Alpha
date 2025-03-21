using Business.Factories;
using Business.Models;
using Data.Entities;
using Data.Repositories;

namespace Business.Services;

public class ProjectService(ProjectRepository repository) : IProjectService
{
    private readonly ProjectRepository _repository = repository;
    
    public async Task<bool> CreateProjectAsync(ProjectFormRegistration form)
    {
        var mappedProject = ProjectFactory.MapProjectEntity(form);

        if (mappedProject != null)
        {
           var createdProject = await _repository.CreateAsync(mappedProject);

           if (createdProject != null)
           {
               return true;
           }
        }
        return false;

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