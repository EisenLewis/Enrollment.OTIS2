using AutoMapper;
using Enrollment.App.ViewModels;
using Enrollment.DatabaseModels;

namespace Enrollment.App.Configuration
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Student, StudentVM>().ReverseMap();
        }
    }
}
