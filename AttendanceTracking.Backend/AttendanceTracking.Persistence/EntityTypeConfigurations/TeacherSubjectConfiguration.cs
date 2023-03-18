﻿using AttendanceTracking.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AttendanceTracking.Persistence.EntityTypeConfigurations;

public class TeacherSubjectConfiguration : IEntityTypeConfiguration<TeacherSubject>
{
    public void Configure(EntityTypeBuilder<TeacherSubject> builder)
    {
        builder.HasKey(ts => new { ts.TeacherId, ts.SubjectId });

        builder.HasOne(ts => ts.Teacher)
            .WithMany(t => t.TeachersSubjects)
            .HasForeignKey(ts => ts.TeacherId);

        builder.HasOne(ts => ts.Subject)
            .WithMany(s => s.TeachersSubjects)
            .HasForeignKey(ts => ts.SubjectId);
    }
}