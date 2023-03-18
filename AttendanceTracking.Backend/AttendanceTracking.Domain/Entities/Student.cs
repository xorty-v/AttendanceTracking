namespace AttendanceTracking.Domain.Entities;

public class Student 
{
    public Guid Id { get; set; }

    public Guid GroupId { get; set; }
    public Group Group { get; set; }
    public ICollection<Visit> Visits { get; set; }
}