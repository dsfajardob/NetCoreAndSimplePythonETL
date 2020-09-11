using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using EventsBack.Core.Entities;

namespace EventsBack.Infraestructure.Data
{
    public partial class Prueba_12Context : DbContext
    {
        public Prueba_12Context()
        {
        }

        public Prueba_12Context(DbContextOptions<Prueba_12Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Visitas> Visitas { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Visitas>(entity =>
            {
                entity.HasKey(e => e.Cedula)
                    .HasName("PK__visitas__415B7BE48B92D379");

                entity.ToTable("visitas");

                entity.Property(e => e.Cedula)
                    .HasColumnName("cedula")
                    .ValueGeneratedNever();

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombres)
                    .HasColumnName("nombres")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasColumnName("telefono")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
