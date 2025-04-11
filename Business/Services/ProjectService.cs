using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Data.Entities;
using Data.Interfaces;

namespace Business.Services;

public class ProjectService(IProjectRepository repository) : IProjectService
{
    private readonly IProjectRepository _repository = repository;
    
    public async Task<bool> CreateProjectAsync(ProjectFormRegistration form)
    {
        
        var mappedProject = ProjectFactory.MapCreateProject(form);

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
    public async Task<IEnumerable<Project>?> GetProjectsAsync()
    {
        var entityList = await _repository.GetAllAsync();
        return entityList.Select(ProjectFactory.MapProjects);
    }

    public async Task<Project?> GetProjectAsync(int id)
    {
        var entity = await _repository.GetAsync(x => x.Id == id);

        if (entity != null)
        {
            return ProjectFactory.MapProject(entity);
        }
        return null;
    }

    public async Task<bool> UpdateProjectAsync(ProjectEntity entity)
    {
        var result = await _repository.UpdateAsync(x => x.Id == entity.Id, entity);
        
        if (result != null)
        {
            return true;
        }
        return false;
    }

    public async Task<bool> DeleteProjectAsync(int id)
    {
       var result = await _repository.DeleteAsync(x => x.Id == id);
       return result; 
    }
}