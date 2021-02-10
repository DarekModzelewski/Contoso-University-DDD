using AutoMapper;
using ContosoUniversity.Modules.Courses.Application.Students;

namespace ContosoUniversity.Modules.Courses.Infrastructure.Configuration.AutoMapper
{
    public static class AutoMapperConfig
    {
        public static IMapper Initialize()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddMaps(typeof(MappingProfile));               
            });

            return config.CreateMapper();
        }
        

    }
}
