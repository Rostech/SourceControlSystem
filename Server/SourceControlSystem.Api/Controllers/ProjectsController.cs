namespace SourceControlSystem.Api.Controllers
{
    using System.Web.Http;
    using System.Linq;

    using SourceControlSystem.Data;
    using SourceControlSystem.Models;
    using Common.Constants;
    public class ProjectsController : ApiController
    {
        private readonly IRepository<SoftwareProject> projects;
        private readonly IRepository<User> users;

        public ProjectsController()
        {
            var db = new SourceControlSystemDbContext();
            this.users = new EfGenericRepository<User>(db);
        }

        public IHttpActionResult Get()
        {
            var result = this.projects
                .All()
                .OrderByDescending(pr => pr.CreatedOn)
                .Skip(0)
                .Take(GlobalConstants.DefaultPageSize)
                .Select(Models.Projects.SoftwareProjectDetailsResponseModel.FromModel)
                .ToList();

            return this.Ok(result);
        }

        [Authorize]
        public IHttpActionResult Get(string id)
        {
            if(string.IsNullOrEmpty(id))
            {
                return this.BadRequest("Project name can't be null or empty.");
            }

            var result = this.projects
                .All()
                .Where(pr => pr.Name == id && (!pr.Private && pr.Users.Any(c => c.UserName == this.User.Identity.Name)))
                .Select(Models.Projects.SoftwareProjectDetailsResponseModel.FromModel)
                .FirstOrDefault();

            if (result == null)
            {
                return this.NotFound();
            }

            return this.Ok(result);
        }

        [Authorize]
        public IHttpActionResult Post(Models.Projects.SaveProjectRequestModel model)
        {
            var currentUser = this.users
                .All()
                .FirstOrDefault(u => u.UserName == this.User.Identity.Name);

            var newProject = new SourceControlSystem.Models.SoftwareProject
            {
                Name = model.Name,
                Description = model.Description,
                Private = model.Private,
                CreatedOn = System.DateTime.Now
            };

            newProject.Users.Add(currentUser);

            this.projects.Add(newProject);
            this.projects.SaveChanges();

            return this.Ok(newProject.Id);
        }

        [Route("api/projects/all")]
        public IHttpActionResult Get(int page, int pageSize = GlobalConstants.DefaultPageSize)
        {
            var result = this.projects
                   .All()
                   .OrderByDescending(pr => pr.CreatedOn)
                   .Skip((page - 1) * pageSize)
                   .Take(pageSize)
                   .Select(Models.Projects.SoftwareProjectDetailsResponseModel.FromModel)
                   .ToList();

            return this.Ok(result);
        }
    }
}