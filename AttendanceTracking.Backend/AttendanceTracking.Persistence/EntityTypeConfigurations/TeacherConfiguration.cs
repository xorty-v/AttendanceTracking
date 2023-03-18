using AttendanceTracking.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AttendanceTracking.Persistence.EntityTypeConfigurations;

public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
{
    public void Configure(EntityTypeBuilder<Teacher> builder)
    {
        builder
            .HasMany(t => t.Subjects)
            .WithMany(s => s.Teachers)
            .UsingEntity<TeacherSubject>(
                ts => ts.HasOne(t => t.Subject).WithMany(ts => ts.TeachersSubjects),
                ts => ts.HasOne(l => l.Teacher).WithMany(ts => ts.TeachersSubjects)
            );
    }
}
