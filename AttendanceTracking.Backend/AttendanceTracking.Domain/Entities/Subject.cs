namespace AttendanceTracking.Domain.Entities;

public class Subject
{
    public Guid Id { get; set; }
    public string Name { get; set; }
        
    public ICollection<Lesson> Lessons { get; set; }
    public ICollection<Teacher> Teachers { get; set; }
    public ICollection<TeacherSubject> TeachersSubjects { get; set; }
}