using AttendanceTracking.Application.Common.Mappings;
using AttendanceTracking.Domain.Entities;
using AutoMapper;

namespace AttendanceTracking.Application.Lessons.Queries.GetLessonsByTeacher;

public class LessonLookupDto : IMapWith<Lesson>
{
    public Guid Id { get; set; }
    public string SubjectName { get; set; }
    public string TeacherFullName { get; set; }
    public DateTime DateTimeLesson { get; set; }

    // TODO: уточнить как лучше возвращать имя и фамилию пользователя
    public void Mapping(Profile profile)
    {
        profile.CreateMap<Lesson, LessonLookupDto>()
            .ForMember(lessonDto => lessonDto.SubjectName,
                opt => opt.MapFrom(lesson => lesson.Subject.Name))
            .ForMember(lessonDto => lessonDto.TeacherFullName,
                opt => opt.MapFrom(lesson => $"{lesson.Teacher.FirstName} {lesson.Teacher.LastName}"));
    }
}