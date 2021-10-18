using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace LoginAPI1.ELearnModel
{
    public partial class ELearnApp1Context : DbContext
    {
        public ELearnApp1Context()
        {
        }

        public ELearnApp1Context(DbContextOptions<ELearnApp1Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Answer> Answers { get; set; }
        public virtual DbSet<Class> Classes { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<CourseEnroll> CourseEnrolls { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Fee> Fees { get; set; }
        public virtual DbSet<NewStaff> NewStaffs { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<Topic> Topics { get; set; }
        public virtual DbSet<UserAccount> UserAccounts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\SQLSERVER2019ISH;Database=ELearnApp1;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Answer>(entity =>
            {
                entity.ToTable("Answer");

                entity.Property(e => e.AnswerId).HasColumnName("Answer_id");

                entity.Property(e => e.Answer1)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.QuestionId).HasColumnName("Question_id");

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.Answers)
                    .HasForeignKey(d => d.QuestionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Answer__Question__4CA06362");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Answers)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Answer__UserId__4D94879B");
            });

            modelBuilder.Entity<Class>(entity =>
            {
                entity.ToTable("Class");

                entity.Property(e => e.ClassId).HasColumnName("Class_id");

                entity.Property(e => e.CLink)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("C_link");

                entity.Property(e => e.ClassDate).HasColumnType("datetime");

                entity.Property(e => e.CourseId).HasColumnName("Course_id");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Classes)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK__Class__Course_id__3F466844");
            });

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.HasKey(e => e.Cid)
                    .HasName("PK__Contact__C1F8DC39F692C253");

                entity.ToTable("Contact");

                entity.Property(e => e.Cid).HasColumnName("CId");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Message)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("Course");

                entity.Property(e => e.CourseId).HasColumnName("Course_id");

                entity.Property(e => e.Amount).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.CourseName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Picture)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Course__UserId__3C69FB99");
            });

            modelBuilder.Entity<CourseEnroll>(entity =>
            {
                entity.HasKey(e => e.EnrollId)
                    .HasName("PK__CourseEn__405B562C28F3D26D");

                entity.ToTable("CourseEnroll");

                entity.Property(e => e.CourseId).HasColumnName("Course_id");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.CourseEnrolls)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CourseEnr__Cours__440B1D61");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.CourseEnrolls)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CourseEnr__UserI__4316F928");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.CustId)
                    .HasName("PK__Customer__049E3AA9F6CC5371");

                entity.ToTable("Customer");

                entity.Property(e => e.CourseId).HasColumnName("Course_id");

                entity.Property(e => e.Debit)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Expiry)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Customer__Course__5165187F");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Customer__UserId__5070F446");
            });

            modelBuilder.Entity<Fee>(entity =>
            {
                entity.ToTable("Fee");

                entity.Property(e => e.CourseId).HasColumnName("Course_id");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Fees)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Fee__Course_id__5535A963");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Fees)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Fee__UserId__5441852A");
            });

            modelBuilder.Entity<NewStaff>(entity =>
            {
                entity.HasKey(e => e.Sid)
                    .HasName("PK__NewStaff__CA1E5D7868665960");

                entity.ToTable("NewStaff");

                entity.Property(e => e.College)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Department)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Experience)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.High)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('false')");

                entity.Property(e => e.UserImage)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.ToTable("Question");

                entity.Property(e => e.QuestionId).HasColumnName("Question_id");

                entity.Property(e => e.Question1)
                    .IsRequired()
                    .HasColumnType("text");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Questions)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Question__UserId__49C3F6B7");
            });

            modelBuilder.Entity<Topic>(entity =>
            {
                entity.ToTable("Topic");

                entity.Property(e => e.TopicId).HasColumnName("Topic_id");

                entity.Property(e => e.CourseId).HasColumnName("Course_id");

                entity.Property(e => e.MaterialPath)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Material_path");

                entity.Property(e => e.TopicDesc)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Topic_Desc");

                entity.Property(e => e.TopicName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Topic_Name");

                entity.Property(e => e.VideoPath)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Video_path");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Topics)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK__Topic__Course_id__46E78A0C");
            });

            modelBuilder.Entity<UserAccount>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__UserAcco__1788CC4C089A7DA4");

                entity.ToTable("UserAccount");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Role)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UserImage)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
