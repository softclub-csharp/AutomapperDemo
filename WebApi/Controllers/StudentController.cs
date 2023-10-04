using Domain;
using Domain.DTOs.Student;
using Infrastructure.Services.StudentServices;
using Microsoft.AspNetCore.Mvc;
namespace WebApi.Controllers;

[Route("[controller]")]
public class StudentController : ControllerBase
{
    private readonly IStudentService _service;
    public StudentController(IStudentService service)=>_service = service;

    [HttpGet("get-students")]
    public async Task<List<GetStudentDto>> GetStudentsAsync()=>await _service.GetStudentsAsync();

    [HttpGet("get-student-by-id")]
    public async Task<GetStudentDto> GetStudentByIdAsync(int id)=>await _service.GetStudentByIdAsync(id);
    
    [HttpPost("add-student")]
    public async Task<AddStudentDto> AddStudentAsync([FromBody]AddStudentDto model)=>await _service.AddStudentAsync(model);

    [HttpPut("update-student")]
    public async Task<BaseStudentDto> UpdateStudentAsync([FromBody]AddStudentDto model)=>await _service.UpdateStudentAsync(model);

    [HttpDelete("delete-student")]
    public async Task<string> DeleteStudentAsync(int id)=>await _service.DeleteStudentAsync(id);
}