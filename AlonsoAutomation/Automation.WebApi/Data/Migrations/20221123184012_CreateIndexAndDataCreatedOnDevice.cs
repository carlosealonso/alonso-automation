using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Automation.WebApi.Data.Migrations
{
    public partial class CreateIndexAndDataCreatedOnDevice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "LastCommunication",
                table: "Devices",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Humidities_DateCreated",
                table: "Humidities",
                column: "DateCreated");

            migrationBuilder.CreateIndex(
                name: "IX_Humidities_DeviceId",
                table: "Humidities",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_Devices_DeviceExternalId",
                table: "Devices",
                column: "DeviceExternalId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Humidities_DateCreated",
                table: "Humidities");

            migrationBuilder.DropIndex(
                name: "IX_Humidities_DeviceId",
                table: "Humidities");

            migrationBuilder.DropIndex(
                name: "IX_Devices_DeviceExternalId",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "LastCommunication",
                table: "Devices");
        }
    }
}
