using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Origin.API.Migrations
{
    public partial class DataCard : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cards",
                columns: new[] { "Id", "Balance", "DueDate", "Lock", "Number", "Pin" },
                values: new object[] { 1, 30000.0, new DateTime(2023, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "yJWsD3xDtulOjqR4Anel/hX6z8+bSlJi9FVad428Rn8=", "0HtYz7AMjUMM9M0KqQDPDQ==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
