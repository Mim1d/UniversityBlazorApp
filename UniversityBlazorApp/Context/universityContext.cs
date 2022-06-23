using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using UniversityBlazorApp.Data;

namespace UniversityBlazorApp.Context
{
    public partial class universityContext : DbContext
    {
        public universityContext()
        {
        }

        public universityContext(DbContextOptions<universityContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Auditorium> Auditoriums { get; set; } = null!;
        public virtual DbSet<AuditoriumType> AuditoriumTypes { get; set; } = null!;
        public virtual DbSet<Mark> Marks { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;
        public virtual DbSet<Subject> Subjects { get; set; } = null!;
        public virtual DbSet<Teacher> Teachers { get; set; } = null!;
        public virtual DbSet<TeachersToSubject> TeachersToSubjects { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost;Database=university;Username=postgres;Password=qwerty");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Auditorium>(entity =>
            {
                entity.ToTable("auditoriums");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Accommodates).HasColumnName("accommodates");

                entity.Property(e => e.Room)
                    .HasMaxLength(3)
                    .HasColumnName("room")
                    .IsFixedLength();

                entity.Property(e => e.Type).HasColumnName("type");

                entity.HasOne(d => d.TypeNavigation)
                    .WithMany(p => p.Auditoria)
                    .HasForeignKey(d => d.Type)
                    .HasConstraintName("auditoriums_type_fkey");
            });

            modelBuilder.Entity<AuditoriumType>(entity =>
            {
                entity.ToTable("auditorium_types");

                entity.HasIndex(e => e.Type, "auditorium_types_type_key")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Type)
                    .HasMaxLength(30)
                    .HasColumnName("type");
            });

            modelBuilder.Entity<Mark>(entity =>
            {
                entity.ToTable("marks");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Mark1).HasColumnName("mark");

                entity.Property(e => e.MarkDate).HasColumnName("mark_date");

                entity.Property(e => e.StudentId).HasColumnName("student_id");

                entity.Property(e => e.SubjectId).HasColumnName("subject_id");

                entity.Property(e => e.TeacherId).HasColumnName("teacher_id");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Marks)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("marks_student_id_fkey");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.Marks)
                    .HasForeignKey(d => d.SubjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("marks_subject_id_fkey");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.Marks)
                    .HasForeignKey(d => d.TeacherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("marks_teacher_id_fkey");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("students");

                entity.HasIndex(e => e.Email, "students_email_key")
                    .IsUnique();

                entity.HasIndex(e => e.Phone, "students_phone_key")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Birthdate).HasColumnName("birthdate");

                entity.Property(e => e.Class)
                    .HasColumnName("class")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.Email)
                    .HasMaxLength(30)
                    .HasColumnName("email");

                entity.Property(e => e.FamilyName)
                    .HasMaxLength(20)
                    .HasColumnName("family_name");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(20)
                    .HasColumnName("first_name");

                entity.Property(e => e.MiddleName)
                    .HasMaxLength(20)
                    .HasColumnName("middle_name");

                entity.Property(e => e.Phone)
                    .HasMaxLength(20)
                    .HasColumnName("phone");
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.ToTable("subjects");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Subject1)
                    .HasMaxLength(30)
                    .HasColumnName("subject");
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.ToTable("teachers");

                entity.HasIndex(e => e.Email, "teachers_email_key")
                    .IsUnique();

                entity.HasIndex(e => e.Phone, "teachers_phone_key")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Birthdate).HasColumnName("birthdate");

                entity.Property(e => e.Email)
                    .HasMaxLength(30)
                    .HasColumnName("email");

                entity.Property(e => e.FamilyName)
                    .HasMaxLength(20)
                    .HasColumnName("family_name");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(20)
                    .HasColumnName("first_name");

                entity.Property(e => e.MiddleName)
                    .HasMaxLength(20)
                    .HasColumnName("middle_name");

                entity.Property(e => e.Phone)
                    .HasMaxLength(20)
                    .HasColumnName("phone");

                entity.Property(e => e.Post)
                    .HasMaxLength(20)
                    .HasColumnName("post");

                entity.Property(e => e.Salary)
                    .HasColumnType("money")
                    .HasColumnName("salary");
            });

            modelBuilder.Entity<TeachersToSubject>(entity =>
            {
                entity.ToTable("teachers_to_subjects");

                entity.HasIndex(e => new { e.TeacherId, e.SubjectId }, "UI_teachers_to_subjects_teacher_id_subject_id")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.SubjectId).HasColumnName("subject_id");

                entity.Property(e => e.TeacherId).HasColumnName("teacher_id");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.TeachersToSubjects)
                    .HasForeignKey(d => d.SubjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_subject_id");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.TeachersToSubjects)
                    .HasForeignKey(d => d.TeacherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_teacher_id");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
