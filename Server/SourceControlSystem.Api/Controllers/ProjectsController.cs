namespace SourceControlSystem.Api.Controllers
{
    using System.Web.Http;
    using System.Linq;

    using SourceControlSystem.Data;

    public class ProjectsController : ApiController
    {
        private readonly SourceControlSystemDbContext db;

        public ProjectsController()
        {
            this.db = new SourceControlSystemDbContext();
        }

        public IHttpActionResult Get()
        {
            var result = this.db
                .SoftwareProjcets
                .OrderByDescending(pr => pr.CreatedOn)
                .Take(10)
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

            var result = this.db
                .SoftwareProjcets
                .Where(pr => pr.Name == id)
                .FirstOrDefault();

            if (result == null)
            {
                return this.NotFound();
            }

            if (result.Private && !result.Users.Any(c => c.UserName == this.User.Identity.Name))
            {
                return this.Unauthorized();
            }

            return this.Ok(result);
        }

        [Authorize]
        public IHttpActionResult Post(Models.Projects.SaveProjectRequestModel model)
        {
            var currentUser = this.db
                .Users
                .FirstOrDefault(u => u.UserName == this.User.Identity.Name);

            var newProject = new SourceControlSystem.Models.SoftwareProject
            {
                Name = model.Name,
                Description = model.Description,
                Private = model.Private,
                CreatedOn = System.DateTime.Now
            };

            newProject.Users.Add(currentUser);

            this.db.SoftwareProjcets.Add(newProject);
            this.db.SaveChanges();

            return this.Ok(newProject.Id);
        }

        [Route("api/projects/all")]
        public IHttpActionResult Get(int page, int pageSize = 10)
        {
            var result = this.db
                   .SoftwareProjcets
                   .OrderByDescending(pr => pr.CreatedOn)
                   .Skip((page - 1) * pageSize)
                   .Take(pageSize)
                   .Select(Models.Projects.SoftwareProjectDetailsResponseModel.FromModel)
                   .ToList();

            return this.Ok(result);
        }
    }
}