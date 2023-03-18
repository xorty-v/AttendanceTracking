using AttendanceTracking.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AttendanceTracking.Persistence.EntityTypeConfigurations;

public class SubjectConfiguration : IEntityTypeConfiguration<Subject>
{
    public void Configure(EntityTypeBuilder<Subject> builder)
    {
        builder
            .HasMany(s => s.Teachers)
            .WithMany(t => t.Subjects)
            .UsingEntity<TeacherSubject>(
                ts => ts.HasOne(t => t.Teacher).WithMany(ts => ts.TeachersSubjects),
                ts => ts.HasOne(l => l.Subject).WithMany(ts => ts.TeachersSubjects)
            );
    }
}