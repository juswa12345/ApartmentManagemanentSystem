using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Billing.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Billing");

            migrationBuilder.CreateTable(
                name: "Payments",
                schema: "Billing",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UnitID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    DateOfPayment = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    NextDuePaymentDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    NextDueAmountToPay = table.Column<double>(type: "float", nullable: false),
                    isNextDuePaid = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Payments",
                schema: "Billing");
        }
    }
}
