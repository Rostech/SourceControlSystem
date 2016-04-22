namespace SourceControlSystem.Api
{
    using System.Data.Entity;

    using SourceControlSystem.Data;
    using SourceControlSystem.Data.Migrations;

    public class DatabaseConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SourceControlSystemDbContext, Configuration>());
            SourceControlSystemDbContext.Create().Database.Initialize(true);
        }
    }
}