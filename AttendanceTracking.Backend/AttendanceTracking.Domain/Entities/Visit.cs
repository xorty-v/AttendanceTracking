namespace AttendanceTracking.Domain.Entities;

public class Visit
{
    public Guid Id { get; set; }

    public DateTime DateTimeVisit { get; set; }
        
    public Guid StudentId { get; set; }
    public Student Student { get; set; }
        
    public Guid LessonId { get; set; }
    public Lesson Lesson { get; set; }
}