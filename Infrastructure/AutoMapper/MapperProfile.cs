using AutoMapper;
using Domain.DTOs.Student;
using Domain.Entities;

namespace Infrastructure.AutoMapper;
public class MapperProfile:Profile
{
    public MapperProfile()
    {
        CreateMap<Student, AddStudentDto>();
        CreateMap<Student, GetStudentDto>()
            .ForMember(sDto => sDto.FulName, opt => opt.MapFrom(s => $"{s.FirstName} {s.LastName}"))
            .ForMember(sDto => sDto.EmailAddress, opt => opt.MapFrom(s =>s.Email));
        CreateMap<BaseStudentDto,Student>().ReverseMap();

            
    }
}
