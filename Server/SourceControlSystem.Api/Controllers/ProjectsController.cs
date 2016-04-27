namespace SourceControlSystem.Api.Controllers
{
    using System.Web.Http;
    using System.Linq;

    using SourceControlSystem.Data;
    using SourceControlSystem.Models;
    using Common.Constants;
    using Services.Data.Contracts;
    using Services.Data;
    using System.Web.Http.Cors;
    public class ProjectsController : ApiController
    {
        private readonly IProjectsService projects;

        public ProjectsController(IProjectsService projectService)
        {
            this.projects = projectService;
        }

        [EnableCors("*", "*", "*")]
        public IHttpActionResult Get()
        {
            var result = this.projects
                .All(page: 1)
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
            if(!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var createdProjectId = this.projects.Add(
                model.Name, 
                model.Description, 
                this.User.Identity.Name, 
                model.Private);

            return this.Ok(createdProjectId);
        }

        [Route("api/projects/all")]
        public IHttpActionResult Get(int page, int pageSize = GlobalConstants.DefaultPageSize)
        {
            var result = this.projects
                   .All(page, pageSize)
                   .Select(Models.Projects.SoftwareProjectDetailsResponseModel.FromModel)
                   .ToList();

            return this.Ok(result);
        }
    }
}