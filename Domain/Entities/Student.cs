using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;
public class Student
{
    [Key]
    public int Id { get; set; }
    [MaxLength(30)]
    public string FirstName { get; set; }
    [MaxLength(30)]
    public string LastName { get; set; }
    [MaxLength(100)]
    public string Email { get; set; }
    [MaxLength(100)]
    public string Address { get; set; }
    [MaxLength(13)]
    public string Phone { get; set; }
    public char Gender { get; set; }
    public DateTime BirthDate { get; set; }
    public DateTime JoinDate { get; set; }
}
