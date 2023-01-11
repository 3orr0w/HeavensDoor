using System;
using HeavensDoorClass;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace HeavensDoorServer
{
    public partial class SpaSalonContext : DbContext
    {
        public SpaSalonContext()
        {
        }

        public SpaSalonContext(DbContextOptions<SpaSalonContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Delivery> Deliveries { get; set; }
        public virtual DbSet<Material> Materials { get; set; }
        public virtual DbSet<MaterialForProcedure> MaterialForProcedures { get; set; }
        public virtual DbSet<MaterialInDelivery> MaterialInDeliveries { get; set; }
        public virtual DbSet<MaterialToStorage> MaterialToStorages { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Procedure> Procedures { get; set; }
        public virtual DbSet<ProcedureToPost> ProcedureToPosts { get; set; }
        public virtual DbSet<Session> Sessions { get; set; }
        public virtual DbSet<StaffStatus> StaffStatuses { get; set; }
        public virtual DbSet<StatusDelivery> StatusDeliveries { get; set; }
        public virtual DbSet<StatusSession> StatusSessions { get; set; }
        public virtual DbSet<Storage> Storages { get; set; }
        public virtual DbSet<Suplier> Supliers { get; set; }
        public virtual DbSet<staff> staff { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-P17R4JP\\SQLEXPRESS;Database=SpaSalon;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.Idaccount);

                entity.HasIndex(e => e.Idstaff, "AccountsStaff")
                    .IsUnique();

                entity.Property(e => e.Idaccount).HasColumnName("IDAccount");

                entity.Property(e => e.Idstaff).HasColumnName("IDStaff");

                entity.Property(e => e.LoginStaff)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PasswordStaff)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdstaffNavigation)
                    .WithOne(p => p.Account)
                    .HasForeignKey<Account>(d => d.Idstaff)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Accounts_Staffs");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasKey(e => e.Idclient);

                entity.ToTable("Client");

                entity.Property(e => e.Idclient).HasColumnName("IDClient");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MiddleName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Sex)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Delivery>(entity =>
            {
                entity.HasKey(e => e.Iddelivey);

                entity.ToTable("Delivery");

                entity.Property(e => e.Iddelivey).HasColumnName("IDDelivey");

                entity.Property(e => e.Articul)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DateDelivery).HasColumnType("datetime");

                entity.Property(e => e.DateOrder).HasColumnType("datetime");

                entity.Property(e => e.Idstaff).HasColumnName("IDStaff");

                entity.Property(e => e.Idsupplier).HasColumnName("IDSupplier");

                entity.HasOne(d => d.IdStatusDeliveryNavigation)
                    .WithMany(p => p.Deliveries)
                    .HasForeignKey(d => d.IdStatusDelivery)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Delivery_StatusDelivery");

                entity.HasOne(d => d.IdstaffNavigation)
                    .WithMany(p => p.Deliveries)
                    .HasForeignKey(d => d.Idstaff)
                    .HasConstraintName("FK_Delivery_Staff");

                entity.HasOne(d => d.IdsupplierNavigation)
                    .WithMany(p => p.Deliveries)
                    .HasForeignKey(d => d.Idsupplier)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Delivery_Suplier");
            });

            modelBuilder.Entity<Material>(entity =>
            {
                entity.HasKey(e => e.Idmaterial)
                    .HasName("PK_Materials");

                entity.ToTable("Material");

                entity.Property(e => e.Idmaterial).HasColumnName("IDMaterial");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MaterialForProcedure>(entity =>
            {
                entity.HasKey(e => new { e.Idprocedure, e.Idmaterial });

                entity.ToTable("MaterialForProcedure");

                entity.Property(e => e.Idprocedure).HasColumnName("IDProcedure");

                entity.Property(e => e.Idmaterial).HasColumnName("IDMaterial");

                entity.HasOne(d => d.IdmaterialNavigation)
                    .WithMany(p => p.MaterialForProcedures)
                    .HasForeignKey(d => d.Idmaterial)
                    .HasConstraintName("FK_MaterialForProcedure_Materials");

                entity.HasOne(d => d.IdprocedureNavigation)
                    .WithMany(p => p.MaterialForProcedures)
                    .HasForeignKey(d => d.Idprocedure)
                    .HasConstraintName("FK_MaterialForProcedure_Procedures");
            });

            modelBuilder.Entity<MaterialInDelivery>(entity =>
            {
                entity.HasKey(e => new { e.Idmaterial, e.Iddelivery });

                entity.ToTable("MaterialInDelivery");

                entity.Property(e => e.Idmaterial).HasColumnName("IDMaterial");

                entity.Property(e => e.Iddelivery).HasColumnName("IDDelivery");

                entity.HasOne(d => d.IddeliveryNavigation)
                    .WithMany(p => p.MaterialInDeliveries)
                    .HasForeignKey(d => d.Iddelivery)
                    .HasConstraintName("FK_MaterialInDelivery_Delivery");

                entity.HasOne(d => d.IdmaterialNavigation)
                    .WithMany(p => p.MaterialInDeliveries)
                    .HasForeignKey(d => d.Idmaterial)
                    .HasConstraintName("FK_MaterialInDelivery_Materials");
            });

            modelBuilder.Entity<MaterialToStorage>(entity =>
            {
                entity.HasKey(e => e.Idmaterial)
                    .HasName("PK_MaterialToStorage_1");

                entity.ToTable("MaterialToStorage");

                entity.Property(e => e.Idmaterial)
                    
                    .HasColumnName("IDMaterial");

                entity.HasOne(d => d.IdmaterialNavigation)
                    .WithOne(p => p.MaterialToStorage)
                    .HasForeignKey<MaterialToStorage>(d => d.Idmaterial)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MaterialToStorage_Materials");
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.HasKey(e => e.Idpost);

                entity.ToTable("Post");

                entity.Property(e => e.Idpost).HasColumnName("IDPost");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.WorkSchedule)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Work_schedule");
            });

            modelBuilder.Entity<Procedure>(entity =>
            {
                entity.HasKey(e => e.Idprocedure);

                entity.Property(e => e.Idprocedure).HasColumnName("IDProcedure");

                entity.Property(e => e.Description)
                    .HasMaxLength(350)
                    .IsUnicode(false);

              

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ProcedureToPost>(entity =>
            {
                entity.HasKey(e => new { e.Idpost, e.Idprocedure });

                entity.ToTable("ProcedureToPost");

                entity.Property(e => e.Idpost).HasColumnName("IDPost");

                entity.Property(e => e.Idprocedure).HasColumnName("IDProcedure");

                entity.HasOne(d => d.IdpostNavigation)
                    .WithMany(p => p.ProcedureToPosts)
                    .HasForeignKey(d => d.Idpost)
                    .HasConstraintName("FK_ProcedureToPost_Posts");

                entity.HasOne(d => d.IdprocedureNavigation)
                    .WithMany(p => p.ProcedureToPosts)
                    .HasForeignKey(d => d.Idprocedure)
                    .HasConstraintName("FK_ProcedureToPost_Procedures");
            });

            modelBuilder.Entity<Session>(entity =>
            {
                entity.HasKey(e => e.Idsession);

                entity.Property(e => e.Idsession).HasColumnName("IDSession");

                entity.Property(e => e.DateOrder).HasColumnType("datetime");

                entity.Property(e => e.DateTime).HasColumnType("datetime");

                entity.Property(e => e.Idclient).HasColumnName("IDClient");

                entity.Property(e => e.Idprocedures).HasColumnName("IDProcedures");

                entity.Property(e => e.Idstaff).HasColumnName("IDStaff");

                entity.Property(e => e.Idstatus).HasColumnName("IDStatus");

                entity.HasOne(d => d.IdclientNavigation)
                    .WithMany(p => p.Sessions)
                    .HasForeignKey(d => d.Idclient)
                    .HasConstraintName("FK_Sessions_Client");

                entity.HasOne(d => d.IdproceduresNavigation)
                    .WithMany(p => p.Sessions)
                    .HasForeignKey(d => d.Idprocedures)
                    .HasConstraintName("FK_Sessions_Procedures");

                entity.HasOne(d => d.IdstaffNavigation)
                    .WithMany(p => p.Sessions)
                    .HasForeignKey(d => d.Idstaff)
                    .HasConstraintName("FK_Sessions_Staffs");

                entity.HasOne(d => d.IdstatusNavigation)
                    .WithMany(p => p.Sessions)
                    .HasForeignKey(d => d.Idstatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sessions_StatusSession");
            });

            modelBuilder.Entity<StaffStatus>(entity =>
            {
                entity.HasKey(e => e.IdstaffStatus);

                entity.ToTable("StaffStatus");

                entity.Property(e => e.IdstaffStatus)
                    .ValueGeneratedNever()
                    .HasColumnName("IDStaffStatus");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<StatusDelivery>(entity =>
            {
                entity.HasKey(e => e.Idstatus);

                entity.ToTable("StatusDelivery");

                entity.Property(e => e.Idstatus).HasColumnName("IDStatus");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<StatusSession>(entity =>
            {
                entity.HasKey(e => e.Idstatus);

                entity.ToTable("StatusSession");

                entity.Property(e => e.Idstatus)
                    .ValueGeneratedNever()
                    .HasColumnName("IDStatus");

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Storage>(entity =>
            {
                entity.HasKey(e => e.Idstorage);

                entity.ToTable("Storage");

                entity.Property(e => e.Idstorage).HasColumnName("IDStorage");

                entity.Property(e => e.NameStorage)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Suplier>(entity =>
            {
                entity.HasKey(e => e.Idsuplier);

                entity.ToTable("Suplier");

                entity.Property(e => e.Idsuplier).HasColumnName("IDSuplier");

                entity.Property(e => e.Adress)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<staff>(entity =>
            {
                entity.HasKey(e => e.Idstaff);

                entity.ToTable("Staff");

                entity.Property(e => e.Idstaff)
                    .ValueGeneratedNever()
                    .HasColumnName("IDStaff");

                entity.Property(e => e.Adress)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Idpost).HasColumnName("IDPost");

                entity.Property(e => e.IdstatusStaff).HasColumnName("IDStatusStaff");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MiddleName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Sex)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdpostNavigation)
                    .WithMany(p => p.staff)
                    .HasForeignKey(d => d.Idpost)
                    .HasConstraintName("FK_Staff_Post");

                entity.HasOne(d => d.IdstatusStaffNavigation)
                    .WithMany(p => p.staff)
                    .HasForeignKey(d => d.IdstatusStaff)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Staff_StaffStatus");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
