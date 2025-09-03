using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Leasing.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updateLeasingRecord : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LeasingRecords_Owners_OwnerId",
                schema: "Leasing",
                table: "LeasingRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_LeasingRecords_Tenants_TenantId",
                schema: "Leasing",
                table: "LeasingRecords");

            migrationBuilder.DropIndex(
                name: "IX_LeasingRecords_OwnerId",
                schema: "Leasing",
                table: "LeasingRecords");

            migrationBuilder.DropIndex(
                name: "IX_LeasingRecords_TenantId",
                schema: "Leasing",
                table: "LeasingRecords");

            migrationBuilder.DropColumn(
                name: "MonthlyRent",
                schema: "Leasing",
                table: "LeasingRecords");

            migrationBuilder.RenameColumn(
                name: "LeaseStartDate",
                schema: "Leasing",
                table: "LeasingRecords",
                newName: "LeaseStart");

            migrationBuilder.RenameColumn(
                name: "LeaseEndDate",
                schema: "Leasing",
                table: "LeasingRecords",
                newName: "LeaseEnd");

            migrationBuilder.AddColumn<decimal>(
                name: "MonthlyRentAmount",
                schema: "Leasing",
                table: "LeasingRecords",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "MonthlyRentCurrency",
                schema: "Leasing",
                table: "LeasingRecords",
                type: "varchar(3)",
                unicode: false,
                maxLength: 3,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                schema: "Leasing",
                table: "LeasingRecords",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MonthlyRentAmount",
                schema: "Leasing",
                table: "LeasingRecords");

            migrationBuilder.DropColumn(
                name: "MonthlyRentCurrency",
                schema: "Leasing",
                table: "LeasingRecords");

            migrationBuilder.DropColumn(
                name: "Status",
                schema: "Leasing",
                table: "LeasingRecords");

            migrationBuilder.RenameColumn(
                name: "LeaseStart",
                schema: "Leasing",
                table: "LeasingRecords",
                newName: "LeaseStartDate");

            migrationBuilder.RenameColumn(
                name: "LeaseEnd",
                schema: "Leasing",
                table: "LeasingRecords",
                newName: "LeaseEndDate");

            migrationBuilder.AddColumn<double>(
                name: "MonthlyRent",
                schema: "Leasing",
                table: "LeasingRecords",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateIndex(
                name: "IX_LeasingRecords_OwnerId",
                schema: "Leasing",
                table: "LeasingRecords",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_LeasingRecords_TenantId",
                schema: "Leasing",
                table: "LeasingRecords",
                column: "TenantId");

            migrationBuilder.AddForeignKey(
                name: "FK_LeasingRecords_Owners_OwnerId",
                schema: "Leasing",
                table: "LeasingRecords",
                column: "OwnerId",
                principalSchema: "Leasing",
                principalTable: "Owners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LeasingRecords_Tenants_TenantId",
                schema: "Leasing",
                table: "LeasingRecords",
                column: "TenantId",
                principalSchema: "Leasing",
                principalTable: "Tenants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
