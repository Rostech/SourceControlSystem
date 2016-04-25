﻿namespace SourceControlSystem.Services.Data
{
    using SourceControlSystem.Services.Data.Contracts;
    using System.Linq;
    using SourceControlSystem.Models;
    using SourceControlSystem.Data;
    using Common.Constants;

    public class ProjectsService : IProjectsService
    {
        private readonly IRepository<SoftwareProject> projects;

        public ProjectsService()
        {
            var db = new SourceControlSystemDbContext();
            this.projects = new EfGenericRepository<SoftwareProject>(db);
        }

        public IQueryable<SoftwareProject> All(int page = 1, int pageSize = GlobalConstants.DefaultPageSize)
        {
            return this.projects
                .All()
                .OrderByDescending(pr => pr.CreatedOn)
                .Skip((page - 1) * pageSize)
                .Take(pageSize);
        }
    }
}