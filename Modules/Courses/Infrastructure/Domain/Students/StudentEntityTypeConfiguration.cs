using ContosoUniversity.Modules.Courses.Domain.Students;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace ContosoUniversity.Modules.Courses.Infrastructure.Domain.Students
{
    internal class StudentEntityTypeConfiguration : IEntityTypeConfiguration<Student>
    {       
        public void Configure(EntityTypeBuilder<Student> builder)
        {         
            builder.HasKey(s => s.Id);
            builder.Property(s => s.EnrollmentDate).HasField("_enrollmentDate");
            builder.Property(s => s.CreateDate).HasField("_createDate");
            builder.Property("_version").HasColumnName("Version").IsConcurrencyToken();
            builder.Property("_modificationDate").HasColumnName("ModificationDate");
            builder.Property("_isDeleted").HasColumnName("IsDeleted"); ;
            builder.HasQueryFilter(s => EF.Property<bool>(s, "_isDeleted") == false);
            builder.OwnsOne(i => i.PersonName, pn =>
            {
                pn.Property(x => x.First).HasColumnName("FirstName");
                pn.Property(x => x.Last).HasColumnName("LastName");
            });
            builder.HasMany(i => i.Enrollments).WithOne(e => e.Student);               
            builder.ToTable("Students", "courses");

        }
    }
   
}
