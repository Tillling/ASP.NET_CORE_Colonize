using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Colonize.Website.Data.Migrations
{
    public partial class AddSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Voyage_Destination_DestinationId",
                table: "Voyage");

            migrationBuilder.DropForeignKey(
                name: "FK_Voyage_Ship_ShipId",
                table: "Voyage");

            migrationBuilder.AlterColumn<int>(
                name: "ShipId",
                table: "Voyage",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DestinationId",
                table: "Voyage",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Destination",
                columns: new[] { "Id", "Description", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { 1, "Luna", "https://via.placeholder.com/1280x440png?text=Picture+of+the+moon", "Moon" },
                    { 2, "The Red Planet", "https://via.placeholder.com/1280x440png?text=planet", "Mars" }
                });

            migrationBuilder.InsertData(
                table: "Ship",
                columns: new[] { "Id", "Description", "ImageUrl", "Name", "PassengerCapacity" },
                values: new object[,]
                {
                    { 1, "A standard commercial Rocket for interplanetary travel", "https://via.placeholder.com/1280x440png?text=moonshot", "Moonshot", 1000 },
                    { 2, "A Mars Rocket", "https://via.placeholder.com/1280x440png?text=mars+rocket", "Mars Rocket", 2000 }
                });

            migrationBuilder.InsertData(
                table: "Voyage",
                columns: new[] { "Id", "ArrivedAt", "DepartureAt", "DestinationId", "ShipId" },
                values: new object[] { 1, new DateTime(2020, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 });

            migrationBuilder.InsertData(
                table: "Voyage",
                columns: new[] { "Id", "ArrivedAt", "DepartureAt", "DestinationId", "ShipId" },
                values: new object[] { 2, new DateTime(2029, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2029, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2 });

            migrationBuilder.AddForeignKey(
                name: "FK_Voyage_Destination_DestinationId",
                table: "Voyage",
                column: "DestinationId",
                principalTable: "Destination",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Voyage_Ship_ShipId",
                table: "Voyage",
                column: "ShipId",
                principalTable: "Ship",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Voyage_Destination_DestinationId",
                table: "Voyage");

            migrationBuilder.DropForeignKey(
                name: "FK_Voyage_Ship_ShipId",
                table: "Voyage");

            migrationBuilder.DeleteData(
                table: "Voyage",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Voyage",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Destination",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Destination",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Ship",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Ship",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AlterColumn<int>(
                name: "ShipId",
                table: "Voyage",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "DestinationId",
                table: "Voyage",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Voyage_Destination_DestinationId",
                table: "Voyage",
                column: "DestinationId",
                principalTable: "Destination",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Voyage_Ship_ShipId",
                table: "Voyage",
                column: "ShipId",
                principalTable: "Ship",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
