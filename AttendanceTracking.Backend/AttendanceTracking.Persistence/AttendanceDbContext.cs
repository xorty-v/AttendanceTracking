using AttendanceTracking.Application.Interfaces;
using AttendanceTracking.Domain.Entities;
using AttendanceTracking.Persistence.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;

namespace AttendanceTracking.Persistence;

public class AttendanceDbContext : DbContext, IAttendanceDbContext
{
    public DbSet<Student> Students { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<Subject> Subjects { get; set; }
    public DbSet<Lesson> Lessons { get; set; }
    public DbSet<Visit> Visits { get; set; }
    public DbSet<LessonGroup> LessonsGroups { get; set; }
    public DbSet<TeacherSubject> TeachersSubjects { get; set; }

    public AttendanceDbContext(DbContextOptions<AttendanceDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new LessonGroupConfiguration());
        builder.ApplyConfiguration(new LessonConfiguration());
        builder.ApplyConfiguration(new GroupConfiguration());
        
        builder.ApplyConfiguration(new TeacherSubjectConfiguration());
        builder.ApplyConfiguration(new TeacherConfiguration());
        builder.ApplyConfiguration(new SubjectConfiguration());
        
        base.OnModelCreating(builder);
    }
}