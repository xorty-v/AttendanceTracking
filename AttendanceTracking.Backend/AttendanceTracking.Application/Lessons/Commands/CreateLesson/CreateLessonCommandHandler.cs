using AttendanceTracking.Application.Interfaces;
using AttendanceTracking.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using MediatR;

namespace AttendanceTracking.Application.Lessons.Commands.CreateLesson;

public class CreateLessonCommandHandler : IRequestHandler<CreateLessonCommand, Guid>
{
    private readonly IAttendanceDbContext _dbContext;
    public CreateLessonCommandHandler(IAttendanceDbContext dbContext) => _dbContext = dbContext;

    public async Task<Guid> Handle(CreateLessonCommand request, CancellationToken cancellationToken)
    {
        Lesson lesson = new Lesson
        {
            Id = Guid.NewGuid(),
            TeacherId = request.TeacherId,
            SubjectId = request.SubjectId,
            DateTime = request.DateTime
        };

        _dbContext.Lessons.Add(lesson);

        //Todo: удостовериться в потребности этого
        var groups = await _dbContext.Groups.Where(g => request.GroupsId
                .Contains(g.Id)).Select(g => g.Id).ToListAsync();

        foreach (var groupId in groups)
        {
            LessonGroup lessonGroup = new LessonGroup
            {
                GroupId = groupId,
                LessonId = lesson.Id
            };
            
            _dbContext.LessonsGroups.Add(lessonGroup);
        }
        
        await _dbContext.SaveChangesAsync(cancellationToken);

        return lesson.Id;
    }
}