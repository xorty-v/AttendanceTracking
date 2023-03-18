using MediatR;

namespace AttendanceTracking.Application.Lessons.Commands.CreateLesson;

public class CreateLessonCommand : IRequest<Guid>
{
    public Guid TeacherId { get; set; }
    public Guid SubjectId { get; set; }
    public IList<Guid> GroupsId { get; set; }
    public DateTime DateTime { get; set; }
}