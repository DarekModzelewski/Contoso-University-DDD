using ContosoUniversity.Modules.Courses.Domain.Instructors;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace ContosoUniversity.Modules.Courses.Infrastructure.Domain.Instructors
{
    internal class InstructorEntityTypeConfiguration : IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> builder)
        {         
            builder.HasKey(i => i.Id);
            builder.Property(i => i.HireDate).HasField("_hireDate");
            builder.Property<int>("_version").HasColumnName("Version").IsConcurrencyToken();
            builder.Property<DateTime?>("_modificationDate").HasColumnName("ModificationDate");
            builder.Property("_isDeleted").HasColumnName("IsDeleted"); ;
            builder.HasQueryFilter(s => EF.Property<bool>(s, "_isDeleted") == false);
            builder.OwnsOne(i => i.PersonName, pn => 
            {
                pn.Property(x => x.First).HasColumnName("FirstName");
                pn.Property(x => x.Last).HasColumnName("LastName");
            });
            builder.OwnsOne(i => i.OfficeLocation, ol => 
            {
                ol.Property(x => x.Address).HasColumnName("Address");
                ol.Property(x => x.City).HasColumnName("City");
                ol.Property(x => x.PostalCode).HasColumnName("PostalCode");
            });
            builder.HasMany(i => i.Assignments).WithOne(a => a.Instructor);     
            builder.ToTable("Instructors", "courses");

        }
    }    
}
