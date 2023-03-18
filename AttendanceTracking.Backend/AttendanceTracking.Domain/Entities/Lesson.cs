namespace AttendanceTracking.Domain.Entities;

public class Lesson
{
    public Guid Id { get; set; }
    public DateTime DateTime { get; set; }

    public Guid TeacherId { get; set; }
    public Teacher Teacher { get; set; }

    public Guid SubjectId { get; set; }
    public Subject Subject { get; set; }

    public ICollection<Group> Groups { get; set; }
    public ICollection<LessonGroup> LessonsGroups { get; set; }
    public ICollection<Visit> Visits { get; set; }
}