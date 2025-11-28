using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clinic.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clinic.Infrastructure.Persistens.EntityConfigurations;

public class PatientConfiguration : IEntityTypeConfiguration<Patient>
{
    public void Configure(EntityTypeBuilder<Patient> builder)
    {

        builder.ToTable("Patients");

        builder.HasKey(p => p.Id);

        builder.Property(x => x.Id)
            .HasDefaultValueSql("NEWSEQUENTIALID()");

        builder.OwnsOne(p => p.FullName, fullname =>
        {
            fullname.Property(p => p.Name)
            .IsRequired();

            fullname.Property(p => p.Surname)
            .IsRequired();

            fullname.ToTable("Patients");
        });

    }
}
