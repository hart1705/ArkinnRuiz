using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AR.Persistence.Migrations
{
    public partial class RetentionsChild : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RetentionApproval",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Position = table.Column<string>(nullable: true),
                    Signiture = table.Column<string>(nullable: true),
                    MyProperty = table.Column<int>(nullable: false),
                    ApprovalType = table.Column<int>(nullable: false),
                    RetentionId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RetentionApproval", x => x.Id);
                    table.ForeignKey(
                        name: "RetentionA",
                        column: x => x.RetentionId,
                        principalTable: "Retentions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RetentionCollectionUnitPlan",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    SoldDate = table.Column<DateTime>(nullable: true),
                    ReservedDate = table.Column<DateTime>(nullable: true),
                    PaymentPlan = table.Column<string>(nullable: true),
                    FirstInstallment = table.Column<DateTime>(nullable: true),
                    LastInstallment = table.Column<DateTime>(nullable: true),
                    NoSettledInstallments = table.Column<int>(nullable: false),
                    NoOfInstallments = table.Column<int>(nullable: false),
                    CollectedAmount = table.Column<decimal>(nullable: false),
                    TotalCollectedAmount = table.Column<decimal>(nullable: false),
                    CollectedPercent = table.Column<decimal>(nullable: false),
                    DueAmount = table.Column<decimal>(nullable: false),
                    RemainingAmount = table.Column<decimal>(nullable: false),
                    CollectionType = table.Column<int>(nullable: false),
                    RetentionId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RetentionCollectionUnitPlan", x => x.Id);
                    table.ForeignKey(
                        name: "RetentionC",
                        column: x => x.RetentionId,
                        principalTable: "Retentions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RetentionUnit",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    Project = table.Column<string>(nullable: true),
                    UnitNo = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    GP = table.Column<decimal>(nullable: false),
                    GPValue = table.Column<decimal>(nullable: false),
                    RetentionId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RetentionUnit", x => x.Id);
                    table.ForeignKey(
                        name: "RetentionU",
                        column: x => x.RetentionId,
                        principalTable: "Retentions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RetentionWaiver",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    InstallementAmount = table.Column<decimal>(nullable: false),
                    ServiceChargeAmount = table.Column<decimal>(nullable: false),
                    BearingCost = table.Column<decimal>(nullable: false),
                    RetentionId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RetentionWaiver", x => x.Id);
                    table.ForeignKey(
                        name: "RetentionW",
                        column: x => x.RetentionId,
                        principalTable: "Retentions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RetentionApproval_RetentionId",
                table: "RetentionApproval",
                column: "RetentionId");

            migrationBuilder.CreateIndex(
                name: "IX_RetentionCollectionUnitPlan_RetentionId",
                table: "RetentionCollectionUnitPlan",
                column: "RetentionId");

            migrationBuilder.CreateIndex(
                name: "IX_RetentionUnit_RetentionId",
                table: "RetentionUnit",
                column: "RetentionId");

            migrationBuilder.CreateIndex(
                name: "IX_RetentionWaiver_RetentionId",
                table: "RetentionWaiver",
                column: "RetentionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RetentionApproval");

            migrationBuilder.DropTable(
                name: "RetentionCollectionUnitPlan");

            migrationBuilder.DropTable(
                name: "RetentionUnit");

            migrationBuilder.DropTable(
                name: "RetentionWaiver");
        }
    }
}
