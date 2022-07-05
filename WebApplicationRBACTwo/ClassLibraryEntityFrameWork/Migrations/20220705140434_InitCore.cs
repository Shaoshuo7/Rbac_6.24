using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ClassLibraryEntityFrameWork.Migrations
{
    public partial class InitCore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    AdminId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdmName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdmPassWord = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdmEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastLoginIP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsLock = table.Column<bool>(type: "bit", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateId = table.Column<int>(type: "int", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.AdminId);
                });

            migrationBuilder.CreateTable(
                name: "Meun",
                columns: table => new
                {
                    MeunId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MeunName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MeId = table.Column<int>(type: "int", nullable: false),
                    MeunLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateId = table.Column<int>(type: "int", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meun", x => x.MeunId);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateId = table.Column<int>(type: "int", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "AdminAndRole",
                columns: table => new
                {
                    AdminAndRoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdminId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminAndRole", x => x.AdminAndRoleId);
                    table.ForeignKey(
                        name: "FK_AdminAndRole_Admin_AdminId",
                        column: x => x.AdminId,
                        principalTable: "Admin",
                        principalColumn: "AdminId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdminAndRole_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleAndMeun",
                columns: table => new
                {
                    RoleAndMeunId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    MeunId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleAndMeun", x => x.RoleAndMeunId);
                    table.ForeignKey(
                        name: "FK_RoleAndMeun_Meun_MeunId",
                        column: x => x.MeunId,
                        principalTable: "Meun",
                        principalColumn: "MeunId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleAndMeun_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdminAndRole_AdminId",
                table: "AdminAndRole",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_AdminAndRole_RoleId",
                table: "AdminAndRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleAndMeun_MeunId",
                table: "RoleAndMeun",
                column: "MeunId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleAndMeun_RoleId",
                table: "RoleAndMeun",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminAndRole");

            migrationBuilder.DropTable(
                name: "RoleAndMeun");

            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "Meun");

            migrationBuilder.DropTable(
                name: "Role");
        }
    }
}
