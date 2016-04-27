using Microsoft.VisualStudio.TestTools.UnitTesting;
using SourceControlSystem.Api.Controllers;
using SourceControlSystem.Api.Models.Projects;
using System.Web.Http;

namespace SourceControlSystem.Api.Test.ControllerTests
{
    [TestClass]
    public class ProjectsControllerTests
    {
        [TestMethod]
        public void PostShouldValidateModelState()
        {
            var controller = new ProjectsController(TestObjectFactory.GetProjectsService());
            controller.Configuration = new HttpConfiguration();

            var model = TestObjectFactory.GetInvalidModel();

            controller.Validate(model);

            var result = controller.Post(model);

            Assert.IsFalse(controller.ModelState.IsValid);
        }
    }
}
