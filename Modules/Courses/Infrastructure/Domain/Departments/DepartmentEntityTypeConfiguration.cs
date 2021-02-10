using ContosoUniversity.Modules.Courses.Domain.Departments;
using ContosoUniversity.Modules.Courses.Domain.Instructors;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace ContosoUniversity.Modules.Courses.Infrastructure.Domain.Departments
{
    internal class DepartmentEntityTypeConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {         
            builder.HasKey(d => d.Id);
            builder.Property<InstructorId>("_instructorId").HasColumnName("InstructorId");
            builder.Property(d => d.Name).HasField("_name");
            builder.Property(d => d.StartDate).HasField("_startDate");
            builder.Property<int>("_version").HasColumnName("Version").IsConcurrencyToken();
            builder.Property<DateTime?>("_modificationDate").HasColumnName("ModificationDate");
            builder.Property("_isDeleted").HasColumnName("IsDeleted"); ;
            builder.HasQueryFilter(s => EF.Property<bool>(s, "_isDeleted") == false);
            builder.HasOne(d => d.Administrator);  
            builder.OwnsOne(d => d.Budget,b => 
            {
                b.Property(x => x.Currency).HasColumnName("Currency");
                b.Property(x => x.Moment).HasColumnName("Moment");
                b.Property(x => x.Value).HasColumnName("Value");
            });
            builder.HasMany(d => d.Courses).WithOne(c => c.Department);                                
            builder.ToTable("Departments", "university");

        }
    }
}
