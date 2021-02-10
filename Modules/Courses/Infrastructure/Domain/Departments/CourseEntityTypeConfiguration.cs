using ContosoUniversity.Modules.Courses.Domain.Departments;
using ContosoUniversity.Modules.Courses.Domain.Instructors;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace ContosoUniversity.Modules.Courses.Infrastructure.Domain.Departments
{
    internal class CourseEntityTypeConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {         
            builder.HasKey(c => c.Id);
            builder.Property<InstructorId>("_instructorId").HasColumnName("InstructorId");
            builder.Property(c => c.Credits).HasField("_credits");
            builder.Property(c => c.Title).HasField("_title");
            builder.Property<int>("_version").HasColumnName("Version").IsConcurrencyToken();
            builder.Property<DateTime?>("_modificationDate").HasColumnName("ModificationDate");
            builder.HasOne(c => c.Department).WithMany(d => d.Courses);
            builder.HasMany(c => c.StudentEnrollments).WithOne(e => e.Course);
            builder.Property("_isDeleted").HasColumnName("IsDeleted"); ;
            builder.HasQueryFilter(s => EF.Property<bool>(s, "_isDeleted") == false);
            builder.ToTable("Courses", "university");

        }
    }
}
