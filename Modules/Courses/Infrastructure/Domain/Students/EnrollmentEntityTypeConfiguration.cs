using ContosoUniversity.Modules.Courses.Domain.Students;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ContosoUniversity.Modules.Courses.Infrastructure.Domain.Students
{
    internal class EnrollmentEntityTypeConfiguration : IEntityTypeConfiguration<Enrollment>
    {
        public void Configure(EntityTypeBuilder<Enrollment> builder)
        {
            builder.HasKey("StudentId", "CourseId");
            builder.OwnsOne(e => e.Grade, g =>
            {
                g.Property(x => x.Value).HasColumnName("Grade");
            });
            builder.HasOne(e => e.Student).WithMany(s => s.Enrollments);
            builder.HasOne(e => e.Course).WithMany(c => c.StudentEnrollments);
            builder.Property("_isDeleted").HasColumnName("IsDeleted"); ;
            builder.HasQueryFilter(s => EF.Property<bool>(s, "_isDeleted") == false);
            builder.ToTable("StudentEnrollments", "university");

        }
    }
}
