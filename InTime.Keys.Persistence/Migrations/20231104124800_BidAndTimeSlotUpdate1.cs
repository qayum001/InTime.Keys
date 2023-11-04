using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InTime.Keys.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class BidAndTimeSlotUpdate1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TimeSlots",
                table: "TimeSlots");

            migrationBuilder.RenameTable(
                name: "TimeSlots",
                newName: "TimeSlot");

            migrationBuilder.AddColumn<Guid>(
                name: "AudienceId",
                table: "Keys",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "AudienceName",
                table: "Keys",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Bids",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "KeyId",
                table: "Bids",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "LessonNumber",
                table: "Bids",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Bids",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "TimeSlot",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "LessonNumber",
                table: "TimeSlot",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TimeSlot",
                table: "TimeSlot",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TimeSlot",
                table: "TimeSlot");

            migrationBuilder.DropColumn(
                name: "AudienceId",
                table: "Keys");

            migrationBuilder.DropColumn(
                name: "AudienceName",
                table: "Keys");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Bids");

            migrationBuilder.DropColumn(
                name: "KeyId",
                table: "Bids");

            migrationBuilder.DropColumn(
                name: "LessonNumber",
                table: "Bids");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Bids");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "TimeSlot");

            migrationBuilder.DropColumn(
                name: "LessonNumber",
                table: "TimeSlot");

            migrationBuilder.RenameTable(
                name: "TimeSlot",
                newName: "TimeSlots");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TimeSlots",
                table: "TimeSlots",
                column: "Id");
        }
    }
}
