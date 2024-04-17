using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Backend.Model;

public partial class TempContext : DbContext
{
    public TempContext()
    {
    }

    public TempContext(DbContextOptions<TempContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Measure> Measures { get; set; }

    public virtual DbSet<Setting> Settings { get; set; }

    public virtual DbSet<Temperature> Temperatures { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Server=192.168.0.247;Username=tomasz;Database=temp;Port=5432;Password=tomasz;SSLMode=Prefer;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Measure>(entity =>
        {
            entity.ToTable("measures");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.EndTime)
                .HasDefaultValueSql("'-infinity'::timestamp with time zone")
                .HasColumnName("end_time");
            entity.Property(e => e.IsActive).HasColumnName("is_active");
            entity.Property(e => e.StartTime)
                .HasDefaultValueSql("'-infinity'::timestamp with time zone")
                .HasColumnName("start_time");
        });

        modelBuilder.Entity<Setting>(entity =>
        {
            entity.ToTable("settings");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Value).HasColumnName("value");
        });

        modelBuilder.Entity<Temperature>(entity =>
        {
            entity.ToTable("temperatures");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Date)
                .HasDefaultValueSql("'-infinity'::timestamp with time zone")
                .HasColumnName("date");
            entity.Property(e => e.InsideTemperature).HasColumnName("inside_temperature");
            entity.Property(e => e.MeasureId).HasColumnName("measure_id");
            entity.Property(e => e.OutsideTemperature).HasColumnName("outside_temperature");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("users");

            entity.HasIndex(e => e.Id, "IX_users_id").IsUnique();

            entity.HasIndex(e => e.Name, "IX_users_name").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Password).HasColumnName("password");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
