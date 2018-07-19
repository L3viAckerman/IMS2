using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace IMSv2.Models
{
    public partial class imsv2Context : DbContext
    {
        public imsv2Context()
        {
        }

        public imsv2Context(DbContextOptions<imsv2Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admin { get; set; }
        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<Hremployee> Hremployee { get; set; }
        public virtual DbSet<InternFollow> InternFollow { get; set; }
        public virtual DbSet<InternNews> InternNews { get; set; }
        public virtual DbSet<InternReport> InternReport { get; set; }
        public virtual DbSet<InternshipCourse> InternshipCourse { get; set; }
        public virtual DbSet<Lecture> Lecture { get; set; }
        public virtual DbSet<LectureFollow> LectureFollow { get; set; }
        public virtual DbSet<Message> Message { get; set; }
        public virtual DbSet<Operation> Operation { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<StudentLecture> StudentLecture { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("data source=den1.mssql5.gear.host;initial catalog=imsv2;persist security info=True;user id=imsv2;password=Qy1?~4kE16yY;multipleactiveresultsets=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<Hremployee>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Hremployee)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("FK_Hremployee_Company");
            });

            modelBuilder.Entity<InternFollow>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.InternNews)
                    .WithMany(p => p.InternFollow)
                    .HasForeignKey(d => d.InternNewsId)
                    .HasConstraintName("FK_InternFollow_InternNews");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.InternFollow)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK_InternFollow_Student");
            });

            modelBuilder.Entity<InternNews>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ExpiredDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.InternNews)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InternNews_Company");
            });

            modelBuilder.Entity<InternReport>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.HasOne(d => d.InternshipCourse)
                    .WithMany(p => p.InternReport)
                    .HasForeignKey(d => d.InternshipCourseId)
                    .HasConstraintName("FK_InternReport_InternshipCourse");
            });

            modelBuilder.Entity<InternshipCourse>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.End).HasColumnType("datetime");

                entity.Property(e => e.Start).HasColumnType("datetime");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.InternshipCourse)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InternshipCourse_Student");
            });

            modelBuilder.Entity<Lecture>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<LectureFollow>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.End).HasColumnType("datetime");

                entity.Property(e => e.Start).HasColumnType("datetime");

                entity.HasOne(d => d.Lecture)
                    .WithMany(p => p.LectureFollow)
                    .HasForeignKey(d => d.LectureId)
                    .HasConstraintName("FK_LectureFollow_Lecture");

                entity.HasOne(d => d.StudentI)
                    .WithMany(p => p.LectureFollow)
                    .HasForeignKey(d => d.StudentIid)
                    .HasConstraintName("FK_LectureFollow_Student");
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Date).HasColumnType("datetime");
            });

            modelBuilder.Entity<Operation>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Birthday).HasColumnType("datetime");

                entity.Property(e => e.Gpa).HasColumnName("GPA");
            });

            modelBuilder.Entity<StudentLecture>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Lecture)
                    .WithMany(p => p.StudentLecture)
                    .HasForeignKey(d => d.LectureId)
                    .HasConstraintName("FK_StudentLecture_Lecture");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.StudentLecture)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK_StudentLecture_Student");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.User)
                    .HasForeignKey<User>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Admin");

                entity.HasOne(d => d.Id1)
                    .WithOne(p => p.User)
                    .HasForeignKey<User>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Hremployee");

                entity.HasOne(d => d.Id2)
                    .WithOne(p => p.User)
                    .HasForeignKey<User>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Lecture");

                entity.HasOne(d => d.Id3)
                    .WithOne(p => p.User)
                    .HasForeignKey<User>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Student");
            });
        }
    }
}
