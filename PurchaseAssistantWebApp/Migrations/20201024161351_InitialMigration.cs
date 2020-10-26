using Microsoft.EntityFrameworkCore.Migrations;

namespace PurchaseAssistantWebApp.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CallSetupRequest",
                columns: table => new
                {
                    RequestId = table.Column<string>(nullable: false),
                    CoustomerName = table.Column<string>(nullable: true),
                    Organisation = table.Column<string>(nullable: true),
                    Region = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    SelectedModels = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CallSetupRequest", x => x.RequestId);
                });

            migrationBuilder.CreateTable(
                name: "Models",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductName = table.Column<string>(nullable: true),
                    ProductKey = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Price = table.Column<string>(nullable: true),
                    Weight = table.Column<double>(nullable: false),
                    Portable = table.Column<bool>(nullable: false),
                    ScreenSize = table.Column<double>(nullable: false),
                    TouchScreenSupport = table.Column<bool>(nullable: false),
                    MonitorResolution = table.Column<string>(nullable: true),
                    BatterySupport = table.Column<string>(nullable: true),
                    MultiPatientSupport = table.Column<string>(nullable: true),
                    BpCheck = table.Column<string>(nullable: true),
                    HeartRateCheck = table.Column<string>(nullable: true),
                    EcgCheck = table.Column<string>(nullable: true),
                    SpO2Check = table.Column<string>(nullable: true),
                    TemperatureCheck = table.Column<string>(nullable: true),
                    CardiacOutputCheck = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Models", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalesRepresentatives",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    DepartmentRegion = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesRepresentatives", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserName = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Organisation = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserName);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CallSetupRequest");

            migrationBuilder.DropTable(
                name: "Models");

            migrationBuilder.DropTable(
                name: "SalesRepresentatives");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
