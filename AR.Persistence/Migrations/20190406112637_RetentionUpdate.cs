using Microsoft.EntityFrameworkCore.Migrations;

namespace AR.Persistence.Migrations
{
    public partial class RetentionUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CollectionType",
                table: "RetentionCollectionUnitPlan");

            migrationBuilder.DropColumn(
                name: "MyProperty",
                table: "RetentionApproval");

            migrationBuilder.AddColumn<int>(
                name: "UnitType",
                table: "RetentionUnit",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UnitType",
                table: "RetentionCollectionUnitPlan",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UnitType",
                table: "RetentionUnit");

            migrationBuilder.DropColumn(
                name: "UnitType",
                table: "RetentionCollectionUnitPlan");

            migrationBuilder.AddColumn<int>(
                name: "CollectionType",
                table: "RetentionCollectionUnitPlan",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MyProperty",
                table: "RetentionApproval",
                nullable: false,
                defaultValue: 0);
        }
    }
}
