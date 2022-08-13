using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Origin.API.Migrations
{
    public partial class DataTypesOperations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TypesOperations",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Balance" });

            migrationBuilder.InsertData(
                table: "TypesOperations",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Retiro" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TypesOperations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TypesOperations",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
