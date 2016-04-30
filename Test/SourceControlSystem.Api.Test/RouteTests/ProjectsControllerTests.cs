using MyTested.WebApi;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using SourceControlSystem.Api.Controllers;
using SourceControlSystem.Api.Models.Projects;
using System.Web.Http;

namespace SourceControlSystem.Api.Test.RouteTests
{
    [TestClass]
    public class ProjectsControllerTests
    {
        [TestInitialize]
        public void Init()
        {
            var config = new HttpConfiguration();
            WebApiConfig.Register(config);
            MyWebApi.IsUsing(WebApiConfig.CurrentConfig);
        }

        [TestMethod]
        public void PostShouldMapCorrectly()
        {
            MyWebApi
                .Routes()
                .ShouldMap("/api/Projects")
                .WithHttpMethod(HttpMethod.Post)
                .WithJsonContent(@"{ ""Name"": ""Test"", ""Private"": true}")
                .To<ProjectsController>(c => c.Post(new SaveProjectRequestModel
                {
                    Name = "Test",
                    Private = true
                }));
        }
    }
}
