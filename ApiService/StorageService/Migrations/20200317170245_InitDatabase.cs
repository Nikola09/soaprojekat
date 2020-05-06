using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StorageService.Migrations
{
    public partial class InitDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ambients",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Lumix = table.Column<float>(nullable: false),
                    Temperature = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ambients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Apiis",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Still = table.Column<int>(nullable: false),
                    OnFoot = table.Column<int>(nullable: false),
                    Walking = table.Column<int>(nullable: false),
                    Running = table.Column<int>(nullable: false),
                    OnBicycle = table.Column<int>(nullable: false),
                    InVehicle = table.Column<int>(nullable: false),
                    Tilting = table.Column<int>(nullable: false),
                    Unknown = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apiis", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Batteries",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Level = table.Column<int>(nullable: false),
                    Temperature = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Batteries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Accuracy = table.Column<float>(nullable: false),
                    Latitude = table.Column<double>(nullable: false),
                    Longitude = table.Column<double>(nullable: false),
                    Altitude = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ambients");

            migrationBuilder.DropTable(
                name: "Apiis");

            migrationBuilder.DropTable(
                name: "Batteries");

            migrationBuilder.DropTable(
                name: "Locations");
        }
    }
}
