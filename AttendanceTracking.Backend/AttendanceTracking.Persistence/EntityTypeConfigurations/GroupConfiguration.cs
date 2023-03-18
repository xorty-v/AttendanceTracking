using AttendanceTracking.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AttendanceTracking.Persistence.EntityTypeConfigurations;

public class GroupConfiguration : IEntityTypeConfiguration<Group>
{
    public void Configure(EntityTypeBuilder<Group> builder)
    {
        builder
            .HasMany(g => g.Lessons)
            .WithMany(l => l.Groups)
            .UsingEntity<LessonGroup>(
                lg => lg.HasOne(g => g.Lesson).WithMany(lg => lg.LessonsGroups),
                lg => lg.HasOne(l => l.Group).WithMany(lg => lg.LessonsGroups)
            );
    }
}