using MediatR;

namespace AttendanceTracking.Application.Lessons.Commands.UpdateLesson;

public class UpdateLessonCommand : IRequest
{
    public Guid Id { get; set; }
    public Guid TeacherId { get; set; }
    public Guid SubjectId { get; set; }
    public List<Guid> GroupsId { get; set; }
    public DateTime DateTime { get; set; }
}