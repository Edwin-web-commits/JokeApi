using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JokeApi.Migrations
{
    public partial class SeededJokesCommentsAndUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "username" },
                values: new object[] { 1, "edwin@bbd.co.za" });

            migrationBuilder.InsertData(
                table: "Joke",
                columns: new[] { "Id", "Body", "UserId" },
                values: new object[] { 1, "First Joke", 1 });

            migrationBuilder.InsertData(
                table: "Joke",
                columns: new[] { "Id", "Body", "UserId" },
                values: new object[] { 2, "Second Joke", 1 });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Body", "JokeId", "UserId" },
                values: new object[] { 1, "First Comment", 1, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Joke",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Joke",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
