namespace Domain.DTOs.Student;
public class GetStudentDto : BaseStudentDto
{
    public int Id { get; set; }
    public string FulName { get; set; }
    public string EmailAddress { get; set; }
}
