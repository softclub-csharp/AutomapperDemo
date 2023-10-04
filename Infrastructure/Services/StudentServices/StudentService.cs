using AutoMapper;
using Domain;
using Domain.DTOs.Student;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services.StudentServices;
public class StudentService : IStudentService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;
    public StudentService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<GetStudentDto>> GetStudentsAsync()
    {
        try
        {
            var students = await _context.Students.Select(s=>new GetStudentDto() { 
                Id=s.Id,
                FulName=s.FirstName+" "+s.LastName,
                Address=s.Address,
                BirthDate=s.BirthDate,
                EmailAddress=s.Email,
                Gender=s.Gender,
                JoinDate=s.JoinDate,
                Phone=s.Phone
            }).ToListAsync();
            
            // AutoMapper var mapperStudents=_mapper.Map<List<GetStudentDto>>(students);

            return new List<GetStudentDto>(students);
            
        }
        catch (Exception ex)
        {
            return new List<GetStudentDto>();
        }
    }

    public async Task<GetStudentDto> GetStudentByIdAsync(int id)
    {
        try
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null) return null;

            var studentMap = new GetStudentDto() { 
                Id = id,
                Address = student.Address,
                BirthDate = student.BirthDate,
                EmailAddress = student.Email,
                FulName = student.FirstName+" "+student.LastName,
                Gender = student.Gender,
                Phone = student.Phone,
                JoinDate=student.JoinDate
            };

            // AutoMapper var mapperStudents=_mapper.Map<List<GetStudentDto>>(students);

            return studentMap;

        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public async Task<AddStudentDto> AddStudentAsync(AddStudentDto model)
    {
        try
        {
            var student = new Student()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Address = model.Address,
                BirthDate = model.BirthDate,
                Email = model.Email,
                Gender = model.Gender,
                Phone = model.Phone,
                JoinDate = DateTime.UtcNow
            };

            //automapper
            //var student = _mapper.Map<Student>(model);
            //student.JoinDate = DateTime.UtcNow;

            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
            return model;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public async Task<BaseStudentDto> UpdateStudentAsync(AddStudentDto model)
    {
        try
        {
            var student = await _context.Students.FindAsync(model.Id);
            if (student == null) return null;
            student.FirstName = model.FirstName;
            student.LastName = model.LastName;
            student.Address = model.Address;
            student.BirthDate = model.BirthDate;
            student.Email = model.Email;
            student.Gender = model.Gender;
            student.Phone = model.Phone;

            //automapper  _mapper.Map(model,student); 

            _context.Students.Update(student);
            await _context.SaveChangesAsync();
            var baseStudent = _mapper.Map<BaseStudentDto>(student);

            return baseStudent;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public async Task<string> DeleteStudentAsync(int id)
    {
        try
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null) return "not found";
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return "Deleted";
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }

    
}
