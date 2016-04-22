namespace SourceControlSystem.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;

    using SourceControlSystem.Models;

    public class SourceControlSystemDbContext : IdentityDbContext<User>
    {
        public SourceControlSystemDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static SourceControlSystemDbContext Create()
        {
            return new SourceControlSystemDbContext();
        }
    }
}
