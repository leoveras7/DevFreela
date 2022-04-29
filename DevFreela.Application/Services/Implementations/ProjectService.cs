using DevFreela.Application.InputModels;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModels;
using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;

namespace DevFreela.Application.Services.Implementations
{
    public class ProjectService : IProjectService
    {
        private readonly DevFreelaDbContext _dbcontext;

        public ProjectService(DevFreelaDbContext dbContext)
        {
            _dbcontext = dbContext;
        }
        public int Create(NewProjectInputModel inputModel)
        {
            var project = new Project(inputModel.Title, inputModel.Description, inputModel.IdClient, inputModel.IdFreelancer, inputModel.TotalCost);

            _dbcontext.Projects.Add(project);

            return project.Id;
        }

        public void CreateComment(CreateCommentInputModel InputModel)
        {
            var comment = new ProjectComment(InputModel.Content, InputModel.IdProject, InputModel.IdUser);

            _dbcontext.ProjectComments.Add(comment);
        }

        public void Delete(int id)
        {
            var project = _dbcontext.Projects.SingleOrDefault(p => p.Id == id);

            project.Cancel();
        }

        public void Finish(int id)
        {
            var project = _dbcontext.Projects.SingleOrDefault(p => p.Id == id);

            project.Finish();
        }

        public List<ProjectViewModel> GetAll(string query)
        {
            var projects = _dbcontext.Projects;

            var projectsViewModel = projects
                .Select(p => new ProjectViewModel(p.Title, p.CreatedAt))
                .ToList();

            return projectsViewModel;
        }

        public ProjectDetailsViewModel GetById(int id)
        {
            var project = _dbcontext.Projects.SingleOrDefault(p => p.Id == id);

            var projectDetailsViewModel = new ProjectDetailsViewModel(
                project.Id,
                project.Title,
                project.Description,
                project.TotalCost,
                project.StartedAt,
                project.FinishedAt
                );

            return projectDetailsViewModel;
        }

        public void Start(int id)
        {
            var project = _dbcontext.Projects.SingleOrDefault(p => p.Id == id);

            project.Start();
        }

        public void Update(UpdateProjectInputModel inputModel)
        {
            var project = _dbcontext.Projects.SingleOrDefault(p => p.Id == inputModel.Id);

            project.Update(inputModel.Title, inputModel.Description, inputModel.TotalCost);


        }
    }
}
