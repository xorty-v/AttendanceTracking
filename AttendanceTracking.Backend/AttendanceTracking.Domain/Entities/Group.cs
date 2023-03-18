namespace AttendanceTracking.Domain.Entities;

public class Group
{
    public Guid Id { get; set; }
    public int GroupNumber { get; set; }

    public ICollection<Student> Students { get; set; }
    public ICollection<Lesson> Lessons { get; set; }
    public ICollection<LessonGroup> LessonsGroups { get; set; }
}