using AttendanceTracking.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AttendanceTracking.Application.Interfaces;

public interface IAttendanceDbContext
{
    DbSet<Teacher> Teachers { get; set; }
    DbSet<Student> Students { get; set; }
    DbSet<Group> Groups { get; set; }
    DbSet<Subject> Subjects { get; set; }
    DbSet<Lesson> Lessons { get; set; }
    DbSet<Visit> Visits { get; set; }
    DbSet<LessonGroup> LessonsGroups { get; set; }
    DbSet<TeacherSubject> TeachersSubjects { get; set; }
    
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}