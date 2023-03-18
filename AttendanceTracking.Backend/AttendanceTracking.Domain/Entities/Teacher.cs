namespace AttendanceTracking.Domain.Entities;

public class Teacher 
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public ICollection<Lesson> Lessons { get; set; }
    public ICollection<Subject> Subjects { get; set; }
    public ICollection<TeacherSubject> TeachersSubjects { get; set; }
}