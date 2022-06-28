using Microsoft.EntityFrameworkCore.Migrations;

namespace ClassLibraryEntityFrameWork.Migrations
{
    public partial class Init628 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDefault",
                table: "Meun",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDefault",
                table: "Meun");
        }
    }
}
