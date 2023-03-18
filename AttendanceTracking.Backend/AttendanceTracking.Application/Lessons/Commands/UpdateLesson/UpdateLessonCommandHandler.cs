using AttendanceTracking.Application.Interfaces;
using AttendanceTracking.Application.Lessons.Commands.CreateLesson;
using System.Threading;
using System.Threading.Tasks;
using AttendanceTracking.Application.Common.Exceptions;
using AttendanceTracking.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AttendanceTracking.Application.Lessons.Commands.UpdateLesson;

public class UpdateLessonCommandHandler : IRequestHandler<UpdateLessonCommand>
{
    private readonly IAttendanceDbContext _dbContext;
    public UpdateLessonCommandHandler(IAttendanceDbContext dbContext) => _dbContext = dbContext;

    public async Task<Unit> Handle(UpdateLessonCommand request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Lessons
            .FirstOrDefaultAsync(l => l.Id == request.Id, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Lesson), request.Id);
        }

        entity.TeacherId = request.TeacherId;
        entity.SubjectId = request.SubjectId;
        entity.DateTime = request.DateTime;

        //Todo: удостовериться в потребности этого
        var groups = await _dbContext.Groups.Where(g => request.GroupsId
                .Contains(g.Id)).Select(g => g.Id).ToListAsync();
        
        foreach (var groupId in groups)
        {
            LessonGroup lessonGroup = new LessonGroup
            {
                GroupId = groupId,
                LessonId = request.Id
            };
            
            _dbContext.LessonsGroups.Add(lessonGroup);
        }

        await _dbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}