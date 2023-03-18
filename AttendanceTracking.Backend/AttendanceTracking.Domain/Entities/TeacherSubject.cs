namespace AttendanceTracking.Domain.Entities;

public class TeacherSubject
{
    public Guid SubjectId { get; set; }
    public Subject Subject { get; set; }
        
    public Guid TeacherId { get; set; }
    public Teacher Teacher { get; set; }
}