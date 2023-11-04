using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InTime.Keys.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class BidAndTimeSlotUpdate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Bids");

            migrationBuilder.DropColumn(
                name: "LessonNumber",
                table: "Bids");

            migrationBuilder.AddColumn<Guid>(
                name: "TimeSlotId",
                table: "Bids",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Bids_KeyId",
                table: "Bids",
                column: "KeyId");

            migrationBuilder.CreateIndex(
                name: "IX_Bids_TimeSlotId",
                table: "Bids",
                column: "TimeSlotId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bids_Keys_KeyId",
                table: "Bids",
                column: "KeyId",
                principalTable: "Keys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bids_TimeSlot_TimeSlotId",
                table: "Bids",
                column: "TimeSlotId",
                principalTable: "TimeSlot",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bids_Keys_KeyId",
                table: "Bids");

            migrationBuilder.DropForeignKey(
                name: "FK_Bids_TimeSlot_TimeSlotId",
                table: "Bids");

            migrationBuilder.DropIndex(
                name: "IX_Bids_KeyId",
                table: "Bids");

            migrationBuilder.DropIndex(
                name: "IX_Bids_TimeSlotId",
                table: "Bids");

            migrationBuilder.DropColumn(
                name: "TimeSlotId",
                table: "Bids");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Bids",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "LessonNumber",
                table: "Bids",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
