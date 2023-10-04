using Domain;
using Domain.DTOs.Student;

namespace Infrastructure.Services.StudentServices;
public interface IStudentService
{   
    Task<List<GetStudentDto>> GetStudentsAsync();
    Task<GetStudentDto> GetStudentByIdAsync(int id);
    Task<AddStudentDto> AddStudentAsync(AddStudentDto model);
    Task<BaseStudentDto> UpdateStudentAsync(AddStudentDto model);
    Task<string> DeleteStudentAsync(int id);
}
