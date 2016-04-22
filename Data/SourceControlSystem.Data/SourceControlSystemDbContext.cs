﻿namespace SourceControlSystem.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;

    using SourceControlSystem.Models;
    using System.Data.Entity;
    public class SourceControlSystemDbContext : IdentityDbContext<User>
    {
        public SourceControlSystemDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public virtual IDbSet<Commit> Commits { get; set; }

        public virtual IDbSet<SoftwareProject> SoftwareProjcets { get; set; }

        public static SourceControlSystemDbContext Create()
        {
            return new SourceControlSystemDbContext();
        }
    }
}