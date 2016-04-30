using Microsoft.VisualStudio.TestTools.UnitTesting;
using SourceControlSystem.Api.Controllers;
using SourceControlSystem.Api.Models.Projects;
using System.Web.Http;
using System.Web.Http.Results;
using MyTested.WebApi;
using SourceControlSystem.Services.Data.Contracts;

namespace SourceControlSystem.Api.Test.ControllerTests
{
    [TestClass]
    public class ProjectsControllerTests
    {
        [TestMethod]
        public void PostShouldValidateModelState()
        {
            MyWebApi
                .Controller<ProjectsController>()
                .WithResolvedDependencyFor(TestObjectFactory.GetProjectsService())
                .Calling(c => c.Post(TestObjectFactory.GetInvalidModel()))
                .ShouldHave()
                .InvalidModelState();


            //var controller = new ProjectsController(TestObjectFactory.GetProjectsService());
            //controller.Configuration = new HttpConfiguration();

            //var model = TestObjectFactory.GetInvalidModel();

            //controller.Validate(model);

            //var result = controller.Post(model);

            //Assert.IsFalse(controller.ModelState.IsValid);
        }

        [TestMethod]
        public void PostShouldReturnBadRequestWithInvalidModel()
        {
            //MyWebApi
            //    .Controller<ProjectsController>()
            //    .WithResolvedDependencyFor<IProjectsService>(TestObjectFactory.GetProjectsService())
            //    .Calling(c => c.Get())
            //    .ShouldReturn()
            //    .Ok()
            //    .WithResponseModel<List<Soddd>>

            //MyWebApi
            //    .Controller<ProjectsController>()
            //    .WithResolvedDependencyFor(TestObjectFactory.GetProjectsService())
            //    .Calling(c => c.Post(TestObjectFactory.GetInvalidModel()))
            //    .ShouldHave()
            //    .InvalidModelState()
            //    .AndAlso()
            //    .ShouldReturn()
            //    .BadRequest();

            ////var controller = new ProjectsController(TestObjectFactory.GetProjectsService());
            ////controller.Configuration = new HttpConfiguration();

            ////var model = TestObjectFactory.GetInvalidModel();

            ////controller.Validate(model);

            ////var result = controller.Post(model);

            ////Assert.AreEqual(typeof(InvalidModelStateResult), result.GetType());
        }
    }
}
