using Moq;
using SourceControlSystem.Api.Models.Projects;
using SourceControlSystem.Services.Data.Contracts;

namespace SourceControlSystem.Api.Test
{
    public static class TestObjectFactory
    {
        public static IProjectsService GetProjectsService()
        {
            var projectsService = new Mock<IProjectsService>();
            projectsService.Setup(pr => pr.Add(
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<bool>())).Returns(1);

            return projectsService.Object;
        }

        public static SaveProjectRequestModel GetInvalidModel()
        {
            return new SaveProjectRequestModel { Description = "TestDescription" };
        }
    }
}
