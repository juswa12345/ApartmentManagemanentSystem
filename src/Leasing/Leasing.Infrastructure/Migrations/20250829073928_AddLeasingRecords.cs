using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Leasing.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddLeasingRecords : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LeasingRecords",
                schema: "Leasing",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UnitId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LeaseStartDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LeaseEndDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    MonthlyRent = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeasingRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeasingRecords_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalSchema: "Leasing",
                        principalTable: "Tenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LeasingRecords_Units_UnitId",
                        column: x => x.UnitId,
                        principalSchema: "Leasing",
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LeasingRecords_TenantId",
                schema: "Leasing",
                table: "LeasingRecords",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_LeasingRecords_UnitId",
                schema: "Leasing",
                table: "LeasingRecords",
                column: "UnitId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LeasingRecords",
                schema: "Leasing");
        }
    }
}
