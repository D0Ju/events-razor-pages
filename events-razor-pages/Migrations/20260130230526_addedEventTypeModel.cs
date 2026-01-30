using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace events_razor_pages.Migrations
{
    /// <inheritdoc />
    public partial class addedEventTypeModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EventType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MinimalnoPolaznika = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventType", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventType");
        }
    }
}
