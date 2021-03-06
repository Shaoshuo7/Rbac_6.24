// <auto-generated />
using System;
using ClassLibraryEntityFrameWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ClassLibraryEntityFrameWork.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20220705141107_705-1")]
    partial class _7051
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ClassLibraryEntityFrameWork.Admin", b =>
                {
                    b.Property<int>("AdminId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AdmEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AdmName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AdmPassWord")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CreateId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<bool>("IsLock")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastLoginIP")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AdminId");

                    b.ToTable("Admin");
                });

            modelBuilder.Entity("ClassLibraryEntityFrameWork.AdminAndRole", b =>
                {
                    b.Property<int>("AdminAndRoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AdminId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("AdminAndRoleId");

                    b.HasIndex("AdminId");

                    b.HasIndex("RoleId");

                    b.ToTable("AdminAndRole");
                });

            modelBuilder.Entity("ClassLibraryEntityFrameWork.Meun", b =>
                {
                    b.Property<int>("MeunId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CreateId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDefault")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<int>("MeId")
                        .HasColumnType("int");

                    b.Property<string>("MeunLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MeunName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("MeunId");

                    b.ToTable("Meun");
                });

            modelBuilder.Entity("ClassLibraryEntityFrameWork.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CreateId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("RoleName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoleId");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("ClassLibraryEntityFrameWork.RoleAndMeun", b =>
                {
                    b.Property<int>("RoleAndMeunId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MeunId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("RoleAndMeunId");

                    b.HasIndex("MeunId");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleAndMeun");
                });

            modelBuilder.Entity("ClassLibraryEntityFrameWork.AdminAndRole", b =>
                {
                    b.HasOne("ClassLibraryEntityFrameWork.Admin", null)
                        .WithMany("AdminAndRole")
                        .HasForeignKey("AdminId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ClassLibraryEntityFrameWork.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ClassLibraryEntityFrameWork.RoleAndMeun", b =>
                {
                    b.HasOne("ClassLibraryEntityFrameWork.Meun", null)
                        .WithMany()
                        .HasForeignKey("MeunId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ClassLibraryEntityFrameWork.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ClassLibraryEntityFrameWork.Admin", b =>
                {
                    b.Navigation("AdminAndRole");
                });
#pragma warning restore 612, 618
        }
    }
}
