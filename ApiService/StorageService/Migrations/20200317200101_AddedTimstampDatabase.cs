using Microsoft.EntityFrameworkCore.Migrations;

namespace StorageService.Migrations
{
    public partial class AddedTimstampDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "Timestamp",
                table: "Locations",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "Timestamp",
                table: "Batteries",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "Timestamp",
                table: "Apiis",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "Timestamp",
                table: "Ambients",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Timestamp",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "Timestamp",
                table: "Batteries");

            migrationBuilder.DropColumn(
                name: "Timestamp",
                table: "Apiis");

            migrationBuilder.DropColumn(
                name: "Timestamp",
                table: "Ambients");
        }
    }
}
