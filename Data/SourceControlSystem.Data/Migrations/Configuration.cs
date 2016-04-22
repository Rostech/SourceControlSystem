namespace SourceControlSystem.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public sealed class Configuration : DbMigrationsConfiguration<SourceControlSystemDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(SourceControlSystemDbContext context)
        {
            // Here we add admin role.. and stuff.
        }
    }
}
