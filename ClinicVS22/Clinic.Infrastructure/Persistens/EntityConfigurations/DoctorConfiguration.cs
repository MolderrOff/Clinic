using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clinic.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clinic.Infrastructure.Persistens.EntityConfigurations;

public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
{
    public void Configure(EntityTypeBuilder<Doctor> builder)
    {
        builder.ToTable("Doctors");

        builder.HasKey(d => d.Id);

        builder.Property(d => d.Id)
            .HasDefaultValueSql("NEWSEQUENTIALID()");

        builder.OwnsOne(d => d.FullName, fullname =>
        {
            fullname.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(50);

            fullname.Property(p => p.Surname)
                .IsRequired()
                .HasMaxLength(50);

            fullname.ToTable("Doctors");
        });


    }
}
