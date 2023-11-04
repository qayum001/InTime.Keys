using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InTime.Keys.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class BidAndTimeSlotInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Key",
                table: "Key");

            migrationBuilder.DropColumn(
                name: "AudienceId",
                table: "Key");

            migrationBuilder.DropColumn(
                name: "AudienceName",
                table: "Key");

            migrationBuilder.RenameTable(
                name: "Key",
                newName: "Keys");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Keys",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Keys",
                table: "Keys",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Bids",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BidStatus = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bids", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TimeSlots",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeSlots", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bids");

            migrationBuilder.DropTable(
                name: "TimeSlots");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Keys",
                table: "Keys");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Keys");

            migrationBuilder.RenameTable(
                name: "Keys",
                newName: "Key");

            migrationBuilder.AddColumn<Guid>(
                name: "AudienceId",
                table: "Key",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "AudienceName",
                table: "Key",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Key",
                table: "Key",
                column: "Id");
        }
    }
}
