using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JokeApi.Migrations
{
    public partial class AddedIdentityRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a55073d0-1118-4c7e-8a3d-f17e84de9b54", "c897a49e-94db-48bd-90d7-94c16bdc3f2c", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b6056bc7-b986-47b9-b4a3-d3203f4cd785", "faeb00e3-a3b4-4cb1-963b-f569a485790c", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a55073d0-1118-4c7e-8a3d-f17e84de9b54");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b6056bc7-b986-47b9-b4a3-d3203f4cd785");
        }
    }
}
