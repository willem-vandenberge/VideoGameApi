using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VideoGameApi.Migrations
{
    /// <inheritdoc />
    public partial class Seedingdevelopers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Developers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Developers", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Developers",
                columns: new[] { "Id", "Email", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "melliw.delamontagne@gmail.com", "Melliw", "De la Montange" },
                    { 2, "alexander.delamer@gmail.com", "Alexander", "De la Mer" },
                    { 3, "Mik.Treaccab@gmail.com", "Mik", "Treaccab" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Developers");
        }
    }
}
