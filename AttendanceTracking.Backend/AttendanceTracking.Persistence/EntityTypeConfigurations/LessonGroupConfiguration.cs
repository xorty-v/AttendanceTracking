using AttendanceTracking.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AttendanceTracking.Persistence.EntityTypeConfigurations;

public class LessonGroupConfiguration : IEntityTypeConfiguration<LessonGroup>
{
    public void Configure(EntityTypeBuilder<LessonGroup> builder)
    {
        builder.HasKey(lg => new { lg.LessonId, lg.GroupId });

        builder
            .HasOne(lg => lg.Lesson)
            .WithMany(l => l.LessonsGroups)
            .HasForeignKey(lg => lg.LessonId);

        builder
            .HasOne(lg => lg.Group)
            .WithMany(g => g.LessonsGroups)
            .HasForeignKey(lg => lg.GroupId);
    }
}