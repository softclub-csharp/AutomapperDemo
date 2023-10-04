namespace Domain.DTOs.Student;
public class BaseStudentDto
{
    public int Id { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    public char Gender { get; set; }
    public DateTime BirthDate { get; set; }
    public DateTime JoinDate { get; set; }
    
}
