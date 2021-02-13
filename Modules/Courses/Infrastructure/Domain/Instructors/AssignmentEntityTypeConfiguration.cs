using ContosoUniversity.Modules.Courses.Domain.Instructors;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ContosoUniversity.Modules.Courses.Infrastructure.Domain.Instructors
{
    internal class AssignmentEntityTypeConfiguration : IEntityTypeConfiguration<Assignment>
    {
        public void Configure(EntityTypeBuilder<Assignment> builder)
        {
            builder.HasKey("InstructorId", "CourseId");
            builder.HasOne(a => a.Instructor).WithMany(i => i.Assignments);
            builder.HasOne(e => e.Course).WithMany(c => c.InstructorAssignments);
            builder.Property("_isDeleted").HasColumnName("IsDeleted"); ;
            builder.HasQueryFilter(s => EF.Property<bool>(s, "_isDeleted") == false);
            builder.ToTable("InstructorAssignments", "courses");

        }
    }
}
