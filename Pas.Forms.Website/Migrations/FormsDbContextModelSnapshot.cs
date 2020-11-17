﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Pas.Forms.Website.Data;

namespace Pas.Forms.Website.Migrations
{
    [DbContext(typeof(FormsDbContext))]
    partial class FormsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Pas.Forms.Website.Data.Db", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ConnectionString")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsValid")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Dbs");
                });

            modelBuilder.Entity("Pas.Forms.Website.Data.DbField", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("DbTableId")
                        .HasColumnType("int");

                    b.Property<string>("Field")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ForeignField")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ForeignTable")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("InsertIgnore")
                        .HasColumnType("bit");

                    b.Property<bool>("IsForeignKey")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("UpdateIgnore")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("DbTableId");

                    b.ToTable("DbFields");
                });

            modelBuilder.Entity("Pas.Forms.Website.Data.DbSource", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("DbId")
                        .HasColumnType("int");

                    b.Property<string>("Fields")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Remark")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sql")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DbId");

                    b.ToTable("DbSources");
                });

            modelBuilder.Entity("Pas.Forms.Website.Data.DbTable", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("DbId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DbId");

                    b.ToTable("DbTables");
                });

            modelBuilder.Entity("Pas.Forms.Website.Data.Form", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("DbTableId")
                        .HasColumnType("int");

                    b.Property<string>("Fields")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Remark")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DbTableId");

                    b.ToTable("Forms");
                });

            modelBuilder.Entity("Pas.Forms.Website.Data.FormField", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<bool>("Auto")
                        .HasColumnType("bit");

                    b.Property<string>("DataSource")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DataSourceType")
                        .HasColumnType("int");

                    b.Property<string>("FieldName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FiledId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FormId")
                        .HasColumnType("int");

                    b.Property<string>("Label")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Options")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Params")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Placeholder")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Readonly")
                        .HasColumnType("bit");

                    b.Property<bool>("Required")
                        .HasColumnType("bit");

                    b.Property<string>("TableId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TableName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TextField")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ValueField")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("FormFields");
                });

            modelBuilder.Entity("Pas.Forms.Website.Data.FormTable", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("DbTableId")
                        .HasColumnType("int");

                    b.Property<int>("FormId")
                        .HasColumnType("int");

                    b.Property<string>("MasterField")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SubField")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DbTableId");

                    b.HasIndex("FormId");

                    b.ToTable("FormTables");
                });

            modelBuilder.Entity("Pas.Forms.Website.Data.DbField", b =>
                {
                    b.HasOne("Pas.Forms.Website.Data.DbTable", null)
                        .WithMany("Fields")
                        .HasForeignKey("DbTableId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Pas.Forms.Website.Data.DbSource", b =>
                {
                    b.HasOne("Pas.Forms.Website.Data.Db", "Db")
                        .WithMany()
                        .HasForeignKey("DbId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Db");
                });

            modelBuilder.Entity("Pas.Forms.Website.Data.DbTable", b =>
                {
                    b.HasOne("Pas.Forms.Website.Data.Db", "Db")
                        .WithMany("Tables")
                        .HasForeignKey("DbId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Db");
                });

            modelBuilder.Entity("Pas.Forms.Website.Data.Form", b =>
                {
                    b.HasOne("Pas.Forms.Website.Data.DbTable", "DbTable")
                        .WithMany()
                        .HasForeignKey("DbTableId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DbTable");
                });

            modelBuilder.Entity("Pas.Forms.Website.Data.FormTable", b =>
                {
                    b.HasOne("Pas.Forms.Website.Data.DbTable", "DbTable")
                        .WithMany()
                        .HasForeignKey("DbTableId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Pas.Forms.Website.Data.Form", "Form")
                        .WithMany("FormTables")
                        .HasForeignKey("FormId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("DbTable");

                    b.Navigation("Form");
                });

            modelBuilder.Entity("Pas.Forms.Website.Data.Db", b =>
                {
                    b.Navigation("Tables");
                });

            modelBuilder.Entity("Pas.Forms.Website.Data.DbTable", b =>
                {
                    b.Navigation("Fields");
                });

            modelBuilder.Entity("Pas.Forms.Website.Data.Form", b =>
                {
                    b.Navigation("FormTables");
                });
#pragma warning restore 612, 618
        }
    }
}
