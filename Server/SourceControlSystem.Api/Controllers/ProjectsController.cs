namespace SourceControlSystem.Api.Controllers
{
    using System.Web.Http;
    using System.Linq;
    using Common.Constants;
    using Services.Data.Contracts;
    using System.Web.Http.Cors;
    using Models.Projects;
    using AutoMapper.QueryableExtensions;
    using AutoMapper;
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
            Mapper.CreateMap<SourceControlSystem.Models.SoftwareProject, SoftwareProjectDetailsResponseModel>()
                .ForMember(s => s.TotalUsers, opts => opts.MapFrom(s => s.Users.Count()));

            var result = this.projects
                .All(page: 1)
                .ProjectTo<SoftwareProjectDetailsResponseModel>()
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
                .ProjectTo<SoftwareProjectDetailsResponseModel>()
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
                   .ProjectTo<SoftwareProjectDetailsResponseModel>()
                   .ToList();

            return this.Ok(result);
        }
    }
}