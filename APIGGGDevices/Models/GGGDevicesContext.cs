using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace APIGGGDevices.Models
{
    public partial class GGGDevicesContext : DbContext
    {
        public GGGDevicesContext()
        {
        }

        public GGGDevicesContext(DbContextOptions<GGGDevicesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AudioGroup> AudioGroups { get; set; } = null!;
        public virtual DbSet<ContentGroup> ContentGroups { get; set; } = null!;
        public virtual DbSet<Device> Devices { get; set; } = null!;
        public virtual DbSet<Group> Groups { get; set; } = null!;
        public virtual DbSet<PlaylistTime> PlaylistTimes { get; set; } = null!;
        public virtual DbSet<SiteMapGroup> SiteMapGroups { get; set; } = null!;
        public virtual DbSet<TotalScenario> TotalScenarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-EI91MQN;Database=GGGDevices;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AudioGroup>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.DataNumber).HasMaxLength(50);

                entity.Property(e => e.UpdateAt).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<ContentGroup>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.DataNumber).HasMaxLength(50);

                entity.Property(e => e.GroupId).HasColumnName("GroupID");

                entity.Property(e => e.TypeLcd).HasColumnName("TypeLCD");

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.ContentGroups)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("FK_ContentGroups_Groups");

                entity.HasMany(d => d.PlaylistTimes)
                    .WithMany(p => p.ContentGroups)
                    .UsingEntity<Dictionary<string, object>>(
                        "ContentTime",
                        l => l.HasOne<PlaylistTime>().WithMany().HasForeignKey("PlaylistTimeId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_ContentTimes_PlaylistTimes"),
                        r => r.HasOne<ContentGroup>().WithMany().HasForeignKey("ContentGroupId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_ContentTimes_ContentGroups"),
                        j =>
                        {
                            j.HasKey("ContentGroupId", "PlaylistTimeId");

                            j.ToTable("ContentTimes");

                            j.IndexerProperty<int>("ContentGroupId").HasColumnName("ContentGroupID");

                            j.IndexerProperty<int>("PlaylistTimeId").HasColumnName("PlaylistTimeID");
                        });
            });

            modelBuilder.Entity<Device>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.Imei).HasColumnName("IMEI");

                entity.Property(e => e.TotalScenarioId).HasColumnName("TotalScenarioID");

                entity.Property(e => e.TypeId).HasColumnName("TypeID");

                entity.HasOne(d => d.TotalScenario)
                    .WithMany(p => p.Devices)
                    .HasForeignKey(d => d.TotalScenarioId)
                    .HasConstraintName("FK_Devices_TotalScenarios");
            });

            modelBuilder.Entity<Group>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ParentId).HasColumnName("ParentID");

                entity.HasMany(d => d.Devices)
                    .WithMany(p => p.Groups)
                    .UsingEntity<Dictionary<string, object>>(
                        "GroupDevice",
                        l => l.HasOne<Device>().WithMany().HasForeignKey("DeviceId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_GroupDevice_Devices"),
                        r => r.HasOne<Group>().WithMany().HasForeignKey("GroupId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_GroupDevice_Groups1"),
                        j =>
                        {
                            j.HasKey("GroupId", "DeviceId");

                            j.ToTable("GroupDevice");

                            j.IndexerProperty<int>("GroupId").HasColumnName("GroupID");

                            j.IndexerProperty<int>("DeviceId").HasColumnName("DeviceID");
                        });
            });

            modelBuilder.Entity<PlaylistTime>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.GroupId).HasColumnName("GroupID");

                entity.Property(e => e.TypeLcd).HasColumnName("TypeLCD");

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.PlaylistTimes)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("FK_PlaylistTimes_Groups");

                entity.HasMany(d => d.TotalScenarios)
                    .WithMany(p => p.PlaylistTimes)
                    .UsingEntity<Dictionary<string, object>>(
                        "TotalTime",
                        l => l.HasOne<TotalScenario>().WithMany().HasForeignKey("TotalScenarioId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_TotalTime_TotalScenarios"),
                        r => r.HasOne<PlaylistTime>().WithMany().HasForeignKey("PlaylistTimeId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_TotalTime_PlaylistTimes"),
                        j =>
                        {
                            j.HasKey("PlaylistTimeId", "TotalScenarioId");

                            j.ToTable("TotalTime");

                            j.IndexerProperty<int>("PlaylistTimeId").HasColumnName("PlaylistTimeID");

                            j.IndexerProperty<int>("TotalScenarioId").HasColumnName("TotalScenarioID");
                        });
            });

            modelBuilder.Entity<SiteMapGroup>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.GroupId).HasColumnName("GroupID");

                entity.Property(e => e.SiteMapId).HasColumnName("SiteMapID");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.SiteMapGroups)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("FK_SiteMapGroups_Groups");
            });

            modelBuilder.Entity<TotalScenario>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AudioGroupId).HasColumnName("AudioGroupID");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.DataNumber).HasMaxLength(50);

                entity.Property(e => e.GroupId).HasColumnName("GroupID");

                entity.Property(e => e.TypeLcd).HasColumnName("TypeLCD");

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.AudioGroup)
                    .WithMany(p => p.TotalScenarios)
                    .HasForeignKey(d => d.AudioGroupId)
                    .HasConstraintName("FK_TotalScenarios_AudioGroups");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.TotalScenarios)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("FK_TotalScenarios_Groups");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
