using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clinic.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace Clinic.Infrastructure.Persistens;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
        : base(options)
    {
    }

    public DbSet<Patient> Patients { get; set; }
    public DbSet<Disease> Diseases { get; set; }

    public DbSet<Doctor> Doctors { get; set; }

    protected ApplicationDbContext()
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
        => modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
}
