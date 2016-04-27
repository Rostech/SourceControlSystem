namespace SourceControlSystem.Api.Models.Projects
{
    using Infrastructure.Mappings;
    using SourceControlSystem.Models;
    using System;
    using AutoMapper;

    public class SoftwareProjectDetailsResponseModel : IMapFrom<SoftwareProject>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime CreatedOn { get; set; }

        public int TotalUsers { get; set; }

        public void CreateMappings(IConfiguration config)
        {
            throw new NotImplementedException();
        }
    }
}