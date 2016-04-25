namespace SourceControlSystem.Services.Data.Contracts
{
    using SourceControlSystem.Common.Constants;
    using SourceControlSystem.Models;
    using System.Linq;

    public interface IProjectsService
    {
        IQueryable<SoftwareProject> All(int page = 1, int pageSize = GlobalConstants.DefaultPageSize);
    }
}
