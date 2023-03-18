using AttendanceTracking.Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AttendanceTracking.Application.Lessons.Queries.GetLessonsByTeacher;

public class GetLessonsByTeacherQueryHandler : IRequestHandler<GetLessonsByTeacherQuery, LessonListVm>
{
    private readonly IAttendanceDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetLessonsByTeacherQueryHandler(IAttendanceDbContext dbContext, IMapper mapper) =>
        (_dbContext, _mapper) = (dbContext, mapper);

    public async Task<LessonListVm> Handle(GetLessonsByTeacherQuery request, CancellationToken cancellationToken)
    {
        var lessonsQuery = await _dbContext.Lessons
            .Where(lesson => lesson.TeacherId == request.TeacherId)
            .Include(s => s.Subject)
            .Include(t => t.Teacher)
            .ProjectTo<LessonLookupDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return new LessonListVm { Lessons = lessonsQuery };
    }
}