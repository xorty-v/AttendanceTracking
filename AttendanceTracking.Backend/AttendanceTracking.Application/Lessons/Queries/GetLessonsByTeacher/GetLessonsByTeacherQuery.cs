using MediatR;

namespace AttendanceTracking.Application.Lessons.Queries.GetLessonsByTeacher;

public class GetLessonsByTeacherQuery : IRequest<LessonListVm>
{
    public Guid TeacherId { get; set; }
}