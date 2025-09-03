using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Leasing.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class udpatedatabasebasedonthechanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UnitId",
                schema: "Leasing",
                table: "Tenants",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tenants_UnitId",
                schema: "Leasing",
                table: "Tenants",
                column: "UnitId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Tenants_Units_UnitId",
                schema: "Leasing",
                table: "Tenants",
                column: "UnitId",
                principalSchema: "Leasing",
                principalTable: "Units",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LeasingRecords_Owners_OwnerId",
                schema: "Leasing",
                table: "LeasingRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_LeasingRecords_Tenants_TenantId",
                schema: "Leasing",
                table: "LeasingRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_Tenants_Units_UnitId",
                schema: "Leasing",
                table: "Tenants");

            migrationBuilder.DropIndex(
                name: "IX_Tenants_UnitId",
                schema: "Leasing",
                table: "Tenants");

            migrationBuilder.DropIndex(
                name: "IX_LeasingRecords_OwnerId",
                schema: "Leasing",
                table: "LeasingRecords");

            migrationBuilder.DropIndex(
                name: "IX_LeasingRecords_TenantId",
                schema: "Leasing",
                table: "LeasingRecords");

            migrationBuilder.DropColumn(
                name: "UnitId",
                schema: "Leasing",
                table: "Tenants");
        }
    }
}
