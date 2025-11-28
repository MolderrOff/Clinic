using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clinic.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clinic.Infrastructure.Persistens.EntityConfigurations;

public class DiseaseConfiguration : IEntityTypeConfiguration<Disease>
{
    public void Configure(EntityTypeBuilder<Disease> builder)
    {
        builder.ToTable("Diseases");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasDefaultValueSql("NEWSEQUENTIALID()");

        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder           
               .HasMany(d => d.Patients)
               .WithOne(d => d.Disease)            
               .HasForeignKey(p => p.DiseaseId)
               .IsRequired();   
    }
}
