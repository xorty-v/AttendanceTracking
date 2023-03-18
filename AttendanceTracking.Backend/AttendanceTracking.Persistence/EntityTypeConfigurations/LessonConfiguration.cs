using AttendanceTracking.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AttendanceTracking.Persistence.EntityTypeConfigurations;

public class LessonConfiguration : IEntityTypeConfiguration<Lesson>
{
    public void Configure(EntityTypeBuilder<Lesson> builder)
    {
        builder
            .HasMany(l => l.Groups)
            .WithMany(g => g.Lessons)
            .UsingEntity<LessonGroup>(
                lg => lg.HasOne(l => l.Group).WithMany(lg => lg.LessonsGroups),
                lg => lg.HasOne(g => g.Lesson).WithMany(lg => lg.LessonsGroups)
            );
    }
}