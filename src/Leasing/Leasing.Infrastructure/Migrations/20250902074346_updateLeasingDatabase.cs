using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Leasing.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updateLeasingDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "OwnerId",
                schema: "Leasing",
                table: "LeasingRecords",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_LeasingRecords_OwnerId",
                schema: "Leasing",
                table: "LeasingRecords",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_LeasingRecords_Owners_OwnerId",
                schema: "Leasing",
                table: "LeasingRecords",
                column: "OwnerId",
                principalSchema: "Leasing",
                principalTable: "Owners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LeasingRecords_Owners_OwnerId",
                schema: "Leasing",
                table: "LeasingRecords");

            migrationBuilder.DropIndex(
                name: "IX_LeasingRecords_OwnerId",
                schema: "Leasing",
                table: "LeasingRecords");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                schema: "Leasing",
                table: "LeasingRecords");
        }
    }
}
