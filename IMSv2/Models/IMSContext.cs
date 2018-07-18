using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace IMS.Models
{
    public partial class IMSContext : DbContext
    {
        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<HrEmployee> HrEmployees { get; set; }
        public virtual DbSet<InternFollow> InternFollows { get; set; }
        public virtual DbSet<InternNews> InternNews { get; set; }
        public virtual DbSet<InternReport> InternReports { get; set; }
        public virtual DbSet<InternshipCourse> InternshipCourses { get; set; }
        public virtual DbSet<Lecturer> Lecturers { get; set; }
        public virtual DbSet<LecturerFollow> LecturerFollows { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<Operation> Operations { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<StudentLecturer> StudentLecturers { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"data source=den1.mssql5.gear.host;initial catalog=IMS;persist security info=True;user id=imsv2;password=Qy1?~4kE16yY;multipleactiveresultsets=True;");
                //optionsBuilder.UseSqlServer(@"data source=10.4.24.60;initial catalog=IMS;persist security info=True;user id=intern;password=123456a@;multipleactiveresultsets=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.ToTable("Admin");

                entity.HasIndex(e => e.Cx)
                    .HasName("CX_Admin")
                    .IsUnique()
                    .ForSqlServerIsClustered();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Cx)
                    .HasColumnName("CX")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Gmail).HasColumnName("GMail");

                entity.Property(e => e.Vnumail).HasColumnName("VNUMail");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Admin)
                    .HasForeignKey<Admin>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Admin_User1");
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.ToTable("Company");

                entity.HasIndex(e => e.Cx)
                    .HasName("CX_Company")
                    .IsUnique()
                    .ForSqlServerIsClustered();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Cx)
                    .HasColumnName("CX")
                    .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<HrEmployee>(entity =>
            {
                entity.ToTable("HrEmployee");

                entity.HasIndex(e => e.Cx)
                    .HasName("CX_HREmployee")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Cx)
                    .HasColumnName("CX")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Name).HasColumnType("nchar(20)");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.HrEmployees)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("FK_HREmployee_Company");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.HrEmployee)
                    .HasForeignKey<HrEmployee>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HREmployee_User1");
            });

            modelBuilder.Entity<InternFollow>(entity =>
            {
                entity.ToTable("InternFollow");

                entity.HasIndex(e => e.Cx)
                    .HasName("CX_InternFollow")
                    .IsUnique()
                    .ForSqlServerIsClustered();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Cx)
                    .HasColumnName("CX")
                    .ValueGeneratedOnAdd();

                entity.HasOne(d => d.InternNews)
                    .WithMany(p => p.InternFollows)
                    .HasForeignKey(d => d.InternNewsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InternFollow_InternNews");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.InternFollows)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InternFollow_Student");
            });

            modelBuilder.Entity<InternNews>(entity =>
            {
                entity.HasIndex(e => e.Cx)
                    .HasName("CX_InternNews")
                    .IsUnique()
                    .ForSqlServerIsClustered();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Cx)
                    .HasColumnName("CX")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.ExpiredDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.InternNews)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("FK_InternNews_Company1");
            });

            modelBuilder.Entity<InternReport>(entity =>
            {
                entity.ToTable("InternReport");

                entity.HasIndex(e => e.Cx)
                    .HasName("CX_InternReport")
                    .IsUnique()
                    .ForSqlServerIsClustered();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Cx).ValueGeneratedOnAdd();

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.HasOne(d => d.InternshipCourse)
                    .WithMany(p => p.InternReports)
                    .HasForeignKey(d => d.InternshipCourseId)
                    .HasConstraintName("FK_InternReport_InternshipCourse");
            });

            modelBuilder.Entity<InternshipCourse>(entity =>
            {
                entity.ToTable("InternshipCourse");

                entity.HasIndex(e => e.Cx)
                    .HasName("CX_InternshipCourse")
                    .IsUnique()
                    .ForSqlServerIsClustered();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Cx)
                    .HasColumnName("CX")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.End).HasColumnType("datetime");

                entity.Property(e => e.Start).HasColumnType("datetime");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.InternshipCourses)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("FK_InternshipCourse_Company");

                entity.HasOne(d => d.Lecturer)
                    .WithMany(p => p.InternshipCourses)
                    .HasForeignKey(d => d.LecturerId)
                    .HasConstraintName("FK_InternshipCourse_Lecturer");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.InternshipCourses)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK_InternshipCourse_Student");
            });

            modelBuilder.Entity<Lecturer>(entity =>
            {
                entity.ToTable("Lecturer");

                entity.HasIndex(e => e.Cx)
                    .HasName("CX_Lecture")
                    .IsUnique()
                    .ForSqlServerIsClustered();

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Cx)
                    .HasColumnName("CX")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Gmail).HasColumnName("GMail");

                entity.Property(e => e.Vnumail).HasColumnName("VNUMail");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Lecturer)
                    .HasForeignKey<Lecturer>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Lecturer_User");
            });

            modelBuilder.Entity<LecturerFollow>(entity =>
            {
                entity.ToTable("LecturerFollow");

                entity.HasIndex(e => e.Cx)
                    .HasName("CX_LecturerFollow")
                    .IsUnique()
                    .ForSqlServerIsClustered();

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Cx)
                    .HasColumnName("CX")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.End).HasColumnType("date");

                entity.Property(e => e.Start).HasColumnType("date");

                entity.HasOne(d => d.Lecturer)
                    .WithMany(p => p.LecturerFollows)
                    .HasForeignKey(d => d.LecturerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LecturerFollow_Lecture");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.LecturerFollows)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LecturerFollow_Student");
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.ToTable("Message");

                entity.HasIndex(e => e.Cx)
                    .HasName("CX_Message")
                    .IsUnique()
                    .ForSqlServerIsClustered();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Cx)
                    .HasColumnName("CX")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Date).HasColumnType("datetime");
            });

            modelBuilder.Entity<Operation>(entity =>
            {
                entity.ToTable("Operation");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Role).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Student");

                entity.HasIndex(e => e.Cx)
                    .HasName("CX_Student")
                    .IsUnique()
                    .ForSqlServerIsClustered();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Cx).ValueGeneratedOnAdd();

                entity.Property(e => e.Gpa).HasColumnName("GPA");

                entity.Property(e => e.Vnumail).HasColumnName("VNUMail");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Student)
                    .HasForeignKey<Student>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Student_User");
            });

            modelBuilder.Entity<StudentLecturer>(entity =>
            {
                entity.HasKey(e => new { e.StudentId, e.LecturerId });

                entity.ToTable("StudentLecturer");

                entity.HasOne(d => d.Lecturer)
                    .WithMany(p => p.StudentLecturers)
                    .HasForeignKey(d => d.LecturerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StudentLecturer_Lecture");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.StudentLecturers)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StudentLecturer_Student");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.HasIndex(e => e.Cx)
                    .HasName("CX_User")
                    .IsUnique()
                    .ForSqlServerIsClustered();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Cx)
                    .HasColumnName("CX")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Role).HasDefaultValueSql("((0))");
            });
        }
    }
}
