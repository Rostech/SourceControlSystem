namespace SourceControlSystem.Api.Infrastructure.Mappings
{
    using AutoMapper;

    public interface IHaveCustomMappings
    {
        void CreateMappings(IConfiguration config);
    }
}
